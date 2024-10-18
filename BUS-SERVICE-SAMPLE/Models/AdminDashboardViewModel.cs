namespace BUS_SERVICE_SAMPLE.Models
{
    using System.Collections.Generic;

    public class AdminDashboardViewModel : BaseModel
    {
        public List<ApplicationViewModel> Applications { get; set; }
    }

}
