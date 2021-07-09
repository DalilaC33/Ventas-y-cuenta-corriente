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
    public class APIVENTAS_DETALLESController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIVENTAS_DETALLES
        public IQueryable<VENTAS_DETALLES> GetVENTAS_DETALLES()
        {
            return db.VENTAS_DETALLES;
        }

        // GET: api/APIVENTAS_DETALLES/5
        [ResponseType(typeof(VENTAS_DETALLES))]
        public IHttpActionResult GetVENTAS_DETALLES(int id)
        {
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            if (vENTAS_DETALLES == null)
            {
                return NotFound();
            }

            return Ok(vENTAS_DETALLES);
        }




        // PUT: api/APIVENTAS_DETALLES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTAS_DETALLES(int id, VENTAS_DETALLES vENTAS_DETALLES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTAS_DETALLES.VENTAS_DETALLESId)
            {
                return BadRequest();
            }

            db.Entry(vENTAS_DETALLES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTAS_DETALLESExists(id))
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

        // POST: api/APIVENTAS_DETALLES
        [ResponseType(typeof(VENTAS_DETALLES))]
        public IHttpActionResult PostVENTAS_DETALLES(VENTAS_DETALLES vENTAS_DETALLES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vENTAS_DETALLES.VENTAId = db.VENTA.Find(vENTAS_DETALLES.VENTAId.iva);
            vENTAS_DETALLES.PRODUCTOId = db.PRODUCTO.Find(vENTAS_DETALLES.PRODUCTOId.precio); 

            db.VENTAS_DETALLES.Add(vENTAS_DETALLES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vENTAS_DETALLES.VENTAS_DETALLESId }, vENTAS_DETALLES);
        }

        // DELETE: api/APIVENTAS_DETALLES/5
        [ResponseType(typeof(VENTAS_DETALLES))]
        public IHttpActionResult DeleteVENTAS_DETALLES(int id)
        {
            VENTAS_DETALLES vENTAS_DETALLES = db.VENTAS_DETALLES.Find(id);
            if (vENTAS_DETALLES == null)
            {
                return NotFound();
            }

            db.VENTAS_DETALLES.Remove(vENTAS_DETALLES);
            db.SaveChanges();

            return Ok(vENTAS_DETALLES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTAS_DETALLESExists(int id)
        {
            return db.VENTAS_DETALLES.Count(e => e.VENTAS_DETALLESId == id) > 0;
        }
    }
}