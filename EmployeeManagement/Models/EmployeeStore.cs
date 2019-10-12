using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeStore
    {
        private static Dictionary<int, EmployeeModel> employees;

        static EmployeeStore()
        {
            employees = new Dictionary<int, EmployeeModel>();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            return employees.Values.ToList();
        }

        public EmployeeModel GetEmployeeById(int empId)
        {
            if (!employees.ContainsKey(empId))
            {
                throw new Exception("Employee id is not found");
            }

            return employees[empId];
        }

        public void AddEmployee(EmployeeModel emp)
        {
            if (employees.ContainsKey(emp.EmployeeId))
            {
                throw new Exception("Already employee is exist");
            }

            employees.Add(emp.EmployeeId, emp);
        }

        public void UpdateEmployee(EmployeeModel emp)
        {
            if (!employees.ContainsKey(emp.EmployeeId))
            {
                throw new Exception("Employee is not found");
            }

            var employee = employees[emp.EmployeeId];
            employee.Address = emp.Address;
            employee.EmployeeName = emp.EmployeeName;
            employee.Age = emp.Age;
            employee.MobileNumber = emp.MobileNumber;
        }
        public void DeleteEmployee(int empId)
        {
            if (!employees.ContainsKey(empId))
            {
                throw new Exception("Employee is not found");
            }

            employees.Remove(empId);
        }
    }
}