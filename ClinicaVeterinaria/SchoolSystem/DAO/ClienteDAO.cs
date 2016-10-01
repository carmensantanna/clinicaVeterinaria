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
    class ClienteDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public ClienteDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        //Resgata os dados do Cliente a partir do ID dele
        public Cliente Get(int idCliente)
        {
            Cliente cliente = null;
            Data dtNasc = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT c.ID, c.nome, c.cpf, c.nascimento, c.email, c.telefone, c.celular, c.idEndereco " +
                                      "FROM cliente c " +
                                      "WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idCliente;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    cliente = new Cliente();
                    dtNasc = new Data();
                    //Seta os dados resgatados no objeto criado
                    cliente.Codigo = int.Parse(reader["ID"].ToString());
                    cliente.Nome = reader["nome"].ToString();
                    cliente.CPF = reader["cpf"].ToString();
                    cliente.Nascimento = dtNasc.toBR(reader["nascimento"].ToString());
                    cliente.Email = reader["email"].ToString();
                    cliente.Telefone = reader["telefone"].ToString();
                    cliente.Celular = reader["celular"].ToString();
                    cliente.Endereco.Codigo = int.Parse(reader["idEndereco"].ToString());
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return cliente;
        }

        //Resgata os dados do Cliente a partir do ID dele
        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = null;
            Data dtNasc = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT c.ID, c.nome, c.cpf, c.nascimento, c.email, c.telefone, c.celular, c.idEndereco " +
                                      "FROM cliente c";

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    cliente = new Cliente();
                    dtNasc = new Data();
                    //Seta os dados resgatados no objeto criado
                    cliente.Codigo = int.Parse(reader["ID"].ToString());
                    cliente.Nome = reader["nome"].ToString();
                    cliente.CPF = reader["cpf"].ToString();
                    cliente.Nascimento = dtNasc.toBR(reader["nascimento"].ToString());
                    cliente.Email = reader["email"].ToString();
                    cliente.Telefone = reader["telefone"].ToString();
                    cliente.Celular = reader["celular"].ToString();
                    cliente.Endereco.Codigo = int.Parse(reader["idEndereco"].ToString());

                    //Insere na lista de clientes
                    clientes.Add(cliente);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return clientes;
        }

        //Insere um cliente no banco de dados
        public int Insert(Cliente cliente)
        {

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO cliente(nome, cpf, nascimento, email, telefone, celular, idEndereco) " +
                            "VALUES(@nome, @cpf, @nascimento, @email, @telefone, @celular, @endereco); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = cliente.Nome;
                comando.Parameters.Add("@cpf", MySqlDbType.Text).Value = cliente.CPF;
                comando.Parameters.Add("@nascimento", MySqlDbType.Date).Value = cliente.Nascimento.toUS();
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = cliente.Email;
                comando.Parameters.Add("@telefone", MySqlDbType.Text).Value = cliente.Telefone;
                comando.Parameters.Add("@celular", MySqlDbType.Text).Value = cliente.Celular;
                comando.Parameters.Add("@endereco", MySqlDbType.Text).Value = cliente.Endereco.Codigo;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                cliente.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return cliente.Codigo;
        }


        //Atualiza os dados do cliente no banco
        public bool Update(Cliente cliente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE cliente c SET c.nome = @nome" +
                ", c.cpf = @cpf" +
                ", c.nascimento = @nascimento" +
                ", c.email = @email" +
                ", c.telefone = @telefone" +
                ", c.celular = @celular" +
                " WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = cliente.Nome;
                comando.Parameters.Add("@cpf", MySqlDbType.Text).Value = cliente.CPF;
                comando.Parameters.Add("@nascimento", MySqlDbType.Date).Value = cliente.Nascimento.toUS();
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = cliente.Email;
                comando.Parameters.Add("@telefone", MySqlDbType.Text).Value = cliente.Telefone;
                comando.Parameters.Add("@celular", MySqlDbType.Text).Value = cliente.Celular;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = cliente.Codigo;

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
        public bool Delete(int idCliente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM cliente c WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idCliente;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }
        public Cliente GetPetNome(string nome)
        {
            Cliente cliente = null;
            Data dtNasc = null;
            nome = "";
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT  c.nome, c.idPet, p.nome as nomePet " +
                                      "FROM cliente c " +
                                      "INNER JOIN pet p ON p.idPet = c.ID " +
                                      "WHERE c.nome = @nome";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Int16).Value = nome;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    cliente = new Cliente();
                    dtNasc = new Data();
                    //Seta os dados resgatados no objeto criado
                    cliente.Codigo = int.Parse(reader["ID"].ToString());
                    cliente.Nome = reader["nome"].ToString();
                    cliente.CPF = reader["cpf"].ToString();
                    cliente.Nascimento = dtNasc.toBR(reader["nascimento"].ToString());
                    cliente.Email = reader["email"].ToString();
                    cliente.Telefone = reader["telefone"].ToString();
                    cliente.Celular = reader["celular"].ToString();
                    cliente.Endereco.Codigo = int.Parse(reader["idEndereco"].ToString());

                    //Insere na lista de clientes
                    //cliente.Add(cliente);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return cliente;
        }
    }
}
