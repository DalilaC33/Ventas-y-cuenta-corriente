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
    public class DETALLE_CREDITOController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DETALLE_CREDITO
        public ActionResult Index()
        {
            return View(db.DETALLE_CREDITOS.ToList());
        }

        // GET: DETALLE_CREDITO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            if (dETALLE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_CREDITO);
        }

        // GET: DETALLE_CREDITO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETALLE_CREDITO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DETALLE_CREDITOId,MONTO_CUOTA,NRO_CUOTA,PAGADO")] DETALLE_CREDITO dETALLE_CREDITO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_CREDITOS.Add(dETALLE_CREDITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dETALLE_CREDITO);
        }

        // GET: DETALLE_CREDITO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            if (dETALLE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_CREDITO);
        }

        // POST: DETALLE_CREDITO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DETALLE_CREDITOId,MONTO_CUOTA,NRO_CUOTA,PAGADO")] DETALLE_CREDITO dETALLE_CREDITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_CREDITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dETALLE_CREDITO);
        }

        // GET: DETALLE_CREDITO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            if (dETALLE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_CREDITO);
        }

        // POST: DETALLE_CREDITO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            db.DETALLE_CREDITOS.Remove(dETALLE_CREDITO);
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
