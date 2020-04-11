using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library_management.Model;


namespace library_management.Controllers
{
    public class authorController : Controller
    {
        LibraryDatabase1Entities db = new LibraryDatabase1Entities();

        // GET: author
        public ActionResult Index_author()
        {
            return View(db.Authors.ToList());

        }

       

        // GET: author/Create
        public ActionResult Create_author()
        {
            return View();
        }

        // POST: author/Create
        [HttpPost]
        public ActionResult Create_author(Author author)
        {
     
            try
            {
                if (ModelState.IsValid)


                {
                   
                    db.Authors.Add(author);
                    db.SaveChanges();

                }

                // TODO: Add insert logic here

                return RedirectToAction("Index_author");
            }
            catch
            {
                return View();
            }
        }

        // GET: author/Edit/5
        public ActionResult Edit_author(int id)
        {
            Author author = db.Authors.Single(a => a.Author_Id == id);
            return View(author);
        }

        // POST: author/Edit/5
        [HttpPost]
        public ActionResult Edit_author(int id, Author author)
        {
            try
            {
                Author oldauthor = db.Authors.Single(a => a.Author_Id == id);
                oldauthor.Author_Name = author.Author_Name;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index_author");
            }
            catch
            {
                return View();
            }
        }


        // GET: author/Delete/5
        public ActionResult Delete_author(int id)
        {
            Author author = db.Authors.Single(a => a.Author_Id == id);
            return View(author);
        }

        // POST: author/Delete/5
        [HttpPost]
        public ActionResult Delete_author(int id, FormCollection collection)
        {
            try
            {
                Author author = db.Authors.Single(a => a.Author_Id == id);
                db.Authors.Remove(author);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index_author");
            }
            catch
            {
                return View();
            }
        }
    }
}

