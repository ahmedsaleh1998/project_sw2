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
    public class ClientController : Controller
    {
        private LibraryDatabase1Entities db = new LibraryDatabase1Entities();
        /////////////////////////////////// View All Clients ////////////////////////////
        public ActionResult Index_client()
        {
            return View(db.Clients.ToList());
        }
        /////////////////////////////////// Edit Clients (Get Method) /////////////////////////
        public ActionResult Edit_client(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        /////////////////////////////////// Edit Clients (Post Method) /////////////////////////
        [HttpPost]
        public ActionResult Edit_client(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_client");
            }
            return View(client);
        }
        public ActionResult Details_client(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }
        public ActionResult Delete_client(int id)
        {
            Client client = db.Clients.Single(a => a.Client_Id == id);
            return View(client);
        }

        // POST: author/Delete/5
        [HttpPost]
        public ActionResult Delete_client(int id, FormCollection collection)
        {
            try
            {
                Client client = db.Clients.Include(i => i.Books).First(j => j.Client_Id == id);
                db.Clients.Remove(client);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index_client");
            }
            catch
            {
                return View();
            }
        }



        /// ///////////////////////sign up/////////////////////


        // GET: Clients2/Create
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: Clients2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "Client_Id,Client_Name,Password,Mobile,Email,National_Id,DateOfBirth")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            return View(client);
        }




        /// ////////////////////////////////login //////////////////////

        public ActionResult login()
        {
            if (Session["u_id"] != null)
            {
                return RedirectToAction("mainpage", "Client", new { id = Session["u_id"] });
            }
            else
               return View();
            
        }


        [HttpPost]
        public ActionResult login(Client avm)
        {
            if (avm.Email == "am304844@gmail.com" && avm.Password == "123456789")
                return RedirectToAction("AdminHomePage", "Admin");
            Client ad = db.Clients.Where(x => x.Email == avm.Email && x.Password == avm.Password).SingleOrDefault();
            if (ad != null)
            {

                Session["u_id"] = ad.Client_Id;
                return RedirectToAction("mainpage", "Client",new { id=avm.Client_Id,name=avm.Client_Name});


            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }

            return View();
        }


        public ActionResult mainpage()
        {
            if (Session["u_id"]==null)
            {
                RedirectToAction("login", "Client");
            }
             return View(); 
           
        }
        public ActionResult all_books()
        {
            var book = db.Books.Include(p => p.Category);
            return View(book.ToList());
        }
        [HttpPost]
        public ActionResult all_books(string searchtext)
        {
            var pro = db.Books.Include(p => p.Category).Where(p => p.Category.Category_Name.Contains(searchtext) || searchtext == null).ToList();
            return View(pro);
        }

       
        /// ///////////////////////////////my information ///////////////////
        
        public ActionResult myinfo()
        {
            return RedirectToAction("Details_client2", new { id = Session["u_id"] });
        
        }
        ////////////////////////////////////details about client in client model/////////////////////
        public ActionResult Details_client2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        ////////////////////////////////////edit  about client in client model/////////////////////
        ///


        public ActionResult Edit_client2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        /////////////////////////////////// Edit Clients (Post Method) /////////////////////////
        [HttpPost]
        public ActionResult Edit_client2(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_client");
            }
            return View(client);
        }

        /////////////sign out ////////////////////
        ///
        public ActionResult signOut()
        {
            Session["u_id"] = null;
            return RedirectToAction("login");
        }



    }
}