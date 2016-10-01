using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace TI_ClinicaVeterinaria
{
    class VeterinarioDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public VeterinarioDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }
        //Resgata os dados do Endereço a partir do ID dele
        public Veterinario Get(int idUser)
        {
            Veterinario veterinario = new Veterinario();
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT u.ID, u.nome, u.login, u.senha, u. email, v.crmv, v.ID " +
                            "FROM usuario u INNER JOIN veterinario v ON u.ID = v.idUsuario " +
                            "WHERE u.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idUser;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    veterinario = new Veterinario();
                    //Seta os dados resgatados no objeto criado
                    veterinario.Codigo = reader.GetInt16(0);
                    veterinario.Nome = reader.GetString(1);
                    veterinario.Login = reader.GetString(2);
                    veterinario.Senha = reader.GetString(3);
                    veterinario.Email = reader.GetString(4);
                    veterinario.CRMV = reader.GetString(5);
                    veterinario.CodVeterinario = reader.GetInt16(6);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return veterinario;
        }


        //Insere um endereço no banco de dados
        public int Insert(Veterinario veterinario)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO veterinario(codUsuario, nome, login, senha, email,crmv,codAgenda )" +
                            " VALUES(@codUsuario, @nome, @login, @senha, @email,@crmv,@codAgenda ); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = veterinario.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = veterinario.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = veterinario.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = veterinario.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = veterinario.Email;
                comando.Parameters.Add("@crmv", MySqlDbType.Text).Value = veterinario.CRMV;
                //comando.Parameters.Add("@codAgenda", MySqlDbType.Text).Value = veterinario.CodAgenda;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                veterinario.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return veterinario.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Veterinario veterinario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE veterinario e SET e.codUsuario = @codUsuario, e.nome = @nome, e.login = @login, " +
                            "e.senha = @senha, e.email = @email, e.crmv = @crmv, e.codAgenda =@ codAgenda " +
                            "WHERE e.codVeterinario = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = veterinario.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = veterinario.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = veterinario.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = veterinario.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = veterinario.Email;
                comando.Parameters.Add("@crmv", MySqlDbType.Text).Value = veterinario.CRMV;
               // comando.Parameters.Add("@codAgenda", MySqlDbType.Int16).Value = veterinario.CodAgenda;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = veterinario.CodVeterinario;
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
        public bool Delete(int idVeterinario)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM endereco e WHERE e.codVeterinario = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVeterinario;

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
