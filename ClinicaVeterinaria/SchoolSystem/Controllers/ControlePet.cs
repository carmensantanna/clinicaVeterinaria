using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_ClinicaVeterinaria;

namespace TI_ClinicaVeterinaria
{
    class ControlePet
    {
        Pet pet;
        PetDAO petDAO;
        Cliente cliente;
        //--------------------------------Controle Pet--------------------------------

        //Resgata os dados do Cliente a partir do ID dele
        public Pet GetPet(int idPet)
        {
            this.pet = petDAO.Get(idPet);

            //this.pet.Endereco = enderecoDAO.Get(this.cliente.Endereco.Codigo);

            //retorna o objeto pet preenchido
            return this.pet;
        }

        

        /*public List<Pet> GetPets(int idCliente)
        {
            return this.cliente.Pets = petDAO.GetPets(idCliente);
        }*/


        //Insere um pet no banco de dados
        public int Insert(Pet pet)
        {
            //ID do pet que vai ser gerado ao inserir no BD
            int idPet = 0;

            idPet = petDAO.Insert(pet);

            //Retorna o ID atualizado do pet
            return idPet;
        }


        //Atualiza os dados do cliente no banco
        public bool Update(Pet pet)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (petDAO.Update(pet))
                return sucesso;
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }


        //Remove um pet do banco de dados
        public bool DeletePet(int idPet)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (petDAO.Delete(cliente.Endereco.Codigo))
                return sucesso;
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }


        //--------------------------------Get e Set --------------------------------

        /*public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }*/

    }
}
