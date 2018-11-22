using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.model
{
    class Livro
    {
        #region properties
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn
        {
            get
            {
                return isbn;
            }

            set
            {
                isbn = value;
            }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public string Autor
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }

        public string Editora
        {
            get
            {
                return editora;
            }

            set
            {
                editora = value;
            }
        }

        internal List<Exemplar> Exemplares
        {
            get
            {
                return exemplares;
            }

            set
            {
                exemplares = value;
            }
        }
        #endregion



        #region constructors

        public Livro(int isbn)
        {
            Isbn = isbn;
        }

        public Livro()
        {
            Isbn = 0;
            Titulo = "";
            Autor = "";
            Editora = "";
            Exemplares = new List<Exemplar>();
        }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public Livro(string titulo)
        {
            this.Titulo = titulo;
        }
        #endregion

        #region methods
        public void adicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return Exemplares.Count();
        }

        public int qtdeDisponiveis()
        {
            int qtdeDisponiveis = 0;
            foreach (Exemplar exemplar in Exemplares)
            {
                if (exemplar.disponivel())
                {
                    qtdeDisponiveis++;
                }
            }
            return qtdeDisponiveis;
        }

        public int qtdeEmprestimos()
        {
            int qtdeEmprestimos = 0;
            foreach (Exemplar exemplar in Exemplares)
            {
                qtdeEmprestimos += exemplar.qtdeEmprestimos();
            }
            return qtdeEmprestimos;
        }

        public double percDisponibilidade()
        {
            return ((qtdeDisponiveis() * 100) / Exemplares.Count);
        }
        
        public String dadosBasicos()
        {
            return "Isbn: " + Isbn.ToString() +
                "\nTitulo: " + Titulo +
                "\nAutor: " + Autor +
                "\nEditora: " + Editora +
                "\nQt exemplares: " + qtdeExemplares() +
                "\nQt disponíveis: " + qtdeDisponiveis() +
                "\nQt empréstimos: " + qtdeEmprestimos() +
                "\npercentual Disponível: " + percDisponibilidade() + "%";
        }
        public string dadosSinteticos()
        {
            return "Relatório Sintético\n" +
                dadosBasicos();
        }

        public string dadosAnaliticos()
        {
            string exemplar = null;
            string informacaoDisponivelPorExemplar = null;
            string informacaoEmprestimosPorExemplar = null;
            string informacaoFinal = null;

            for (int i = 0; i < qtdeExemplares(); i++)
            {
                exemplar = "\nExemplar " + Exemplares.ElementAt(i).Tombo + "\n";
                informacaoDisponivelPorExemplar = "Disponível: " + (Exemplares.ElementAt(i).disponivel() ? "Sim" : "Não") + "\n";
                informacaoEmprestimosPorExemplar = "Qtde emprestimos: " + Exemplares.ElementAt(i).qtdeEmprestimos() + "\n";
                informacaoFinal += exemplar + informacaoDisponivelPorExemplar + informacaoEmprestimosPorExemplar;
            }
            return "Relatório Analítico\n" +
               dadosBasicos() + "\n" +
               informacaoFinal;
        }
        #endregion

        public override bool Equals(object obj)
        {
            Livro l = (Livro)obj;
            return this.isbn.Equals(l.isbn);
        }
    }
}
