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
    public class APINOTAS_DE_CREDITOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APINOTAS_DE_CREDITO
        public IQueryable<NOTAS_DE_CREDITO> GetNOTAS_DE_CREDITO()
        {
            return db.NOTAS_DE_CREDITO;
        }

        // GET: api/APINOTAS_DE_CREDITO/5
        [ResponseType(typeof(NOTAS_DE_CREDITO))]
        public IHttpActionResult GetNOTAS_DE_CREDITO(int id)
        {
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            if (nOTAS_DE_CREDITO == null)
            {
                return NotFound();
            }

            return Ok(nOTAS_DE_CREDITO);
        }

        // PUT: api/APINOTAS_DE_CREDITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNOTAS_DE_CREDITO(int id, NOTAS_DE_CREDITO nOTAS_DE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nOTAS_DE_CREDITO.NOTAS_DE_CREDITOId)
            {
                return BadRequest();
            }

            db.Entry(nOTAS_DE_CREDITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NOTAS_DE_CREDITOExists(id))
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

        // POST: api/APINOTAS_DE_CREDITO
        [ResponseType(typeof(NOTAS_DE_CREDITO))]
        public IHttpActionResult PostNOTAS_DE_CREDITO(NOTAS_DE_CREDITO nOTAS_DE_CREDITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NOTAS_DE_CREDITO.Add(nOTAS_DE_CREDITO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nOTAS_DE_CREDITO.NOTAS_DE_CREDITOId }, nOTAS_DE_CREDITO);
        }

        // DELETE: api/APINOTAS_DE_CREDITO/5
        [ResponseType(typeof(NOTAS_DE_CREDITO))]
        public IHttpActionResult DeleteNOTAS_DE_CREDITO(int id)
        {
            NOTAS_DE_CREDITO nOTAS_DE_CREDITO = db.NOTAS_DE_CREDITO.Find(id);
            if (nOTAS_DE_CREDITO == null)
            {
                return NotFound();
            }

            db.NOTAS_DE_CREDITO.Remove(nOTAS_DE_CREDITO);
            db.SaveChanges();

            return Ok(nOTAS_DE_CREDITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NOTAS_DE_CREDITOExists(int id)
        {
            return db.NOTAS_DE_CREDITO.Count(e => e.NOTAS_DE_CREDITOId == id) > 0;
        }
    }
}