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
    public class APIASIENTOS_DETALLESController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIASIENTOS_DETALLES
        public IQueryable<ASIENTOS_DETALLES> GetASIENTOS_DETALLES()
        {
            return db.ASIENTOS_DETALLES;
        }

        // GET: api/APIASIENTOS_DETALLES/5
        [ResponseType(typeof(ASIENTOS_DETALLES))]
        public IHttpActionResult GetASIENTOS_DETALLES(int id)
        {
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            if (aSIENTOS_DETALLES == null)
            {
                return NotFound();
            }

            return Ok(aSIENTOS_DETALLES);
        }

        // PUT: api/APIASIENTOS_DETALLES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutASIENTOS_DETALLES(int id, ASIENTOS_DETALLES aSIENTOS_DETALLES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aSIENTOS_DETALLES.ASIENTOS_DETALLESId)
            {
                return BadRequest();
            }

            db.Entry(aSIENTOS_DETALLES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ASIENTOS_DETALLESExists(id))
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

        // POST: api/APIASIENTOS_DETALLES
        [ResponseType(typeof(ASIENTOS_DETALLES))]
        public IHttpActionResult PostASIENTOS_DETALLES(ASIENTOS_DETALLES aSIENTOS_DETALLES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ASIENTOS_DETALLES.Add(aSIENTOS_DETALLES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aSIENTOS_DETALLES.ASIENTOS_DETALLESId }, aSIENTOS_DETALLES);
        }

        // DELETE: api/APIASIENTOS_DETALLES/5
        [ResponseType(typeof(ASIENTOS_DETALLES))]
        public IHttpActionResult DeleteASIENTOS_DETALLES(int id)
        {
            ASIENTOS_DETALLES aSIENTOS_DETALLES = db.ASIENTOS_DETALLES.Find(id);
            if (aSIENTOS_DETALLES == null)
            {
                return NotFound();
            }

            db.ASIENTOS_DETALLES.Remove(aSIENTOS_DETALLES);
            db.SaveChanges();

            return Ok(aSIENTOS_DETALLES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ASIENTOS_DETALLESExists(int id)
        {
            return db.ASIENTOS_DETALLES.Count(e => e.ASIENTOS_DETALLESId == id) > 0;
        }
    }
}