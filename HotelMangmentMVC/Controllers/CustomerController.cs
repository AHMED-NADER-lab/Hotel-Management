using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotalMangment.Bussiness.Bussiness;
using HotalMangment.Bussiness.HotelMV;

namespace HotelMangmentMVC.Controllers
{
    
    public class CustomerController : Controller
    {
        CustomerBussiness customer = new CustomerBussiness();
        
        // GET: Customer
        public ActionResult Index()
        {
            return View(customer.listofcustomer());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Createcustomer(CustomerMV newcustomer)
        {
            Response result = customer.createnewcustomer(newcustomer);

            if (result.IsValid == true) {

                TempData["customerOPer"] = result.SucessMessages.SingleOrDefault().Value;
                return RedirectToAction("Index");
               
               
            }
            else
            {


                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
              
                return View("Create", newcustomer);

            }

             
        
                
            
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customer.Selectcustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditCustomer(CustomerMV tempcustomer)
        {
            Response result = customer.ubdatecustomer(tempcustomer);
            if (result.IsValid == true)
            {
                TempData["customerOPer"] = result.SucessMessages.SingleOrDefault().Value;
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View("Edit", tempcustomer.customerId);
            }

        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
           Response result= customer.Selectcustomerdelete(id);
            if (result.IsValid == true)
            {
                TempData["customerOPer"] = result.SucessMessages.SingleOrDefault().Value;
            }
            else
            {
                TempData["customerOPer"] = result.ErrorMessages.SingleOrDefault().Value;
            }
            return RedirectToAction("Index");

        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
