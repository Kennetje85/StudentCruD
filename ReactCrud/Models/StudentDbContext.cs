using Microsoft.EntityFrameworkCore;

namespace ReactCrud.Models

{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6C6PF5S\\SQLEXPRESS;Initial Catalog=lbs; Integrated Security=True");
        }
    }
}
