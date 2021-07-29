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
    public class DETALLES_FACTURAController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DETALLES_FACTURA
        public ActionResult Index()
        {
            return View(db.DETALLES_FACTURA.ToList());
        }

        // GET: DETALLES_FACTURA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            if (dETALLES_FACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACTURA);
        }

        // GET: DETALLES_FACTURA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETALLES_FACTURA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DETALLES_FACTURAId,fecha,iva,total")] DETALLES_FACTURA dETALLES_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLES_FACTURA.Add(dETALLES_FACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dETALLES_FACTURA);
        }

        // GET: DETALLES_FACTURA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            if (dETALLES_FACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACTURA);
        }

        // POST: DETALLES_FACTURA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DETALLES_FACTURAId,fecha,iva,total")] DETALLES_FACTURA dETALLES_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLES_FACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dETALLES_FACTURA);
        }

        // GET: DETALLES_FACTURA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            if (dETALLES_FACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACTURA);
        }

        // POST: DETALLES_FACTURA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            db.DETALLES_FACTURA.Remove(dETALLES_FACTURA);
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
