using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BUS_SERVICE_SAMPLE.Helpers
{
    public class SessionFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionFilter(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(_contextAccessor.HttpContext.Session.GetString("StudentID"))
                && (string.IsNullOrEmpty(_contextAccessor.HttpContext.Session.GetString("AdminID"))))
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                _contextAccessor.HttpContext.Response.Redirect($"/");
                return;
            }
        }
    }
}
