using MVCProject.DBGateWay;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Manager
{
    public class DepartmentManager
    {
        DepartmentDBContext departmentDBContext = new DepartmentDBContext();
        public List<Department> GetDepartmentList()
        {
            return departmentDBContext.GetDepartmentList();
        }
    }
}