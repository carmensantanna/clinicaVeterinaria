using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class MovimentoEstoque : System.Web.UI.Page
    {
        private Produto produto;
        private EstoqueDAO estoqueDAO;
        private ControleProduto controleProduto;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*var list = new ControleProduto().GetProduto();
            if ((list != null) && (list.Count > 0))
            {
                this.gridEstoque.DataSource = list;
                this.gridEstoque.DataBind();
            }*/
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            RegistrarEstoque();
        }

        public void RegistrarEstoque()
        {
            controleProduto = new ControleProduto();
            produto = new Produto();
           // string codigo = idpd_txt.Text.Trim();
            this.produto.Codigo = int.Parse(idpd_txt.Text.Trim());
            var prodt = controleProduto.Get(produto.Codigo);
            double quantidade = double.Parse(qtd_txt.Text.Trim());
            char mov = char.Parse(ddl.SelectedItem.Value);
            controleProduto.movimentoEstoque(mov, prodt, quantidade);
        }

        protected void gridEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}