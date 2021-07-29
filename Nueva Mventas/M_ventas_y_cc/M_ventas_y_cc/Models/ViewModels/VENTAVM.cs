
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models.ViewModels
{
    public class VENTAVM
    {


        public int VENTAId { get; set; }

        public virtual ENCARGADO ENCARGADOId { get; set; }

        public String ruc { get; set; }

        public float total { get; set; }

        public float iva { get; set; }

        public string nombreEncargado { get; set; }

        public string nombreCliente { get; set; }

        public int facturado { get; set; }

        public IList<PRODUCTOSVM> detalles { get; set; }
        public virtual CLIENTE CLIENTEId { get; set; }

        public DateTime fecha { get; set; }

        public String estado { get; set; }
      





    }
}