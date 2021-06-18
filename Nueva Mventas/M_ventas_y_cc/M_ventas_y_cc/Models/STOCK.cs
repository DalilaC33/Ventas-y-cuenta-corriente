
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{
    public class STOCK
    {
        public int STOCKId { get; set; }

        public string Nombre_producto { get; set; }

        public virtual PRODUCTO PRODUCTOId { get; set; }

        public virtual DEPOSITO DEPOSITOId { get; set; }

        public int cantidad { get; set; }


    }
}