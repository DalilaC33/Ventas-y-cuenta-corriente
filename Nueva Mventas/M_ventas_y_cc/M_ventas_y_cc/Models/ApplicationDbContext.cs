using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<ENCARGADO> ENCARGADOS { get; set; }

       
        public DbSet<BANCO> BANCO { get; set; }

        public DbSet<DETALLE_CREDITO> DETALLE_CREDITOS { get; set; }

        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<TARJETA> TARJETA { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<FORMAS_DE_PAGO> FORMAS_DE_PAGO { get; set; }
        public DbSet<SESIONES> SESIONES { get; set; }

        public DbSet<DEPOSITO> DEPOSITO { get; set; }
        public DbSet<STOCK> STOCK { get; set; }
        public DbSet<SESION> SESION { get; set; }
        public DbSet<DETALLES_FACTURA> DETALLES_FACTURA { get; set; }
        public DbSet<FACTURA> FACTURA { get; set; }
        public DbSet<VENTA> VENTA { get; set; }
        public DbSet<VENTAS_DETALLES> VENTAS_DETALLES { get; set; }

        public DbSet<DETALLES_DE_PAGO> DETALLES_DE_PAGO { get; set; }

        public DbSet<PAGOS> PAGOS { get; set; }

        public DbSet<DETALLES_FACT_PAGO> DETALLES_FACT_PAGO { get; set; }
        public DbSet<NOTAS_DE_CREDITO> NOTAS_DE_CREDITO { get; set; }
        
        public DbSet<CUENTAS> CUENTAS { get; set; }
        public DbSet<ASIENTO> ASIENTO { get; set; }
        public DbSet<ASIENTOS_DETALLES> ASIENTOS_DETALLES { get; set; }

        public DbSet<DETALLES_NOTAS_DE_CREDITO> DETALLES_NOTAS_DE_CREDITO { get; set; }
    }

}