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
    public class APIDETALLES_FACT_PAGOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDETALLES_FACT_PAGO
        public IQueryable<DETALLES_FACT_PAGO> GetDETALLES_FACT_PAGO()
        {
            return db.DETALLES_FACT_PAGO;
        }

        // GET: api/APIDETALLES_FACT_PAGO/5
        [ResponseType(typeof(DETALLES_FACT_PAGO))]
        public IHttpActionResult GetDETALLES_FACT_PAGO(int id)
        {
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            if (dETALLES_FACT_PAGO == null)
            {
                return NotFound();
            }

            return Ok(dETALLES_FACT_PAGO);
        }

        // PUT: api/APIDETALLES_FACT_PAGO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLES_FACT_PAGO(int id, DETALLES_FACT_PAGO dETALLES_FACT_PAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLES_FACT_PAGO.DETALLES_FACT_PAGOId)
            {
                return BadRequest();
            }

            db.Entry(dETALLES_FACT_PAGO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLES_FACT_PAGOExists(id))
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

        // POST: api/APIDETALLES_FACT_PAGO
        [ResponseType(typeof(DETALLES_FACT_PAGO))]
        public IHttpActionResult PostDETALLES_FACT_PAGO(DETALLES_FACT_PAGO dETALLES_FACT_PAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


           //dETALLES_FACT_PAGO.DETALLE_CREDITOId = db.DETALLES_FACT_PAGO.Find(dETALLES_FACT_PAGO.Find(DETALLE_CREDITOId.);

            db.DETALLES_FACT_PAGO.Add(dETALLES_FACT_PAGO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLES_FACT_PAGO.DETALLES_FACT_PAGOId }, dETALLES_FACT_PAGO);
        }

        // DELETE: api/APIDETALLES_FACT_PAGO/5
        [ResponseType(typeof(DETALLES_FACT_PAGO))]
        public IHttpActionResult DeleteDETALLES_FACT_PAGO(int id)
        {
            DETALLES_FACT_PAGO dETALLES_FACT_PAGO = db.DETALLES_FACT_PAGO.Find(id);
            if (dETALLES_FACT_PAGO == null)
            {
                return NotFound();
            }

            db.DETALLES_FACT_PAGO.Remove(dETALLES_FACT_PAGO);
            db.SaveChanges();

            return Ok(dETALLES_FACT_PAGO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLES_FACT_PAGOExists(int id)
        {
            return db.DETALLES_FACT_PAGO.Count(e => e.DETALLES_FACT_PAGOId == id) > 0;
        }
    }
}