using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Pet
    {
        private int codPet;
        private string nome;
        private double peso;
        private double altura;
        private Animal animal;
        private Cliente cliente;
        private static int ultimoCod;

        static Pet()
        {
            ultimoCod = 1;
        }

        public Pet()
        {
            Init(0, "", 0, 0, new Animal(), new Cliente());
        }

        public Pet(int codPet, string nome, double peso, double altura, Animal animal, Cliente cliente)
        {
            Init(codPet, nome, peso, altura, animal, cliente);
        }

        public Pet(string nome, double peso, double altura, Animal animal, Cliente cliente)
        {
            Init(0, nome, peso, altura, animal, cliente);
        }

        private void Init(int codPet, string nome, double peso, double altura, Animal animal, Cliente cliente)
        {
            if (codPet == 0)
                this.codPet = ultimoCod++;

            this.nome = nome;
            this.peso = peso;
            this.altura = altura;
            this.animal = animal;
            this.cliente = cliente;
        }

        public int Codigo
        {
            get { return codPet; }
            set { codPet = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
    }
}
