using System.ComponentModel.DataAnnotations;

namespace TutorLiveMentor.Models // <- Make sure this namespace matches your project name!
{
    public class StudentRegistrationModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
