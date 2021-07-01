using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class ASIENTO
    {

        public int ASIENTOId { get; set; }
        public float numero { get; set; }
        public DateTime fecha { get; set; }
        public String descripcion { get; set; }
        public float totalDEBE { get; set; }
        public float totalHABER { get; set; }
        public DateTime fecha_creacion { get; set; }
        public String estado { get; set; }

    }
}