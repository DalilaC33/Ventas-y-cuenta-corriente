using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class SESIONES
    {



       

            public int SESIONESId { get; set; }

            public int ENCARGADOSId { get; set; }

            public String usuario { get; set; }
            public String contraseña { get; set; }

            public virtual ENCARGADO ENCARGADOId { get; set; }



        
    }
}