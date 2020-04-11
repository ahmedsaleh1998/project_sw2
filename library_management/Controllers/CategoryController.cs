using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using library_management.Model;

namespace library_management.Controllers
{
    public class CategoryController : Controller
    {
        private LibraryDatabase1Entities db = new LibraryDatabase1Entities();

   
        public ActionResult Index_category()
        {
            return View(db.Categories.ToList());
        }

       
        public ActionResult Create_category()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_category(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index_category");
            }

            return View(category);
        }
    }
}
