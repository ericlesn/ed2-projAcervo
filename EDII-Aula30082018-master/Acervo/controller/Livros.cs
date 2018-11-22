using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acervo.model;

namespace Acervo.controller
{
    class Livros
    {
        #region properties
        private List<Livro> acervo;
        #endregion


        #region constructors
        public Livros()
        {
            Acervo = new List<Livro>();
        }

        internal List<Livro> Acervo
        {
            get
            {
                return acervo;
            }

            set
            {
                acervo = value;
            }
        }


        #endregion

        #region methods
        public void adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            Livro retorno = new Livro();

            foreach (Livro li in Acervo)
            {
                if (li.Equals(livro))
                {
                    retorno = li;
                }
            }
            return retorno;
        }
        #endregion
    }
}
