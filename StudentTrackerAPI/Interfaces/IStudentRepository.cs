using StudentTracker.Models;

namespace StudentTracker.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> GetByStudentNameAsync(string Studentname);

        Task<Student> AddAsync(Student Student);
        Task<Student?> UpdateAsync(Student Student);
        Task<bool> DeleteAsync(int id);
    }
}
