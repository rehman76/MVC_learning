using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_learning.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}