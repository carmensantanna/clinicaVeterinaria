using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class ItemVenda
    {
        private int codItem;
        private int codVenda;
        private int codProduto;
        private int quantidade;
        private double valorUn;
        private double valorTotal;
        private static int ultimoCod;

        public ItemVenda()
        {
            ultimoCod = 1;
            Init(0, 0, 0, 0, 0, 0);
        }

        public ItemVenda(int codItem, int codVenda, int codProduto, int quantidade, double valorUn, double valorTotal)
        {
            Init(codItem, codVenda, codProduto, quantidade, valorUn, valorTotal);
        }

        public ItemVenda(int codVenda, int codProduto, int quantidade, double valorUn, double valorTotal)
        {
            Init(0, codVenda, codProduto, quantidade, valorUn, valorTotal);
        }

        private void Init(int codItem, int codVenda, int codProduto, int quantidade, double valorUn, double valorTotal)
        {
            if (codItem == 0)
                this.codItem = ultimoCod++;

            this.codVenda = codVenda;
            this.codProduto = codProduto;
            this.quantidade = quantidade;
            this.valorUn = valorUn;
            this.valorTotal = valorTotal;
        }

        public int CodigoItem
        {
            get { return codItem; }
            set { codItem = value; }
        }

        public int CodigoVenda
        {
            get { return codVenda; }
            set { codVenda = value; }
        }

        public int CodigoProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public double ValorUn
        {
            get { return valorUn; }
            set { valorUn = value; }
        }

        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
    }
}
