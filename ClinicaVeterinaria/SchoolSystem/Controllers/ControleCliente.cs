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
    public class ControleCliente
    {
        private EnderecoDAO enderecoDAO;
        private Cliente cliente;
        private ClienteDAO clienteDAO;
        private PetDAO petDAO;
        private Pet pet;

        //Construtor recebe a conexão do banco de dados
        public ControleCliente()
        {
            this.enderecoDAO = new EnderecoDAO(new Conexao());
            this.cliente = new Cliente();
            this.clienteDAO = new ClienteDAO(new Conexao());
            this.petDAO = new PetDAO(new Conexao());
            this.pet = new Pet();
        }

        //Resgata os dados do Cliente a partir do ID dele
        public Cliente Get(int idCliente)
        {
            this.cliente = clienteDAO.Get(idCliente);

            this.cliente.Endereco = enderecoDAO.Get(this.cliente.Endereco.Codigo);

            //this.cliente.Pets = petDAO.GetListaPet(idCliente);
            //retorna o objeto cliente preenchido
            return this.cliente;
        }

        public List<Cliente> GetClientes()
        {
            return clienteDAO.GetClientes();
        }

       /* public List<Pet> GetListaPet(int idCliente)
        {
            return this.cliente.Pets = petDAO.GetListaPet(idCliente); 
        }*/
        public Cliente NomePetCliente(string nome)
        {
            this.cliente = clienteDAO.GetPetNome(nome);
            return cliente;
        }
        public List<Pet> GetPets()
        {
           return petDAO.GetPets();
        }

        public Pet GetPet(int idPet)
        {
            return petDAO.Get(idPet);
        }


        //Insere um cliente no banco de dados
        public int Insert(Cliente cliente)
        {
            //ID do endereço que vai ser gerado ao inserir o endereço no BD
            int idEndereco = 0;
            int idCliente = 0;

            idEndereco = enderecoDAO.Insert(cliente.Endereco);
            cliente.Endereco.Codigo = idEndereco;
            idCliente = clienteDAO.Insert(cliente);

            //Retorna o ID atualizado do cliente
            return idCliente;
        }

        public int InsertPet(Pet pet)
        {
            return petDAO.Insert(pet);
        }


        //Atualiza os dados do cliente no banco
        public bool Update(Cliente cliente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (clienteDAO.Update(cliente))
            {
                if (enderecoDAO.Update(cliente.Endereco))
                    return sucesso;
                else
                    sucesso = false;
            } 
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }

        public bool UpdatePet(Pet pet)
        {
            return petDAO.Update(pet);
        }


        //Remove um cliente do banco de dados
        public bool Delete(int idCliente)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;
            cliente.Codigo = idCliente;
            /* if (enderecoDAO.Delete(cliente.Endereco.Codigo))
             {
                 if (clienteDAO.Delete(idCliente))
                     return sucesso;
                 else
                     sucesso = false;
             }*/
            if (clienteDAO.Delete(idCliente))
            {
                return sucesso;
            }
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }

        public List<Animal> getAnimais()
        {
            AnimalDAO animalDAO = new AnimalDAO(new Conexao());
            return animalDAO.GetAnimais();
        }
    }
}
