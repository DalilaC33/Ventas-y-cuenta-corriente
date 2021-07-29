using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class FACTURA
    {
        public int FACTURAId { get; set; }

      //  public virtual DETALLES_FACTURA DETALLES_FACCTURAId { get; set; }
       public String condicion { get; set; }
        public virtual ENCARGADO ENCARGADOId { get; set; }

        public virtual CLIENTE CLIENTEId { get; set; }
        public virtual VENTA VENTAId { get; set; }

        public String estado { get; set; }

        public float total { get; set; }
        public float iva { get; set; }
        public String saldo { get; set; }

        public String factNum { get; set; }








    }
}