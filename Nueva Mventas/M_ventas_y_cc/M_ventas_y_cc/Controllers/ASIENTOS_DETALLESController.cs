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
    public class ASIENTOS_DETALLESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ASIENTOS_DETALLES
        public ActionResult Index()
        {
            return View(db.ASIENTOS_DETALLES.ToList());
        }

        // GET: ASIENTOS_DETALLES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            if (aSIENTOS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTOS_DETALLES);
        }

        // GET: ASIENTOS_DETALLES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ASIENTOS_DETALLES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ASIENTOS_DETALLESId,DEBE,HABER,estado")] ASIENTOS_DETALLES aSIENTOS_DETALLES)
        {
            if (ModelState.IsValid)
            {
                db.ASIENTOS_DETALLES.Add(aSIENTOS_DETALLES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aSIENTOS_DETALLES);
        }

        // GET: ASIENTOS_DETALLES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            if (aSIENTOS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTOS_DETALLES);
        }

        // POST: ASIENTOS_DETALLES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ASIENTOS_DETALLESId,DEBE,HABER,estado")] ASIENTOS_DETALLES aSIENTOS_DETALLES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIENTOS_DETALLES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aSIENTOS_DETALLES);
        }

        // GET: ASIENTOS_DETALLES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            if (aSIENTOS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTOS_DETALLES);
        }

        // POST: ASIENTOS_DETALLES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            db.ASIENTOS_DETALLES.Remove(aSIENTOS_DETALLES);
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
