using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Venda
    {
        private int codVenda;
        private int codVendedor;
        private int codCliente;
        private double valorTotal;
        private Data dataVenda;
        private static int ultimoCod;

        public Venda()
        {
            ultimoCod = 1;
            Init(0, 0, 0, 0, new Data());
        }

        public Venda(int codVenda, int codVendedor, int codCliente, double valorTotal, Data dataVenda)
        {
            Init(codVenda, codVendedor, codCliente, valorTotal, dataVenda);
        }

        private void Init(int codVenda, int codVendedor, int codCliente, double valorTotal, Data dataVenda)
        {
            if (codVenda == 0)
                this.codVenda = ultimoCod++;

            this.codVendedor = codVendedor;
            this.codCliente = codCliente;
            this.valorTotal = valorTotal;
            this.dataVenda = dataVenda;
        }

        public int CodigoVenda
        {
            get { return codVenda; }
            set { codVenda = value; }
        }

        public int CodigoVendedor
        {
            get { return codVendedor; }
            set { codVendedor = value; }
        }

        public int CodigoCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
        public Data DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }
    }
}
