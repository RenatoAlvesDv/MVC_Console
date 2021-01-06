using System;
using System.Collections.Generic;
using System.IO;

namespace MVC_Console.Models
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }
        public float Preco{ get; set;}

        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            string pasta = PATH.Split("/")[0];

            //Vericamos se a pasta não existe e criamos nesta condição
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

             // Verificamos se o arquivo Produto.csv existe, caso não exista, vamos criá-la 
             if(!File.Exists(PATH))
             {
                 File.Create(PATH);
             }

        }

        public List<Produto> Ler()
        {
            List<Produto> produtos = new List<Produto>();

            //Pegar as informações do csv
            string[] linhas = File.ReadAllLines(PATH);



        foreach( string item in linhas)
        {
            //Separar atributos pelo ;
            string[] atributos = item.Split(";");

            // Criamos um produto vazio para poder colocar na lista final de produtos
            Produto prod = new Produto();
            prod.Codigo = int.Parse (atributos[0]);
            prod.Nome = atributos[1];
            prod.Preco = float.Parse(atributos[2]);

            produtos.Add(prod);


        }
            return produtos;
            
        }

         public void Inserir(Produto p)
         {
             //Preparamos um array de String para o método AppendAllLines
             string[] linhas = { PrepararLinhaCSV(p) };

           // Inserimos o array de linhas no arquivo CSV
            File.AppendAllLines(PATH, linhas);
         }


         public string PrepararLinhaCSV(Produto prod)
         {
            //Preparamos a linha para o fomato CSV
            return $"{prod.Codigo};{prod.Nome};{prod.Preco}";
         }
    }
}