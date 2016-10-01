using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Animal
    {
        private int codAnimal;
        private string tipo;
        private string observacao;
        private static int ultimoCod;

        static Animal()
        {
            ultimoCod = 1;
        }

        public Animal()
        {
            Init(0, "", "");
        }

        public Animal(int codAnimal, string tipo, string observacao)
        {
            Init(codAnimal, tipo, observacao);
        }

        public Animal(string tipo, string observacao)
        {
            Init(0, tipo, observacao);
        }

        private void Init(int codAnimal, string tipo, string observacao)
        {
            if (codAnimal == 0)
                this.codAnimal = ultimoCod++;

            this.tipo = tipo;
            this.observacao = observacao;
        }

        public int Codigo
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }
    }
}
