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
        private PetDAO petDAO;
        private ClienteDAO clienteDAO;
        private VeterinarioDAO veterinarioDAO;

        public ControleConsulta()
        {
            consultaDAO = new ConsultaDAO(new Conexao());
            horariosDAO = new HorariosDAO(new Conexao());
            petDAO = new PetDAO(new Conexao());
            clienteDAO = new ClienteDAO(new Conexao());
            veterinarioDAO = new VeterinarioDAO(new Conexao());
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
            Consulta consulta = consultaDAO.Get(idConsulta);
            consulta.Horario = horariosDAO.Get(consulta.Horario.Codigo);
            //consulta.Horario.Consulta = consulta;
            consulta.Horario.Veterinario = veterinarioDAO.Get(consulta.Horario.Veterinario.Codigo);
            consulta.Cliente = clienteDAO.Get(consulta.Cliente.Codigo);
            consulta.Pet = petDAO.Get(consulta.Pet.Codigo);

            return consulta;
        }

    }
}
