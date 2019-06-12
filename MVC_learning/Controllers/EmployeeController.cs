using MVC_learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_learning.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int DepartmentId)
        {
            EmployeeContext employeecontext = new EmployeeContext();
            List<Employee> employees = employeecontext.Employees.Where(em=>em.DepartmentId == DepartmentId).ToList();
            return View(employees);
        }


        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext employeecontext = new EmployeeContext();
            Employee emp = employeecontext.Employees.Single(em => em.Id == id);
            return View(emp);
        }
    }
}