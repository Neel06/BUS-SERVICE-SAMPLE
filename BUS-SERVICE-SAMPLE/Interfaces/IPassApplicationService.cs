using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Interfaces
{
    public interface IPassApplicationService
    {
        void ApplyForPass(PassApplicationViewModel model);

        List<PassApplication> GetStudentApplications(string studentId);

        void UpdateApplicationStatus(int applicationId, string status);


        List<PassApplication> GetAllApplications();
    }

}
