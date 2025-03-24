using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Maps {
    public class CreateMapTagModel : PageModel {

        private readonly ILogger<CreateMapTagModel> logger;
        private readonly IMapRepository repository;

        public CreateMapTagModel(ILogger<CreateMapTagModel> logger, IMapRepository repository) {
            this.logger = logger;
            this.repository = repository;
        }

        public void OnGet() { 
        
        }

        public async Task<ActionResult> OnPostAsync(GeoTag tag) {
            if (ModelState.IsValid == false) {
                string[] errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
                logger.LogWarning($"Переданы недопустимые данные для создания тега карты : \n {string.Join(Environment.NewLine, errors)}");
            } else {
                try {
                    await repository.CreateAsync(tag);
                    logger.LogWarning("Новый тег карты сохранен.");
                } catch (Exception exception) {
                    logger.LogError($"Произошла ошибка при сохранении тега карты: {exception.Message}.");
                }
            }

            return this.RedirectToPage("/Map");
        }
    }
}
