using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using test.Models;

namespace test.Context
{
    public class itiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =LAPTOP-KL1USVIU\\OMARNARU; Database = EFTest; Trusted_Connection = True; Encrypt= False");
           
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(d =>
            {
                d.HasIndex(d=>d.Name).IsUnique();
            });
            modelBuilder.Entity<Student>(s =>
            {
                s.HasOne(st => st.Department)
                 .WithMany(d => d.students)
                 .HasForeignKey(d => d.DeptId)
                 .OnDelete(DeleteBehavior.SetNull);
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
