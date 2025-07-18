using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentResultSystem.Models;

namespace StudentResultSystem.Data
{
    
    public class AppDbContext : DbContext
    {
        

        public DbSet<Student> Students { get; set; }
        //public DbSet<ResultSubject> ResultSubject { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultSubject> ResultSubjects { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
