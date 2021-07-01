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
    public class APIPAGOSController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIPAGOS
        public IQueryable<PAGOS> GetPAGOS()
        {
            return db.PAGOS;
        }

        // GET: api/APIPAGOS/5
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult GetPAGOS(int id)
        {
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return NotFound();
            }

            return Ok(pAGOS);
        }

        // PUT: api/APIPAGOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAGOS(int id, PAGOS pAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAGOS.PAGOSId)
            {
                return BadRequest();
            }

            db.Entry(pAGOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAGOSExists(id))
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

        // POST: api/APIPAGOS
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult PostPAGOS(PAGOS pAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PAGOS.Add(pAGOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pAGOS.PAGOSId }, pAGOS);
        }

        // DELETE: api/APIPAGOS/5
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult DeletePAGOS(int id)
        {
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return NotFound();
            }

            db.PAGOS.Remove(pAGOS);
            db.SaveChanges();

            return Ok(pAGOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAGOSExists(int id)
        {
            return db.PAGOS.Count(e => e.PAGOSId == id) > 0;
        }
    }
}