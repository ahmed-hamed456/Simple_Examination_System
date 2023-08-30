using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Student : Person
    {
        public bool IsMine { get; set; }
        public int Grade { get; set; }
        [ForeignKey("ins")]
        public int? ins_id { get; set; }

        //Navigation Property
        public Instructor? ins { get; set; }
        public List<std_Exams>? std_exams { get; set;}

    }
}
