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
    public class APIFACTURAsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIFACTURAs
        public IQueryable<FACTURA> GetFACTURA()
        {
            return db.FACTURA;
        }

        // GET: api/APIFACTURAs/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult GetFACTURA(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            IList<FACTURAVM> result = new List<FACTURAVM>();

            result.Add(new FACTURAVM()
            {
                FACTURAId = fACTURA.FACTURAId,
                numFact=fACTURA.factNum,
                nombreCliente=fACTURA.CLIENTEId.nombre,
                ruc=fACTURA.CLIENTEId.ruc,
                estado=fACTURA.estado,
                condicion=fACTURA.condicion,
                nombreEncargado=fACTURA.ENCARGADOId.nombre

            });


            return Ok(result);
        }

        // PUT: api/APIFACTURAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFACTURA(int id, FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fACTURA.FACTURAId)
            {
                return BadRequest();
            }

            db.Entry(fACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FACTURAExists(id))
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

        // POST: api/APIFACTURAs
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult PostFACTURA(FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            fACTURA.CLIENTEId = db.CLIENTE.Find(fACTURA.CLIENTEId.credito);
            fACTURA.ENCARGADOId = db.ENCARGADOS.Find(fACTURA.ENCARGADOId.encargadoNum);
            fACTURA.VENTAId = db.VENTA.Find(fACTURA.VENTAId.numVenta);
            db.FACTURA.Add(fACTURA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fACTURA.FACTURAId }, fACTURA);
        }
        // DELETE: api/APIFACTURAs/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult DeleteFACTURA(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            db.FACTURA.Remove(fACTURA);
            db.SaveChanges();

            return Ok(fACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FACTURAExists(int id)
        {
            return db.FACTURA.Count(e => e.FACTURAId == id) > 0;
        }
    }
}