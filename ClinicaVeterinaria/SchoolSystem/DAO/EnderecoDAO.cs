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
    class EnderecoDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public EnderecoDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        //Resgata os dados do Endereço a partir do ID dele
        public Endereco Get(int idEndereco)
        {
            Endereco endereco = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT e.ID, e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, e.cep " +
                            "FROM endereco e " +
                            "WHERE e.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idEndereco;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    endereco = new Endereco();
                    //Seta os dados resgatados no objeto criado
                    endereco.Codigo = int.Parse(reader["ID"].ToString());
                    endereco.Rua = reader["logradouro"].ToString();
                    endereco.Numero = int.Parse(reader["numero"].ToString());
                    endereco.Complemento = reader["complemento"].ToString();
                    endereco.Bairro = reader["bairro"].ToString();
                    endereco.Cidade = reader["cidade"].ToString();
                    endereco.UF = reader["uf"].ToString();
                    endereco.CEP = reader["cep"].ToString();
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return endereco;
        }


        //Insere um endereço no banco de dados
        public int Insert(Endereco endereco)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO endereco(logradouro, numero, complemento, bairro, cidade, uf, cep)" +
                            " VALUES(@logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@logradouro", MySqlDbType.Text).Value = endereco.Rua;
                comando.Parameters.Add("@numero", MySqlDbType.Int16).Value = endereco.Numero;
                comando.Parameters.Add("@complemento", MySqlDbType.Text).Value = endereco.Complemento;
                comando.Parameters.Add("@bairro", MySqlDbType.Text).Value = endereco.Bairro;
                comando.Parameters.Add("@cidade", MySqlDbType.Text).Value = endereco.Cidade;
                comando.Parameters.Add("@uf", MySqlDbType.Text).Value = endereco.UF;
                comando.Parameters.Add("@cep", MySqlDbType.Text).Value = endereco.CEP;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                endereco.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return endereco.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Endereco endereco)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE endereco e SET e.logradouro = @logradouro, e.numero = @numero, e.complemento = @complemento, " +
                            "e.bairro = @bairro, e.cidade = @cidade, e.uf = @uf, e.cep = @cep " +
                            "WHERE e.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@logradouro", MySqlDbType.Text).Value = endereco.Rua;
                comando.Parameters.Add("@numero", MySqlDbType.Int16).Value = endereco.Numero;
                comando.Parameters.Add("@complemento", MySqlDbType.Text).Value = endereco.Complemento;
                comando.Parameters.Add("@bairro", MySqlDbType.Text).Value = endereco.Bairro;
                comando.Parameters.Add("@cidade", MySqlDbType.Text).Value = endereco.Cidade;
                comando.Parameters.Add("@uf", MySqlDbType.Text).Value = endereco.UF;
                comando.Parameters.Add("@cep", MySqlDbType.Text).Value = endereco.CEP;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = endereco.Codigo;

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
        public bool Delete(int idEndereco)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM endereco e WHERE e.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idEndereco;

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
