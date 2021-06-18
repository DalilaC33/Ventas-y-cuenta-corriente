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
    public class STOCKsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: STOCKs
        public ActionResult Index()
        {
            return View(db.STOCK.ToList());
        }

        // GET: STOCKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // GET: STOCKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOCKs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STOCKId,Nombre_producto,cantidad")] STOCK sTOCK)
        {
            if (ModelState.IsValid)
            {
                db.STOCK.Add(sTOCK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOCK);
        }

        // GET: STOCKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // POST: STOCKs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STOCKId,Nombre_producto,cantidad")] STOCK sTOCK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOCK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOCK);
        }

        // GET: STOCKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // POST: STOCKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOCK sTOCK = db.STOCK.Find(id);
            db.STOCK.Remove(sTOCK);
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
