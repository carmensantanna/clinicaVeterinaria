using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    class ControleVenda
    {
        private Venda venda;
        private VendaDAO vendaDAO;
        private List<ItemVenda> itens;
        private ItemVendaDAO itemDAO;

        //Construtor recebe a conexão do banco de dados
        public ControleVenda()
        {
            this.venda = new Venda();
            this.vendaDAO = new VendaDAO(new Conexao());
            this.itens = new List<ItemVenda>();
            this.itemDAO = new ItemVendaDAO(new Conexao());
        }
        public int CriarVenda(Cliente cliente, Usuario usuario)
        {
            venda.CodigoCliente = cliente.Codigo;
            venda.CodigoVendedor = usuario.Codigo;

            int idVenda = vendaDAO.Insert(venda);

            return idVenda;
        }
        public void InserirProduto(Produto produto, int quantidade, int codVenda)
        {
            ItemVenda item = new ItemVenda(codVenda,produto.CodigoProduto,quantidade,produto.Valor,quantidade*produto.Valor);
            itens.Add(item);
            venda.ValorTotal += item.ValorTotal;
        }

        public double EncerrarVenda()
        {
            vendaDAO.InsertItem(itens);
            vendaDAO.Update(venda);
            return venda.ValorTotal;
        }
    }
}