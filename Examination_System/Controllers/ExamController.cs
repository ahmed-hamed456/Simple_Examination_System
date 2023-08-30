using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class ExamController : Controller
    {
        ExamContext context;
        public ExamController()
        {
            context= new ExamContext();
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Check()
        {
            var id = (int)HttpContext.Session.GetInt32("UserID");
            List<Student> std = context.students.ToList();
            var quary = std.Where(s => s.ID == id).SingleOrDefault();
            List<Question> Ques = context.questions.Where(s => s.ins_id == quary.ins_id).ToList();
            return View(Ques);
        }

        public IActionResult result(List<Question> Qs)
        {
            var id = (int)HttpContext.Session.GetInt32("UserID");
            Student std = context.students.SingleOrDefault(q => q.ID == id);

            List<Question> Ques = context.questions.Where(s => s.ins_id == std.ins_id).ToList();
            Console.WriteLine(Qs[0].answer_stud);
            Console.WriteLine(Ques[0].Answer);
            int y = std.Grade;

            for (int i = 0; i < Qs.Count; i++)
            {
                if (Qs[i].answer_stud == Ques[i].Answer)
                {
                    std.Grade = ++y;
                }
            }
            Console.WriteLine(y);
            context.SaveChanges();


            return RedirectToAction("GetAll","Instractor");

        }
    }
}
