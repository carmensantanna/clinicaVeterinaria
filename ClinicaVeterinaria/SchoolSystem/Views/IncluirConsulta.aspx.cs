using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class IncluirConsulta : System.Web.UI.Page
    {
        private ControleCliente controleCliente;
        private ControlePet controlePet;
        private ControleConsulta controleConsulta = new ControleConsulta();
        private Pet pet;
        protected void Page_Load(object sender, EventArgs e)
        {
            controleCliente = new ControleCliente();

            if (Request.QueryString["cliente"] != null)
            {
                peqClienteConsulta.Enabled = false;
                this.carregarcliente(Convert.ToInt32(Request.QueryString["cliente"]));

                DropDownPet.DataSource = controleCliente.GetPets();
                DropDownPet.DataTextField = "Nome";
                DropDownPet.DataValueField = "Codigo";
                DropDownPet.DataBind();
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
        protected void pesqCliente_Click(object sender, EventArgs e)
        {

        }
           

        public void cadastrar()
        {
           /* Consulta consulta = new Consulta();
            ControleConsulta controleconsulta = new ControleConsulta();
            DropDownList1.ClearSelection();
            consulta.Veterinario = DropDownList1.SelectedItem.Text.Trim();
            consulta.Horario.Data.toData(DropDownList2.SelectedItem.Text.Trim());*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void carregaVet(object sender, EventArgs e)
        {
            int codVet = int.Parse(selectVet.Text);
            List<Horarios> horarios = controleConsulta.ConsultaAgenda(codVet);
            this.selectVet.DataSource = horarios;
            this.selectVet.DataTextField = "DataTxt";
            this.selectVet.DataValueField = "Codigo";
        }
    }
}