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
    public partial class cDepositos : System.Web.UI.Page
    {
        Expression<Func<Depositos, bool>> filtro = c => true;
        BLL.RepositorioBase<Depositos> repositorio = new BLL.RepositorioBase<Depositos>();
        List<Depositos> cuentas = new List<Depositos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!IsPostBack)
            {
                cuentas = repositorio.GetList(filtro);
                
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);

            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            int id;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0:

                 
                   filtro = c => true;
                    break;

                case 1:

                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = (c => c.DepositoId == id);
                    break;

                case 2:
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                

                

            }

            DepositoGridView.DataSource = repositorio.GetList(filtro);
            DepositoGridView.DataBind();
        }
    }
    }
