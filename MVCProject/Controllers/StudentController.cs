using MVCProject.Manager;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            StudentManager studentManager = new StudentManager();
            bool isSaved = studentManager.Save(student);
            if (isSaved)
            {
                ViewBag.msg = "Student Saved Successfully";
            }
            else
            {
                ViewBag.msg = "Stuent Couldn't saved";
            }
            return View();
        }

        public ActionResult ShowStudents()
        {
            StudentManager studentManager = new StudentManager();
            ViewBag.studentList = studentManager.GetAllStudents();
            return View();
        }

    }
}