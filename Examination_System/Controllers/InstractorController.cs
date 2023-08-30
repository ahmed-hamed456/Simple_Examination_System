using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Examination_System.Controllers
{
    public class InstractorController : Controller
    { 
        ExamContext context;
        public InstractorController()
        {
            context= new ExamContext();
        }
        [HttpGet]
        public IActionResult AddQuestions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestions(Question question)
        {           
            Question ques = new Question()
            {
                ID = question.ID,
                Head = question.Head,
                Body = question.Body,
                Answer = question.Answer,
                ins_id = HttpContext.Session.GetInt32("UserID")
            };
            context.questions.Add(ques);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            int id = (int)HttpContext.Session.GetInt32("UserID");
            List<Question> question = context.questions.Where(q => q.ins_id == id).ToList();
            return View(question);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Question question = context.questions.SingleOrDefault(q => q.ID == id);
            return View(question);
        }
        [HttpPost]
        public IActionResult Update(Question question)
        {
            Question OldQuestion =context.questions.SingleOrDefault(q=>q.ID == question.ID);
            OldQuestion.Head = question.Head;
            OldQuestion.Body = question.Body;
            OldQuestion.Answer = question.Answer;
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Question question = context.questions.SingleOrDefault(q=>q.ID==id);
                context.questions.Remove(question);
                context.SaveChanges();
                return RedirectToAction("GetAll");

            }catch(Exception ex)
            {
                return Content("Something went wrong");
            }
        }
    }
}
