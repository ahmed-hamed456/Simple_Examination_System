
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Models
{
    public class ExamContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<std_Exams> std_Exams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Exam_System;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    
}
