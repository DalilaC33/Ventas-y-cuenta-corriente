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
    public class CUENTASController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CUENTAS
        public ActionResult Index()
        {
            return View(db.CUENTAS.ToList());
        }

        // GET: CUENTAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            if (cUENTAS == null)
            {
                return HttpNotFound();
            }
            return View(cUENTAS);
        }

        // GET: CUENTAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUENTAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUENTASId,denominacion,codigo,estado")] CUENTAS cUENTAS)
        {
            if (ModelState.IsValid)
            {
                db.CUENTAS.Add(cUENTAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTAS);
        }

        // GET: CUENTAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            if (cUENTAS == null)
            {
                return HttpNotFound();
            }
            return View(cUENTAS);
        }

        // POST: CUENTAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUENTASId,denominacion,codigo,estado")] CUENTAS cUENTAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUENTAS);
        }

        // GET: CUENTAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            if (cUENTAS == null)
            {
                return HttpNotFound();
            }
            return View(cUENTAS);
        }

        // POST: CUENTAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            db.CUENTAS.Remove(cUENTAS);
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
