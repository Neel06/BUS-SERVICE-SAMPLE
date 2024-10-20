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
                Status = "Pending",
                AcademicYear = model.AcademicYear,
                AddressCurrent = model.AddressCurrent,
                AddressPermanant = model.AddressPermanant,
                //BlockCurrent = model.BlockCurrent,
                BlockPermanant = model.BlockPermanant,
                Category = model.Category,
                Class = model.Class,
                ClassGroup = model.ClassGroup,
                ClusterCurrent = model.ClusterCurrent,
                ClusterPermanant = model.ClusterPermanant,
                CounterName = model.CounterName,
                DateOfBirth = model.DateOfBirth,
                DepositAmount = model.DepositAmount,
                DistrictCurrent = model.DistrictCurrent,
                DistrictPermanant = model.DistrictPermanant,
                Email = model.Email,
                FromLocation = model.FromLocation,
                FullName = model.Name,
                Gender = model.Gender,
                IcardAmount = model.IcardAmount,
                IsDeposit = model.IsDeposit,
                IsRural = model.IsRural,
                MobileNumber = model.MobileNumber,
                NumberOfDays = model.NumberOfDays,
                PassAmount = model.PassAmount,
                PassDuration = model.PassDuration,
                PassFrom = model.PassFrom,
                PassTo = model.PassTo,
                PayableAmount = model.PayableAmount,
                PaymentMethod = model.PaymentMethod,
                RollNumber = model.RollNumber,
                Route = model.Route,
                SameAsPermanant = model.SameAsPermanant,
                SchoolAddress = model.SchoolAddress,
                SchoolName = model.SchoolName,
                Section = model.Section,
                Stage = model.Stage,
                Term = model.Term,
                TermFrom = model.TermFrom,
                TermTo = model.TermTo,
                ToLocation = model.ToLocation,
                TotalPassAmount = model.TotalPassAmount,
                VillageCurrent = model.VillageCurrent,
                VillagePermanant = model.VillagePermanant,

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
