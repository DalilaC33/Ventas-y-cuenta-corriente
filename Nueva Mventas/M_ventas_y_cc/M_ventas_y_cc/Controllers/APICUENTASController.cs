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
    public class APICUENTASController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APICUENTAS
        public IQueryable<CUENTAS> GetCUENTAS()
        {
            return db.CUENTAS;
        }

        // GET: api/APICUENTAS/5
        [ResponseType(typeof(CUENTAS))]
        public IHttpActionResult GetCUENTAS(int id)
        {
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            if (cUENTAS == null)
            {
                return NotFound();
            }

            return Ok(cUENTAS);
        }

        // PUT: api/APICUENTAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCUENTAS(int id, CUENTAS cUENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cUENTAS.CUENTASId)
            {
                return BadRequest();
            }

            db.Entry(cUENTAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUENTASExists(id))
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

        // POST: api/APICUENTAS
        [ResponseType(typeof(CUENTAS))]
        public IHttpActionResult PostCUENTAS(CUENTAS cUENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CUENTAS.Add(cUENTAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cUENTAS.CUENTASId }, cUENTAS);
        }

        // DELETE: api/APICUENTAS/5
        [ResponseType(typeof(CUENTAS))]
        public IHttpActionResult DeleteCUENTAS(int id)
        {
            CUENTAS cUENTAS = db.CUENTAS.Find(id);
            if (cUENTAS == null)
            {
                return NotFound();
            }

            db.CUENTAS.Remove(cUENTAS);
            db.SaveChanges();

            return Ok(cUENTAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CUENTASExists(int id)
        {
            return db.CUENTAS.Count(e => e.CUENTASId == id) > 0;
        }
    }
}