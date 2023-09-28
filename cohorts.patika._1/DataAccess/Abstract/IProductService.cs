using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;

namespace cohorts.patika._1.DataAccess.Abstract
{
    // IProductService arayüzü, ürün işlemlerini tanımlar ve bu işlemlerin uygulanmasını zorunlu kılar.
    public interface IProductService
    {
        // Belirli bir ProductsCreateRequestModel ile yeni bir ürün eklemek için kullanılır.
        void Add(ProductsCreateRequestModel model);

        // Belirli bir Id'ye sahip ürünü silmek için kullanılır.
        void Delete(int id);

        // Belirli bir ProductsUpdateRequestModel ile ürün bilgilerini güncellemek için kullanılır.
        void UpdatePatch(ProductsUpdateRequestModel model);

        // Ürünleri isme göre listeleyen metot.
        // İsim parametresi null olabilir ve sıralama parametresi varsayılan olarak "ASC" (artan sıralama) olarak ayarlanır.
        List<Product> GetList(string? name, string order = "ASC");

        // Belirli bir Id'ye sahip ürünü getiren metot.
        Product GetById(int id);
    }
}
