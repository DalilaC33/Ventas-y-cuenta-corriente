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
    public class APISESIONsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APISESIONs
        public IQueryable<SESION> GetSESION()
        {
            return db.SESION;
        }

        // GET: api/APISESIONs/5
        [ResponseType(typeof(SESION))]
        public IHttpActionResult GetSESION(int id)
        {
            SESION sESION = db.SESION.Find(id);
            if (sESION == null)
            {
                return NotFound();
            }

            return Ok(sESION);
        }

        // PUT: api/APISESIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSESION(int id, SESION sESION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sESION.SESIONId)
            {
                return BadRequest();
            }

            db.Entry(sESION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SESIONExists(id))
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

        // POST: api/APISESIONs
        [ResponseType(typeof(SESION))]
        public IHttpActionResult PostSESION(SESION sESION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SESION.Add(sESION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sESION.SESIONId }, sESION);
        }

        // DELETE: api/APISESIONs/5
        [ResponseType(typeof(SESION))]
        public IHttpActionResult DeleteSESION(int id)
        {
            SESION sESION = db.SESION.Find(id);
            if (sESION == null)
            {
                return NotFound();
            }

            db.SESION.Remove(sESION);
            db.SaveChanges();

            return Ok(sESION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SESIONExists(int id)
        {
            return db.SESION.Count(e => e.SESIONId == id) > 0;
        }
    }
}