using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models.ViewModels
{
    public class FACTURAVM
    {

        public int FACTURAId { get; set; }
        public String numFact { get; set; }

        public String nombreCliente { get; set; }
        public  String ruc { get; set; }
        public String estado { get; set; }

        public String condicion { get; set; }

        public String nombreEncargado { get; set; }
    }
}