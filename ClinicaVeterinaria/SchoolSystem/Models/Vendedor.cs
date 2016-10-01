using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Vendedor:Usuario
    {
        private int codVendedor;
        private double comissao;
        private static int ultimoCod;

        static Vendedor()
        {
            ultimoCod = 1;
        }
        public Vendedor():
            base(0, "", "", "", "")
        {
            Init(0, 0.00);
        }

        public Vendedor(int codUsuario,int codVendedor, string nome,string login, string senha, string email,double comissao):
            base(codUsuario,nome,login,senha,email)
        {
            Init(codVendedor, comissao);
        }

        private void Init(int codVendedor, double comissao)
        {
            if (codVendedor == 0)
                codVendedor = ultimoCod++;

            this.codVendedor = codVendedor;
            this.comissao = comissao;
        }
        
        public int CodVendedor
        {
            get { return codVendedor; }
            set { codVendedor = value; }
        }

        public double Comissao
        {
            get { return comissao; }
            set { comissao = value; }
        }
    }
}
