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
        private string nomeProduto;
        private double valor;
        private Estoque estoque;
        private static int ultimoCod;

        public Produto()
        {
            ultimoCod = 1;
            Init(0, "", 0);
        }

        public Produto(int codProduto, string nomeProduto, int valor)
        {
            Init(codProduto, nomeProduto, valor);
        }

        private void Init(int codProduto, string nomeProduto, double valor)
        {
            if (codProduto == 0)
                this.codProduto = ultimoCod++;

            this.nomeProduto = nomeProduto;
            this.codProduto = codProduto;
            this.valor = valor;
        }

        public int CodigoProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public Estoque Estoque
        {
            get { return estoque; }
            set { estoque = value; }
        }
    }
}
