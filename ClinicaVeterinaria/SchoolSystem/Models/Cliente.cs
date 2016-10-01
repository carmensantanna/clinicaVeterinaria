using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Cliente
    {
        private int codCliente;
        private string nome;
        private string cpf;
        private Data dtNascimento;
        private string email;
        private string telefone;
        private string celular;
        private Endereco endereco;
        private static int ultimoCod;
        //private List<Pet> pets;

        static Cliente()
        {
            ultimoCod = 1;
        }

        public Cliente()
        {
            Init(0, "", "", new Data(), "", "", "", new Endereco());
        }

        public Cliente(int codCliente, string nome, string CPF, Data dtNascimento, string email, string telefone,
            string celular, Endereco endereco)
        {
            Init(codCliente, nome, CPF, dtNascimento, email, telefone, celular, endereco);
        }

        public Cliente(string nome, string CPF, Data dtNascimento, string email, string telefone,
            string celular, Endereco endereco)
        {
            Init(0, nome, CPF, dtNascimento, email, telefone, celular, endereco);
        }

        private void Init(int codCliente, string nome, string CPF, Data dtNascimento, string email, string telefone,
            string celular, Endereco endereco)
        {
            if (codCliente == 0)
                this.codCliente = ultimoCod++;

            this.nome = nome;
            this.cpf = CPF;
            this.dtNascimento = dtNascimento;
            this.email = email;
            this.telefone = telefone;
            this.celular = celular;
            this.endereco = endereco;
            //this.pets = pets;
        }

        public int Codigo
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public Data Nascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

       /* public List<Pet> Pets
        {
            get { return pets; }
            set { pets = value; }
        }*/
    }
}
