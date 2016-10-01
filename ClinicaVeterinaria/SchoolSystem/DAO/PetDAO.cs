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
    public class PetDAO
    {
        private Conexao conexaoBD;
        private AnimalDAO animalDAO;
        private ClienteDAO clienteDAO;

        //Construtor recebe a conexão do banco de dados
        public PetDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
            this.animalDAO = new AnimalDAO(conexaoBD);
            this.clienteDAO = new ClienteDAO(conexaoBD);
        }


        //Resgata os dados do Pet a partir do ID dele
        public Pet Get(int idPet)
        {
            Pet pet = null;
            int idAnimal = 0;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT p.ID, p.nome, p.peso, p.altura, p.idAnimal, p.idCliente, c.nome as nomeCliente, a.tipo as tipoAnimal " +
                                      "FROM pet p " +
                                      "INNER JOIN cliente c ON p.idCliente = c.ID " +
                                      "INNER JOIN animal a ON p.idAnimal = a.ID " +
                                      "WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idPet;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    pet = new Pet();
                    //Seta os dados resgatados no objeto criado
                    pet.Codigo = int.Parse(reader["ID"].ToString());
                    pet.Nome = reader["nome"].ToString();
                    pet.Peso = double.Parse(reader["peso"].ToString());
                    pet.Altura = double.Parse(reader["altura"].ToString());
                    pet.Animal.Codigo = int.Parse(reader["idAnimal"].ToString());
                    pet.Animal.Tipo = reader["tipoAnimal"].ToString();
                    pet.Cliente.Codigo = int.Parse(reader["idCliente"].ToString());
                    pet.Cliente.Nome = reader["nomeCliente"].ToString();

                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return pet;
        }

        public List<Pet> GetPets()
        {
            Pet pet = null;
            List<Pet> pets = new List<Pet>();
            int idAnimal = 0;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT p.ID, p.nome, p.peso, p.altura, p.idAnimal, p.idCliente, c.nome as nomeCliente, a.tipo as tipoAnimal " +
                                      "FROM pet p " +
                                      "INNER JOIN cliente c ON p.idCliente = c.ID " +
                                      "INNER JOIN animal a ON p.idAnimal = a.ID";

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    pet = new Pet();
                    //Seta os dados resgatados no objeto criado
                    pet.Codigo = int.Parse(reader["ID"].ToString());
                    pet.Nome = reader["nome"].ToString();
                    pet.Peso = double.Parse(reader["peso"].ToString());
                    pet.Altura = double.Parse(reader["altura"].ToString());
                    pet.Animal.Codigo = int.Parse(reader["idAnimal"].ToString());
                    pet.Animal.Tipo = reader["tipoAnimal"].ToString();
                    pet.Cliente.Codigo = int.Parse(reader["idCliente"].ToString());
                    pet.Cliente.Nome = reader["nomeCliente"].ToString();

                    pets.Add(pet);

                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto cliente preenchido
            return pets;
        }


        //Insere um pet no banco de dados
        public int Insert(Pet pet)
        {
            //int idAnimal = animalDAO.Insert(pet.Animal);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO pet(nome, peso, altura, idAnimal, idCliente)" +
                            "VALUES(@nome, @peso, @altura, @idAnimal, @idCliente); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = pet.Nome;
                comando.Parameters.Add("@peso", MySqlDbType.Double).Value = pet.Peso;
                comando.Parameters.Add("@altura", MySqlDbType.Double).Value = pet.Altura;
                comando.Parameters.Add("@idAnimal", MySqlDbType.Int16).Value = pet.Animal.Codigo;
                comando.Parameters.Add("@idCliente", MySqlDbType.Int16).Value = pet.Cliente.Codigo;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                pet.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do pet
            return pet.Codigo;
        }


        //Atualiza os dados do pet no banco
        public bool Update(Pet pet)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE pet p SET p.nome = @nome" +
                ", p.peso = @peso" +
                ", p.altura = @altura" +
                ", p.idAnimal = @idAnimal" +
                " WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = pet.Nome;
                comando.Parameters.Add("@peso", MySqlDbType.Double).Value = pet.Peso;
                comando.Parameters.Add("@altura", MySqlDbType.Double).Value = pet.Altura;
                comando.Parameters.Add("@idAnimal", MySqlDbType.Int16).Value = pet.Animal.Codigo;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = pet.Codigo;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso 
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }


        //Remove um pet do banco de dados
        public bool Delete(int idPet)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM pet p WHERE p.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idPet;

                //Verifica quantos registros foram afetados com o Update. Se nenhum registro foi afetado(<= zero) significa que não foi executado com sucesso
                if (comando.ExecuteNonQuery() <= 0)
                    sucesso = false;

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o resultado da execução
            return sucesso;
        }

        public List<Pet> GetListaPet(int idCliente)
        {
            Pet pet = null;
            List < Pet > pets = new List<Pet>();
            int idAnimal = 0;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "SELECT p.ID, p.nome, p.peso, p.altura, p.idAnimal, p.idCliente, a.tipo " +
                                      "FROM pet p, animal a " +
                                      "WHERE p.ID = @ID and p.idAnimal = a.ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idCliente;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    pet = new Pet();
                    //Seta os dados resgatados no objeto criado
                    pet.Codigo = int.Parse(reader["ID"].ToString());
                    pet.Nome = reader["nome"].ToString();
                    pet.Peso = double.Parse(reader["peso"].ToString());
                    pet.Altura = double.Parse(reader["altura"].ToString());
                    //idAnimal = int.Parse(reader["idAnimal"].ToString());
                    pet.Animal.Codigo = int.Parse(reader["idAnimal"].ToString());
                    pet.Animal.Tipo = reader["tipo"].ToString();
                    pet.Cliente.Codigo = int.Parse(reader["idCliente"].ToString());
                    pets.Add(pet);
                    
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna a lista de pets preenchida
            return pets;
        }

       
    }
}
