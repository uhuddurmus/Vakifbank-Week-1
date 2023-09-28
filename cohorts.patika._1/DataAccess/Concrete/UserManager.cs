using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.DataAccess.DB;
using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;

namespace cohorts.patika._1.DataAccess.Concrete
{
    // IUserService arayüzünü uygulayan UserManager sınıfı tanımlanıyor.
    public class UserManager : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // UserManager sınıfının yapıcı metodu, IHttpContextAccessor türünden bir bağımlılığı alır.
        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Kullanıcı girişi işlemini kontrol eden metot.
        public bool Login(LoginRequestModel model)
        {
            // Verilen kullanıcı adı ve şifre ile bir kullanıcı aranıyor.
            User? user = UserDB.GetUser(model);

            if (user != null)
            {
                // Kullanıcı bulunduğunda, UserDB sınıfındaki UpdateUser metodu kullanılarak kullanıcının
                // giriş yapma durumu güncellenir.
                UserDB.UpdateUser(user);

                // Giriş başarılı olduğunda true döndürülür.
                return true;
            }

            // Kullanıcı bulunamadığında veya giriş başarısız olduğunda false döndürülür.
            return false;
        }
    }
}
