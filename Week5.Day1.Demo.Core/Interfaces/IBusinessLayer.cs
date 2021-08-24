using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Day1.Demo.Core.Models;

namespace Week5.Day1.Demo.Core.Interfaces
{
    public interface IBusinessLayer 
    {
        IEnumerable<Employee> FetchEmployees();
        Employee GetEmployeeById(int id);
        EmployeeResult AddNewEmployee(Employee newEmp);
        EmployeeResult EditEmployee(Employee data);
        EmployeeResult DeleteEmployeeById(int id);
    }
}
