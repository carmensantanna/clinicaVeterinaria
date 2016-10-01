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
    class ControleProduto
    {
        private Produto produto;
        private ProdutoDAO produtoDAO;
        //Construtor recebe a conexão do banco de dados
        public ControleProduto()
        {
            this.produto = new Produto();
            this.produtoDAO = new ProdutoDAO(new Conexao());
        }
        public Produto Get(int idProduto)
        {
            this.produto = produtoDAO.Get(idProduto);
            //retorna o objeto cliente preenchido
            return this.produto;
        }

        //Insere um cliente no banco de dados
        public int Insert(Produto produto)
        {
            //ID do endereço que vai ser gerado ao inserir o endereço no BD
            int idProduto = 0;

            idProduto = produtoDAO.Insert(produto);

            //Retorna o ID atualizado do cliente
            return idProduto;
        }
        public bool Update(Produto produto)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

            if (produtoDAO.Update(produto))
            {
                    return sucesso;
            }
            else
                sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }
        public bool Delete(int idProduto)
        {
            //FLAG que irá retornar a execução da query (sucesso = true ou falha = false)
            bool sucesso = true;

                if (produtoDAO.Delete(produto.CodigoProduto))
                    return sucesso;
                else
                    sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }
    }
}
