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
            if (e.CommandName.Equals("Editar"))
            {
                string idCliente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idCliente))
                    this.Response.Redirect("EditarClientes.aspx?codigo=" + idCliente);
            }
            else if (e.CommandName.Equals("IncluirPet"))
            {
                string idCliente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idCliente))
                    this.Response.Redirect("IncluirPet.aspx?cliente=" + idCliente);
            }
            else if (e.CommandName.Equals("AgendarConsulta"))
            {
                string idCliente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idCliente))
                    this.Response.Redirect("IncluirConsulta.aspx?cliente=" + idCliente);
            }
        }

        protected void gridConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}