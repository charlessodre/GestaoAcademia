using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class ReciboOT : BaseOT
    {
        #region Atributos

        private int _codigoLancamentoConta;

      
        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e escreve o codigo do Lançamento da Conta
        /// </summary>
        public int CodigoLancamentoConta
        {
            get { return _codigoLancamentoConta; }
            set { _codigoLancamentoConta = value; }
        }
      

        #endregion

        #region Métodos


        #endregion
    }
}
