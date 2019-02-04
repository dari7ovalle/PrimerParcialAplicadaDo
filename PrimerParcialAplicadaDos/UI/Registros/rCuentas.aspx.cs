using BLL;
using Entities;
using PrimerParcialAplicadaDos.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicadaDos.UI
{
    public partial class rCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BalanceTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void LlenaCampos(Cuentas cuentas)
        {
            CuentaIdTextBox.Text = cuentas.CuentaId.ToString();
            FechaTextBox.Text = cuentas.Fecha.ToString();
            NombreTextBox.Text = cuentas.Nombre.ToString();
            BalanceTextBox.Text = cuentas.Balance.ToString();
        }


        private void Limpiar()
        {
            CuentaIdTextBox.Text = "";
            FechaTextBox.Text = "";
            NombreTextBox.Text = "";
            BalanceTextBox.Text = "";
        }

        private Cuentas LlenaClase(Cuentas cuentas)
        {      
            cuentas.CuentaId = Util.ToInt(CuentaIdTextBox.Text);
            cuentas.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = Util.ToDecimal(BalanceTextBox.Text);

            return cuentas;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {

            BLL.RepositorioBase<Cuentas> repositorio = new BLL.RepositorioBase<Cuentas>();
            Cuentas cuentas = new Cuentas();
            bool paso = false;

       
            LlenaClase(cuentas);

            if (IsValid)
            {
                if (cuentas.CuentaId == 0)
                {
                    if (paso = repositorio.Guardar(cuentas))

                        Util.ShowToastr(this, "saved successfully", "Success", "success");

                 
                    else
                    {
                        Util.ShowToastr(this, "Error al Guardar", "Error", "error");

                       
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(cuentas))
                    {
                        Util.ShowToastr(this, "Modificado  successfully", "Success", "success");
                        Limpiar();
                    }
                    else
                    {
                        Util.ShowToastr(this, "Error al Modificar", "Error", "error");

                      
                    }
                }
            }

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas = repositorio.Buscar(Util.ToInt(CuentaIdTextBox.Text));

            if (cuentas != null)
            {
                LlenaCampos(cuentas);
            }
            else
            {
                Limpiar();
                Util.ShowToastr(this, "No Existe en la Base de datos", "Error", "error");
               
            }



        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Cuentas> repositorio = new BLL.RepositorioBase<Cuentas>();
            int id = Util.ToInt(CuentaIdTextBox.Text);

            var cuentas = repositorio.Buscar(id);

            if (cuentas == null)
                Util.ShowToastr(this, "No se puede elliminar Error  ", "Error", "error");
            
            else
                repositorio.Eliminar(id);
            Util.ShowToastr(this, " Eliminado ", "Success", "success");
            Limpiar();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
    
