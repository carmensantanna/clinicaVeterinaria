using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI_ClinicaVeterinaria
{
    public partial class Consultar : System.Web.UI.Page
    {
        ControleConsulta ctrlConsulta = new ControleConsulta();
        Consulta consulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["codigo"] != null)
                this.carregarConsulta(Convert.ToInt32(Request.QueryString["codigo"]));
        }

        private void carregarConsulta(int idConsulta)
        {
            consulta = ctrlConsulta.Get(idConsulta);

            this.idConsulta_txt.Text = consulta.Codigo.ToString();
            this.dtConsulta_txt.Text = consulta.Horario.Data.DataTxt;
            this.horaConsulta_txt.Text = consulta.Horario.Data.HoraMin;
            this.pet_txt.Text = consulta.Pet.Nome;
            this.pesoPet_txt.Text = consulta.Pet.Peso.ToString();
            this.altPet_txt.Text = consulta.Pet.Altura.ToString();
            this.cliente_txt.Text = consulta.Cliente.Nome;
            this.diagnostico_txt.Text = consulta.Prontuario;
            this.receita_txt.Text = consulta.Receita;
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
        }
    }
}