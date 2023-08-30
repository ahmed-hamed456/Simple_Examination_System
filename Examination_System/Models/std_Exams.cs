using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    [PrimaryKey("std_id", "ex_id")]
    public class std_Exams
    {
        [ForeignKey("student")]
        public int? std_id { get; set; }

        [ForeignKey("exam")]
        public int? ex_id { get; set; }

        //Navigation Property
        public Student? student { get; set; }
        public Exam? exam { get; set; }
    }
}
