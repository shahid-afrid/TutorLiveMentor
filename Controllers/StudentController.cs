using Microsoft.AspNetCore.Mvc;
using TutorLiveMentor.Models;

namespace TutorLiveMentor.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                // Save logic will go here
                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Placeholder for login logic
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // Temporary: always succeed
                return RedirectToAction("Index"); // Or Dashboard
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }
    }
}
