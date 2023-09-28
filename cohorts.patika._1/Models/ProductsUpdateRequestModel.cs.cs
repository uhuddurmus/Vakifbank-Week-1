using System.ComponentModel.DataAnnotations;

namespace cohorts.patika._1.Models
{
    // ProductsUpdateRequestModel adında bir sınıf tanımlanıyor.
    public class ProductsUpdateRequestModel
    {
        // [Required] niteliği, bu özelliğin (property) zorunlu olduğunu belirtir ve
        // bu özelliğin boş (null) veya varsayılan değeri olamayacağını ifade eder.
        // Hata mesajı "Id alanı zorunludur." olarak ayarlanmıştır.
        [Required(ErrorMessage = "Id alanı zorunludur.")]
        public int Id { get; set; }

        // Name adında bir string özelliği (property) tanımlanıyor.
        // Bu özelliğin null değer alabileceği belirtiliyor (? kullanarak).
        public string? Name { get; set; }

        // Price adında bir double özelliği (property) tanımlanıyor.
        // Bu özelliğin null değer alabileceği belirtiliyor (? kullanarak).
        public double? Price { get; set; }
    }
}
