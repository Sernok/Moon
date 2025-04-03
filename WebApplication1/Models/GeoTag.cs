using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApplication1.Models {
    public class GeoTag {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите заголовок.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длинна заголовка от 5 до 20 символов.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите описание.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длинна описания от 5 до 200 символов.")]
        public string Description { get; set; } = string.Empty;
        public string Construction { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public string CenterIcon { get; set; } = string.Empty;
        public static int idcounter = 0;

        public int Icon { get; set; }
        public string IconClass { get; set; } = string.Empty;


    }
}
