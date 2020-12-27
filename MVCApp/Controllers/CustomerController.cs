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
        private MyDbContext _context;

        public CustomerController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            // now we're pulling customer data from the dbset
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        // GET: Customer/Details/id
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            
            return View(customer);
        }

        //private IEnumerable<CustomerModel> GetCustomers()
        //{
        //    return new List<CustomerModel>
        //    {
        //        new CustomerModel(){ Id = 1, FirstName="Timmy", LastName="Jones"},
        //        new CustomerModel(){ Id = 2, FirstName="Jason", LastName="Glee"},
        //        new CustomerModel(){ Id = 3, FirstName="Sarah", LastName="Pooter"}
        //    };
        //}
    }
}