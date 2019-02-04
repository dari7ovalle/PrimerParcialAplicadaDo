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
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombos();
                int id = Util.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Response.Write("<script>alert('Guardado Correctamente');</script>");
                    //  Mensaje(TipoMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(cuenta);
                }
            }
        }
        private void LlenaCampos(Depositos depositos)
        {
            DepositoIdTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString();
            CuentaDropDownList.Text = depositos.CuentaId.ToString();
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }
        void LlenarCombos()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            CuentaDropDownList.DataSource = repositorio.GetList(c => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }
        private Depositos LlenaClase(Depositos depositos)
        {
       

            depositos.DepositoId = Util.ToInt(DepositoIdTextBox.Text);
            depositos.Fecha = Util.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = Util.ToInt(CuentaDropDownList.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = Util.ToDecimal(MontoTextBox.Text);

            return depositos;
        }


        protected void guardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Depositos> repositorio = new BLL.RepositorioBase<Depositos>();
            Depositos depositos = new Depositos();
            bool paso = false;

            //todo: validaciones adicionales
            LlenaClase(depositos);

            if (IsValid)
            {
                if (depositos.DepositoId == 0)
                {
                    if (paso = repositorio.Guardar(depositos))

                         Util.ShowToastr(this, "saved successfully", "Success", "success");
                      //  Response.Write("<script>alert('Guardado Correctamente');</script>");

                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                   // Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(depositos))
                    {
                        Response.Write("<script>alert('Modificado Correctamente');</script>");
                        //Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Modificar');</script>");
                    }
                }
            }

        }
    }
}
    