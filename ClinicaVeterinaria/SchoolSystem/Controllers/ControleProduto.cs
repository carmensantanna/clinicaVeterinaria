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
        private EstoqueDAO estoqueDAO;
        private const char movEntrada = 'E';
        private const char movSaida = 'S';
        //Construtor recebe a conexão do banco de dados
        public ControleProduto()
        {
            this.produto = new Produto();
            this.produtoDAO = new ProdutoDAO(new Conexao());
            this.estoqueDAO = new EstoqueDAO(new Conexao());
        }
        public Produto Get(int idProduto)
        {
            this.produto = produtoDAO.Get(idProduto);
            //double quantidade = estoqueDAO.Get(idProduto);
            //retorna o objeto produto preenchido
            return this.produto;
        }

        public List<Produto> GetProduto()
        {
            return produtoDAO.GetProdutos();
        }

        //Insere um cliente no banco de dados
        public int Insert(Produto produto)
        {
            //ID do endereço que vai ser gerado ao inserir o endereço no BD
            int idProduto = 0;

            idProduto = produtoDAO.Insert(produto);
            //movimentoEstoque(movEntrada, produto, produto.Estoque);

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

                if (produtoDAO.Delete(produto.Codigo))
                    return sucesso;
                else
                    sucesso = false;

            //Retorna o resultado da execução
            return sucesso;
        }
        public void movimentoEstoque(char movimento,Produto produto, double quantidade)
        {
            if (quantidade > 0)
            {
                double quantidadeAtual = estoqueDAO.Get(produto.Codigo);
                movimento = movimento.ToString().ToUpper()[0];
                switch (movimento)
                {
                    case 'E':
                        quantidadeAtual += quantidade;
                        estoqueDAO.Insert(produto.Codigo, movEntrada, quantidade, quantidadeAtual);
                        break;
                    case 'S':
                        quantidadeAtual -= quantidade;
                        if (quantidadeAtual < 0)
                            quantidadeAtual = 0;
                        estoqueDAO.Insert(produto.Codigo, movSaida, quantidade, quantidadeAtual);
                        break;
                }
                //produto.Estoque = quantidadeAtual;
            }
        }

    }
}
