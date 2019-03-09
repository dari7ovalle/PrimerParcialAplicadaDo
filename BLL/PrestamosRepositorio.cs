using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamosRepositorio : RepositorioBase<Prestamos>
    {
        public override Prestamos Buscar(int id)
        {
            Prestamos facturas = new Prestamos();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Prestamos.Find(id);

                if (facturas != null)
                {
                    facturas.Detalle.Count();
                    foreach (var item in facturas.Detalle)
                    {
                      //  string p = item.ValorPrestamo.ToString();
                    }
                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return facturas;
        }
        public static decimal GetCapital(decimal capital,int meses)
        {
          decimal  acumCapital = capital / meses;
            return acumCapital;

        }

        public static  decimal GetInteres(decimal capital,decimal porCienInteres,int meses)
        {
           return (capital * porCienInteres )/ meses;
            

        }
        

        public static decimal GetBalance(decimal Meses, decimal capital, decimal pctInteres)
        {
            decimal totalInteres = 0;
            decimal montoInteres = 0;
            decimal Cuota;
            decimal Balance = 0;
            decimal CapitalM = 0;
            CapitalM = capital / Meses;
            pctInteres /= 100;
            montoInteres = capital * pctInteres;
            Cuota = CapitalM + montoInteres;
            // totalInteres = montoInteres * Meses;
            Balance = (capital + montoInteres);// - Cuota;
            return Balance;
        }
        
    }
}

