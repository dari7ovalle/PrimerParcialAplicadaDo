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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            PrestamosRepositorio repositorio = new PrestamosRepositorio();
            int id = 0;

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
                   // filtro = (c => c.CuentaId.Contains(CriterioTextBox.Text) && c.Fecha >= Desde && c.Fecha <= hasta);
                    //  filtro = c => c.Fecha.Equals(CriterioTextBox.Text);
                    break;

                case 3://CuentaId
                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = c => (c.CuentaId == id);

                    break;

                    
            }

            PrestamoGridView.DataSource = repositorio.GetList(filtro);
            PrestamoGridView.DataBind();

        }
    }
    }
