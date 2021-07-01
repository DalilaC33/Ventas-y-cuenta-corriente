using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class ASIENTOS_DETALLES
    {
        public int ASIENTOS_DETALLESId { get; set; }
        public virtual ASIENTO ASIENTOId { get; set; }
        public virtual CUENTAS CUENTASId { get; set; }
        public float DEBE { get; set; }
        public float HABER { get; set; }
        public String estado { get; set; }

    }
}