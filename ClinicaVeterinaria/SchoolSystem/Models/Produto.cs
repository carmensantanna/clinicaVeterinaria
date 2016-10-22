using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Produto
    {
        private int codProduto;
        private string nome;
        private double valor;
        private double estoque;
        private static int ultimoCod;

        public Produto()
        {
            ultimoCod = 1;
            Init(0, "", 0);
        }

        public Produto(int codProduto, string nome, int valor)
        {
            Init(codProduto, nome, valor);
        }

        private void Init(int codProduto, string nome, double valor)
        {
            if (codProduto == 0)
                this.codProduto = ultimoCod++;

            this.nome = nome;
            this.codProduto = codProduto;
            this.valor = valor;
        }

        public int Codigo
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public double Estoque
        {
            get { return estoque; }
            set {
                if (value >= 0)
                    estoque = value;
                else
                    estoque = 0;
                }
        }

        public string ValorReal
        {
            get
            {
                return "R$ " + valor.ToString();
            }
        }
    }
}
