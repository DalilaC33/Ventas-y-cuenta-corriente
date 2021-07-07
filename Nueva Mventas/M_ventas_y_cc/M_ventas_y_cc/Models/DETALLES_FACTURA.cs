using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class DETALLES_FACTURA
    {
        public int DETALLES_FACTURAId { get; set; }

        public virtual FACTURA FACTURAId { get; set; } 
        public virtual ENCARGADO ENCARGADOId { get; set; }

        public virtual DETALLE_CREDITO DETALLE_CREDITOId { get; set; }

        public DateTime fecha { get; set; }

        public float iva { get; set; }

        public float total { get; set; }

        public String estado { get; set; }


    }
}