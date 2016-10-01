using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Endereco
    {
        private int codEndereco;
        private string logradouro;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;
        private static int ultimoCod;

        static Endereco()
        {
            ultimoCod = 1;
        }

        public Endereco()
        {
            Init(0, "", 0, "", "", "", "", "");
        }

        public Endereco(int codEndereco, string logradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            Init(codEndereco, logradouro, numero, complemento, bairro, cidade, UF, CEP);
        }

        public Endereco(string lougradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            Init(0, logradouro, numero, complemento, bairro, cidade, UF, CEP);
        }

        private void Init(int codEndereco, string logradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            if (codEndereco == 0)
                this.codEndereco = ultimoCod++;

            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cidade = cidade;
            this.uf = UF;
            this.cep = CEP;
        }

        public int Codigo
        {
            get { return codEndereco; }
            set { codEndereco = value; }
        }

        public string Rua
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }

        public string CEP
        {
            get { return cep; }
            set { cep = value; }
        }
    }
}
