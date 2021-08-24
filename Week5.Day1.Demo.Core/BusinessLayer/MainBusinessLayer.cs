using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Day1.Demo.Core.Interfaces;
using Week5.Day1.Demo.Core.Models;

namespace Week5.Day1.Demo.Core.BusinessLayer
{

    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IEmployeeRepository empRepository;

        public MainBusinessLayer(IEmployeeRepository emplRepo)
        {
            this.empRepository = emplRepo;
        }

        public IEnumerable<Employee> FetchEmployees()
        {
            return empRepository.FetchAll();
        }

        public EmployeeResult AddNewEmployee(Employee newEmp)
        {
            if (newEmp == null)
            {
                throw new ArgumentNullException("Invalid item");
            }

            var result = empRepository.AddItem(newEmp);

            if (result)
            {
                return new EmployeeResult
                {
                    Success = true,
                    Message = "Ok"
                };
            }
            return new EmployeeResult
            {
                Success = false,
                Message = $"Employee {newEmp.FirstName} - {newEmp.LastName} cannot be saved"
            };

        }

        public Employee GetEmployeeById(int id)
        {
            //Guardia
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return empRepository.GetById(id);
        }

        public EmployeeResult EditEmployee(Employee data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Invalid info");
            }

            var result = empRepository.EditItem(data);
            if (result)
            {
                return new EmployeeResult
                {
                    Success = true,
                    Message = ""
                };
            }

            return new EmployeeResult
            {
                Success = false,
                Message = "Cannot to edit"
            };
        }

        public EmployeeResult DeleteEmployeeById(int id)
        {
            //Guardia
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id");
            }
            Employee EmployeeToBeDeleted = empRepository.GetById(id);
            var result = empRepository.DeleteItemById(EmployeeToBeDeleted);
          
            if (result)
            {
                return new EmployeeResult
                {
                    Success = true,
                    Message = ""
                };
            }

            return new EmployeeResult
            {
                Success = false,
                Message = "Cannot to Delete this id"
            };
        }
    }
}
