using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5.Day1.Demo.Core.Interfaces;
using Week5.Day1.Demo.Core.Models;
using Week5.Day1.Demo.MVC.Models;

namespace Week5.Day1.Demo.MVC.Controllers
{

    public class EmployeeController : Controller

    {
        private readonly IBusinessLayer bl;

        public EmployeeController(IBusinessLayer businessLayer)
        {
            this.bl = businessLayer;
         }

        // GET: EmployeeController

        public ActionResult Index()
        {
           var model = bl.FetchEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/{id}
        public ActionResult Details(int id)
        {
            //Validazione dell'input
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel());
            }

            //Recupero impiegato da visualizzare
            var emp = bl.GetEmployeeById(id);

            //Restituzione della vista (check del modello)
            if (emp == null)
            {
                return View("NotFound", new NotFoundViewModel()
                {
                    EntityId = id,
                    Message = "Something wrong"
                });
            }
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Employee data)
        {
            //validazione
            if (data == null)
            {
                return View("Error", new ErrorViewModel());
            }
            //chiamata al business layer
            EmployeeResult result = bl.AddNewEmployee(data);
            //restituzione della view
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: EmployeeController/Edit/{id}
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel());
            }

            //recupero l'impiegato da modificare
            var model = bl.GetEmployeeById(id);
            if (model == null)
            {
                return View("NotFound", new NotFoundViewModel { EntityId = id, Message = "Sorry, not found" });
            }

            return View(model);
        }

        // POST: EmployeeController/Edit/{id}
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public ActionResult Edit(Employee data)
        {
            if (data == null)
            {
                return View("Error", new ErrorViewModel());
            }

            var result = bl.EditEmployee(data);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: EmployeeController/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Validazione dell'input
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel());
            }

            //Recupero impiegato da visualizzare
            var emp = bl.GetEmployeeById(id);

            //Restituzione della vista (check del modello)
            if (emp == null)
            {
                return View("NotFound", new NotFoundViewModel()
                {
                    EntityId = id,
                    Message = "Something wrong"
                });
            }
            return View(emp);
        }

        // POST: EmployeeController/Delete/{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(Employee itemToBeDeleted)
        {
            try
            {
                if (itemToBeDeleted.EmployeeID <= 0)
                {
                    return View("Error", new ErrorViewModel());
                }

                var result = bl.DeleteEmployeeById(itemToBeDeleted.EmployeeID);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                    //return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
