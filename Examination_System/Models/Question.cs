using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public string Answer { get; set; }
        public string? answer_stud { get; set; }

        [ForeignKey("instructor")]
        public int? ins_id { get; set; }

        [ForeignKey("exam")]
        public int? Ex_id { get; set; }


        //Navigation Property
        public Instructor? instructor { get; set; }
        public Exam? exam { get; set; }
    }
}
