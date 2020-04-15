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
    }
}