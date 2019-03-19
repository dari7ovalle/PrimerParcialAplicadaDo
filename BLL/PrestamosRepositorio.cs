using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamosRepositorio : RepositorioBase<Prestamos>
    {
        public override Prestamos Buscar(int id)
        {

            //Prestamos facturas = new Prestamos();
            //Contexto contexto = new Contexto();

            //try
            //{
            //    facturas = contexto.Prestamos.Find(id);

            //    if (facturas != null)
            //    {
            //        facturas.Detalle.Count();
            //        foreach (var item in facturas.Detalle)
            //        {
            //          //  string p = item.ValorPrestamo.ToString();
            //        }
            //    }



            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    contexto.Dispose();
            //}


            //return facturas;

            Contexto contexto = new Contexto();
            Prestamos prestamo = null;
            try
            {
                prestamo = contexto.Prestamos.Include(x => x.Detalle).Where(z => z.PrestamoId == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return prestamo;


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
        public override List<Prestamos> GetList(Expression<Func<Prestamos, bool>> expression)
        {
            List<Prestamos> list = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Prestamos.Include(x => x.Detalle).Where(expression).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return list;
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
        public override bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.Prestamos.Find(prestamo.PrestamoId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!prestamo.Detalle.Exists(d => d.Id == item.Id))
                    {
                        item.ValorPrestamo = 0;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in prestamo.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(prestamo).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public override bool Guardar(Prestamos entity)
        {
              int ToInt(string valor)
            {
                int retorno = 0;
                int.TryParse(valor, out retorno);

                return retorno;
            }
            int totalINT;
            bool paso = false;
            decimal Total = 0;
            _contexto = new DAL.Contexto();
            try
            {
                foreach (var item in entity.Detalle)
                {
                    
                    Total += item.ValorPrestamo;
                }
                totalINT=ToInt(Total.ToString());
                _contexto.Cuentas.Find(entity.CuentaId).Balance += totalINT;
                _contexto.Prestamos.Add(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}

