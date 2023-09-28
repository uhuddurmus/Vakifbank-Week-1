using cohorts.patika._1.Middlewares;

namespace cohorts.patika._1.Extensions
{
    // ErrorHandlingMiddlewareExtension adında bir genişletme (extension) sınıfı tanımlanıyor.
    public static class ErrorHandlingMiddlewareExtension
    {
        // UseErrorHandlingMiddleware adında bir genişletilmiş metot tanımlanıyor.
        public static IApplicationBuilder UseErrorHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            // Bu metot, IApplicationBuilder türündeki bir builder örneği üzerinde kullanılabilir ve 
            // ErrorHandlingMiddleware türündeki bir middleware'i kullanmak için kullanılır.

            return builder.UseMiddleware<ErrorHandlingMiddleware>();
            // UseMiddleware<ErrorHandlingMiddleware>() metodu, ErrorHandlingMiddleware türündeki bir 
            // middleware'i uygulamanın HTTP istek işleme hattına ekler. Bu middleware, HTTP isteklerini 
            // işlerken oluşabilecek hataları ele alır ve uygun bir yanıt döner.
        }
    }
}
