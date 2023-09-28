using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;

namespace cohorts.patika._1.DataAccess.DB
{
    // Kullanıcı verilerini saklayan ve işleyen UserDB sınıfı tanımlanıyor.
    public class UserDB
    {
        // Kullanıcı verilerini saklamak için bir liste oluşturuluyor.
        public static List<User> users = new List<User>
        {
            // Örnek kullanıcılar ekleniyor.
            new()
            {
                Username = "Mustafa_Uhud",
                Password = "QWE123qwe"
            },
            new()
            {
                Username = "Ahmet_Kaya",
                Password = "ABC456abc"
            },
            new()
            {
                Username = "Ayşe_Yılmaz",
                Password = "123XYZxyz"
            },
            new()
            {
                Username = "Mehmet_Demir",
                Password = "PQR789pqr"
            }
        };

        private readonly IHttpContextAccessor _httpContextAccessor;

        // UserDB sınıfının yapıcı metodu, IHttpContextAccessor türünden bir bağımlılığı alır.
        public UserDB(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Verilen kullanıcı adı ve şifreye sahip kullanıcıyı döndüren bir metot.
        public static User? GetUser(LoginRequestModel model)
        {
            return users.FirstOrDefault(c => c.Username == model.Username && c.Password == model.Password);
        }

        // Kullanıcının giriş durumunu güncelleyen bir metot.
        public static void UpdateUser(User model)
        {
            User? user = GetUser(new LoginRequestModel { Username = model.Username, Password = model.Password });

            if (user != null)
            {
                // Kullanıcının giriş yapma durumu ve son giriş tarihini güncelliyoruz.
                user.IsLogged = model.IsLogged;
                user.LoggedDate = model.LoggedDate;
            }
        }

        // Aktif giriş yapan kullanıcıların kontrolünü sağlayan bir metot.
        public static bool LoginUserControl()
        {
            return users.Any(c => c.IsLogged);
        }
    }
}
