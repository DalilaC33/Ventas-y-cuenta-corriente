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
    public class PAGOSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PAGOS
        public ActionResult Index()
        {
            return View(db.PAGOS.ToList());
        }

        // GET: PAGOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return HttpNotFound();
            }
            return View(pAGOS);
        }

        // GET: PAGOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAGOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAGOSId,total,fecha")] PAGOS pAGOS)
        {
            if (ModelState.IsValid)
            {
                db.PAGOS.Add(pAGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAGOS);
        }

        // GET: PAGOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return HttpNotFound();
            }
            return View(pAGOS);
        }

        // POST: PAGOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAGOSId,total,fecha")] PAGOS pAGOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAGOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAGOS);
        }

        // GET: PAGOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return HttpNotFound();
            }
            return View(pAGOS);
        }

        // POST: PAGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAGOS pAGOS = db.PAGOS.Find(id);
            db.PAGOS.Remove(pAGOS);
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
