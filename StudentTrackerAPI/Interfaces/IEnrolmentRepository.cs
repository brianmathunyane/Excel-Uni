using StudentTracker.Models;

namespace StudentTracker.Interfaces
{
    public interface IEnrolmentRepository
    {
        Task<IEnumerable<Enrolment>> GetAllAsync();
        Task<Enrolment?> GetByIdAsync(int id);
        Task<Enrolment> GetByQualificationNameAsync(string qualification);

        Task<Enrolment> AddAsync(Enrolment Student);
        Task<Enrolment?> UpdateAsync(Enrolment Student);
        Task<bool> DeleteAsync(int id);
    }
}
