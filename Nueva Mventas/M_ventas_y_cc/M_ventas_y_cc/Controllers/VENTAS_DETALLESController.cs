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
    public class VENTAS_DETALLESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VENTAS_DETALLES
        public ActionResult Index()
        {
            return View(db.VENTAS_DETALLES.ToList());
        }

        // GET: VENTAS_DETALLES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            if (vENTAS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(vENTAS_DETALLES);
        }

        // GET: VENTAS_DETALLES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENTAS_DETALLES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VENTAS_DETALLESId,cantidad,precio_unitario,subtotal")] VENTAS_DETALLES vENTAS_DETALLES)
        {
            if (ModelState.IsValid)
            {
                db.VENTAS_DETALLES.Add(vENTAS_DETALLES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vENTAS_DETALLES);
        }

        // GET: VENTAS_DETALLES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            if (vENTAS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(vENTAS_DETALLES);
        }

        // POST: VENTAS_DETALLES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VENTAS_DETALLESId,cantidad,precio_unitario,subtotal")] VENTAS_DETALLES vENTAS_DETALLES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTAS_DETALLES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENTAS_DETALLES);
        }

        // GET: VENTAS_DETALLES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            if (vENTAS_DETALLES == null)
            {
                return HttpNotFound();
            }
            return View(vENTAS_DETALLES);
        }

        // POST: VENTAS_DETALLES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            db.VENTAS_DETALLES.Remove(vENTAS_DETALLES);
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
