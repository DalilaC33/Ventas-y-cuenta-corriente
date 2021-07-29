using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models.ViewModels
{
    public class PAGOSVM
    {
        public String estado { get; set; }

        public int nroFactura { get; set; }

        public DateTime fecha { get; set; }

        public String cliente { get; set; }

        public String ruc { get; set; }

        public String condicion { get; set; }

        public String encargado { get; set; }

        public float monto { get; set; }


    }
}