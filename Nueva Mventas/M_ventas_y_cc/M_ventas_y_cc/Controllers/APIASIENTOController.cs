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
    public class APIASIENTOController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIASIENTO
        public IQueryable<ASIENTO> GetASIENTO()
        {
            return db.ASIENTO;
        }

        // GET: api/APIASIENTO/5
        [ResponseType(typeof(ASIENTO))]
        public IHttpActionResult GetASIENTO(int id)
        {
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            if (aSIENTO == null)
            {
                return NotFound();
            }

            return Ok(aSIENTO);
        }

        // PUT: api/APIASIENTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutASIENTO(int id, ASIENTO aSIENTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aSIENTO.ASIENTOId)
            {
                return BadRequest();
            }

            db.Entry(aSIENTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ASIENTOExists(id))
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

        // POST: api/APIASIENTO
        [ResponseType(typeof(ASIENTO))]
        public IHttpActionResult PostASIENTO(ASIENTO aSIENTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ASIENTO.Add(aSIENTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aSIENTO.ASIENTOId }, aSIENTO);
        }

        // DELETE: api/APIASIENTO/5
        [ResponseType(typeof(ASIENTO))]
        public IHttpActionResult DeleteASIENTO(int id)
        {
            ASIENTO aSIENTO = db.ASIENTO.Find(id);
            if (aSIENTO == null)
            {
                return NotFound();
            }

            db.ASIENTO.Remove(aSIENTO);
            db.SaveChanges();

            return Ok(aSIENTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ASIENTOExists(int id)
        {
            return db.ASIENTO.Count(e => e.ASIENTOId == id) > 0;
        }
    }
}