using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class EditarPet : System.Web.UI.Page
    {
        private ControleCliente controle;
        private Pet pet;
        private ControlePet controlpet;

        protected void Page_Load(object sender, EventArgs e)
        {
            controle = new ControleCliente();
            pet = new Pet();

            

            if (Request.QueryString["codigo"] != null)
            {
                carregaAnimais();
                this.carregarpet(Convert.ToInt32(Request.QueryString["codigo"]));
            }
                
        }

        private void carregaAnimais()
        {
            listAnimais.DataSource = controle.getAnimais();
            listAnimais.DataTextField = "Tipo";
            listAnimais.DataValueField = "Codigo";
            listAnimais.DataBind();
        }

        private void carregarpet(int idPet)
        {
            pet = controle.GetPet(idPet);

            if (pet != null)
            {
                IDCliente.Text = pet.Cliente.Codigo.ToString();
                NomeCliente.Text = pet.Cliente.Nome;
                id_txt.Text = pet.Codigo.ToString();
                nome_txt.Text = pet.Nome;
                altura_txt.Text = pet.Altura.ToString();
                peso_txt.Text = pet.Peso.ToString();
                listAnimais.SelectedValue = pet.Animal.Codigo.ToString();
            }

        }

        protected void bntAtualizar_Click(object sender, EventArgs e)
        {
            pet = new Pet();
            pet.Codigo = int.Parse(id_txt.Text);
            pet.Nome = nome_txt.Text.Trim();
            pet.Altura = double.Parse(altura_txt.Text);
            pet.Peso = double.Parse(peso_txt.Text);
            pet.Animal.Codigo = int.Parse(listAnimais.SelectedValue);
            controlpet = new ControlePet();
            bool recebe = controlpet.Update(pet);
            if(recebe == true)
            {
                this.Response.Redirect("EditarPet.aspx?codigo=" + pet.Codigo);
            }
            /*if(controle.UpdatePet(pet))
                this.Response.Redirect("EditarPet.aspx?codigo=" + pet.Codigo);*/
        }

        protected void pesqCliente_Click(object sender, EventArgs e)
        {

        }
    }
}