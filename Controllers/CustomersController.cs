using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Aaron Peterson"},
                new Customer {Id = 2, Name = "Kamil Kuklinski"},
            };

            var viewModel = new AllCustomersViewModel
            {
                Customers = customers
            };

            
            return View(viewModel);

        }


        public ActionResult Details(int? id)
        {

            if (!id.HasValue)
            {

                return RedirectToAction("Index");
            }
            


            if (id.Value == 1)
            {
                var customer = new CustomerDetailsViewModel {Id = 1, Name = "Aaron Peterson"};

                return View(customer);

            }

            if (id.Value == 2)
            {

                var customer = new CustomerDetailsViewModel {Id = 2, Name = "Kamil Kuklinski"};

                return View(customer);
            }


            return HttpNotFound();




        }

    }
}

   
    
    
    