using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class DETALLES_NOTAS_DE_CREDITO
    {
        public int DETALLES_NOTAS_DE_CREDITOId { get; set; }
        public virtual NOTAS_DE_CREDITO NOTAS_DE_CREDITOId { get; set; }

        public int numDetalleNC { get; set; }

        public virtual PRODUCTO PRODUCTOId { get; set; }
        public int cantidad { get; set; }
        public float subtotal { get; set; }

    }
}