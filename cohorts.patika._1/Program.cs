using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.DataAccess.Concrete;
using cohorts.patika._1.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Web uygulamas� olu�turmak i�in bir builder (olu�turucu) kullan�l�r. "args" parametresi komut sat�r� arg�manlar�n� i�erir.

// DependencyInjection (Ba��ml�l�k Y�netimi)
builder.Services.AddTransient<IProductService, ProductManager>();
builder.Services.AddTransient<IUserService, UserManager>();
// Uygulama i�inde kullan�lacak servisleri tan�mlar ve kaydeder. "AddTransient" ile her istekte yeni bir �rnek olu�turulur.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(config =>
{
    config.AddConsole();
});
// Servislerin eklendi�i b�l�m. Web API i�in gerekli olan servisler eklenir.

var app = builder.Build();
// Uygulaman�n son halini olu�turmak i�in builder.Build() �a�r�l�r.

// HTTP istek i�leme hatt�n� yap�land�rma
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Uygulama geli�tirme ortam�nda ise Swagger dok�mantasyon aray�z� kullan�l�r.

app.UseHttpsRedirection();
// HTTP isteklerini HTTPS'e y�nlendiren bir ara yaz�l�m ekler.

app.UseAuthorization();
// Yetkilendirme ara yaz�l�m�n� ekler.

// GlobalExceptionMiddleware i�in yazd�m
app.UseErrorHandlingMiddleware();
// �zel bir hata i�leme ara yaz�l�m�n� ekler.

app.MapControllers();
// Controller'lar� e�le�tirir.

app.Run();
// Uygulamay� �al��t�r�r.
