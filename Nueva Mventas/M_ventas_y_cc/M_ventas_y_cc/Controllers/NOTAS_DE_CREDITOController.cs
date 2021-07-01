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
    public class NOTAS_DE_CREDITOController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NOTAS_DE_CREDITO
        public ActionResult Index()
        {
            return View(db.NOTAS_DE_CREDITO.ToList());
        }

        // GET: NOTAS_DE_CREDITO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            if (nOTAS_DE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(nOTAS_DE_CREDITO);
        }

        // GET: NOTAS_DE_CREDITO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NOTAS_DE_CREDITO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOTAS_DE_CREDITOId,fecha_emision,concepto,razon,monto,iva")] NOTAS_DE_CREDITO nOTAS_DE_CREDITO)
        {
            if (ModelState.IsValid)
            {
                db.NOTAS_DE_CREDITO.Add(nOTAS_DE_CREDITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nOTAS_DE_CREDITO);
        }

        // GET: NOTAS_DE_CREDITO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            if (nOTAS_DE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(nOTAS_DE_CREDITO);
        }

        // POST: NOTAS_DE_CREDITO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOTAS_DE_CREDITOId,fecha_emision,concepto,razon,monto,iva")] NOTAS_DE_CREDITO nOTAS_DE_CREDITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTAS_DE_CREDITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nOTAS_DE_CREDITO);
        }

        // GET: NOTAS_DE_CREDITO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            if (nOTAS_DE_CREDITO == null)
            {
                return HttpNotFound();
            }
            return View(nOTAS_DE_CREDITO);
        }

        // POST: NOTAS_DE_CREDITO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            db.NOTAS_DE_CREDITO.Remove(nOTAS_DE_CREDITO);
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
