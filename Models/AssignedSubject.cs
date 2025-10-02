namespace TutorLiveMentor.Models
{
    public class AssignedSubject
    {
        public int AssignedSubjectId { get; set; }
        public int FacultyId { get; set; }
        public string Year { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public virtual Faculty? Faculty { get; set; }
    }
}
