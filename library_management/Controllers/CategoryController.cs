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

        public ActionResult Edit_category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit_category(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_category");
            }
            return View(category);
        }

        public ActionResult Delete_category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost, ActionName("Delete_category")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index_category");
        }

    }
}
