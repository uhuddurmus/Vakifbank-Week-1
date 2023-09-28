using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace cohorts.patika._1.DataAccess.DB
{
    // ProductDB sınıfı, ürünlerin veritabanı işlemlerini gerçekleştirmek için kullanılır.
    public class ProductDB
    {
        // Ürünlerin bir listesi oluşturuluyor ve bazı örnek ürünler ekleniyor.
        public static List<Product> products = new List<Product>
         {
            // Örnek ürünler oluşturuluyor.
            new Product { Id = 1, Name = "Magic Potion", Price = 15.0 },
            new Product { Id = 2, Name = "Eternal Sunshine", Price = 25.0 },
            new Product { Id = 3, Name = "Galactic Gadget", Price = 30.0 },
            new Product { Id = 4, Name = "Mystical Elixir", Price = 12.5 },
            new Product { Id = 5, Name = "Dream Weaver", Price = 18.75 },
            new Product { Id = 6, Name = "Cosmic Key", Price = 22.99 },
            new Product { Id = 7, Name = "Time Traveler's Guide", Price = 16.5 },
            new Product { Id = 8, Name = "Stardust Collector", Price = 29.95 },
            new Product { Id = 9, Name = "Enchanted Relic", Price = 21.0 },
            new Product { Id = 10, Name = "Whimsical Widget", Price = 14.99 },
        
            // Diğer örnek ürünler burada eklenebilir.
        };

        // Belirli bir Id'ye sahip ürünü döndüren metot.
        public static Product GetById(int id)
        {
            return products.Find(x => x.Id == id);
        }

        // Adı belirtilen bir ürün listesini döndüren metot.
        // Sıralama parametresine göre artan (ASC) veya azalan (DESC) sıralama yapılabilir.
        public static List<Product> GetList(string? name, string order = "ASC")
        {
            return order == "ASC"
                ? products.Where(c => (name == null || c.Name.ToLower().Contains(name.ToLower())))
                .OrderBy(c => c.Id).ToList()
            : products.Where(c => (name == null || c.Name.ToLower().Contains(name.ToLower())))
                .OrderByDescending(c => c.Id).ToList();
        }

        // Yeni bir ürün eklemek için kullanılan metot.
        public static void Add(ProductsCreateRequestModel model)
        {
            // Gelen model verileri kullanılarak yeni bir ürün oluşturuluyor ve listeye ekleniyor.
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
            };
            products.Add(product);
        }

        // Belirli bir Id'ye sahip ürünü silmek için kullanılan metot.
        public static void Delete(int id)
        {
            var entity = products.Find(x => x.Id == id);
            if (entity != null)
            {
                // Ürün listeden kaldırılıyor.
                products.Remove(entity);
            }
        }

        // Ürün bilgilerini güncellemek için kullanılan metot.
        public static void UpdatePatch(ProductsUpdateRequestModel model)
        {
            var entity = products.Find(products => products.Id == model.Id);
            if (entity != null)
            {
                // Ürün bilgileri güncelleniyor.
                entity.Price = model.Price;
                entity.Name = model.Name;
            }
        }
    }
}
