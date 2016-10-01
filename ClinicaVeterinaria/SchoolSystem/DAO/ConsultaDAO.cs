using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;


namespace TI_ClinicaVeterinaria
{
    class ConsultaDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public ConsultaDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }
        //Resgata os dados do Endereço a partir do ID dele
        public Consulta Get(int idConsulta)
        {
            Consulta consulta = null;
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;
            HorariosDAO horariosDAO = new HorariosDAO(conexaoBD);
            ClienteDAO clienteDAO = new ClienteDAO(conexaoBD);
            PetDAO petDAO = new PetDAO(conexaoBD);

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;               
                //Monta a query
                comando.CommandText = "SELECT c.ID, c.idCliente, c.idPet, c.idHorarios, c.receita, c.prontuario, c.veterinario " +
                            "FROM Consulta c " +
                            "WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idConsulta;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    consulta = new Consulta();
                    //Seta os dados resgatados no objeto criado
                    consulta.Codigo = reader.GetInt16(0);
                    consulta.Cliente = clienteDAO.Get(reader.GetInt16(1));
                    consulta.Pet = petDAO.Get(reader.GetInt16(2));
                    consulta.Horario = horariosDAO.Get(reader.GetInt16(3));
                    consulta.Receita = reader.GetString(4);
                    consulta.Prontuario = reader.GetString(5);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna o objeto endereço preenchido
            return consulta;
        }


        //Insere um endereço no banco de dados
        public int Insert(Consulta consulta)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO consulta(idCliente, idPet, idHorarios, receita, prontuario)" +
                            " VALUES(@idCliente, @idPet, @idHorarios, @receita, @prontuario); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idCliente", MySqlDbType.Int16).Value = consulta.Cliente.Codigo;
                comando.Parameters.Add("@idPet", MySqlDbType.Int16).Value = consulta.Pet.Codigo;
                comando.Parameters.Add("@idHorarios", MySqlDbType.Int16).Value = consulta.Horario.Codigo;
                comando.Parameters.Add("@receita", MySqlDbType.Double).Value = consulta.Receita;
                comando.Parameters.Add("@prontuario", MySqlDbType.Double).Value = consulta.Prontuario;
                comando.Parameters.Add("@veterinario", MySqlDbType.Double).Value = consulta.Veterinario;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                consulta.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return consulta.Codigo;
        }


        //Atualiza os dados do endereço no banco
        public bool Update(Consulta consulta)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "UPDATE consulta c SET c.idHorarios = @idHorarios, c.idPet = @idPet, c.receita = @receita, c.prontuario = @prontuario " +
                            "WHERE c.ID = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@idHorarios", MySqlDbType.Int16).Value = consulta.Horario.Codigo;
                comando.Parameters.Add("@idPet", MySqlDbType.Int16).Value = consulta.Pet.Codigo;
                comando.Parameters.Add("@receita", MySqlDbType.Text).Value = consulta.Receita;
                comando.Parameters.Add("@prontuario", MySqlDbType.Text).Value = consulta.Prontuario;
                comando.Parameters.Add("@vetrinario", MySqlDbType.Text).Value = consulta.Veterinario;
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = consulta.Codigo;
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
        public bool Delete(int idConsulta)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "DELETE FROM consulta c WHERE c.idConsulta = @ID";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idConsulta;

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
