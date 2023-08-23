

using University_Management.Core;


namespace University_Management.Services.Application.Interfaces
{
    public interface IStudendRepository 
    {
        IEnumerable<Student> StudentWithCourse();
        IEnumerable<Student> StudentsTeachers();
        IEnumerable<Student> NotContain();
        IEnumerable<Province> StudentByProvince();
        IEnumerable<Course> StudentByAlphabet();
    }
}
