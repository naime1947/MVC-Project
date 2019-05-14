using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models.ViewModel
{
    public class StudentWithDepartment
    {
        public int StudentId { get; set; }
        public string RegiNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int DeptId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }

    }
}