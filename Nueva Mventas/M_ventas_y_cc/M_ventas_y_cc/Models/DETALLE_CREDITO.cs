using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class DETALLE_CREDITO
    {

        public int DETALLE_CREDITOId { get; set; }
        public int MONTO_CUOTA { get; set; }
        public int NRO_CUOTA { get; set; }
        public Boolean PAGADO { get; set; }


    }
}