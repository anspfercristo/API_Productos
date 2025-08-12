using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Productos.Infraestructure
{
    /// <summary>
    /// Filtro de accion para segurizar EPs
    /// La clave que entre por X-API-KEY debe coincidir con la Key configurada
    /// Se activa con [ApiKeyAuth] decorando el EP segurizado (Ver en Controller)
    /// </summary>
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "X-API-KEY";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = config["Authorize:Key"];

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedKey) || providedKey != apiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            await next();
        }
    }
}
