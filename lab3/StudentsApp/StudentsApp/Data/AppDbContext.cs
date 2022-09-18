using StudentsApp.Models;
using System.Data.Entity;

namespace StudentsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("serverConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}