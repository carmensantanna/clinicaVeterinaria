using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class IncluirPet : System.Web.UI.Page
    {

        private ControleCliente controleCliente;
        private Pet pet;

        protected void Page_Load(object sender, EventArgs e)
        {
            controleCliente = new ControleCliente();

            if (Request.QueryString["cliente"] != null)
            {
                pesqCliente.Enabled = false;
                this.carregarcliente(Convert.ToInt32(Request.QueryString["cliente"]));

                listAnimais.DataSource = getAnimais();
                listAnimais.DataTextField = "Tipo";
                listAnimais.DataValueField = "Codigo";
                listAnimais.DataBind();
            }
        }

        private void carregarcliente(int IdCliente)
        {
            Cliente cliente = controleCliente.Get(IdCliente);
            if (cliente != null)
            {
                //this.txtProduto.Text = dadosProduto.ProductName;
                this.IDCliente.Text = cliente.Codigo.ToString();
                this.NomeCliente.Text = cliente.Nome;
            }
        }

        private List<Animal> getAnimais()
        {
            return controleCliente.getAnimais();
        }

        protected void bntAdd_Click(object sender, EventArgs e)
        {
            pet = new Pet();
            pet.Nome = nome_txt.Text.Trim();
            pet.Altura = double.Parse(altura_txt.Text.Trim());
            pet.Peso = double.Parse(peso_txt.Text.Trim());
            pet.Animal.Codigo = int.Parse(listAnimais.SelectedValue);
            pet.Cliente.Codigo = int.Parse(IDCliente.Text.Trim());

            if(controleCliente.InsertPet(pet) > 0)
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Pet cadastrado com sucesso!')", true);
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não foi possível cadastrar esse Pet!')", true);
        }

        protected void pesqCliente_Click(object sender, EventArgs e)
        {

        }
    }
}