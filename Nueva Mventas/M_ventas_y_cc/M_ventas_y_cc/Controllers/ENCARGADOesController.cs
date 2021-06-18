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
    public class ENCARGADOesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ENCARGADOes
        public ActionResult Index()
        {
            return View(db.ENCARGADOS.ToList());
        }

        // GET: ENCARGADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ENCARGADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ENCARGADOId,usuario,contraseña,nombre,apellido,ci,telefono,correo,direccion")] ENCARGADO eNCARGADO)
        {
            if (ModelState.IsValid)
            {
                db.ENCARGADOS.Add(eNCARGADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // POST: ENCARGADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ENCARGADOId,usuario,contraseña,nombre,apellido,ci,telefono,correo,direccion")] ENCARGADO eNCARGADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNCARGADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // POST: ENCARGADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            db.ENCARGADOS.Remove(eNCARGADO);
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
