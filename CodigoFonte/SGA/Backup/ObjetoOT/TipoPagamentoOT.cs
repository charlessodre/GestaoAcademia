using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class TipoPagamentoOT : BaseOT
    {
        #region Atributos

        private SubTipoPagamentoOT _subTipoPagamentoOT = null;
        private string _nomeFormaPagamento;
        private string _codigoFP;


        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e escreve o subtipo de pagamento.
        /// </summary>
        public SubTipoPagamentoOT SubTipoPagamento
        {
            get { return _subTipoPagamentoOT = _subTipoPagamentoOT ?? new SubTipoPagamentoOT(); }
            set { _subTipoPagamentoOT = value; }
        }

        /// <summary>
        /// Lê e escreve o nome da forma de pagamento.
        /// </summary>
        public string NomeFormaPagamento
        {
            get { return _nomeFormaPagamento; }
            set { _nomeFormaPagamento = value; }
        }

        /// <summary>
        /// Lê e escreve o código da formada pagamento.
        /// </summary>
        public string CodigoFP
        {
            get { return _codigoFP; }
            set { _codigoFP = value; }
        }

        #endregion

        #region Métodos


        #endregion
    }
}
