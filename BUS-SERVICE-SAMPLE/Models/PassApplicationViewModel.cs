using System.ComponentModel.DataAnnotations;

namespace BUS_SERVICE_SAMPLE.Models
{
    public class PassApplicationViewModel : BaseModel
    {
        
        public string StudentID { get; set; }

        [Required]
        [Display(Name = "Pass Type")]
        public string PassType { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public bool IsRural { get; set; }
        public string DistrictPermanant { get; set; }
        public string BlockPermanant { get; set; }
        public string ClusterPermanant { get; set; }
        public string VillagePermanant { get; set; }
        public string DistrictCurrent { get; set; }
        public string BlockCurrent { get; set; }
        public string ClusterCurrent { get; set; }
        public string VillageCurrent { get; set; }
        public string Section { get; set; }
        public string RollNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Class { get; set; }
        public string ClassGroup { get; set; }
        public string Category { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string AddressPermanant { get; set; }
        public string AddressCurrent { get; set; }
        public bool SameAsPermanant { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string Route { get; set; }
        public string CounterName { get; set; }
        public int Stage { get; set; }
        public string AcademicYear { get; set; }
        public string Term { get; set; }
        public DateTime TermFrom { get; set; }
        public DateTime TermTo { get; set; }
        public int NumberOfDays { get; set; }
        public string PassDuration { get; set; }
        public DateTime PassFrom { get; set; }
        public DateTime PassTo { get; set; }
        public bool IsDeposit { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal PassAmount { get; set; }
        public decimal TotalPassAmount { get; set; }
        public decimal IcardAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }


    }

}
