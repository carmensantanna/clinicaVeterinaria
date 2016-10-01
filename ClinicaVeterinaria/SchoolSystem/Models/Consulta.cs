using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Consulta
    {
        private int codConsulta;
        private Cliente cliente;
        private Pet pet;
        private string veterinario;
        private Horarios horarioConsulta;
        private string receita;
        private string prontuario;
        private static int ultimoCod;

        static Consulta()
        {
            ultimoCod = 1;
        }

        public Consulta()
        {
            Init(0, new Cliente(), new Pet(), new Horarios(), "", "", "");
        }

        public Consulta(int codConsulta, Cliente cliente, Pet pet, Horarios horario, string receita, string prontuarios,string vetrinario)
        {
            Init(codConsulta, cliente, pet, horario, receita, prontuario,veterinario);
        }

        public Consulta(Cliente cliente, Pet pet, Horarios horario, string receita, string prontuario,string vetrinario)
        {
            Init(0, cliente, pet, horario, receita, prontuario,vetrinario);
        }

        private void Init(int codConsulta, Cliente cliente, Pet pet, Horarios horario, string receita, string prontuario,string veterinario)
        {
            if (codConsulta == 0)
                codConsulta = ultimoCod++;

            this.codConsulta = codConsulta;
            this.cliente = cliente;
            this.pet = pet;
            this.horarioConsulta = horario;
            this.receita = receita;
            this.prontuario = prontuario;
            this.veterinario = veterinario;
        }

        public int Codigo
        {
            get { return codConsulta; }
            set { codConsulta = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Pet Pet
        {
            get { return pet; }
            set { pet = value; }
        }

        public Horarios Horario
        {
            get { return horarioConsulta; }
            set { horarioConsulta = value; }
        }

        public string Receita
        {
            get { return receita; }
            set { receita = value; }
        }

        public string Prontuario
        {
            get { return prontuario; }
            set { prontuario = value; }
        }
        public string Veterinario
        {
            get { return veterinario; }
            set { veterinario = value; }
        }
    }
}
