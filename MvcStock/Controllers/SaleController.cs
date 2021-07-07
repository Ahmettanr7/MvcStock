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
    public class SaleController : Controller
    {
        // GET: Sale
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult SaleList()
        {
            var values = db.TBLSALES.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult NewSaleAdd()
        {
            List<SelectListItem> values = (from product in db.TBLPRODUCTS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = product.PRODUCTNAME,
                                               Value = product.ID.ToString()
                                           }).ToList();
            ViewBag.product = values;
            List<SelectListItem> values2 = (from customer in db.TBLCUSTOMERS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = customer.CUSTOMERFİRSTNAME + " " + customer.CUSTOMERLASTNAME,
                                               Value = customer.CUSTOMERID.ToString()
                                           }).ToList();
            ViewBag.customer = values2;
            return View();
        }

        [HttpPost]
        public ActionResult NewSaleAdd(TBLSALES sale)
        {
            var product = db.TBLPRODUCTS.Where(m => m.ID == sale.TBLPRODUCTS.ID).FirstOrDefault();
            sale.TBLPRODUCTS = product;

            var customer = db.TBLCUSTOMERS.Where(m => m.CUSTOMERID == sale.TBLCUSTOMERS.CUSTOMERID).FirstOrDefault();
            sale.TBLCUSTOMERS = customer;

            db.TBLSALES.Add(sale);
            db.SaveChanges();
            return RedirectToAction("SaleList");
        }

        public ActionResult Delete(int id)
        {
            var sale = db.TBLSALES.Find(id);
            db.TBLSALES.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("SaleList");
        }
    }
}