using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using WebApplication1.Models;

namespace WebApplication1.Data {
    public class JsonMapRepository : IMapRepository {
        private const string DATA_FILE_PATH = @"Data/map.json";

        public async Task<IReadOnlyCollection<GeoTag>?> GetAsync() {
            return await GetListAsync();
        }

        public async Task<GeoTag?> GetAsync(Guid geoTagId) {
            IReadOnlyCollection<GeoTag>? tags = await GetListAsync();
            return tags != null ? tags.FirstOrDefault(t => t.Id == geoTagId) : null;
        }

        public async Task CreateAsync(GeoTag geoTag) {
            List<GeoTag>? geoTags = await GetListAsync();
            geoTag.Id = Guid.NewGuid();
            geoTags!.Add(geoTag);

            await SaveFile(geoTags);
        }


        public async Task UpdateAsync(GeoTag geoTag) {
            List<GeoTag>? geoTags = await GetListAsync();

            GeoTag? tag = null;
            if (geoTags != null) {
                tag = geoTags.FirstOrDefault(tag => tag.Id == geoTag.Id);

                if (tag != null) {
                    tag.Title = geoTag.Title;
                    tag.Description = geoTag.Description;
                    tag.Path = geoTag.Path;
                    await SaveFile(geoTags);
                }
            }
        }

        public async Task DeleteAsync(Guid tagId) {
            List<GeoTag>? geoTags = await GetListAsync();

            GeoTag? tag = null;
            if (geoTags != null) {
                tag = geoTags.FirstOrDefault(tag => tag.Id == tagId);

                if (tag != null) {
                    geoTags.Remove(tag);
                    await SaveFile(geoTags);
                }
            }
        }

        private async Task<List<GeoTag>?> GetListAsync() {
            string json = await File.ReadAllTextAsync(DATA_FILE_PATH);
            return JsonSerializer.Deserialize<List<GeoTag>>(json);
        }

        private async Task SaveFile(IReadOnlyCollection<GeoTag> geoTags) {
            JsonSerializerOptions options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(geoTags, options);

            using (FileStream stream = File.Open(DATA_FILE_PATH, FileMode.OpenOrCreate, FileAccess.Write)) {
                stream.SetLength(0);

                using (StreamWriter writer = new StreamWriter(stream)) {
                    await writer.WriteAsync(json);
                    await writer.FlushAsync();
                }
            }

        }
    }
}
