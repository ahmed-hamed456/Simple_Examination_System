namespace Examination_System.Models
{
    public class Instructor : Person
    {
        public string? Address { get; set; }

        //Navigation Property
        public List<Student>? stds { get; set; }
        public List<Question>? questions { get; set; }
    }
}
