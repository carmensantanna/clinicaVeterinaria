using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace TI_ClinicaVeterinaria
{
    public partial class NovaVenda : System.Web.UI.Page
    {
        ControleProduto ctrlProd = new ControleProduto();

        protected void Page_Load(object sender, EventArgs e)
        {
            data_venda.Text = DateTime.Now.ToShortDateString();
            horario_venda.Text = DateTime.Now.ToShortTimeString();
            vendedor_venda.Text = "vendedor01";
        }

        [WebMethod]
        public static string InserirProduto()
        {
            //int cod = int.Parse(codigo);
            //Produto produto = ctrlProd.Get(cod);

            return "blaa";
        }

        protected void incluirItem_Click(object sender, EventArgs e)
        {

        }
    }
}