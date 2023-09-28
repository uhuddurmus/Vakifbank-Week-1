using System.ComponentModel.DataAnnotations;

namespace cohorts.patika._1.Entities
{
    // Product sınıfı, ürün verilerini temsil etmek için kullanılır.
    public class Product
    {
        // Ürünün benzersiz kimliğini temsil eden Id özelliği.
        // [Required] niteliği, bu özelliğin zorunlu olduğunu belirtir.
        [Required(ErrorMessage = "Id alanı zorunludur.")]
        public int Id { get; set; }

        // Ürünün adını temsil eden Name özelliği.
        // [Required] niteliği, bu özelliğin zorunlu olduğunu belirtir.
        // [MaxLength] niteliği, bu özelliğin maksimum uzunluğunu sınırlar ve 100 karakteri geçemez.
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad alanı en fazla 100 karakter olabilir.")]
        public string? Name { get; set; }

        // Ürünün fiyatını temsil eden Price özelliği.
        // [Required] niteliği, bu özelliğin zorunlu olduğunu belirtir.
        public double? Price { get; set; }
    }
}
