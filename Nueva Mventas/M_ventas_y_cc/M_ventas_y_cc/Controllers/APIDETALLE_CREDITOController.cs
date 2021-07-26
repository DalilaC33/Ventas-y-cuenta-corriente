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
    public class APIDETALLE_CREDITOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDETALLE_CREDITO
        public IQueryable<DETALLE_CREDITO> GetDETALLE_CREDITOS()
        {
            return db.DETALLE_CREDITOS;
        }

        // GET: api/APIDETALLE_CREDITO/5
        [ResponseType(typeof(DETALLE_CREDITO))]
        public IHttpActionResult GetDETALLE_CREDITO(int id)
        {
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            if (dETALLE_CREDITO == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_CREDITO);
        }

        // PUT: api/APIDETALLE_CREDITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_CREDITO(int id, DETALLE_CREDITO dETALLE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_CREDITO.DETALLE_CREDITOId)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_CREDITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_CREDITOExists(id))
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

        // POST: api/APIDETALLE_CREDITO
        [ResponseType(typeof(DETALLE_CREDITO))]
        public IHttpActionResult PostDETALLE_CREDITO(DETALLE_CREDITO dETALLE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dETALLE_CREDITO.PAGOSId = db.PAGOS.Find(dETALLE_CREDITO.PAGOSId.numPago);
            db.DETALLE_CREDITOS.Add(dETALLE_CREDITO);
            db.SaveChanges();
         
            return CreatedAtRoute("DefaultApi", new { id = dETALLE_CREDITO.DETALLE_CREDITOId }, dETALLE_CREDITO);
        }

        // DELETE: api/APIDETALLE_CREDITO/5
        [ResponseType(typeof(DETALLE_CREDITO))]
        public IHttpActionResult DeleteDETALLE_CREDITO(int id)
        {
            DETALLE_CREDITO dETALLE_CREDITO = db.DETALLE_CREDITOS.Find(id);
            if (dETALLE_CREDITO == null)
            {
                return NotFound();
            }

            db.DETALLE_CREDITOS.Remove(dETALLE_CREDITO);
            db.SaveChanges();

            return Ok(dETALLE_CREDITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_CREDITOExists(int id)
        {
            return db.DETALLE_CREDITOS.Count(e => e.DETALLE_CREDITOId == id) > 0;
        }
    }
}