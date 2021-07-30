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
    public class APIDETALLES_DE_PAGOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDETALLES_DE_PAGO
        public IQueryable<DETALLES_DE_PAGO> GetDETALLES_DE_PAGO()
        {
            return db.DETALLES_DE_PAGO;
        }

        // GET: api/APIDETALLES_DE_PAGO/5
        [ResponseType(typeof(DETALLES_DE_PAGO))]
        public IHttpActionResult GetDETALLES_DE_PAGO(int id)
        {
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            if (dETALLES_DE_PAGO == null)
            {
                return NotFound();
            }



            return Ok(dETALLES_DE_PAGO);
        }

        // PUT: api/APIDETALLES_DE_PAGO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLES_DE_PAGO(int id, DETALLES_DE_PAGO dETALLES_DE_PAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLES_DE_PAGO.DETALLES_DE_PAGOId)
            {
                return BadRequest();
            }

            db.Entry(dETALLES_DE_PAGO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLES_DE_PAGOExists(id))
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

        // POST: api/APIDETALLES_DE_PAGO
        [ResponseType(typeof(DETALLES_DE_PAGO))]
        public IHttpActionResult PostDETALLES_DE_PAGO(DETALLES_DE_PAGO dETALLES_DE_PAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            dETALLES_DE_PAGO.TARJETAId = db.TARJETA.Find(dETALLES_DE_PAGO.TARJETAId.numTarjeta);
            dETALLES_DE_PAGO.FORMAS_DE_PAGOId = db.FORMAS_DE_PAGO.Find(dETALLES_DE_PAGO.FORMAS_DE_PAGOId.numFDP);
            dETALLES_DE_PAGO.PAGOSId = db.PAGOS.Find(dETALLES_DE_PAGO.PAGOSId.numPago);
            dETALLES_DE_PAGO.BANCOId = db.BANCO.Find(dETALLES_DE_PAGO.BANCOId.BANCOId);

            db.DETALLES_DE_PAGO.Add(dETALLES_DE_PAGO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLES_DE_PAGO.DETALLES_DE_PAGOId }, dETALLES_DE_PAGO);
        }

        // DELETE: api/APIDETALLES_DE_PAGO/5
        [ResponseType(typeof(DETALLES_DE_PAGO))]
        public IHttpActionResult DeleteDETALLES_DE_PAGO(int id)
        {
            DETALLES_DE_PAGO dETALLES_DE_PAGO = db.DETALLES_DE_PAGO.Find(id);
            if (dETALLES_DE_PAGO == null)
            {
                return NotFound();
            }

            db.DETALLES_DE_PAGO.Remove(dETALLES_DE_PAGO);
            db.SaveChanges();

            return Ok(dETALLES_DE_PAGO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLES_DE_PAGOExists(int id)
        {
            return db.DETALLES_DE_PAGO.Count(e => e.DETALLES_DE_PAGOId == id) > 0;
        }
    }
}