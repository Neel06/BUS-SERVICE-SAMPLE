using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Interfaces
{
    public interface IPassApplicationRepository
    {
        void AddApplication(PassApplication application);

        List<PassApplication> GetApplicationsByStudentId(string studentId);

        PassApplication GetApplicationById(int applicationId);

        void UpdateApplication(PassApplication application);

        List<PassApplication> GetAllApplications();
    }

}
