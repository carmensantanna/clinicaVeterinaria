using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Usuario
    {
        private int codUsuario;
        protected string nome;
        protected string login;
        protected string senha;
        protected string email;
        private static int ultimoCod;

        static Usuario()
        {
            ultimoCod = 1;
        }

        public Usuario() {
            Init(0, "", "", "", "");
        }

        public Usuario(int codUsuario,string nome,string login,string senha,string email)
        {
            Init(codUsuario, nome, login, senha, email);
        }

        private void Init(int codUsuario, string nome, string login, string senha, string email)
        {
            if (codUsuario == 0)
                codUsuario = ultimoCod++;

            this.codUsuario = codUsuario;
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.email = email;
        }

        public int Codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
