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
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                LlenarCombos();
                Cuentas cuentas = new Cuentas();
                int id = Util.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Util.ShowToastr(this, "No Existe en la Base de datos", "Error", "error");

                    else
                        LlenaCampos(cuenta);
                }
            }
        }
        private void Limpiar()
        {
            DepositoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            CuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";

        }
        private void LlenaCampos(Depositos depositos)
        {
            DepositoIdTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.Text = Convert.ToString(depositos.CuentaId);
            // CuentaDropDownList.SelectedIndex = depositos.CuentaId;
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
        }
        public  Depositos LlenaClase()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = Util.ToInt(DepositoIdTextBox.Text);
            depositos.Fecha = Util.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = Util.ToInt(CuentaDropDownList.SelectedValue);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = Util.ToInt(MontoTextBox.Text);

            return depositos;
        }


        protected void guardarButton_Click(object sender, EventArgs e)
        {

        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            int id = Util.ToInt(DepositoIdTextBox.Text);

            var depositos = repositorio.Buscar(id);

            if (depositos == null)
                Util.ShowToastr(this, "No Existe en la Base de datos", "Error", "error");

            else
                repositorio.Eliminar(id);
            Util.ShowToastr(this, "Eliminado ", "Success", "success");
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            bool paso = false;
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos depositos = new Depositos();
           

            depositos= LlenaClase();
            
                if (depositos.DepositoId == 0)
                {
                if (paso = repositorio.Guardar(depositos))
                {
                    Util.ShowToastr(this, "Guardado", "Success", "success");
                    Limpiar();
                }
                else
                {
                    Util.ShowToastr(this, "Error Al Guardar", "Error", "error");
                }

                }

                else
                {
                    if (paso = repositorio.Modificar(depositos))
                    {
                        Util.ShowToastr(this, "saved successfully Modificar", "Info", "info");
                    Limpiar();
                    }
                    else
                    {
                        Util.ShowToastr(this, "Error Al Modificar", "Error", "error");

                    }
                }
            }
        

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos depositos = repositorio.Buscar(Util.ToInt(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                LlenaCampos(depositos);
            }
            else
            {
         
                Util.ShowToastr(this, "No Existe en la Base de datos", "Error", "error");
                Limpiar();
            }

        }
    }
}
    