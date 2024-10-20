using System.ComponentModel.DataAnnotations;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class Admin : BaseModel
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        public int UserRole { get; set; }
    }

}
