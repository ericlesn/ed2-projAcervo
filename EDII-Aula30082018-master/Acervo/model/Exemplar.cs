using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.model
{
    class Exemplar
    {
        #region properties
        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo
        {
            get
            {
                return tombo;
            }

            set
            {
                tombo = value;
            }
        }

        internal List<Emprestimo> Emprestimos
        {
            get
            {
                return emprestimos;
            }

            set
            {
                emprestimos = value;
            }
        }
        #endregion

        #region constructors
        public Exemplar()
        {
            Tombo = 0;
            Emprestimos = new List<Emprestimo>();
        }

        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }
        #endregion

        #region methods
        public bool emprestar()
        {
            if (disponivel()) {
                Emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!disponivel())
            {
                Emprestimos[Emprestimos.Count - 1].DtDevolucao = DateTime.Now;
            return true;

            }
            return false;
        }

        public bool disponivel()
        {
            if (Emprestimos.Count > 0)
            {
                if (Emprestimos[Emprestimos.Count - 1].DtDevolucao == DateTime.MinValue)
                {
                    return false;
                }
            }
            return true;
        }

        public int qtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
        #endregion

        public override bool Equals(object obj)
        {
            Exemplar e = (Exemplar)obj;
            return this.tombo.Equals(e.tombo);
        }
    }
}
