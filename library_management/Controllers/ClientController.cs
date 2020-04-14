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

    }
}