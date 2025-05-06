using StudentTracker.Interfaces;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class EnrolmentService : IEnrolmentService
    {
        private readonly IEnrolmentRepository _EnrolmentRepository;

        public EnrolmentService(IEnrolmentRepository EnrolmentRepository)
        {
            _EnrolmentRepository = EnrolmentRepository;
        }

        public async Task<IEnumerable<Enrolment>> GetAllEnrolmentAsync() => await _EnrolmentRepository.GetAllAsync();


        public async Task<Enrolment?> GetEnrolmentByIdAsync(int id) => await _EnrolmentRepository.GetByIdAsync(id);


        public async Task<Enrolment> CreateEnrolmentAsync(Enrolment Enrolment) => await _EnrolmentRepository.AddAsync(Enrolment);


       

        public async Task<Enrolment?> UpdateEnrolmentAsync(Enrolment Enrolment)
        {
           
            return await _EnrolmentRepository.UpdateAsync(Enrolment);
        }

        public async Task<bool> DeleteEnrolmentAsync(int id) => await _EnrolmentRepository.DeleteAsync(id);


    }
}
