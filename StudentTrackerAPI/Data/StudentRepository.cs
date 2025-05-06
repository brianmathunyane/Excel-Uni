using StudentTracker.Models;
using StudentTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentTracker.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() =>  await _context.Student!
                .Include(m => m.Enrolment)
                .ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) => await _context.Student! .Include(m => m.Enrolment)
                .FirstOrDefaultAsync(m => m.StudentId == id);

        public async Task<Student> AddAsync(Student Student)
        {
            _context.Student!.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student?> UpdateAsync(Student Student)
        {
            var existing = await _context.Student!.FindAsync(Student.StudentId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(Student);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Student = await _context.Student!.FindAsync(id);
            if (Student == null) return false;

            _context.Student!.Remove(Student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Student> GetByStudentNameAsync(string Studentname) => await _context.Student.FirstOrDefaultAsync(u => u.FirstName == Studentname);

        public async Task<IEnumerable<Student>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Student!
               .Include(m => m.Enrolment)
               .Where(m => m.StudentId == studentId)
               .ToListAsync();
        }

    }
}
