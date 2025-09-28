using Microsoft.AspNetCore.Mvc;

using TutorLiveMentor.Models;
// <- Make sure this namespace matches your project name!
public class StudentController : Controller
{
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
            // Save to DB later!
            return RedirectToAction("Login");
        }
        return View(model);
    }
}
