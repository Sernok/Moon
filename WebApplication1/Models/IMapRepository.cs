namespace WebApplication1.Models {
    public interface IMapRepository {
        Task<IReadOnlyCollection<GeoTag>?> GetAsync();
        Task<GeoTag?> GetAsync(Guid geoTagId);
        Task CreateAsync(GeoTag geoTag);
        Task UpdateAsync(GeoTag geoTag);
        Task DeleteAsync(Guid tagId);
    }
}
