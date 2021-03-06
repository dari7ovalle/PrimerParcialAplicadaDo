﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
   public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal TasaInteres { get; set; }
        public int Tiempo { get; set; }

        public virtual List<Cuota> Detalle { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Capital = 0;
            TasaInteres = 0;
            Tiempo = 0;
            Detalle = new List<Cuota>();
        }
       

        //public void LimpiarList()
        //{
        //    this.Detalle.Clear();
        //}

        public Prestamos(int prestamoId, DateTime fecha, int cuentaId, decimal capital, decimal tasaInteres, int tiempo, List<Cuota> detalle)
        {
            PrestamoId = prestamoId;
            Fecha = fecha;
            CuentaId = cuentaId;
            Capital = capital;
            TasaInteres = tasaInteres;
            Tiempo = tiempo;
            Detalle = detalle;
        }

      
    }
}

    

