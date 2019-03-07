using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositoRepositorio : RepositorioBase<Depositos>
    {
        public override bool Eliminar(int id)
        {
             Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Depositos depositos = contexto.Depositos.Find(id);
                contexto.Cuentas.Find(depositos.CuentaId).Balance -= depositos.Monto;
                contexto.Depositos.Remove(depositos);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Guardar(Depositos entity)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Depositos.Add(entity);
                contexto.Cuentas.Find(entity.CuentaId).Balance += entity.Monto;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Modificar(Depositos entity)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(entity).State = EntityState.Modified;

                Depositos DepAnt = contexto.Depositos.Find(entity.DepositoId);
                var cuenta = contexto.Cuentas.Find(entity.CuentaId);
                var cuentaAnt = contexto.Cuentas.Find(DepAnt.CuentaId);

                if (entity.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += entity.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                {
                    decimal diferencia = entity.Monto - DepAnt.Monto;
                    cuenta.Balance += Convert.ToInt32(diferencia);


                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
    }
}

