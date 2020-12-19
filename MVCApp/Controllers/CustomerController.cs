using MVCApp.Models;
using MVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var viewModel = new RandomGameViewModel
            {
                Customers = new List<CustomerModel>
                {
                    new CustomerModel(){ FirstName="Timmy", LastName="Jones"},
                    new CustomerModel(){ FirstName="Jason", LastName="Glee"},
                    new CustomerModel(){ FirstName="Sarah", LastName="Pooter"}
                }
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            id = id - 1;
            var customers = new List<CustomerModel>
            {
                new CustomerModel(){ FirstName="Timmy", LastName="Jones"},
                new CustomerModel(){ FirstName="Jason", LastName="Glee"},
                new CustomerModel(){ FirstName="Sarah", LastName="Pooter"}
            };

            if (id > customers.Count && id < customers.Count)
            {
                return HttpNotFound();
            }
            
            return View(customers[id]);
        }
    }
}