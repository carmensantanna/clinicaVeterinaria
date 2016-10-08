using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TI_ClinicaVeterinaria
{
    public class Estoque
    {
        private int codEstoque;
        private float quantidade;
        static int ultimocod;

        public void Init(int codEstoque,float quantidade)
        {
            if (codEstoque == 0)
                ultimocod++;
            this.codEstoque = codEstoque;
            this.quantidade = quantidade;
        }
        public Estoque()
        {
            Init(0, 0.00f);
        }
        public Estoque(int codEstoque, float quantoidade)
        {
            Init(codEstoque, quantidade);
        }
        public int Codigo { get { return codEstoque; } set { codEstoque = value; } }
        public float Quantidade { get { return quantidade; } set { quantidade = value; } }
    }
}