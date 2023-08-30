namespace Examination_System.Models
{
    public class Exam
    {
        public int ID { get; set; }
        
        //Navigation Property
        public List<Question>? questions { get; set; }
        public List<std_Exams>? std_exams { get; set; }

    }
}
