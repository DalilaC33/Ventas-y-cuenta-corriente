using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using M_ventas_y_cc.Models;

namespace M_ventas_y_cc.Controllers
{
    public class APIDETALLES_FACTURAController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDETALLES_FACTURA
        public IQueryable<DETALLES_FACTURA> GetDETALLES_FACTURA()
        {
            return db.DETALLES_FACTURA;
        }

        // GET: api/APIDETALLES_FACTURA/5
        [ResponseType(typeof(DETALLES_FACTURA))]
        public IHttpActionResult GetDETALLES_FACTURA(int id)
        {
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            if (dETALLES_FACTURA == null)
            {
                return NotFound();
            }

            return Ok(dETALLES_FACTURA);
        }

        // PUT: api/APIDETALLES_FACTURA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLES_FACTURA(int id, DETALLES_FACTURA dETALLES_FACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLES_FACTURA.DETALLES_FACTURAId)
            {
                return BadRequest();
            }

            db.Entry(dETALLES_FACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLES_FACTURAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIDETALLES_FACTURA
        [ResponseType(typeof(DETALLES_FACTURA))]
        public IHttpActionResult PostDETALLES_FACTURA(DETALLES_FACTURA dETALLES_FACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLES_FACTURA.Add(dETALLES_FACTURA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLES_FACTURA.DETALLES_FACTURAId }, dETALLES_FACTURA);
        }

        // DELETE: api/APIDETALLES_FACTURA/5
        [ResponseType(typeof(DETALLES_FACTURA))]
        public IHttpActionResult DeleteDETALLES_FACTURA(int id)
        {
            DETALLES_FACTURA dETALLES_FACTURA = db.DETALLES_FACTURA.Find(id);
            if (dETALLES_FACTURA == null)
            {
                return NotFound();
            }

            db.DETALLES_FACTURA.Remove(dETALLES_FACTURA);
            db.SaveChanges();

            return Ok(dETALLES_FACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLES_FACTURAExists(int id)
        {
            return db.DETALLES_FACTURA.Count(e => e.DETALLES_FACTURAId == id) > 0;
        }
    }
}