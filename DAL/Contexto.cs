using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace DAL
{
    public class Contexto : DbContext

    {
        //public DbSet<Categorias> Categorias { get; set; }
        //public DbSet<TiposEgresos> TiposEgresos { get; set; }
        //public DbSet<Presupuestos> Presupuestos { get; set; }
        //public DbSet<Articulos> Articulo { get; set; }
        //public DbSet<Cotizaciones> Cotizaciones { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}