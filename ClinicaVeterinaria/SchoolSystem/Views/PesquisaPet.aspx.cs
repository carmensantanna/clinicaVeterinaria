using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class PesquisaPet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var listaPets = new ControleCliente().GetPets();
                if (listaPets != null && listaPets.Count > 0)
                {
                    this.gridPet.DataSource = listaPets;
                    this.gridPet.DataBind();
                }
            }
        }

        protected void gridPet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                string idCliente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idCliente))
                    this.Response.Redirect("EditarPet.aspx?codigo=" + idCliente);
            }
        }

        protected void gridPet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}