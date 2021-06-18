using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class CLIENTE
    {
        public int CLIENTEId { get; set; }
        public int ruc { get; set; }

        public String nombre { get; set; }

        public String apellido { get; set; }
        public String telefono { get; set; }
        public String correo { get; set; }
        public String credito { get; set; }


    }
}