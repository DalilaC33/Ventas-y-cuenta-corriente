using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class DETALLES_FACT_PAGO
    {
        public int DETALLES_FACT_PAGOId { get; set; }
        public virtual PAGOS PAGOSId { get; set; }

        public virtual DETALLE_CREDITO DETALLE_CREDITOId { get; set; }

    }
}