using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.model
{
    class Emprestimo
    {
        #region properties
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public DateTime DtEmprestimo
        {
            get
            {
                return dtEmprestimo;
            }

            set
            {
                dtEmprestimo = value;
            }
        }

        public DateTime DtDevolucao
        {
            get
            {
                return dtDevolucao;
            }

            set
            {
                dtDevolucao = value;
            }
        }
        #endregion


        #region constructors
        public Emprestimo()
        {
            
        }

        public Emprestimo(DateTime dateTime)
        {
            DtEmprestimo = dateTime;
        }
        #endregion

    }
}
