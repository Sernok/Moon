using System;
using WebApplication1.Models;
using WebApplication1.Pages.Maps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebApplication1.Pages;

public class MapModel : PageModel
{
    private readonly ILogger<MapModel> logger;
    private readonly IMapRepository repository;

    public IReadOnlyCollection<GeoTag>? GeoTags { get; set; }
    public GeoTag? SelectTag { get; set; }

    public MapModel(ILogger<MapModel> logger, IMapRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task OnGetAsync(Guid? tagId)
    {
        try
        {
            GeoTags = await repository.GetAsync();
            if (GeoTags != null && GeoTags.Count > 0)
            {
                SelectTag = (tagId != null) ? GeoTags.FirstOrDefault(t => t.Id == tagId) : null;
                if (SelectTag == null)
                {
                    SelectTag = GeoTags.FirstOrDefault();
                }
            }
            logger.LogWarning($"Получены данные тегов карт для отображения.");
        }
        catch (Exception exception)
        {
            logger.LogError($"Произошла ошибка при получении данных тегов карт для отображения: {exception.Message}.");
        }
    }
}