using StudentTracker.Interfaces;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentService(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _StudentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _StudentRepository.GetByIdAsync(id);
        }

        public async Task<Student> CreateStudentAsync(Student Student)
        {

            return await _StudentRepository.AddAsync(Student);
        }

        public async Task<Student?> UpdateStudentAsync(Student Student)
        {

            return await _StudentRepository.UpdateAsync(Student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _StudentRepository.DeleteAsync(id);
        }

        public async Task<Student> GetStudentByStudentnameAsync(string Studentname)
        {
            return await _StudentRepository.GetByStudentNameAsync(Studentname);
        }

    }
}
