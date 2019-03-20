using BLL;
using Entities;
using PrimerParcialAplicadaDos.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicadaDos.UI.Consultas
{
    public partial class cPrestamos : System.Web.UI.Page
    {
        Expression<Func<Prestamos, bool>> filtro = c => true;
        public static List<Prestamos> listaPrestamos = new List<Prestamos>();
        PrestamosRepositorio repositorio = new PrestamosRepositorio();
        protected void Page_Load(object sender, EventArgs e)
        {
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            listaPrestamos = repositorio.GetList(x => true);

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
          
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;

                case 1://PrestamoId
                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = c => c.PrestamoId == id;
                    break;

                case 2://Fecha
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = c => (c.CuentaId == id);

                    break;

                    
            }

            listaPrestamos= repositorio.GetList(filtro);
            PrestamoGridView.DataSource = listaPrestamos;
            PrestamoGridView.DataBind();

        }

        protected void ImprimirLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Reportes\PrestamosReporteViewer.aspx");
        }
    }
    }
