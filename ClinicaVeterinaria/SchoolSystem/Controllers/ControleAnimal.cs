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
    class ControleAnimal
    {
        private Animal animal;
        private AnimalDAO animalDAO;

        //Construtor recebe a conexão do banco de dados
        public ControleAnimal()
        {
            this.animal = new Animal();
            this.animalDAO = new AnimalDAO(new Conexao());
        }

        //Resgata os dados do Animal a partir do ID dele
        public Animal Get(int idAnimal)
        {
            this.animal = animalDAO.Get(idAnimal);
            //retorna o objeto animal preenchido
            return this.animal;
        }

        //Insere um animal no banco de dados
        public int Insert(Animal animal)
        {
            //ID do endereço que vai ser gerado ao inserir o endereço no BD
            int idAnimal = 0;

            idAnimal = animalDAO.Insert(animal);

            //Retorna o ID atualizado do animal
            return idAnimal;
        }

        //Atualiza os dados do animal no banco
        public bool Update(Animal animal)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (animalDAO.Update(animal))
                return sucesso;

            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso; ;
        }

        //Remove um animal do banco de dados
        public bool Delete(int idAnimal)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (animalDAO.Delete(idAnimal))
                return sucesso;
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }
    }
}
