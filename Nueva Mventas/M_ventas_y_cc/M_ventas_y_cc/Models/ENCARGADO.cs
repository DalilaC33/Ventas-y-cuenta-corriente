﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class ENCARGADO
    {

        public int ENCARGADOId { get; set; }

        
        public String usuario { get; set; }
        public String contraseña { get; set; }
        public String nombre { get; set; }
      //  public string apellido { get; set; }
        public String ci { get; set; }
        public String telefono { get; set; }
        public String correo { get; set; }
        public String direccion { get; set; }

        public int encargadoNum { get; set; }







    }
}