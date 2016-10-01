using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Veterinario:Usuario
    {
        private static int ultimoCod;
        private int codVeterinario;
        private string crmv;
        private List<Horarios> agenda;

        static Veterinario()
        {
            ultimoCod = 1;
        }

        public Veterinario():
            base(0, "", "", "", "")
        {
            Init(0, "", new List<Horarios>());
        }

        public Veterinario(int codUsuario, int codVeterinario, string nome, string login, string senha, string email,
            string crmv):
                base(codUsuario, nome, login, senha, email)
        {
            Init(codVeterinario, crmv, new List<Horarios>());
        }

        public void Init(int codVeterinario, string crmv, List<Horarios> agenda)
        {
            if (codVeterinario == 0)
                codVeterinario = ultimoCod++;

            this.codVeterinario = codVeterinario;
            this.crmv = crmv;
            this.agenda = agenda;
        }
        
        public int CodVeterinario
        {
            get { return codVeterinario; }
            set { codVeterinario = value; }
        }
        
        public string CRMV
        {
            get { return crmv; }
            set { crmv = value; }
        }
        public List<Horarios> Agenda
        {
            get { return agenda; }
            set { agenda = value; }
        }
    }
}
