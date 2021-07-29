using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class PAGOS
    {
        public int PAGOSId { get; set; }
        public virtual CLIENTE CLIENTEId { get; set; }
        public virtual VENTA VENTAId { get; set; }

        public int numPago { get; set; }

        public virtual FACTURA FACTURAId {get;set;}


        //  public virtual DETALLES_DE_PAGO DETALLES_DE_PAGO { get; set; }

        public float total { get; set; }

        public DateTime fecha { get; set; }




    }
}