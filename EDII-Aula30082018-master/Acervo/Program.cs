using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acervo.controller;
using Acervo.model;

namespace Acervo
{
    class Program
    {
        const string TYPE_ISBN_MESSAGE = "Digite o isbn do livro";
        const string TYPE_TOMBO_MESSAGE = "Digite o tombo do livro";

        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            string option = " ";

            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("| 0.Sair                             |");
                Console.WriteLine("| 1.Adicionar livro                  |");
                Console.WriteLine("| 2.Pesquisar livro(sintético) *     |");
                Console.WriteLine("| 3.Pesquisar livro(analítico) * *   |");
                Console.WriteLine("| 4.Adicionar exemplar               |");
                Console.WriteLine("| 5.Registrar empréstimo             |");
                Console.WriteLine("| 6.Registrar devolução              |");
                Console.WriteLine("--------------------------------------");

                option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Você foi deslogado da sessão. Obrigado");
                        Console.ReadKey();
                        break;
                    case "1":
                        adicionarLivro(biblioteca);
                        break;
                    case "2":
                        relatorioSintetico(biblioteca);
                        break;
                    case "3":
                        relatorioAnal(biblioteca);
                        break;
                    case "4":
                        adicionarExemplar(biblioteca);
                        break;
                    case "5":
                        emprestar(biblioteca);
                        break;
                    case "6":
                        devolver(biblioteca);
                        break;
                    
                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }

            }
            while (option != "0");
        }

        static void adicionarLivro(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            biblioteca.adicionar(new Livro(isbn, "A Revolução dos bichos", "George Orwell", "Globo"));
            Console.WriteLine("Livro cadastrado! :)");
            Console.ReadKey();
        }

        static void relatorioSintetico(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.pesquisar(new Livro(isbn));
            Console.WriteLine(livro.dadosSinteticos());
            Console.ReadKey();
        }

        static void relatorioAnal(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.pesquisar(new Livro(isbn));
            livro.dadosAnaliticos();
            Console.ReadKey();
        }

        static void adicionarExemplar(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            Console.WriteLine(TYPE_TOMBO_MESSAGE);
            int tombo = int.Parse(Console.ReadLine());
            biblioteca.pesquisar(new Livro(isbn)).adicionarExemplar(new Exemplar(tombo));
            Console.WriteLine("Exemplar Adicionado!");
            Console.ReadKey();
        }

        static void emprestar(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            if (biblioteca.pesquisar(new Livro(isbn)).Exemplares.FirstOrDefault(i => i.emprestar()) != null)
                Console.WriteLine("Emprestado!");
            else Console.WriteLine("Não há livros para empréstimo!");
            Console.ReadKey();
        }

        static void devolver(Livros biblioteca)
        {
            Console.WriteLine(TYPE_ISBN_MESSAGE);
            int isbn = int.Parse(Console.ReadLine());
            Console.WriteLine(TYPE_TOMBO_MESSAGE);
            int tombo = int.Parse(Console.ReadLine());
            biblioteca.pesquisar(new Livro(isbn)).Exemplares.FirstOrDefault(i => i.devolver());
            Console.WriteLine("Devolvido!");
        }

        
    }
}
