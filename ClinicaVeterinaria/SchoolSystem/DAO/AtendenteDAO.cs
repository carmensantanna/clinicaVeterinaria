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
    class AtendenteDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public AtendenteDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }
        //Resgata os dados do Endereço a partir do ID dele
        public Atendente Get(int idAtendente)
        {
            Atendente atendente= null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT e.codUsuario, e.codAtendente, e.nome, e.login, e.senha, e.email " +
                            "FROM Atendente e " +
                            "WHERE e.codAtendente = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idAtendente;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    atendente = new Atendente();
                    //Seta os dados resgatados no objeto criado
                    atendente.Codigo = int.Parse(reader["codUsuario"].ToString());
                    atendente.CodAtendente = int.Parse(reader["CodVendedor"].ToString());
                    atendente.Nome = reader["nome"].ToString();
                    atendente.Login = reader["login"].ToString();
                    atendente.Senha = reader["senha"].ToString();
                    atendente.Email = reader["email"].ToString();
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return atendente;
        }


        //Insere um endereço no banco de dados
        public int Insert(Atendente atendente)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO atendete(codUsuario, nome, login, senha, email )" +
                            " VALUES(@codUsuario, @nome, @login, @senha, @email ); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = atendente.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = atendente.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = atendente.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = atendente.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = atendente.Email;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                atendente.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return atendente.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Atendente atendente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE atendente e SET e.codUsuario = @codUsuario, e.nome = @nome, e.login = @login, " +
                            "e.senha = @senha, e.email = @email " +
                            "WHERE e.codAtendente = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = atendente.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = atendente.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = atendente.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = atendente.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = atendente.Email;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = atendente.CodAtendente;
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
        public bool Delete(int idAtendente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM endereco e WHERE e.codAtendente = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idAtendente;

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
