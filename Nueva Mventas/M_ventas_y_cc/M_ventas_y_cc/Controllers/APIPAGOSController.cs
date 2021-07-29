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
    public class APIPAGOSController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIPAGOS
        public IQueryable<PAGOS> GetPAGOS()
        {
            var pagos = db.PAGOS.Include(p => p.CLIENTEId).Include(p => p.FACTURAId).Include(p => p.VENTAId);
            IList<PAGOSVM> result = new List<PAGOSVM>();

            foreach (PAGOS pAGOS in pagos)
            {
                result.Add(new PAGOSVM()
                {
                  //  estado = pAGOS.VENTAId.estado,
                    nroFactura = pAGOS.FACTURAId.factNum,
                    condicion = pAGOS.FACTURAId.condicion,


                    cliente = pAGOS.CLIENTEId.nombre,
                    ruc = pAGOS.CLIENTEId.ruc,
                    fecha = pAGOS.fecha,
                    monto = pAGOS.total,
                    encargado = pAGOS.VENTAId.ENCARGADOId.nombre,


                });
            }
            return db.PAGOS;
        }

        // GET: api/APIPAGOS/5
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult GetPAGOS(int id)
        {
            PAGOS pAGOS = db.PAGOS.Find(id);
            // FACTURA factura = db.FACTURA.Find(pAGOS.VENTAId.VENTAId);
            if (pAGOS == null)
            {
                return NotFound();
            }



            var detalles = db.DETALLES_DE_PAGO;

            IList<DETALLES_DE_PAGOVM> result = new List<DETALLES_DE_PAGOVM>();

            foreach (DETALLES_DE_PAGO det in detalles)
            {


                if (det.PAGOSId.PAGOSId == pAGOS.PAGOSId)
                {



                    result.Add(new DETALLES_DE_PAGOVM()
                    {
                        idpagos = det.PAGOSId.PAGOSId,
                        numCuota = det.numero,
                        fechaVenc = det.PAGOSId.fechaVenc,
                        estado = det.PAGOSId.estado

                    });
                }

                
            }
            return Ok(result);
        }

        // return Ok(pAGOS);

        



        // PUT: api/APIPAGOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAGOS(int id, PAGOS pAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAGOS.PAGOSId)
            {
                return BadRequest();
            }

            db.Entry(pAGOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAGOSExists(id))
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

        // POST: api/APIPAGOS
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult PostPAGOS(PAGOS pAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pAGOS.fecha = DateTime.Today;
            pAGOS.CLIENTEId = db.CLIENTE.Find(pAGOS.CLIENTEId.credito);
            pAGOS.VENTAId = db.VENTA.Find(pAGOS.VENTAId.numVenta);

            db.PAGOS.Add(pAGOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pAGOS.PAGOSId }, pAGOS);
        }

        // DELETE: api/APIPAGOS/5
        [ResponseType(typeof(PAGOS))]
        public IHttpActionResult DeletePAGOS(int id)
        {
            PAGOS pAGOS = db.PAGOS.Find(id);
            if (pAGOS == null)
            {
                return NotFound();
            }

            db.PAGOS.Remove(pAGOS);
            db.SaveChanges();

            return Ok(pAGOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAGOSExists(int id)
        {
            return db.PAGOS.Count(e => e.PAGOSId == id) > 0;
        }
    }
}