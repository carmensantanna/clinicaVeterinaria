using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TI_ClinicaVeterinaria
{
    class HorariosDAO
    {

        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public HorariosDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        //Resgata os dados do Endereço a partir do ID dele
        public Horarios Get(int idHorario)
        {
            Horarios horario = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;
            VeterinarioDAO veterinarioDAO = new VeterinarioDAO(conexaoBD);
            ConsultaDAO consultaDAO = new ConsultaDAO(conexaoBD);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT h.ID, h.idVeterinario, h.data, h.idConsulta " +
                            "FROM horarios h " +
                            "WHERE h.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idHorario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    horario = new Horarios();
                    //Seta os dados resgatados no objeto criado
                    horario.Codigo = reader.GetInt16(0);
                    horario.Veterinario = veterinarioDAO.Get(reader.GetInt16(1));
                    horario.Data = new Data(reader.GetDateTime(2).ToString(), "usTime");
                    horario.Consulta = consultaDAO.Get(reader.GetInt16(3));
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return horario;
        }

        //Resgata a agenda do veterinário
        /*public List<Horarios> GetAgenda(int idVeterinario)
        {
            List<Horarios> agenda = new List<Horarios>();
            Horarios horario = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;
            VeterinarioDAO veterinarioDAO = new VeterinarioDAO(conexaoBD);
            ConsultaDAO consultaDAO = new ConsultaDAO(conexaoBD);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT h.ID, h.idVeterinario, h.data, h.idConsulta " +
                            "FROM horarios h " +
                            "WHERE h.idVeterinario = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVeterinario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    horario = new Horarios();
                    //Seta os dados resgatados no objeto criado
                    horario.Codigo = reader.GetInt16(0);
                    horario.Veterinario = veterinarioDAO.Get(reader.GetInt16(1));
                    horario.Data = new Data(reader.GetDateTime(2).ToString(), "usTime");
                    horario.Consulta = consultaDAO.Get(reader.GetInt16(3));

                    agenda.Add(horario);
                }
                //Fecha o leitor
                reader.Close();
            }
        }*/

        //Resgata a agenda do veterinário
        public List<Horarios> GetDisponibilidade(int idVeterinario)
        {
            List<Horarios> agenda = new List<Horarios>();
            Horarios horario = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;
            VeterinarioDAO veterinarioDAO = new VeterinarioDAO(conexaoBD);
            ConsultaDAO consultaDAO = new ConsultaDAO(conexaoBD);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT h.ID, h.idVeterinario, h.data " +
                            "FROM horarios h " +
                            "WHERE h.idVeterinario = @ID AND h.idConsulta = 0";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVeterinario;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    horario = new Horarios();
                    //Seta os dados resgatados no objeto criado
                    horario.Codigo = reader.GetInt16(0);
                    horario.Veterinario = veterinarioDAO.Get(reader.GetInt16(1));
                    horario.Data = new Data(reader.GetDateTime(2).ToString(), "usTime");
                    horario.Consulta = null;

                    agenda.Add(horario);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return agenda;
        }

        //Verifica se uma data está disponível para agendar consulta
        public List<Horarios> verificaHorarios(int idVeterinario, Data data)
        {
            List<Horarios> agenda = new List<Horarios>();
            Horarios horario = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;
            VeterinarioDAO veterinarioDAO = new VeterinarioDAO(conexaoBD);
            ConsultaDAO consultaDAO = new ConsultaDAO(conexaoBD);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT h.ID, h.idVeterinario, h.data, h.idConsulta " +
                            "FROM horarios h " +
                            "WHERE DATE(h.data) = @data AND h.idConsulta = 0";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@data", MySqlDbType.Int16).Value = data.toUS();

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    horario = new Horarios();
                    //Seta os dados resgatados no objeto criado
                    horario.Codigo = reader.GetInt16(0);
                    horario.Veterinario = veterinarioDAO.Get(reader.GetInt16(1));
                    horario.Data = new Data(reader.GetDateTime(2).ToString(), "usTime");
                    horario.Consulta = consultaDAO.Get(reader.GetInt16(3));

                    agenda.Add(horario);
                }
                //Fecha o leitor
                reader.Close();
            }

            conexaoBD.fechar();

            return agenda;
        }


        //Insere um endereço no banco de dados
        public int Insert(Horarios horario)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO horarios(idVeterinario, data)" +
                            " VALUES(@idVeterinario, @data); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idVeterinario", MySqlDbType.Int16).Value = horario.Veterinario.Codigo;
                comando.Parameters.Add("@data", MySqlDbType.DateTime).Value = horario.Data.toUS();
                comando.Parameters.Add("@idConsulta", MySqlDbType.Int16).Value = horario.Consulta.Codigo;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                horario.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return horario.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Horarios horario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE horarios h SET h.data = @data " +
                            "WHERE h.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.DateTime).Value = horario.Data.toUS();
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = horario.Codigo;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso 
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }


        //Remove um endereço do banco de dados
        public bool Delete(int idHorario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM horarios h WHERE h.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idHorario;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        //---------------------------------------------------------------------- Manipulação de consultas

        public bool InsertConsulta(int idHorario, Consulta consulta)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE horarios h SET h.idConsulta = @idConsulta " +
                            "WHERE h.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idConsulta", MySqlDbType.Int16).Value = consulta.Codigo;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idHorario;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso 
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public bool RemoveConsulta(int idHorario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE horarios h SET h.idConsulta = 0 " +
                            "WHERE h.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idHorario;

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