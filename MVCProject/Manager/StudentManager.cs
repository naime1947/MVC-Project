using MVCProject.DBGateWay;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Manager
{
    public class StudentManager
    {
        private StudentDbContext studentDb;
        public bool Save(Student student)
        {
            studentDb = new StudentDbContext();
            return studentDb.Save(student);
            
        }

        public List<Student> GetAllStudents()
        {
            studentDb = new StudentDbContext();
            return studentDb.GetAllStudents();

        }
    }
}