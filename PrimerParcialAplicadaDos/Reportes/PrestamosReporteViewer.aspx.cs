using PrimerParcialAplicadaDos.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicadaDos.Reportes
{
    public partial class PrestamosReporteViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewerPresupuesto.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewerPresupuesto.Reset();
                ReportViewerPresupuesto.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\PrestamosReport.rdlc");
                ReportViewerPresupuesto.LocalReport.DataSources.Clear();
                ReportViewerPresupuesto.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PrestamosDataSet", cPrestamos.listaPrestamos));
                ReportViewerPresupuesto.LocalReport.Refresh();
            }
        }
    }
}