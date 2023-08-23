using Microsoft.AspNetCore.Mvc;
using University_Management.Services.Application.Interfaces;

namespace University_Management.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudendRepository studendRepository;

        public StudentController(IStudendRepository studendRepository)
        {
            this.studendRepository = studendRepository;
        }

        public IActionResult Index()
        {
            var result = studendRepository.StudentsTeachers();
            return View(result);
        }

        public IActionResult NotContain()
        {
            var result = studendRepository.NotContain();
            return View(result);
        }

        public IActionResult StudentByProvince()
        {
            var result = studendRepository.StudentByProvince();
            return View(result);
        }

        public IActionResult Students()
        {
            var result = studendRepository.StudentWithCourse();
            return View(result);
        }

        public IActionResult StudentByAlphabet()
        {
            var result = studendRepository.StudentByAlphabet();
            return View(result);
        }
    }
}
