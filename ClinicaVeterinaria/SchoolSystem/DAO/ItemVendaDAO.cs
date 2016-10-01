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
    class ItemVendaDAO
    {
        private Conexao conexaoBD;

        public ItemVendaDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public ItemVenda Get(int idItemVenda)
        {
            ItemVenda itemVenda = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT i.ID, i.idVenda, i.idProduto, i.quantidade, i.valorUn, i.valorTotal " +
                                      "FROM itemVenda i " +
                                      "WHERE i.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idItemVenda;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    itemVenda = new ItemVenda();
                    //Seta os dados resgatados no objeto criado
                    itemVenda.CodigoItem = int.Parse(reader["ID"].ToString());
                    itemVenda.CodigoVenda = int.Parse(reader["idVenda"].ToString());
                    itemVenda.CodigoProduto = int.Parse(reader["idProduto"].ToString());
                    itemVenda.Quantidade = int.Parse(reader["quantidade"].ToString());
                    itemVenda.ValorUn = double.Parse(reader["valorUn"].ToString());
                    itemVenda.ValorTotal = double.Parse(reader["ValorTotal"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }
            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto item preenchido
            return itemVenda;
        }

        public int Insert(ItemVenda item)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO itemVenda(idVenda, idProduto, quantidade, valorUn, ValorTotal) " +
                            "VALUES(@idVenda, @idProduto, @quantidade, @valorUn, @ValorTotal); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idVenda", MySqlDbType.Int16).Value = item.CodigoVenda;
                comando.Parameters.Add("@idProduto", MySqlDbType.Int16).Value = item.CodigoProduto;
                comando.Parameters.Add("@quantidade", MySqlDbType.Int16).Value = item.Quantidade;
                comando.Parameters.Add("@valorUn", MySqlDbType.Double).Value = item.ValorUn;
                comando.Parameters.Add("@ValorTotal", MySqlDbType.Double).Value = item.ValorTotal;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                item.CodigoItem = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do item
            return item.CodigoItem;
        }

        public bool Update(ItemVenda item)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE ItemVenda i SET i.idVenda = @idVenda" +
                ", i.idProduto = @idProduto" +
                ", i.quantidade = @quantidade" +
                ", i.valorUn = @valorUn" +
                ", i.ValorTotal = @ValorTotal" +
                " WHERE i.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idVenda", MySqlDbType.Int16).Value = item.CodigoVenda;
                comando.Parameters.Add("@idProduto", MySqlDbType.Int16).Value = item.CodigoProduto;
                comando.Parameters.Add("@quantidade", MySqlDbType.Int16).Value = item.Quantidade;
                comando.Parameters.Add("@valorUn", MySqlDbType.Double).Value = item.ValorUn;
                comando.Parameters.Add("@ValorTotal", MySqlDbType.Double).Value = item.ValorTotal;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso  
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public bool Delete(int idItemVenda)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM itemVenda i WHERE i.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idItemVenda;

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
