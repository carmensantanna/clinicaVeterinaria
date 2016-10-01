using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class EditarClientes : System.Web.UI.Page
    {
        private Cliente c = new Cliente();
        private ControleCliente cc = new ControleCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!Page.IsPostBack)
            //{
            c = new Cliente();
            cc = new ControleCliente();
                if (Request.QueryString["codigo"] != null)                  
                    this.carregarcliente(Convert.ToInt32(Request.QueryString["codigo"]));
                    
            //}
        }
        private void carregarcliente(int IdCliente)
        {
            
            //var dadosclientes = new ControleCliente().Get(IdCliente);
            c = cc.Get(IdCliente);
            if (c != null)
            {
                //this.txtProduto.Text = dadosProduto.ProductName;
                this.id_txt.Text = c.Codigo.ToString();
                this.nome_txt.Text = c.Nome;
                this.cpf_txt.Text = c.CPF;
                this.email_txt.Text = c.Email;
                this.dtnasc_txt.Text = c.Nascimento.ToString();
                this.tel_txt.Text = c.Telefone;
                this.cel_txt.Text = c.Celular;
                this.log_txt.Text = c.Endereco.Rua;
                this.num_txt.Text = c.Endereco.Numero.ToString();
                this.comp_txt.Text = c.Endereco.Complemento;
                this.bairro_txt.Text = c.Endereco.Bairro;
                this.cidade_txt.Text = c.Endereco.Cidade;
                this.uf_txt.Text = c.Endereco.UF;
                this.cep_txt.Text = c.Endereco.CEP;
            }
        }


        protected void bntAtualizar_Click1(object sender, EventArgs e)
        {
            Atualizar();
        }
        private void Atualizar()
        {
            c = new Cliente();
            c.Codigo = int.Parse(id_txt.Text.Trim());
            c.Nome = nome_txt.Text.Trim();
            c.CPF = cpf_txt.Text.Trim();
            c.Email = email_txt.Text.Trim();
            c.Telefone = tel_txt.Text.Trim();
            c.Celular = cel_txt.Text.Trim();
            string dtnsc = dtnasc_txt.Text.Trim();
            c.Nascimento.toData(dtnsc);
            c.Endereco.Rua = log_txt.Text.Trim();
            c.Endereco.Complemento = comp_txt.Text.Trim();
            c.Endereco.Cidade = cidade_txt.Text.Trim();
            c.Endereco.Bairro = bairro_txt.Text.Trim();
            c.Endereco.Numero = int.Parse(num_txt.Text.Trim());
            c.Endereco.UF = uf_txt.Text.Trim();
            c.Endereco.CEP = cep_txt.Text.Trim();

            cc = new ControleCliente();
            bool retorno = cc.Update(c);
            if(retorno == true)
            {
                this.Response.Redirect("EditarClientes.aspx?codigo=" + c.Codigo);
            }
            //else
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente não atualizado!')", true);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_value"];
            //int codigo = int.Parse(Request.Form["id_txt"]);

            string confirmValue = confirm_value.Value;
            int codigo = int.Parse(id_txt.Text.Trim());

            if (confirmValue == "Sim")
            {
                if (cc.Delete(codigo))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente excluido com sucesso!')", true);
                }
                else
                    this.Response.Redirect("Clientes.aspx");
            }
            else
            {
                this.Response.Redirect("EditarClientes.aspx?codigo=" + c.Codigo);
            }
        }
    }
}