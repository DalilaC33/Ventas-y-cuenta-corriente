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
    public class APICLIENTEController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APICLIENTE
        public IQueryable<CLIENTE> GetCLIENTE()
        {
            return db.CLIENTE;
        }

        // GET: api/APICLIENTE/5
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult GetCLIENTE(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return NotFound();
            }

            return Ok(cLIENTE);
        }

        // PUT: api/APICLIENTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLIENTE(int id, CLIENTE cLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENTE.CLIENTEId)
            {
                return BadRequest();
            }

            db.Entry(cLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTEExists(id))
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

        // POST: api/APICLIENTE
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult PostCLIENTE(CLIENTE cLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTE.Add(cLIENTE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cLIENTE.CLIENTEId }, cLIENTE);
        }

        // DELETE: api/APICLIENTE/5
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult DeleteCLIENTE(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return NotFound();
            }

            db.CLIENTE.Remove(cLIENTE);
            db.SaveChanges();

            return Ok(cLIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLIENTEExists(int id)
        {
            return db.CLIENTE.Count(e => e.CLIENTEId == id) > 0;
        }
    }
}