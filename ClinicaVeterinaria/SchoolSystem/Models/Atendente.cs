using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Atendente:Usuario
    {
        private int codAtendente;
        private static int ultimoCod;

        static Atendente()
        {
            ultimoCod = 1;
        }

        public Atendente():
            base(0,"","","","")
        {
            Init(0);
        }

        public Atendente(int codUsuario,int codAtendente,string nome, string login, string senha, string email):
            base(codUsuario,nome,login,senha,email)
        {
            Init(codAtendente);
        }

        public void Init(int codAtendente)
        {
            if (codAtendente == 0)
                codAtendente = ultimoCod++;

            this.codAtendente = codAtendente;
        }

        public int CodAtendente
        {
            get { return codAtendente; }
            set { codAtendente = value; }
        }

    }
}
