using Microsoft.AspNetCore.Mvc;
using TutorLiveMentor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace TutorLiveMentor.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

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
        public async Task<IActionResult> Register(StudentRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Students.Any(s => s.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(model);
                }

                var passwordHasher = new PasswordHasher<StudentRegistrationModel>();
                var hash = passwordHasher.HashPassword(model, model.Password);

                var student = new Student
                {
                    FullName = model.FullName,
                    RegdNumber = model.RegdNumber,
                    Year = model.Year,
                    Branch = model.Branch,
                    Email = model.Email,
                    PasswordHash = hash
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Registration successful! Please log in now.";
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == model.Email);
            if (student == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email or Password.");
                return View(model);
            }

            var passwordHasher = new PasswordHasher<LoginViewModel>();
            var result = passwordHasher.VerifyHashedPassword(model, student.PasswordHash, model.Password);

            if (result == PasswordVerificationResult.Success)
            {
                // Optionally: set session here
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Email or Password.");
            return View(model);
        }
    }
}
