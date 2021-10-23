using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static StudentManagement1.StudentSearchViewModel;

namespace StudentManagement1.Migrations
{
    public class UniversityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=StudentManagement_EFCore;MultipleActiveResultSets=true;Trusted_connection=true;Integrated Security=true");
        }
        public DbSet<Student> Students { get; set; }
    }
}
