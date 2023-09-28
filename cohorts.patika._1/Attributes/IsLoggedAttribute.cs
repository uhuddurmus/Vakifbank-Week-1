using cohorts.patika._1.DataAccess.DB;

namespace cohorts.patika._1.Attributes
{
    // IsLoggedAttribute, bir kullanıcının giriş yapmış olup olmadığını denetlemek için kullanılan özel bir niteliktir.
    public class IsLoggedAttribute : Attribute
    {
        // IsLoggedIn metodu, kullanıcının giriş yapmış olup olmadığını kontrol eder.
        public bool IsLoggedIn()
        {
            // UserDB sınıfının LoginUserControl metodu çağrılarak kullanıcının giriş yapmış olup olmadığı kontrol edilir.
            return UserDB.LoginUserControl();
        }
    }
}
