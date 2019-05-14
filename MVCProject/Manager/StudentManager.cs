using MVCProject.DBGateWay;
using MVCProject.Models;
using MVCProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Manager
{
    public class StudentManager
    {
        private StudentDbContext studentDb = new StudentDbContext();
        public bool Save(Student student)
        {
            
            return studentDb.Save(student);
            
        }

        public List<Student> GetAllStudents()
        {
            
            return studentDb.GetAllStudents();

        }

        public Student GetStudentByID(int id)
        {
            
            return studentDb.GetStudentByID(id);
        }
        public bool UpdateStudent(Student student)
        {
            
            return studentDb.UpdateStudent(student);
        }

        public List<StudentWithDepartment> GetStudentWithDepartmentList()
        {
            return studentDb.GetStudentWithDepartmentList();
        }
    }
}