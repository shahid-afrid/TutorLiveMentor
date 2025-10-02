namespace TutorLiveMentor.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual ICollection<AssignedSubject>? AssignedSubjects { get; set; }
    }
}
