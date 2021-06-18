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
    public class APISESIONESController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APISESIONES
        public IQueryable<SESIONES> GetSESIONES()
        {
            return db.SESIONES;
        }

        // GET: api/APISESIONES/5
        [ResponseType(typeof(SESIONES))]
        public IHttpActionResult GetSESIONES(int id)
        {
            SESIONES sESIONES = db.SESIONES.Find(id);
            if (sESIONES == null)
            {
                return NotFound();
            }

            return Ok(sESIONES);
        }

        // PUT: api/APISESIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSESIONES(int id, SESIONES sESIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sESIONES.SESIONESId)
            {
                return BadRequest();
            }

            db.Entry(sESIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SESIONESExists(id))
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

        // POST: api/APISESIONES
        [ResponseType(typeof(SESIONES))]
        public IHttpActionResult PostSESIONES(SESIONES sESIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SESIONES.Add(sESIONES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sESIONES.SESIONESId }, sESIONES);
        }

        // DELETE: api/APISESIONES/5
        [ResponseType(typeof(SESIONES))]
        public IHttpActionResult DeleteSESIONES(int id)
        {
            SESIONES sESIONES = db.SESIONES.Find(id);
            if (sESIONES == null)
            {
                return NotFound();
            }

            db.SESIONES.Remove(sESIONES);
            db.SaveChanges();

            return Ok(sESIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SESIONESExists(int id)
        {
            return db.SESIONES.Count(e => e.SESIONESId == id) > 0;
        }
    }
}