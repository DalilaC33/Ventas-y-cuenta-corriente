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
using M_ventas_y_cc.Models.ViewModels;

namespace M_ventas_y_cc.Controllers
{
    public class APIVENTAsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIVENTAs
        public IList<VENTAVM> GetVENTA()
        {
            var venta = db.VENTA.Include(p => p.ENCARGADOId).Include(p => p.CLIENTEId);
            IList<VENTAVM> result = new List<VENTAVM>();

            foreach(VENTA ven in venta)
            {
                result.Add(new VENTAVM()
                {
                    VENTAId = ven.VENTAId,
                    ENCARGADOId = ven.ENCARGADOId,
                    CLIENTEId = ven.CLIENTEId,
                    fecha = ven.fecha,
                    estado = ven.estado
            });

                
            }
            return result;

           
        }

        // GET: api/APIVENTAs/5
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult GetVENTA(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return NotFound();
            }

            return Ok(vENTA);
        }

        // PUT: api/APIVENTAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTA(int id, VENTA vENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTA.VENTAId)
            {
                return BadRequest();
            }

            db.Entry(vENTA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTAExists(id))
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


        // POST: api/APIVENTAs
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult PostVENTA(VENTA vENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vENTA.fecha = DateTime.Today;

            vENTA.ENCARGADOId = db.ENCARGADOS.Find(vENTA.ENCARGADOId.encargadoNum);
            vENTA.CLIENTEId = db.CLIENTE.Find(vENTA.CLIENTEId.credito);
            db.VENTA.Add(vENTA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vENTA.VENTAId }, vENTA);
        }



        // DELETE: api/APIVENTAs/5
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult DeleteVENTA(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return NotFound();
            }

            db.VENTA.Remove(vENTA);
            db.SaveChanges();

            return Ok(vENTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTAExists(int id)
        {
            return db.VENTA.Count(e => e.VENTAId == id) > 0;
        }
    }
}