using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.DBGateWay
{
    public class DepartmentDBContext:DBContext
    {
        public List<Department> GetDepartmentList()
        {
            List<Department> departmentList = new List<Department>();
            Query = "select * from department";
            Command = new System.Data.SqlClient.SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department department = new Department()
                {
                    Id = (int)Reader["id"],
                    Code = Reader["Code"].ToString(),
                    Name=Reader["Name"].ToString()
                };
                departmentList.Add(department);
            }

            Connection.Close();
            return departmentList;
        }
    }
}