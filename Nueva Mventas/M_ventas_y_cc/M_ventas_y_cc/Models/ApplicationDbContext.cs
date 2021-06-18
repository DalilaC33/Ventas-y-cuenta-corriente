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


    }

}