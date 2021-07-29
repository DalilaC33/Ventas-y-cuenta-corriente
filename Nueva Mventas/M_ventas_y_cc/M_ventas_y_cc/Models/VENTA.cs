


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class VENTA
    {

        public int VENTAId { get; set; }

        public virtual ENCARGADO ENCARGADOId { get; set; } 

        

        public virtual CLIENTE CLIENTEId { get; set; }

        public DateTime fecha { get; set; }

        public int numVenta { get; set; }

        public String estado { get; set; }
        public float total { get; set; }
        public float iva { get; set; }





    }
}