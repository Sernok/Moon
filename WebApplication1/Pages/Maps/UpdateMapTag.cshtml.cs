using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Maps {
    public class UpdateMapTagModel : PageModel {
        private readonly ILogger<UpdateMapTagModel> logger;
        private readonly IMapRepository repository;

        public GeoTag? GeoTag { get; private set; }

        public UpdateMapTagModel(ILogger<UpdateMapTagModel> logger, IMapRepository repository) {
            this.logger = logger;
            this.repository = repository;
        }

        public async Task OnGetAsync(Guid tagId) {
            try {
                GeoTag = await repository.GetAsync(tagId);
            } catch (Exception exception) {
                logger.LogError($"��������� ������ ��� ��������� ������ ���� ����� ��� ���������: {exception.Message}.");
            }
        }

        public async Task<ActionResult> OnPostAsync(GeoTag tag) {
            if (ModelState.IsValid == false) {
                string[] errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
                logger.LogWarning($"�������� ������������ ������ ��� ��������� ���� ����� : \n {string.Join(Environment.NewLine, errors)}");
            } else {
                try {
                    await repository.UpdateAsync(tag);
                    logger.LogWarning($"���������� ��� ����� ��������.");
                } catch (Exception exception) {
                    logger.LogError($"��������� ������ ��� ���������� ����������� ���� �����: {exception.Message}.");
                }
            }

            return this.RedirectToPage("/Residential");
        }
    }
}
