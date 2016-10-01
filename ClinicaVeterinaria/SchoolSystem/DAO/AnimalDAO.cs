using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TI_ClinicaVeterinaria
{
    public class AnimalDAO
    {
        private Conexao conexaoBD;
        
        //Construtor recebe a conexão do banco de dados
        public AnimalDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        //Resgata os dados do Animal a partir do ID dele
        public Animal Get(int idAnimal)
        {
            Animal animal = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT a.ID, a.tipo, a.observacao " +
                                      "FROM animal a " +
                                       "WHERE a.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idAnimal;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    animal = new Animal();
                    //Seta os dados resgatados no objeto criado
                    animal.Codigo = int.Parse(reader["ID"].ToString());
                    animal.Tipo = reader["tipo"].ToString();
                    animal.Observacao = reader["observacao"].ToString();
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return animal;
        }


        //Insere um animal no banco de dados
        public int Insert(Animal animal)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO animal(tipo, observacao) " +
                            "VALUES(@tipo, @raca, @observacao); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@tipo", MySqlDbType.Text).Value = animal.Tipo;
                comando.Parameters.Add("@observacao", MySqlDbType.Text).Value = animal.Observacao;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                animal.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return animal.Codigo;
        }

        //Atualiza os dados do animal no banco
        public bool Update(Animal animal)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE animal a SET a.tipo = @tipo, a.observacao = @observacao " +
                            "WHERE a.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@tipo", MySqlDbType.Text).Value = animal.Tipo;
                comando.Parameters.Add("@observacao", MySqlDbType.Text).Value = animal.Observacao;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = animal.Codigo;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso 
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        //Remove um animal do banco de dados
        public bool Delete(int idAnimal)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM animal a WHERE a.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idAnimal;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public List<Animal> GetAnimais()
        {
            List<Animal> animais = new List<Animal>();
            Animal animal = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT a.ID, a.tipo, a.observacao " +
                                      "FROM animal a";

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    animal = new Animal();
                    //Seta os dados resgatados no objeto criado
                    animal.Codigo = int.Parse(reader["ID"].ToString());
                    animal.Tipo = reader["tipo"].ToString();
                    animal.Observacao = reader["observacao"].ToString();

                    animais.Add(animal);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return animais;
        }
    }
}
