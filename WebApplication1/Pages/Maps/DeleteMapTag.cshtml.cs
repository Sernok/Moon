using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Maps {
    public class DeleteMapTagModel : PageModel {
        private readonly ILogger<DeleteMapTagModel> logger;
        private readonly IMapRepository repository;

        public GeoTag? GeoTag { get; private set; }

        public DeleteMapTagModel(ILogger<DeleteMapTagModel> logger, IMapRepository repository) {
            this.logger = logger;
            this.repository = repository;
        }

        public async Task OnGetAsync(Guid tagId) {
            try {
                GeoTag = await repository.GetAsync(tagId);
            } catch (Exception exception) {
                logger.LogError($"��������� ������ ��� ��������� ������ ���� ����� ��� ��������: {exception.Message}.");
            }
        }

        public async Task<ActionResult> OnPostAsync(Guid tagId) {
            try {
                await repository.DeleteAsync(tagId);
                logger.LogWarning("��� ����� ������.");
            } catch (Exception exception) {
                logger.LogError($"��������� ������ ��� �������� ���� �����: {exception.Message}.");
            }

            return this.RedirectToPage("/Map");
        }
    }
}
