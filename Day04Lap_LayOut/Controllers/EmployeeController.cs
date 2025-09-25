using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Day04Lap_LayOut.Models;
using System.Collections.Immutable;
namespace Day04Lap_LayOut.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employee = new List<Employee>
        {
            new Employee { id=1, fullName= "NGuyen van a",gender="Nam",phone = "0123456789", email = "a@gmail.com", salary = 1000, status = "Active" },
            new Employee { id = 2, fullName = "Tran Thi B", gender = "Nữ", phone = "0987654321", email = "b@gmail.com", salary = 1500, status = "Inactive" }
        };
        public IActionResult Index()
        {
            //danh sach nhan vien
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            //chi tiet nhan vien
            var emp = employee.Find(e => e.id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        public IActionResult Create()
        {
            //tao moi nhan vien
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.id = employee.Count + 1;
            employee.Add(emp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            //sua nhan vien
            var emp = employee.FirstOrDefault(e => e.id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var exitemp = employee.FirstOrDefault(e => e.id == emp.id);
            if (exitemp == null)
            {
                return NotFound();
            }
            exitemp.fullName = emp.fullName;
            exitemp.gender = emp.gender;
            exitemp.phone = emp.phone;
            exitemp.email = emp.email;
            exitemp.salary = emp.salary;
            exitemp.status = emp.status;

            return RedirectToAction("Index");
        }
    }
}
