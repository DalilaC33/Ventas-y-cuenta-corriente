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
    public class APIDETALLES_NOTAS_DE_CREDITOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDETALLES_NOTAS_DE_CREDITO
        public IQueryable<DETALLES_NOTAS_DE_CREDITO> GetDETALLES_NOTAS_DE_CREDITO()
        {
            return db.DETALLES_NOTAS_DE_CREDITO;
        }

        // GET: api/APIDETALLES_NOTAS_DE_CREDITO/5
        [ResponseType(typeof(DETALLES_NOTAS_DE_CREDITO))]
        public IHttpActionResult GetDETALLES_NOTAS_DE_CREDITO(int id)
        {
            DETALLES_NOTAS_DE_CREDITO dETALLES_NOTAS_DE_CREDITO = db.DETALLES_NOTAS_DE_CREDITO.Find(id);
            if (dETALLES_NOTAS_DE_CREDITO == null)
            {
                return NotFound();
            }

            return Ok(dETALLES_NOTAS_DE_CREDITO);
        }

        // PUT: api/APIDETALLES_NOTAS_DE_CREDITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLES_NOTAS_DE_CREDITO(int id, DETALLES_NOTAS_DE_CREDITO dETALLES_NOTAS_DE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLES_NOTAS_DE_CREDITO.DETALLES_NOTAS_DE_CREDITOId)
            {
                return BadRequest();
            }

            db.Entry(dETALLES_NOTAS_DE_CREDITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLES_NOTAS_DE_CREDITOExists(id))
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

        // POST: api/APIDETALLES_NOTAS_DE_CREDITO
        [ResponseType(typeof(DETALLES_NOTAS_DE_CREDITO))]
        public IHttpActionResult PostDETALLES_NOTAS_DE_CREDITO(DETALLES_NOTAS_DE_CREDITO dETALLES_NOTAS_DE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        

            db.DETALLES_NOTAS_DE_CREDITO.Add(dETALLES_NOTAS_DE_CREDITO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLES_NOTAS_DE_CREDITO.DETALLES_NOTAS_DE_CREDITOId }, dETALLES_NOTAS_DE_CREDITO);
        }

        // DELETE: api/APIDETALLES_NOTAS_DE_CREDITO/5
        [ResponseType(typeof(DETALLES_NOTAS_DE_CREDITO))]
        public IHttpActionResult DeleteDETALLES_NOTAS_DE_CREDITO(int id)
        {
            DETALLES_NOTAS_DE_CREDITO dETALLES_NOTAS_DE_CREDITO = db.DETALLES_NOTAS_DE_CREDITO.Find(id);
            if (dETALLES_NOTAS_DE_CREDITO == null)
            {
                return NotFound();
            }

            dETALLES_NOTAS_DE_CREDITO.PRODUCTOId = db.PRODUCTO.Find(dETALLES_NOTAS_DE_CREDITO.PRODUCTOId.numPRODUCTO);
            dETALLES_NOTAS_DE_CREDITO.NOTAS_DE_CREDITOId = db.NOTAS_DE_CREDITO.Find(dETALLES_NOTAS_DE_CREDITO.NOTAS_DE_CREDITOId.NOTAS_DE_CREDITOId);
            db.DETALLES_NOTAS_DE_CREDITO.Remove(dETALLES_NOTAS_DE_CREDITO);
            db.SaveChanges();

            return Ok(dETALLES_NOTAS_DE_CREDITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLES_NOTAS_DE_CREDITOExists(int id)
        {
            return db.DETALLES_NOTAS_DE_CREDITO.Count(e => e.DETALLES_NOTAS_DE_CREDITOId == id) > 0;
        }
    }
}