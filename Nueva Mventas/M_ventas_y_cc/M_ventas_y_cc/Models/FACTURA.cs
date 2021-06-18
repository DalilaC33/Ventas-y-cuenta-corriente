using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class FACTURA
    {
        public int FACTURAId { get; set; }

        public virtual DETALLES_FACTURA DETALLES_FACCTURAId { get; set; }
        public virtual ENCARGADO ENCARGADOId { get; set; }

        public virtual CLIENTE CLIENTEId { get; set; }

        public string estado { get; set; }

        public float total { get; set; }
        public float iva { get; set; }
        public string saldo { get; set; }








    }
}