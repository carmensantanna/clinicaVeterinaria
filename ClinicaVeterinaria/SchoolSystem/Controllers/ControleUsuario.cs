using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class ControleUsuario
    {
        private UsuarioDAO usuarioDAO;
        private VeterinarioDAO veterinarioDAO;
        private VendedorDAO vendedorDAO;
        private AtendenteDAO atendenteDAO;

        public ControleUsuario()
        {
            this.usuarioDAO = new UsuarioDAO(new Conexao());
            this.veterinarioDAO = new VeterinarioDAO(new Conexao());
            this.vendedorDAO = new VendedorDAO(new Conexao());
        }

        public Usuario realizarLogin(string login, string senha)
        {
            Usuario usuario = null;
            int idUser = usuarioDAO.Login(login, senha);

            if (idUser != 0)
            {
                usuario = usuarioDAO.Get(idUser);
            }

            return usuario;
        }


    }
}
