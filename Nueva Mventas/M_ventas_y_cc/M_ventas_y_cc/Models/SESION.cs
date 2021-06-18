using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class SESION
    {

        public int SESIONId { get; set; }

     

        public String usuario { get; set; }
        public String contraseña { get; set; }

        public virtual ENCARGADO ENCARGADOId { get; set; }



    }
}