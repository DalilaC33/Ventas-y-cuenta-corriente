using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class VENTAS_DETALLES
    {
        public int VENTAS_DETALLESId { get; set; }
        public virtual PRODUCTO PRODUCTOId { get; set; }
        public virtual VENTA VENTAId { get; set; }
        public int cantidad { get; set; }
        public float precio_unitario { get; set; }
        public float subtotal { get; set; }




    }
}