using System.ComponentModel.DataAnnotations;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class ApplyPassViewModel : BaseModel
    {
        [Required]
        public string StudentID { get; set; }

        [Required]
        public string PassType { get; set; }
    }

}
