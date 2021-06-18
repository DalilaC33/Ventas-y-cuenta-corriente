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
    public class DEPOSITOesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DEPOSITOes
        public ActionResult Index()
        {
            return View(db.DEPOSITO.ToList());
        }

        // GET: DEPOSITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            if (dEPOSITO == null)
            {
                return HttpNotFound();
            }
            return View(dEPOSITO);
        }

        // GET: DEPOSITOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPOSITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPOSITOId,nombre,direccion")] DEPOSITO dEPOSITO)
        {
            if (ModelState.IsValid)
            {
                db.DEPOSITO.Add(dEPOSITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPOSITO);
        }

        // GET: DEPOSITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            if (dEPOSITO == null)
            {
                return HttpNotFound();
            }
            return View(dEPOSITO);
        }

        // POST: DEPOSITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPOSITOId,nombre,direccion")] DEPOSITO dEPOSITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPOSITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPOSITO);
        }

        // GET: DEPOSITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            if (dEPOSITO == null)
            {
                return HttpNotFound();
            }
            return View(dEPOSITO);
        }

        // POST: DEPOSITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            db.DEPOSITO.Remove(dEPOSITO);
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
