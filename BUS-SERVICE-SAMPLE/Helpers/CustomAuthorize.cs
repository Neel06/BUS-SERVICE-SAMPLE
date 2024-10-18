using Microsoft.AspNetCore.Mvc;

namespace BUS_SERVICE_SAMPLE.Helpers
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute() : base(typeof (SessionFilter))
        {
        }
    }
}
