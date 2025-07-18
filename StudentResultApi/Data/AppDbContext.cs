//namespace StudentResultApi.Data
//{
//    public class AppDbContext
//    {
//    }
//}
//using Microsoft.EntityFrameworkCore;
//using StudentResultApi.Models;
//using System.Collections.Generic;

//namespace StudentResultApi.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        //public DbSet<Student> Students { get; set; }
//        //public DbSet<Subject> Subjects { get; set; }
//        //public DbSet<Result> Results { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public DbSet<Result> Results { get; set; }
//        public DbSet<ResultSubject> ResultSubjects { get; set; }

//    }
//}
//using Microsoft.EntityFrameworkCore;
//using StudentResultApi.Models;

////namespace YourNamespace
//    namespace StudentResultApi.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Student> Students { get; set; }
//        public DbSet<Result> Results { get; set; }
//        public DbSet<ResultSubject> ResultSubjects { get; set; }
//    }
//}
using Microsoft.EntityFrameworkCore;
using StudentResultApi.Models;

namespace StudentResultApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultSubject> ResultSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Decimal precision configuration for ResultSubject
            modelBuilder.Entity<ResultSubject>()
                .Property(rs => rs.MarksObtained)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ResultSubject>()
                .Property(rs => rs.MaximumMarks)
                .HasColumnType("decimal(5,2)");

            // Decimal precision configuration for Result
            modelBuilder.Entity<Result>()
                .Property(r => r.TotalMarksObtained)
                .HasColumnType("decimal(6,2)");

            modelBuilder.Entity<Result>()
                .Property(r => r.TotalMaximumMarks)
                .HasColumnType("decimal(6,2)");

            modelBuilder.Entity<Result>()
                .Property(r => r.Percentage)
                .HasColumnType("decimal(5,2)");
        }
    }
}
