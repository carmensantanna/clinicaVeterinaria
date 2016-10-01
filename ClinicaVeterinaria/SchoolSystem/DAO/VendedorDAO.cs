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
    class VendedorDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public VendedorDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }
        //Resgata os dados do Endereço a partir do ID dele
        public Vendedor Get(int idVendedor)
        {
            Vendedor vendedor = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT e.codUsuario, e.codVendedor, e.nome, e.login, e.senha, e.email, e.comissao " +
                            "FROM Vendedor e " +
                            "WHERE e.codVendedor = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVendedor;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    vendedor = new Vendedor();
                    //Seta os dados resgatados no objeto criado
                    vendedor.Codigo = int.Parse(reader["codUsuario"].ToString());
                    vendedor.CodVendedor =int.Parse( reader["CodVendedor"].ToString());
                    vendedor.Nome = reader["nome"].ToString();
                    vendedor.Login = reader["login"].ToString();
                    vendedor.Senha = reader["senha"].ToString();
                    vendedor.Email = reader["email"].ToString();
                    vendedor.Comissao = double.Parse(reader["comissao"].ToString());           
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return vendedor;
        }


        //Insere um endereço no banco de dados
        public int Insert(Vendedor vendedor)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO vendedor(codUsuario, nome, login, senha, email, comissao)" +
                            " VALUES(@codUsuario, @nome, @login, @senha, @email, @comissao); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = vendedor.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = vendedor.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = vendedor.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = vendedor.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = vendedor.Email;
                comando.Parameters.Add("@comissao", MySqlDbType.Double).Value = vendedor.Comissao;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                vendedor.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return vendedor.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Vendedor vendedor)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE vendedor e SET e.codUsuario = @codUsuario, e.nome = @nome, e.login = @login, " +
                            "e.senha = @senha, e.email = @email, e.comissao = @comissao " +
                            "WHERE e.codVenddor = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@codUsuario", MySqlDbType.Int16).Value = vendedor.Codigo;
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = vendedor.Nome;
                comando.Parameters.Add("@login", MySqlDbType.Text).Value = vendedor.Login;
                comando.Parameters.Add("@senha", MySqlDbType.Text).Value = vendedor.Senha;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = vendedor.Email;
                comando.Parameters.Add("@comissao", MySqlDbType.Double).Value = vendedor.Comissao;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = vendedor.CodVendedor;
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
        public bool Delete(int idVendedor)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM endereco e WHERE e.codVendedor = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVendedor;

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
