using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{ 

    class ControleHorarios
    {
        HorariosDAO horariosDAO;

        public ControleHorarios()
        {
            horariosDAO = new HorariosDAO(new Conexao());
        }

        public Horarios Get(int idHorarios)
        {
            return horariosDAO.Get(idHorarios);
        }

        public void Insert(Horarios horarios)
        {

        }

    }
}
