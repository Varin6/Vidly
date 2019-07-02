using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{

    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
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

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(new CustomerDetailsViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                MembershipType = customer.MembershipType
            });



        }

    }
}

   
    
    
    