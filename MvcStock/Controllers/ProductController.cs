using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult ProductList()
        {
            var values = db.TBLPRODUCTS.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewProductAdd()
        {
            List<SelectListItem> values = (from ctgry in db.TBLCATEGORIES.ToList()
                                           select new SelectListItem
                                           {
                                               Text = ctgry.CATEGORYNAME,
                                               Value = ctgry.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.category = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProductAdd(TBLPRODUCTS prdct)
        {
            var ctgry = db.TBLCATEGORIES.Where(m => m.CATEGORYID == prdct.TBLCATEGORIES.CATEGORYID).FirstOrDefault();
            prdct.TBLCATEGORIES = ctgry;
            db.TBLPRODUCTS.Add(prdct);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult Delete(int id)
        {
            var product = db.TBLPRODUCTS.Find(id);
            db.TBLPRODUCTS.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult GetProduct(int id)
        {
            var product = db.TBLPRODUCTS.Find(id);
            return View("GetProduct", product);
        }
    }
}