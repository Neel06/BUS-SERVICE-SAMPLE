using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class CustomErrorModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet(string message)
        {
            // Capture the error message passed in the query string
            ErrorMessage = message;
        }
    }

}
