using WebApplication1.Models;
using WebApplication1.Data;
using Serilog;
using Serilog.Events;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IMapRepository, JsonMapRepository>();

            //Add support to logging with SERILOG
            builder.Host.UseSerilog((context, configuration) => {
                configuration.MinimumLevel.Warning()
                .WriteTo.File(
                    "Logs/log-.txt",
                    restrictedToMinimumLevel: LogEventLevel.Warning,
                    rollingInterval: RollingInterval.Day
                 );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // ”становка кодировки по умолчанию дл€ ответов
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                await next.Invoke();
            });

            app.MapRazorPages();

            app.Run();
        }
    }
}
