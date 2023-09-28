using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.DataAccess.DB;
using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;

namespace cohorts.patika._1.DataAccess.Concrete
{
    // ProductManager sınıfı, ürün işlemlerini yönetmek için IProductService arayüzünü uygular.
    public class ProductManager : IProductService
    {
        // Ürün eklemek için kullanılan metot.
        public void Add(ProductsCreateRequestModel model)
        {
            // ProductDB sınıfının Add metodu çağrılarak ürün eklenir.
            ProductDB.Add(model);
        }

        // Belirli bir Id'ye sahip ürünü silmek için kullanılan metot.
        public void Delete(int id)
        {
            // ProductDB sınıfının Delete metodu çağrılarak ürün silinir.
            ProductDB.Delete(id);
        }

        // Ürün bilgilerini güncellemek için kullanılan metot.
        public void UpdatePatch(ProductsUpdateRequestModel model)
        {
            // ProductDB sınıfının UpdatePatch metodu çağrılarak ürün güncellenir.
            ProductDB.UpdatePatch(model);
        }

        // Ürünleri isme göre listeleyen metot.
        public List<Product> GetList(string? name, string order = "ASC")
        {
            // ProductDB sınıfının GetList metodu çağrılarak ürünler listelenir.
            return ProductDB.GetList(name, order);
        }

        // Belirli bir Id'ye sahip ürünü getiren metot.
        public Product GetById(int id)
        {
            // ProductDB sınıfının GetById metodu çağrılarak ürün getirilir.
            return ProductDB.GetById(id);
        }
    }
}
