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
    class VendaDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public VendaDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public Venda Get(int idVenda)
        {
            Venda venda = null;
            Data dtVenda = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT v.ID, v.idVendedor, v.idCliente, v.valorTotal, v.dtVenda" +
                                      "FROM venda v " +
                                      "WHERE v.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVenda;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    venda = new Venda();
                    dtVenda = new Data();
                    //Seta os dados resgatados no objeto criado
                    venda.CodigoVenda = int.Parse(reader["ID"].ToString());
                    venda.CodigoVendedor = int.Parse(reader["idVendedor"].ToString());
                    venda.CodigoCliente = int.Parse(reader["idCliente"].ToString());
                    venda.ValorTotal = double.Parse(reader["valorToral"].ToString());
                    venda.DataVenda = dtVenda.toBR(reader["dtVenda"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }
            //Encerra a conexão no banco de dados
            conexaoBD.fechar();
            //retorna o objeto venda preenchido
            return venda;
        }

        public int Insert(Venda venda)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO venda(idVendedor, idCliente, valorTotal, dtVenda) " +
                            "VALUES(@idVendedor, @idCliente, @valorTotal, @dtVenda); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idVendedor", MySqlDbType.Int16).Value = venda.CodigoVendedor;
                comando.Parameters.Add("@idCliente", MySqlDbType.Int16).Value = venda.CodigoCliente;
                comando.Parameters.Add("@valorTotal", MySqlDbType.Double).Value = venda.ValorTotal;
                comando.Parameters.Add("@dtVenda", MySqlDbType.Date).Value = venda.DataVenda.toUS();

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                venda.CodigoVenda = int.Parse(comando.ExecuteScalar().ToString());
            }
            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado da venda
            return venda.CodigoVenda;
        }

        public bool Update(Venda venda)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE venda v SET v.idVendedor = @idVendedor" +
                ", v.idCliente = @idCliente" +
                ", v.valorTotal = @valorTotal" +
                ", v.dtVenda = @dtVenda" +
                " WHERE v.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idVendedor", MySqlDbType.Int16).Value = venda.CodigoVendedor;
                comando.Parameters.Add("@idCliente", MySqlDbType.Int16).Value = venda.CodigoCliente;
                comando.Parameters.Add("@valorTotal", MySqlDbType.Double).Value = venda.ValorTotal;
                comando.Parameters.Add("@dtVenda", MySqlDbType.Date).Value = venda.DataVenda.toUS();
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = venda.CodigoVenda;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso  
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public bool Delete(int idVenda)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM venda v WHERE v.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idVenda;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }
        public void InsertItem(List<ItemVenda> itens)
        {

        }
    }
}
