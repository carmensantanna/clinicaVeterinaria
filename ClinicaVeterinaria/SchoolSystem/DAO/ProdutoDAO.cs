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
    class ProdutoDAO
    {
        private Conexao conexaoBD;
        public ProdutoDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public List<Produto> GetProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            Produto produto = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT p.ID, p.nomeProduto, p.valor, p.estoque " +
                                      "FROM produto p";

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    produto = new Produto();
                    //Seta os dados resgatados no objeto criado
                    produto.Codigo = int.Parse(reader["ID"].ToString());
                    produto.Nome = reader["nome"].ToString();
                    produto.Valor = double.Parse(reader["valor"].ToString());
                    produto.Estoque = double.Parse(reader["estoque"].ToString());

                    //Insere na lista de clientes
                    produtos.Add(produto);
                }
                //Fecha o leitor
                reader.Close();
            }
            return produtos;
        }
        public Produto Get(int idProduto)
        {
            Produto produto = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT p.ID, p.nomeProduto, p.valor, p.estoque " +
                                      "FROM produto p " +
                                      "WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idProduto;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    produto = new Produto();
                    //Seta os dados resgatados no objeto criado
                    produto.Codigo = int.Parse(reader["ID"].ToString());
                    produto.Nome = reader["nomeProduto"].ToString();
                    produto.Valor = double.Parse(reader["valor"].ToString());
                    produto.Estoque = double.Parse(reader["estoque"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto produto preenchido
            return produto;
        }

        public int Insert(Produto produto)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO produto(nome, valor, estoque) " +
                            "VALUES(@nome, @valor, @estoque); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = produto.Nome;
                comando.Parameters.Add("@valor", MySqlDbType.Double).Value = produto.Valor;
                comando.Parameters.Add("@estoque", MySqlDbType.Double).Value = produto.Estoque;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                produto.Codigo = int.Parse(comando.ExecuteScalar().ToString());
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do produto
            return produto.Codigo;
        }

        public bool Update(Produto produto)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE produto p SET p.nomeProduto = @nomeProduto" +
                ", p.valor = @valor" +
                " WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nomeProduto", MySqlDbType.Text).Value = produto.Nome;
                comando.Parameters.Add("@valor", MySqlDbType.Double).Value = produto.Valor;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = produto.Codigo;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso  
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public bool Delete(int idProduto)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM produto p WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idProduto;

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
