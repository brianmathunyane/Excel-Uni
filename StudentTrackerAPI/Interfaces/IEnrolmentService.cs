using StudentTracker.Models;

namespace StudentTracker.Interfaces
{
    public interface IEnrolmentService
    {
        Task<IEnumerable<Enrolment>> GetAllEnrolmentAsync();
        Task<Enrolment?> GetEnrolmentByIdAsync(int id);
        Task<Enrolment> CreateEnrolmentAsync(Enrolment Enrolment);
        Task<Enrolment?> UpdateEnrolmentAsync(Enrolment Enrolment);
        Task<bool> DeleteEnrolmentAsync(int id);
    }
}
