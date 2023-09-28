using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace cohorts.patika._1.Middlewares
{
    // Hata işleme orta yazılımını temsil eden ErrorHandlingMiddleware sınıfı tanımlanıyor.
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        // Constructor, bir sonraki middleware'i alır.
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Invoke metodu, her HTTP isteği işlemek için kullanılır.
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Bir sonraki middleware'i çağır ve HTTP isteğini işle.
                await _next(context);
            }
            catch (Exception ex)
            {
                // Hata durumunda HandleExceptionAsync metoduyla hata işleme işlemini gerçekleştir.
                await HandleExceptionAsync(context, ex);
            }
        }

        // HandleExceptionAsync metodu, hata durumunda cevap oluşturur.
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;

            // Yanıtın türünü "application/json" olarak ayarlar.
            response.ContentType = "application/json";

            // Hata türüne göre yanıt durumunu ayarlar.
            response.StatusCode = exception switch
            {
                // ValidationException türündeki hatalar için HTTP 400 (Bad Request) durum kodunu kullanır.
                ValidationException _ => (int)HttpStatusCode.BadRequest,
                // Diğer tüm hatalar için HTTP 500 (Internal Server Error) durum kodunu kullanır.
                _ => (int)HttpStatusCode.InternalServerError
            };

            // Hata mesajını içeren bir JSON yanıtını gönderir.
            return response.WriteAsync(
                JsonSerializer.Serialize(new List<string>() { exception.Message }));
        }
    }
}
