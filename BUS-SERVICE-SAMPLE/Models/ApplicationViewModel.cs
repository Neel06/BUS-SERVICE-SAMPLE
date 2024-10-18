namespace BUS_SERVICE_SAMPLE.Models
{
    public class ApplicationViewModel : PassApplicationViewModel
    {
        public int ApplicationId { get; set; }
        //public string StudentID { get; set; }
        public string PassType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
    }

}
