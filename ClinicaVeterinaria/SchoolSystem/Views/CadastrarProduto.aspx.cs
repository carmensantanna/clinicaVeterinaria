using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class CadastrarProduto : System.Web.UI.Page
    {
        private Produto produto;
        private ControleProduto controleproduto;
        protected void Page_Load(object sender, EventArgs e)
        {
            //var listaprodutos = controleproduto.GetProduto();
          /*  if (listaprodutos != null && listaprodutos.Count > 0)
            {
                this.gridProdutos.DataSource = listaprodutos;
                this.gridProdutos.DataBind();
            }*/
        }

        protected void bntAdd_Click(object sender, EventArgs e)
        {
            produto = new Produto();
            controleproduto = new ControleProduto();
            produto.Nome = nome_prod.Text.Trim();
            produto.Valor = double.Parse(valor_prod.Text.Trim());
            produto.Estoque = double.Parse(quant_prod.Text.Trim());
            controleproduto.Insert(produto);
        }
        

        protected void gridProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}