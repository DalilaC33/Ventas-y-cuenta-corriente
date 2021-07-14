using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class DETALLES_DE_PAGO
    {
        public int DETALLES_DE_PAGOId { get; set; }

        public int FACTURAId { get; set; }

        public virtual FORMAS_DE_PAGO FORMAS_DE_PAGOId {get; set;}
        
        public virtual TARJETA TARJETAId { get; set; }
        public virtual BANCO BANCOId { get; set; }

        public float monto { get; set; }
        public float vuelto { get; set; }

        public virtual PAGOS PAGOSId { get; set; }

        public int numero { get; set; }

    }
}