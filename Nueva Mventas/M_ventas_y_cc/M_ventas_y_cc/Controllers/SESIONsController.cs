using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M_ventas_y_cc.Models;

namespace M_ventas_y_cc.Controllers
{
    public class SESIONsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SESIONs
        public ActionResult Index()
        {
            return View(db.SESION.ToList());
        }

        // GET: SESIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESION sESION = db.SESION.Find(id);
            if (sESION == null)
            {
                return HttpNotFound();
            }
            return View(sESION);
        }

        // GET: SESIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SESIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SESIONId,usuario,contraseña")] SESION sESION)
        {
            if (ModelState.IsValid)
            {
                db.SESION.Add(sESION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sESION);
        }

        // GET: SESIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESION sESION = db.SESION.Find(id);
            if (sESION == null)
            {
                return HttpNotFound();
            }
            return View(sESION);
        }

        // POST: SESIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SESIONId,usuario,contraseña")] SESION sESION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sESION);
        }

        // GET: SESIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESION sESION = db.SESION.Find(id);
            if (sESION == null)
            {
                return HttpNotFound();
            }
            return View(sESION);
        }

        // POST: SESIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SESION sESION = db.SESION.Find(id);
            db.SESION.Remove(sESION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
