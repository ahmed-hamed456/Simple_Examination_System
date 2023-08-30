using Examination_System.Models;
using Examination_System.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class StudentController : Controller
    {
        ExamContext context;
        
        public StudentController()
        {
            context = new ExamContext();
        }
        public IActionResult GetAll()
        {
            List<Student> students = context.students.ToList();
            return View(students);
            
        }

        public IActionResult IsActive(List<Student> stds)
        {
            int x = (int)HttpContext.Session.GetInt32("UserID");
            List<Student> students = context.students.ToList();
            for(int i = 0; i < students.Count; i++)
            {
                students[i].IsMine= stds[i].IsMine;
                if (students[i].IsMine == true)
                {
                    students[i].ins_id = x;
                }
                
            }
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            Student std = new Student()
            {
                ID= student.ID,
                Name= student.Name,
                Age= student.Age,
                Email= student.Email,
                Grade= student.Grade,
                Password= student.Password,
            };
            context.students.Add(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student student= context.students.SingleOrDefault(s=>s.ID==id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            Student Oldstd=context.students.SingleOrDefault(s=>s.ID==student.ID);
            Oldstd.Name=student.Name;
            Oldstd.Age=student.Age;
            Oldstd.Email=student.Email;
            Oldstd.Grade=student.Grade;
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            Student std =context.students.SingleOrDefault(s=>s.ID==id);
            context.students.Remove(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

    }
}
