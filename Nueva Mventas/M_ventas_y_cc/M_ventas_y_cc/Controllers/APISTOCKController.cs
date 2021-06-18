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
    public class APISTOCKController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APISTOCK
        public IQueryable<STOCK> GetSTOCK()
        {
            return db.STOCK;
        }

        // GET: api/APISTOCK/5
        [ResponseType(typeof(STOCK))]
        public IHttpActionResult GetSTOCK(int id)
        {
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return NotFound();
            }

            return Ok(sTOCK);
        }

        // PUT: api/APISTOCK/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTOCK(int id, STOCK sTOCK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTOCK.STOCKId)
            {
                return BadRequest();
            }

            db.Entry(sTOCK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STOCKExists(id))
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

        // POST: api/APISTOCK
        [ResponseType(typeof(STOCK))]
        public IHttpActionResult PostSTOCK(STOCK sTOCK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STOCK.Add(sTOCK);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sTOCK.STOCKId }, sTOCK);
        }

        // DELETE: api/APISTOCK/5
        [ResponseType(typeof(STOCK))]
        public IHttpActionResult DeleteSTOCK(int id)
        {
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return NotFound();
            }

            db.STOCK.Remove(sTOCK);
            db.SaveChanges();

            return Ok(sTOCK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STOCKExists(int id)
        {
            return db.STOCK.Count(e => e.STOCKId == id) > 0;
        }
    }
}