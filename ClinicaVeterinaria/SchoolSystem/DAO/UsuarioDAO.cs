using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TI_ClinicaVeterinaria
{
    class UsuarioDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public UsuarioDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public int Login(string login, string senha)
        {
            int idUsuario = 0;

            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT u.ID " +
                                      "FROM usuario u " +
                                      "WHERE u.login = @login AND u.senha = @senha";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idUsuario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    idUsuario = int.Parse(reader["ID"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            return idUsuario;
        }

        public int GetTipoUser(int idUsuario)
        {
            int tipoUser = 0;

            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT u.tipoUsuario " +
                                      "FROM usuario u " +
                                      "WHERE u.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idUsuario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    tipoUser = int.Parse(reader["tipoUsuario"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            return tipoUser;
        }

        //Resgata os dados do Cliente a partir do ID dele
        public Usuario Get(int idUsuario)
        {
            Usuario usuario = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT u.ID, u.nome, u.login, u.senha, u.email " +
                                      "FROM usuario u " +
                                      "WHERE u.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idUsuario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    usuario = new Usuario();
                    //Seta os dados resgatados no objeto criado
                    usuario.Codigo = int.Parse(reader["ID"].ToString());
                    usuario.Nome = reader["nome"].ToString();
                    usuario.Login = reader["login"].ToString();
                    usuario.Senha = reader["senha"].ToString();
                    usuario.Email = reader["email"].ToString();
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return usuario;
        }


        //Insere um cliente no banco de dados
        public int Insert(Usuario usuario)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO usuario(login, senha, nome, email) " +
                            "VALUES(@login, @senha, @nome, @email); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = usuario.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = usuario.Senha;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = usuario.Nome;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = usuario.Email;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                usuario.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return usuario.Codigo;
        }


        //Atualiza os dados do cliente no banco
        public bool Update(Usuario usuario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE usuario u SET u.nome = @nome" +
                ", u.login = @login" +
                ", u.senha = @senha" +
                ", u.email = @email" +
                " WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = usuario.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = usuario.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Date).Value = usuario.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = usuario.Email;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = usuario.Codigo;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso  
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }


        //Remove um cliente do banco de dados
        public bool Delete(int idUsuario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM usuario u WHERE u.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idUsuario;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }
    }
}
