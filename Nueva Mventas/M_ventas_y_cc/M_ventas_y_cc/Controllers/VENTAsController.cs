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
    public class VENTAsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VENTAs
        public ActionResult Index()
        {
            return View(db.VENTA.ToList());
        }

        // GET: VENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // GET: VENTAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VENTAId,fecha,estado,total,iva")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.VENTA.Add(vENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vENTA);
        }

        // GET: VENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VENTAId,fecha,estado,total,iva")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENTA);
        }

        // GET: VENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            db.VENTA.Remove(vENTA);
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
