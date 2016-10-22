using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace TI_ClinicaVeterinaria
{
    public class EstoqueDAO
    {
        private Conexao conexaoBD;
        
        public EstoqueDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;

        }

        public double Get(int idProduto)
        {
             double quantidade  = 0;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT MAX(e.ID), e.quantidadeAtual " +
                                      "FROM estoque e " +
                                      "WHERE e.idProduto = @ID ORDER BY e.ID DESC";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idProduto;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                if (reader.RecordsAffected >= 0)
                {
                    //Para cada registro encontrado
                    while (reader.Read())
                    {
                        quantidade = double.Parse(reader["quantidadeAtual"].ToString());
                    }
                }
                else
                    quantidade = 0;
                
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto produto preenchido
            return quantidade;
        }

        public int Insert(int idProduto, char movimento, double quantidade, double quantidadeAtual)
        {
           
            int idMov = 0;
 
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO estoque(idProduto, movimento, quantidade, quantidadeAtual, data) " +
                            "VALUES(@idProduto, @movimento, @quantidade, @quantidadeAtual,NOW()); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idProduto", MySqlDbType.Int16).Value = idProduto;
                comando.Parameters.Add("@movimento", MySqlDbType.VarChar).Value = movimento;
                comando.Parameters.Add("@quantidade", MySqlDbType.Double).Value = quantidade;
                comando.Parameters.Add("@quantidadeAtual", MySqlDbType.Double).Value = quantidadeAtual;
                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                idMov = int.Parse(comando.ExecuteScalar().ToString());
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do produto
            return idMov;
        }    
    }
}