using System.ComponentModel.DataAnnotations;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class Student : BaseModel
    {
        [Key]
        public string StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
    }

}
