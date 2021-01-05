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
    }
}