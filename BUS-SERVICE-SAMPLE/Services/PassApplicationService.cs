using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;
using BUS_SERVICE_SAMPLE.Repository;

namespace BUS_SERVICE_SAMPLE.Services
{
    public class PassApplicationService : IPassApplicationService
    {
        private readonly IPassApplicationRepository _applicationRepository;

        public PassApplicationService(IPassApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public void ApplyForPass(PassApplicationViewModel model)
        {   // To-do : Add map all properties from PssApplicationViewModel; Configue database table for those new fields;
            // Once done remove this comments
            var application = new PassApplication
            {
                StudentID = model.StudentID,
                PassType = model.PassType,
                ApplicationDate = DateTime.Now,
                Status = "Pending"
            };

            _applicationRepository.AddApplication(application);
        }

        public List<PassApplication> GetAllApplications()
        {
            return _applicationRepository.GetAllApplications();
        }

        public List<PassApplication> GetStudentApplications(string studentId)
        {
            return _applicationRepository.GetApplicationsByStudentId(studentId);
        }

        public void UpdateApplicationStatus(int applicationId, string status)
        {
            var application = _applicationRepository.GetApplicationById(applicationId);
            if (application == null)
            {
                throw new Exception("Application not found.");
            }

            application.Status = status;
            _applicationRepository.UpdateApplication(application);
        }
    }

}
