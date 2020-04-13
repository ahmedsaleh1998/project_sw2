using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using library_management.Model;

namespace library_management.Controllers
{
    public class BookController : Controller
    {
        private LibraryDatabase1Entities db = new LibraryDatabase1Entities();

        /////////////////////////////////// View All Books /////////////////////////
        public ActionResult Index_Book()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            return View(books.ToList());
        }

        
        /////////////////////////////////// Create Book (Get Method) /////////////////////////
        public ActionResult Create_Book()
        {
            ViewBag.Author_Id = new SelectList(db.Authors, "Author_Id", "Author_Name");
            ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", "Category_Name");
            return View();
        }

        /////////////////////////////////// Create Book (Get Method) /////////////////////////
        [HttpPost]
        public ActionResult Create_Book(Book book)
        {
            if (book.ImageFile == null)
            {
                ViewBag.error = "*Required";
            }
            else
            {
                string FileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string Extention = Path.GetExtension(book.ImageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extention;
                book.Image = "~/Image/" + FileName;
                FileName = Path.Combine(Server.MapPath("~/Image/"), FileName);
                

                if (Extention.ToLower() == ".jpg" || Extention.ToLower() == ".jpeg" || Extention.ToLower() == ".png")
                {
                    if (ModelState.IsValid)
                    {
                        book.ImageFile.SaveAs(FileName);
                        db.Books.Add(book);
                        db.SaveChanges();
                        return RedirectToAction("Index_Book");
                    }
                }
                else
                {
                    ViewBag.msg = "Invaild File Type";
                }

            }

            ViewBag.Author_Id = new SelectList(db.Authors, "Author_Id", "Author_Name", book.Author_Id);
            ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", "Category_Name", book.Category_Id);
            return View(book);
        }

        

    }
}
