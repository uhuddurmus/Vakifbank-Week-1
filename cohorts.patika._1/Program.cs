using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.DataAccess.Concrete;
using cohorts.patika._1.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Web uygulamasý oluþturmak için bir builder (oluþturucu) kullanýlýr. "args" parametresi komut satýrý argümanlarýný içerir.

// DependencyInjection (Baðýmlýlýk Yönetimi)
builder.Services.AddTransient<IProductService, ProductManager>();
builder.Services.AddTransient<IUserService, UserManager>();
// Uygulama içinde kullanýlacak servisleri tanýmlar ve kaydeder. "AddTransient" ile her istekte yeni bir örnek oluþturulur.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(config =>
{
    config.AddConsole();
});
// Servislerin eklendiði bölüm. Web API için gerekli olan servisler eklenir.

var app = builder.Build();
// Uygulamanýn son halini oluþturmak için builder.Build() çaðrýlýr.

// HTTP istek iþleme hattýný yapýlandýrma
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Uygulama geliþtirme ortamýnda ise Swagger dokümantasyon arayüzü kullanýlýr.

app.UseHttpsRedirection();
// HTTP isteklerini HTTPS'e yönlendiren bir ara yazýlým ekler.

app.UseAuthorization();
// Yetkilendirme ara yazýlýmýný ekler.

// GlobalExceptionMiddleware için yazdým
app.UseErrorHandlingMiddleware();
// Özel bir hata iþleme ara yazýlýmýný ekler.

app.MapControllers();
// Controller'larý eþleþtirir.

app.Run();
// Uygulamayý çalýþtýrýr.
