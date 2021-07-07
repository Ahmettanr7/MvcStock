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
    public class CategoryController : Controller
    {
        // GET: Categories
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult CategoryList()
        {
            var values = db.TBLCATEGORIES.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategoryAdd(TBLCATEGORIES ctgry)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCategoryAdd");
            }
            db.TBLCATEGORIES.Add(ctgry);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult Delete(int id)
        {
            var category = db.TBLCATEGORIES.Find(id);
            db.TBLCATEGORIES.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.TBLCATEGORIES.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult Update(TBLCATEGORIES newCategory)
        {
            var category = db.TBLCATEGORIES.Find(newCategory.CATEGORYID);
            category.CATEGORYNAME = newCategory.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}