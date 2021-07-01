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
    public class ASIENTOSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ASIENTOS
        public ActionResult Index()
        {
            return View(db.ASIENTO.ToList());
        }

        // GET: ASIENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            if (aSIENTO == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTO);
        }

        // GET: ASIENTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ASIENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ASIENTOId,numero,fecha,descripcion,totalDEBE,totalHABER,fecha_creacion,estado")] ASIENTO aSIENTO)
        {
            if (ModelState.IsValid)
            {
                db.ASIENTO.Add(aSIENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aSIENTO);
        }

        // GET: ASIENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            if (aSIENTO == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTO);
        }

        // POST: ASIENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ASIENTOId,numero,fecha,descripcion,totalDEBE,totalHABER,fecha_creacion,estado")] ASIENTO aSIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aSIENTO);
        }

        // GET: ASIENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            if (aSIENTO == null)
            {
                return HttpNotFound();
            }
            return View(aSIENTO);
        }

        // POST: ASIENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            db.ASIENTO.Remove(aSIENTO);
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
