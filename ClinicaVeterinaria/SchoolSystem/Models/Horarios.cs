using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class Horarios
    {
        private int codHorario;
        private Data data;
        private Veterinario veterinario;
        private Consulta consulta;
        private static int ultimoCod;

        public Horarios()
        {
            ultimoCod = 1;
            Init(0,new Data(), new Veterinario(), new Consulta());
        }
        public Horarios(int codigo,Data data, Veterinario veterinario, Consulta consulta)
        {
            Init(codigo, data, veterinario, consulta);
        }
        public void Init(int codigo, Data data, Veterinario veterinario, Consulta consulta)
        {
            if (codigo == 0)
                codigo = ultimoCod++;

            this.codHorario = codigo;
            this.data = data;
            this.veterinario = veterinario;
            this.consulta = consulta;
        }

        public int Codigo
        {
            get { return codHorario; }
            set { codHorario = value; }
        }

        public Data Data
        {
            get { return data; }
            set { data = value; }
        }
        public Veterinario Veterinario
        {
            get { return veterinario; }
            set { veterinario = value; }
        }
        public Consulta Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }
    }
}
