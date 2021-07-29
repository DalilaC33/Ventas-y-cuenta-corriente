using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models.ViewModels
{
    public class DETALLES_DE_PAGOVM
    {

        public int  idpagos { get; set; }

        public int numCuota { get; set; }

        public DateTime fechaVenc { get; set; }

        public string estado { get; set; }



    }
}