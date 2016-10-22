using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class ControleConsulta
    {
        private ConsultaDAO consultaDAO;
        private HorariosDAO horariosDAO;

        public ControleConsulta()
        {
            consultaDAO = new ConsultaDAO(new Conexao());
            horariosDAO = new HorariosDAO(new Conexao());
        }

        public List<Horarios> ConsultaAgenda(int idVeterinario)
        {
            return horariosDAO.GetDisponibilidade(idVeterinario);
        }

        public List<Consulta> ConsultaVeterinario(int idVeterinario)
        {
            return consultaDAO.GetVeterinatio(idVeterinario);
        }

        public void marcarConsulta(Consulta consulta)
        {
            consultaDAO.Insert(consulta);
            horariosDAO.InsertConsulta(consulta.Horario.Codigo, consulta);
        }

        public Consulta Get(int idConsulta)
        {
            return consultaDAO.Get(idConsulta);
        }

    }
}
