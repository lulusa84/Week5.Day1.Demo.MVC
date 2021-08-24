using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Day1.Demo.Core.Interfaces;
using Week5.Day1.Demo.Core.Models;

namespace Week5.Day1.Demo.Mock
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employees =  new List<Employee>()
        {
           
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Sarah",
                    LastName = "Tarantino",
                    BirthDate = new DateTime(1984, 03, 04),
                    HireDate = new DateTime(2021, 02, 04)
                },

                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Antonia",
                    LastName = "Sacchitella",
                    BirthDate = new DateTime(1993, 11, 27),
                    HireDate = new DateTime(2020, 04, 11)
                }

            };


        public bool AddItem(Employee newItem)
        {
            if (newItem == null)
            {
                throw new ArgumentNullException("Invalid item");
            }
            var lastId = FetchAll().Last().EmployeeID;
            newItem.EmployeeID = lastId + 1;
            FetchAll().Add(newItem);
            return true;
        }

        public List<Employee> FetchAll()
        {
            return employees;
        }

        public Employee GetById(int id)
        {
            //Guardia
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return FetchAll().FirstOrDefault(e => e.EmployeeID == id);
        }

        public bool EditItem(Employee itemToEdit)
        {
            if (itemToEdit == null)
            {
                throw new ArgumentNullException("Invalid item");
            }
            var oldItem = FetchAll().FirstOrDefault(e => e.EmployeeID == itemToEdit.EmployeeID);
            FetchAll().Remove(oldItem);
            AddItem(itemToEdit);
            return true;
        }

        public bool DeleteItemById(Employee itemToBeDeleted)
        {
            if(itemToBeDeleted != null)
            {
                throw new ArgumentNullException("Invalid item");
            }
            var ItemID = FetchAll().FirstOrDefault(e => e.EmployeeID == itemToBeDeleted.EmployeeID);
            FetchAll().RemoveAt(Convert.ToInt32(ItemID));

            return true;
        }
    }


}
