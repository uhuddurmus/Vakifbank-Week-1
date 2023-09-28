using System.ComponentModel.DataAnnotations;

namespace cohorts.patika._1.Models
{
    public class ProductsCreateRequestModel
    {
        // Id alanı için doğrulama kuralları
        [Required(ErrorMessage = "Id alanı zorunludur.")]
        public int Id { get; set; }

        // Name alanı için doğrulama kuralları
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad alanı en fazla 100 karakter olabilir.")]
        public string? Name { get; set; }

        // Price alanı için doğrulama kuralları
        [Required(ErrorMessage = "Ücret alanı zorunludur.")]
        public double? Price { get; set; }
    }
}
