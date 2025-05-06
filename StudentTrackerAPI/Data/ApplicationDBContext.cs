using Microsoft.EntityFrameworkCore;
using StudentTracker.Models;

namespace StudentTracker.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Enrolment>? Enrolment { get; set; }

        public DbSet<Student>? Student { get; set; }
    }
}
