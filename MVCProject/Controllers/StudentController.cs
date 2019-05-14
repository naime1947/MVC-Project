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
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.DepartmentList = departmentManager.GetDepartmentList();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            ViewBag.DepartmentList = departmentManager.GetDepartmentList();
            bool isSaved = studentManager.Save(student);
            if (isSaved)
            {
                ViewBag.msg = "Student Saved Successfully";
            }
            else
            {
                ViewBag.msg = "Student Couldn't saved";
            }
            return View();
        }

        public ActionResult ShowStudents()
        {

            ViewBag.StudentWithDeptList = studentManager.GetStudentWithDepartmentList();
            return View();
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            List<Department>departmentList = departmentManager.GetDepartmentList();
            Department department = departmentList.Find(dept => dept.Id == id);

            ViewBag.DepartmentList = departmentList;
            ViewBag.Department = department;
            ViewBag.Student = studentManager.GetStudentByID((int)id);
            return View();
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            
            bool isUpdated = studentManager.UpdateStudent(student);
            return RedirectToAction("ShowStudents");
        }
    }
}