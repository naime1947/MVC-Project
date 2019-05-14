using MVCProject.Models;
using MVCProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.DBGateWay
{
    public class StudentDbContext : DBContext
    {
        public bool Save(Student student)
        {
            Query = "Insert into Student Values('" + student.RegiNo + "','" + student.Name + "','" + student.Email + "','" + student.MobileNo + "')";
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
            Connection.Close();
            return false;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();

            Query = "select * from student";
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student student = new Student();
                student.Id = (int)Reader["id"];
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.RegiNo = Reader["RegiNo"].ToString();
                student.MobileNo = Reader["MobileNo"].ToString();
                studentList.Add(student);
            }

            Connection.Close();
            return studentList;
        }

        public Student GetStudentByID(int id)
        {
            Student student = null;

            Query = "select * from student where id=" + id;
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            if (Reader.HasRows)
            {
                student = new Student();
                student.Id = (int)Reader["id"];
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.RegiNo = Reader["RegiNo"].ToString();
                student.MobileNo = Reader["MobileNo"].ToString();
            }

            Connection.Close();
            return student;

        }
        public bool UpdateStudent(Student student)
        {

            Query = "Update Student Set Regino='" + student.RegiNo + "',Name='" + student.Name + "',Email='" + student.Email + "',MobileNo='" + student.MobileNo + "' Where id=" + student.Id;
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAfected = Command.ExecuteNonQuery();
            if (rowsAfected > 0)
            {
                return true;
            }

            Connection.Close();
            return false;

        }

        public List<StudentWithDepartment> GetStudentWithDepartmentList()
        {
            List<StudentWithDepartment> studentWithDepartmentList = new List<StudentWithDepartment>();
            Query = "Select * from StudentWithDepartment";
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StudentWithDepartment studentWithDepartment = new StudentWithDepartment()
                {
                    StudentId = (int)Reader["StudentId"],
                    RegiNo = Reader["RegiNo"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    MobileNo = Reader["MobileNo"].ToString(),
                    DeptId = (int) Reader["DeptId"],
                    DeptCode = Reader["DeptCode"].ToString(),
                    DeptName = Reader["DeptName"].ToString()
                };
                studentWithDepartmentList.Add(studentWithDepartment);
            }
            Connection.Close();
            return studentWithDepartmentList;
        }
    }
}