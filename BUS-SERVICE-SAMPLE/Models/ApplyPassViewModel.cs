using System.ComponentModel.DataAnnotations;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class ApplyPassViewModel : PassApplication
    {
        [Required]
        public string StudentID { get; set; }

        [Required]
        public string PassType { get; set; }
    }

}
