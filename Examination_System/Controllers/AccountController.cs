using Examination_System.Models;
using Examination_System.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class AccountController : Controller
    {
        ExamContext context;
        public AccountController()
        {
            context = new ExamContext();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(AddPersonVM personVM)
        {
            if (ModelState.IsValid)
            {
                if (personVM.AsInstractor)
                {
                    if (context.instructors.Any(r => r.Email == personVM.Email))
                    {//check about new or old register
                        return NotFound("Email is Already Registered ");
                    }
                    else
                    {
                        Instructor instructor = new Instructor()
                        {
                            ID = personVM.ID,
                            Name = personVM.Name,
                            Age = personVM.Age,
                            Email = personVM.Email,
                            Password = personVM.Password,
                        };
                        context.instructors.Add(instructor);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    if (context.students.Any(r => r.Email == personVM.Email))
                    {//check about new or old register
                        return Content("Email is Already Registered ");
                        //HttpContext.Session.SetString("UserError", "Email is Already Registered ");
                        //return View(personVM);
                    }
                    else
                    {
                        Student student = new Student()
                        {
                            ID = personVM.ID,
                            Name = personVM.Name,
                            Age = personVM.Age,
                            Email = personVM.Email,
                            Password = personVM.Password,
                        };
                        context.students.Add(student);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else { return View(personVM); }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                if (loginVM.AsAnInstractor)
                {
                    Instructor ins = context.instructors.FirstOrDefault(s => s.Email == loginVM.Email && s.Password == loginVM.Password);
                    if (ins == null)
                    {
                        ModelState.AddModelError("", "Wrong Email or password");
                        return View(loginVM);
                    }

                    HttpContext.Session.SetInt32("UserID", ins.ID);
                    HttpContext.Session.SetString("UserName", ins.Name);
                    HttpContext.Session.SetString("UserType", "Instractor");
                }
                else
                {
                    Student student = context.students.FirstOrDefault(s => s.Email == loginVM.Email && s.Password == loginVM.Password);
                    if (student == null)
                    {
                        ModelState.AddModelError("", "Wrong Email or password");
                        return View(loginVM);
                    }

                    HttpContext.Session.SetInt32("UserID", student.ID);
                    HttpContext.Session.SetString("UserName", student.Name);
                    HttpContext.Session.SetString("UserType", "Student");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(loginVM);
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

}
