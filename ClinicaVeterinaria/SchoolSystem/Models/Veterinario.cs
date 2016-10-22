using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Veterinario
    {
        private static int ultimoCod;
        private int codVeterinario;
        private string crmv;
        private string nome;
        private string email;
        //private List<Horarios> agenda;

        static Veterinario()
        {
            ultimoCod = 1;
        }

        public Veterinario()
        {
            Init(0, "", "", "");
        }

        public Veterinario(int codVeterinario, string nome, string email, string crmv)
        {
            Init(codVeterinario, nome, email, crmv);
        }

        public void Init(int codVeterinario, string nome, string email, string crmv)
        {
            if (codVeterinario == 0)
                codVeterinario = ultimoCod++;

            this.codVeterinario = codVeterinario;
            this.crmv = crmv;
            this.nome = nome;
            this.email = email;
            //this.agenda = agenda;
        }

        public int Codigo
        {
            get { return codVeterinario; }
            set { codVeterinario = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        public string CRMV
        {
            get { return crmv; }
            set { crmv = value; }
        }

        
        /*public List<Horarios> Agenda
        {
            get { return agenda; }
            set { agenda = value; }
        }*/
    }
}
