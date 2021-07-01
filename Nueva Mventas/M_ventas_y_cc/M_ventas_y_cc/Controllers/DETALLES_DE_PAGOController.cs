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
    public class DETALLES_DE_PAGOController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DETALLES_DE_PAGO
        public ActionResult Index()
        {
            return View(db.DETALLES_DE_PAGO.ToList());
        }

        // GET: DETALLES_DE_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            if (dETALLES_DE_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_DE_PAGO);
        }

        // GET: DETALLES_DE_PAGO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETALLES_DE_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DETALLES_DE_PAGOId,monto,vuelto,numero")] DETALLES_DE_PAGO dETALLES_DE_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLES_DE_PAGO.Add(dETALLES_DE_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dETALLES_DE_PAGO);
        }

        // GET: DETALLES_DE_PAGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            if (dETALLES_DE_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_DE_PAGO);
        }

        // POST: DETALLES_DE_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DETALLES_DE_PAGOId,monto,vuelto,numero")] DETALLES_DE_PAGO dETALLES_DE_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLES_DE_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dETALLES_DE_PAGO);
        }

        // GET: DETALLES_DE_PAGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            if (dETALLES_DE_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_DE_PAGO);
        }

        // POST: DETALLES_DE_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            db.DETALLES_DE_PAGO.Remove(dETALLES_DE_PAGO);
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
