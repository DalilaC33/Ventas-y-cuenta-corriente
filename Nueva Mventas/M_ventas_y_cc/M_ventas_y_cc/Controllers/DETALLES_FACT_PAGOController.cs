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
    public class DETALLES_FACT_PAGOController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DETALLES_FACT_PAGO
        public ActionResult Index()
        {
            return View(db.DETALLES_FACT_PAGO.ToList());
        }

        // GET: DETALLES_FACT_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            if (dETALLES_FACT_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACT_PAGO);
        }

        // GET: DETALLES_FACT_PAGO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETALLES_FACT_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DETALLES_FACT_PAGOId")] DETALLES_FACT_PAGO dETALLES_FACT_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLES_FACT_PAGO.Add(dETALLES_FACT_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dETALLES_FACT_PAGO);
        }

        // GET: DETALLES_FACT_PAGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            if (dETALLES_FACT_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACT_PAGO);
        }

        // POST: DETALLES_FACT_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DETALLES_FACT_PAGOId")] DETALLES_FACT_PAGO dETALLES_FACT_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLES_FACT_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dETALLES_FACT_PAGO);
        }

        // GET: DETALLES_FACT_PAGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            if (dETALLES_FACT_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLES_FACT_PAGO);
        }

        // POST: DETALLES_FACT_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            db.DETALLES_FACT_PAGO.Remove(dETALLES_FACT_PAGO);
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
