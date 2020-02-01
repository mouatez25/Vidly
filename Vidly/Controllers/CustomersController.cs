using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using AutoMapper;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
       public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                //we initialise customer because we used validationsumary 
                //and we can have en error for the new record which has id empty string
                //and asp.net does not know how to convert it to integer =0
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //first step datanotation in the model
            //second !modelstate.isvalid
            //add in view msg for
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id==0)
            {
                _context.Customers.Add(customer);

            }else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Name = customer.Name;
                ///if you dont would to define each property
              //  Mapper.Map(customer,customerInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
        };
            return View("CustomerForm",viewModel);
        }
        // GET: Customers
        public ViewResult Index()
        {
            //this methods we can load customers and its related object 
            //to display with customer
    //        var customers = _context.Customers.Include(c => c.MembershipType).ToList();
     //       return View(customers);
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}