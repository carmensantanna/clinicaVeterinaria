using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntAdd_Click(object sender, EventArgs e)
        {
            Cadastrar();
            limpar();
        }

        protected void bntAtualizar_Click(object sender, EventArgs e)
        {
            /*Atualizar();
            limpar();   
            */
        }
        private void limpar()
        {
            nome_txt.Text = "";
            cpf_txt.Text = "";
            email_txt.Text = "";
            tel_txt.Text = "";
            cel_txt.Text = "";
            dtnasc_txt.Text = "";
            log_txt.Text = "";
            comp_txt.Text = "";
            cidade_txt.Text = "";
            num_txt.Text = "";
            uf_txt.Text = "";
            cep_txt.Text = "";
        }
        
         private void Cadastrar()
         {
            TI_ClinicaVeterinaria.Cliente c = new TI_ClinicaVeterinaria.Cliente();
             ControleCliente cc = new ControleCliente();
             c.Nome = nome_txt.Text.Trim();
             c.CPF = cpf_txt.Text.Trim();
             c.Email = email_txt.Text.Trim();
             c.Telefone = tel_txt.Text.Trim();
             c.Celular = cel_txt.Text.Trim();
             string dtnsc = dtnasc_txt.Text.Trim();
             c.Nascimento.toData(dtnsc);
             c.Endereco.Rua = log_txt.Text.Trim();
             c.Endereco.Complemento = comp_txt.Text.Trim();
             c.Endereco.Bairro = bairro_txt.Text.Trim();
             c.Endereco.Cidade = cidade_txt.Text.Trim();
             c.Endereco.Numero = int.Parse(num_txt.Text.Trim());
             c.Endereco.UF = uf_txt.Text.Trim();
             c.Endereco.CEP = cep_txt.Text.Trim();
             cc.Insert(c);
            
         }

        protected void dtnasc_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}