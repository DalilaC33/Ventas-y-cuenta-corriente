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
    public class APIENCARGADOesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIENCARGADOes
        public IQueryable<ENCARGADO> GetENCARGADOS()
        {
            return db.ENCARGADOS;
        }





        // GET: api/APIENCARGADOes/5
        [ResponseType(typeof(ENCARGADO))]
        public IHttpActionResult GetSESION(string nombre)
        {
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(nombre);
            if (eNCARGADO == null)
            {
                return NotFound();
            }

            return Ok(eNCARGADO);
        }


        // GET: api/APIENCARGADOes/5
        [ResponseType(typeof(ENCARGADO))]
        public IHttpActionResult GetENCARGADO(int id)
        {
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            if (eNCARGADO == null)
            {
                return NotFound();
            }

            return Ok(eNCARGADO);
        }

        // PUT: api/APIENCARGADOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutENCARGADO(int id, ENCARGADO eNCARGADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eNCARGADO.ENCARGADOId)
            {
                return BadRequest();
            }

            db.Entry(eNCARGADO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ENCARGADOExists(id))
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

        // POST: api/APIENCARGADOes
        [ResponseType(typeof(ENCARGADO))]
        public IHttpActionResult PostENCARGADO(ENCARGADO eNCARGADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ENCARGADOS.Add(eNCARGADO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eNCARGADO.ENCARGADOId }, eNCARGADO);
        }

        // DELETE: api/APIENCARGADOes/5
        [ResponseType(typeof(ENCARGADO))]
        public IHttpActionResult DeleteENCARGADO(int id)
        {
            ENCARGADO eNCARGADO = db.ENCARGADOS.Find(id);
            if (eNCARGADO == null)
            {
                return NotFound();
            }

            db.ENCARGADOS.Remove(eNCARGADO);
            db.SaveChanges();

            return Ok(eNCARGADO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ENCARGADOExists(int id)
        {
            return db.ENCARGADOS.Count(e => e.ENCARGADOId == id) > 0;
        }
    }
}