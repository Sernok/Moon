using System;
using WebApplication1.Models;
using WebApplication1.Pages.Maps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;
public class AllobjectsModel : PageModel
{
    private readonly ILogger<AllobjectsModel> logger;
    private readonly IMapRepository repository;

    public IReadOnlyCollection<GeoTag>? GeoTags { get; set; }
    public GeoTag? SelectTag { get; set; }

    public AllobjectsModel(ILogger<AllobjectsModel> logger, IMapRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task OnGetAsync()
    {
        try
        {
            // Получаем все теги с координатами
            GeoTags = await repository.GetAsync();

            if (GeoTags != null && GeoTags.Count > 0)
            {
                logger.LogWarning($"Получены данные тегов карт для отображения. Всего тегов: {GeoTags.Count}");
            }
            else
            {
                logger.LogWarning("Нет данных для отображения.");
            }
        }
        catch (Exception exception)
        {
            logger.LogError($"Произошла ошибка при получении данных тегов карт для отображения: {exception.Message}.");
        }
    }
}