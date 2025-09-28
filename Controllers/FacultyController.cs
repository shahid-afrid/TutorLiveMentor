using Microsoft.AspNetCore.Mvc;

namespace TutorLiveMentor.Controllers
{
    public class FacultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}