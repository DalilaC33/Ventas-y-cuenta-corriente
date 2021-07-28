using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models.ViewModels
{
    public class PRODUCTOSVM
    {
        public String nombre { get; set; }

        public float precio { get; set; }

        public int cantidad { get; set; }

        public float total { get; set; }
    }
}