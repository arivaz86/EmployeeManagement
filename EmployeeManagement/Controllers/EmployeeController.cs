using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeStore employeeStore;

        public EmployeeController()
        {
            this.employeeStore = new EmployeeStore();
        }

        public ActionResult Index()
        {
            var employess = this.employeeStore.GetAllEmployees();
            return View(employess);
        }

        public ActionResult Edit(int? id)
        {
            EmployeeModel employeeModel = new EmployeeModel(); ;
            if (id.HasValue)
            {
                employeeModel = this.employeeStore.GetEmployeeById(id.Value);
                employeeModel.IsNew = false;
            }

            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            try
            {
                if (employee.IsNew)
                {
                    this.employeeStore.AddEmployee(employee);
                }
                else
                {
                    this.employeeStore.UpdateEmployee(employee);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                this.employeeStore.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
