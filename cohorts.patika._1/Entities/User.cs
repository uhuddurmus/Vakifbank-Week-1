namespace cohorts.patika._1.Entities
{
    // Kullanıcı bilgilerini temsil eden User sınıfı tanımlanıyor.
    public class User
    {
        // Kullanıcının kullanıcı adını temsil eden özellik.
        public string? Username { get; set; }

        // Kullanıcının şifresini temsil eden özellik.
        public string? Password { get; set; }

        // Kullanıcının oturum durumunu (giriş yapmış mı?) belirten özellik.
        public bool IsLogged { get; set; }

        // Kullanıcının son giriş tarihini temsil eden özellik.
        public DateTime LoggedDate { get; set; }
    }
}
