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
    public class APIDEPOSITOesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIDEPOSITOes
        public IQueryable<DEPOSITO> GetDEPOSITO()
        {
            return db.DEPOSITO;
        }

        // GET: api/APIDEPOSITOes/5
        [ResponseType(typeof(DEPOSITO))]
        public IHttpActionResult GetDEPOSITO(int id)
        {
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            if (dEPOSITO == null)
            {
                return NotFound();
            }

            return Ok(dEPOSITO);
        }

        // PUT: api/APIDEPOSITOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEPOSITO(int id, DEPOSITO dEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEPOSITO.DEPOSITOId)
            {
                return BadRequest();
            }

            db.Entry(dEPOSITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEPOSITOExists(id))
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

        // POST: api/APIDEPOSITOes
        [ResponseType(typeof(DEPOSITO))]
        public IHttpActionResult PostDEPOSITO(DEPOSITO dEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DEPOSITO.Add(dEPOSITO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dEPOSITO.DEPOSITOId }, dEPOSITO);
        }

        // DELETE: api/APIDEPOSITOes/5
        [ResponseType(typeof(DEPOSITO))]
        public IHttpActionResult DeleteDEPOSITO(int id)
        {
            DEPOSITO dEPOSITO = db.DEPOSITO.Find(id);
            if (dEPOSITO == null)
            {
                return NotFound();
            }

            db.DEPOSITO.Remove(dEPOSITO);
            db.SaveChanges();

            return Ok(dEPOSITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEPOSITOExists(int id)
        {
            return db.DEPOSITO.Count(e => e.DEPOSITOId == id) > 0;
        }
    }
}