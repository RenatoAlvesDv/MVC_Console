using System.Collections.Generic;
using MVC_Console.Models;
using MVC_Console.Views;

namespace MVC_Console.Controllers
{
    public class ProdutoController
    {

        Produto produto = new Produto();

        ProdutoView produtoView = new ProdutoView();

        public void MostrarProdutos()
        {
            List<Produto> todos = produto.Ler();
            produtoView.ListarTodos(todos);
        }
        public void Cadastrar()
        {
            //Pedimos para nosso modelo inserir as infromaçãoes capturadas na View
            produto.Inserir(produtoView.CadastrarProduto() );

        }
    }
}