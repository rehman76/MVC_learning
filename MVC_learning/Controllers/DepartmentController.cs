using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_learning.Models;

namespace MVC_learning.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext employeecontext = new EmployeeContext();
            List<Department> dep = employeecontext.Departments.ToList();
            return View(dep);

        }
    }
}