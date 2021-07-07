using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customers
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult CustomerList()
        {
            var values = db.TBLCUSTOMERS.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCustomerAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomerAdd(TBLCUSTOMERS cstmr)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomerAdd");
            }
            db.TBLCUSTOMERS.Add(cstmr);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public ActionResult Delete(int id)
        {
            var customer = db.TBLCUSTOMERS.Find(id);
            db.TBLCUSTOMERS.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = db.TBLCUSTOMERS.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult Update(TBLCUSTOMERS newCustomer)
        {
            var customer = db.TBLCUSTOMERS.Find(newCustomer.CUSTOMERID);
            customer.CUSTOMERFİRSTNAME = newCustomer.CUSTOMERFİRSTNAME;
            customer.CUSTOMERLASTNAME = newCustomer.CUSTOMERLASTNAME;
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}