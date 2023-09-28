using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;

namespace cohorts.patika._1.DataAccess.Abstract
{
    // IUserService adında bir arayüz (interface) tanımlanıyor.
    public interface IUserService
    {
        // Login adında bir metot tanımlanıyor.
        // Bu metot, kullanıcı girişi yapmayı amaçlayan bir LoginRequestModel türünden parametre alacak.
        // Login işlemi başarılı ise true, aksi halde false döndürecek.
        bool Login(LoginRequestModel model);
    }
}
