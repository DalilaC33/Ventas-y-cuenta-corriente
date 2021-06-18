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
    public class SESIONESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SESIONES
        public ActionResult Index()
        {
            return View(db.SESIONES.ToList());
        }

        // GET: SESIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES sESIONES = db.SESIONES.Find(id);
            if (sESIONES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES);
        }

        // GET: SESIONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SESIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SESIONESId,ENCARGADOSId,usuario,contraseña")] SESIONES sESIONES)
        {
            if (ModelState.IsValid)
            {
                db.SESIONES.Add(sESIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sESIONES);
        }

        // GET: SESIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES sESIONES = db.SESIONES.Find(id);
            if (sESIONES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES);
        }

        // POST: SESIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SESIONESId,ENCARGADOSId,usuario,contraseña")] SESIONES sESIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sESIONES);
        }

        // GET: SESIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES sESIONES = db.SESIONES.Find(id);
            if (sESIONES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES);
        }

        // POST: SESIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SESIONES sESIONES = db.SESIONES.Find(id);
            db.SESIONES.Remove(sESIONES);
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
