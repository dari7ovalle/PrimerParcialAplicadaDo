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
         // Cuentas cuentas = new Cuentas();

            cuentas.CuentaId = Util.ToInt(CuentaIdTextBox.Text);
           // cuentas.Fecha = DateTime.Now.Date;
            cuentas.Fecha = Util.ToDateTime(FechaTextBox.Text).Date;
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = Util.ToDecimal(BalanceTextBox.Text);

            return cuentas;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {

            BLL.RepositorioBase<Cuentas> repositorio = new BLL.RepositorioBase<Cuentas>();
            Cuentas cuentas = new Cuentas();
            bool paso = false;

            //todo: validaciones adicionales
            LlenaClase(cuentas);

            if (IsValid)
            {
                if (cuentas.CuentaId == 0)
                {
                    if (paso = repositorio.Guardar(cuentas))

                      //  Util.ShowToastr(this, "saved successfully", "Success", "success");
                    Response.Write("<script>alert('Guardado Correctamente');</script>");

                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(cuentas))
                    {
                        Response.Write("<script>alert('Modificado Correctamente');</script>");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Modificar');</script>");
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
                Util.ShowToastr(this, "saved successfully", "Error", "error");
                //  Mensaje(TipoMensaje.Error, "No Encontrado");

            }



        }
    }
}
    
