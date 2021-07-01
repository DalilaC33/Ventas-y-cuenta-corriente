using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class NOTAS_DE_CREDITO
    {
        public int NOTAS_DE_CREDITOId { get; set; }

        public virtual FACTURA FACTURAId { get; set; }
        public virtual ENCARGADO ENCARGADOId { get; set; }
        public DateTime fecha_emision { get; set; }
        public String concepto { get; set; }
        public String razon { get; set; }
        public float monto { get; set; }
        public float iva { get; set; }

    }
}