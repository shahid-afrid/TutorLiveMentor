using System.ComponentModel.DataAnnotations;

namespace TutorLiveMentor.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(10)]
        public string RegdNumber { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Branch { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string SelectedSubject { get; set; } = string.Empty;

    }
}
