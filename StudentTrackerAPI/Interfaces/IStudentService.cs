using StudentTracker.Models;

namespace StudentTracker.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByStudentnameAsync(string Studentname);
        Task<Student> CreateStudentAsync(Student Student);
        Task<Student?> UpdateStudentAsync(Student Student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
