using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class NovaVenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            data_venda.Text = DateTime.Now.ToShortDateString();
            horario_venda.Text = DateTime.Now.ToShortTimeString();
            vendedor_venda.Text = "vendedor01";
        }

        protected void incluirItem_Click(object sender, EventArgs e)
        {

        }
    }
}