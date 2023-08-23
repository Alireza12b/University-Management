using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using University_Management.Core;
using University_Management.Service.Data;
using University_Management.Services.Application.Interfaces;

namespace University_Management.Services.Application.Repositories
{
    public class StudentRepository : IStudendRepository
    {
        private readonly UnivesityManagementDbContext _dbContext;
        public StudentRepository(UnivesityManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> StudentWithCourse()
        {
            var students = _dbContext.Students.Include(x => x.Courses).ToList();
            return students;
        }

        public IEnumerable<Student> StudentsTeachers()
        {
            var result = _dbContext.Students.Include(x => x.Courses).ThenInclude(y => y.Teacher).ToList();
            return result;
        }

        public IEnumerable<Student> NotContain()
        {
            var allCourses = _dbContext.Courses.ToList();

            var studentsWithoutCourses = _dbContext.Students
                .Select(student => new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Address = student.Address,
                    Courses = allCourses.Except(student.Courses).ToList()
                }).ToList();

            return studentsWithoutCourses;
        }

        public IEnumerable<Province> StudentByProvince()
        {
            var result = _dbContext.Provinces.Include(x => x.Addresses).ThenInclude(y => y.Student).ToList();
            return result;
        }

        public IEnumerable<Course> StudentByAlphabet()
        {
            var result = _dbContext.Courses.Select(course => new Course
            {
                Id = course.Id,
                Name = course.Name,
                Student = course.Student.OrderBy(student => student.FirstName).ThenBy(student => student.LastName).ToList(),
            }).ToList();

            return result;
        }
    }
}

