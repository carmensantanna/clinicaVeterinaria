using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class PesquisaConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var listaConsulta = new ControleConsulta().ConsultaVeterinario(1);
                if (listaConsulta != null && listaConsulta.Count > 0)
                {
                    this.gridConsulta.DataSource = listaConsulta;
                    this.gridConsulta.DataBind();
                }
            }
        }

        protected void gridConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string idConsulta = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idConsulta))
                    this.Response.Redirect("Consultar.aspx?codigo=" + idConsulta);
            }
        }

        protected void gridConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}