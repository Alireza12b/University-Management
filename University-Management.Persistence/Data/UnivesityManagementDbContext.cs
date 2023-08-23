using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management.Core;

namespace University_Management.Service.Data
{
    public class UnivesityManagementDbContext : DbContext
    {
        public UnivesityManagementDbContext(DbContextOptions<UnivesityManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnivesityManagementDbContext).Assembly);

            modelBuilder.Entity<Course>()
                .HasOne<Teacher>(s => s.Teacher)
                .WithMany(l => l.Courses)
                .HasForeignKey(h => h.TeacherId);

            modelBuilder.Entity<Address>()
                .HasOne<Province>(s => s.Province)
                .WithMany(l => l.Addresses)
                .HasForeignKey(h => h.ProvinceId);

            modelBuilder.Entity<StudentCourse>().HasKey(s => new { s.StudentId, s.CourseId });

            modelBuilder.Entity<Student>()
           .HasOne<Address>(s => s.Address)
           .WithOne(ad => ad.Student)
           .HasForeignKey<Address>(ad => ad.AddressOfStudentId);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
