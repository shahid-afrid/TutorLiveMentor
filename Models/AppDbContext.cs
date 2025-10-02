using Microsoft.EntityFrameworkCore;
using TutorLiveMentor.Models;


namespace TutorLiveMentor.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<AssignedSubject> AssignedSubjects { get; set; }
    }
}
