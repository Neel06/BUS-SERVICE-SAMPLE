namespace BUS_SERVICE_SAMPLE.Models
{
    public class BaseModel
    {
        public DateTime Created_DateTime { get; set; }
        public string Created_UserId { get; set; }
        public bool IsActive { get; set; }
        public string Updated_UserId { get; set; }
        public DateTime Updated_DateTime { get; set; }
        public int UserRole { get; set; }
    }
}