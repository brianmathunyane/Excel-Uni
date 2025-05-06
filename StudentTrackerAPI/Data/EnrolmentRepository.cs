using Microsoft.EntityFrameworkCore;
using StudentTracker.Data;
using StudentTracker.Interfaces;
using StudentTracker.Models;


namespace EnrolmentTracker.Data
{
    public class EnrolmentRepository : IEnrolmentRepository
    {
        private readonly ApplicationDBContext _context;

        public EnrolmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrolment>> GetAllAsync() => await _context.Enrolment!.ToListAsync();

        public async Task<Enrolment?> GetByIdAsync(int id) => await _context.Enrolment!.FindAsync(id);

        public async Task<Enrolment> AddAsync(Enrolment Enrolment)
        {
            _context.Enrolment!.Add(Enrolment);
            await _context.SaveChangesAsync();
            return Enrolment;
        }

        public async Task<Enrolment?> UpdateAsync(Enrolment Enrolment)
        {
            var existing = await _context.Enrolment!.FindAsync(Enrolment.EnrolmentId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(Enrolment);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Enrolment = await _context.Enrolment!.FindAsync(id);
            if (Enrolment == null) return false;

            _context.Enrolment!.Remove(Enrolment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Enrolment> GetByQualificationNameAsync(string qualification)
        {
            return await _context.Enrolment.FirstOrDefaultAsync(u => u.Qualification == qualification);
        }
    }
}
