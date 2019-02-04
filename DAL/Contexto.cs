using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace DAL
{
    public class Contexto : DbContext

    {

        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Depositos> Depositos { get; set; }


        public Contexto() : base("ConStr")
        {

        }
    }
}