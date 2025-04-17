using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SmartCargo.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Bir sonraki middleware veya işlem noktasına geç
                await _next(context);
            }
            catch (Exception ex)
            {
                // Hata loglanıyor
                _logger.LogError(ex, $"Bir hata oluştu: {ex.Message}");

                // Standart HTTP 500 hatası dönülüyor
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // JSON formatında sade hata mesajı hazırlanıyor
                var result = JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Sunucu tarafında beklenmeyen bir hata oluştu."
                });

                // İstemciye yazılıyor
                await context.Response.WriteAsync(result);
            }
        }
    }
}
