using BLL;
using Entities;
using PrimerParcialAplicadaDos.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicadaDos.UI.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        //private RepositorioBase<Cuentas> repositorioCuentas = new RepositorioBase<Cuentas>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarCombos();
                ViewState["Prestamos"] = new Prestamos();
                int id = Util.ToInt(Request.QueryString["id"]);
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                if (id > 0)
                {

                    PrestamosRepositorio repositorio = new PrestamosRepositorio();
                    Prestamos prestamo = repositorio.Buscar(id);

                    if (prestamo == null)
                        Util.ShowToastr(this, "No Existe en la Base de datos", "Error", "error");
                    else
                        LlenaCampos(prestamo);

                }

            }

        }
        private Prestamos LlenaClase(Prestamos prestamo)
        {
            // prestamo = new Prestamos();
            prestamo = (Prestamos)ViewState["Prestamos"];
            prestamo.PrestamoId =Util.ToInt(PrestamoIdTextBox.Text);
            prestamo.Fecha = Util.ToDateTime(FechaTextBox.Text);
            prestamo.CuentaId = Util.ToInt(CuentaDropDownList.SelectedValue);
            prestamo.TasaInteres = Util.ToInt(InteresTextBox.Text);
            prestamo.Capital = Util.ToDecimal(CapitalTextBox.Text);
            prestamo.Tiempo = Util.ToInt(TiempoTextBox.Text);

          prestamo.Detalle = (List<Cuota>)ViewState["Cuota"];
           // prestamo.Detalle = (Prestamos)ViewState["Prestamos"];
            return prestamo;
        }

        private void LlenaCampos(Prestamos prestamo)
        {
            PrestamoIdTextBox.Text = prestamo.PrestamoId.ToString();
            FechaTextBox.Text = prestamo.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.Text = prestamo.CuentaId.ToString();
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.TasaInteres.ToString();
            TiempoTextBox.Text = prestamo.Tiempo.ToString();
            DetalleGridView.DataSource = prestamo.Detalle;
            DetalleGridView.DataBind();
        }
        //Listo
        private void LlenarCombos()
        {
             RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            CuentaDropDownList.DataSource = repositorio.GetList(c => true);
            CuentaDropDownList.DataValueField ="CuentaId";
            CuentaDropDownList.DataTextField ="Nombre";
            CuentaDropDownList.DataBind();
           
        }
        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Detalle;
            DetalleGridView.DataBind();
            
        }


        private void Limpiar()
        {
            PrestamoIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedIndex = 0;
            CapitalTextBox.Text = "";
            InteresTextBox.Text = "";
            TiempoTextBox.Text = "";
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();
        }


        protected void GuadarButton_Click1(object sender, EventArgs e)
        {
            Prestamos prestamo = new Prestamos();
            PrestamosRepositorio repositorio = new PrestamosRepositorio();
             prestamo = repositorio.Buscar(Util.ToInt(PrestamoIdTextBox.Text));
            bool paso = false;
           
      
         prestamo =LlenaClase(prestamo);

            if (Util.ToInt(PrestamoIdTextBox.Text) == 0)
            {

                paso = repositorio.Guardar(prestamo);
                Util.ShowToastr(this, "Transacción exitosa", "Exito", "success");
                 Limpiar();
            }
            else
                paso = repositorio.Modificar(prestamo);

            //if (paso)
            //{
            //    Util.ShowToastr(this, "Transacción exitosa", "Exito", "success");
            //    Limpiar();
            //}

        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {

            //Prestamos prestamos = new Prestamos();
          List<Cuota>  cuota = new List<Cuota>();
            
        PrestamosRepositorio repositorio = new PrestamosRepositorio();
        int NoCuota = 1;
           decimal porcienInteres= Util.ToDecimal(InteresTextBox.Text);
            decimal capital = Util.ToDecimal(CapitalTextBox.Text);
            int meses = Util.ToInt(TiempoTextBox.Text);
            int AcumulaTiempo = Util.ToInt(TiempoTextBox.Text);
            DateTime fechaGri = DateTime.Now;
            decimal monto = (BLL.PrestamosRepositorio.GetInteres(capital, porcienInteres, meses) / 100) + BLL.PrestamosRepositorio.GetCapital(capital, meses),
                balance= PrestamosRepositorio.GetBalance(Util.ToDecimal(TiempoTextBox.Text), Util.ToDecimal(CapitalTextBox.Text), Util.ToDecimal(InteresTextBox.Text));
        //prestamos = (Prestamos) ViewState["Prestamos"];
            for (int i = 0; i < meses; i++)
            {
                if (i == 0)
                {
                    cuota.Add(new Cuota(0, Util.ToInt(PrestamoIdTextBox.Text), NoCuota, fechaGri, BLL.PrestamosRepositorio.GetInteres(capital, porcienInteres, meses) / 100, BLL.PrestamosRepositorio.GetCapital(capital, meses),
          (BLL.PrestamosRepositorio.GetInteres(capital, porcienInteres, meses) / 100) + BLL.PrestamosRepositorio.GetCapital(capital, meses),
           balance -= monto));

                }
                else
                {
                    cuota.Add(new Cuota(0, Util.ToInt(PrestamoIdTextBox.Text), NoCuota, fechaGri.AddMonths(i), BLL.PrestamosRepositorio.GetInteres(capital, porcienInteres, meses) / 100, BLL.PrestamosRepositorio.GetCapital(capital, meses),
          (BLL.PrestamosRepositorio.GetInteres(capital, porcienInteres, meses) / 100) + BLL.PrestamosRepositorio.GetCapital(capital, meses),
           balance -= monto));

                }
            }

            ViewState["Cuota"] = cuota;
            DetalleGridView.DataSource = ViewState["Cuota"];
            DetalleGridView.DataBind();
       // this.BindGrid();
    }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            PrestamosRepositorio repositorio = new PrestamosRepositorio();
            var prestamo = repositorio.Buscar(
            Util.ToInt(PrestamoIdTextBox.Text));
            if (prestamo != null)
            {
                LlenaCampos(prestamo);
                Util.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                Util.ShowToastr(this,
               "No se pudo encontrar el presupuesto especificado",
               "Error", "error");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            PrestamosRepositorio repositorio = new PrestamosRepositorio();
            Prestamos prestamo = repositorio.Buscar(Util.ToInt(PrestamoIdTextBox.Text));

            if (prestamo != null)
            {
                repositorio.Eliminar(prestamo.PrestamoId);
                Util.ShowToastr(this, "Registro eliminado", "Exito", "success");
                Limpiar();
            }
            else
            {
                Util.ShowToastr(this, "Error al   eliminr", "Error", "error");

                Limpiar();
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
