using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Examination_System.Models.ViewModels
{
    public class InsertQuestions
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = ".")]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Head must be from 5 to 50")]
        public string Head { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = ".")]
        [StringLength(50, MinimumLength = 25, ErrorMessage = "Body must be from 25 to 50")]
        public string Body { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = ".")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Answer must be from 3 to 50")]
        public string Answer { get; set; }
    }
}
