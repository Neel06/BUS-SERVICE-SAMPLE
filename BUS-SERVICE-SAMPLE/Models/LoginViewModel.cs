using System.ComponentModel.DataAnnotations;
namespace BUS_SERVICE_SAMPLE.Models
{
    public class LoginViewModel : BaseModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
