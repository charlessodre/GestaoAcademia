using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class PagamentoOT : BaseOT
    {
        #region Atributos

        private TipoPagamentoOT _tipoPagamentoOT = null;
        private SubTipoPagamentoOT _subTipoPagamentoOT = null;
        private UsuarioOT _usuarioPagamento = null;
        private ReciboOT _recibo = null;
        private DateTime _dataPagamento;
        private string _observacao;
        private int _quantidadeParcelas;
        private decimal _valorPagamento;
        private decimal _valorParcela;
        private bool _troca;
        private string _descricao;
        private int _codigoLancamentoConta;


        #endregion


        #region Propriedades Formatadas


        /// <summary>
        /// Lê e escreve recibo do pagamento
        /// </summary>
        public ReciboOT Recibo
        {
            get { return _recibo = _recibo ?? new ReciboOT(); }
            set { _recibo = value; }
        }


        /// <summary>
        /// Lê e escreve o usuário que recebeu o  pagamento
        /// </summary>
        public UsuarioOT UsuarioPagamento
        {
            get { return _usuarioPagamento = _usuarioPagamento ?? new UsuarioOT(); }
            set { _usuarioPagamento = value; }
        }



        /// <summary>
        /// Lê e escreve o valor a pagar do Pagamento.
        /// </summary>
        public string ValorPagamentoFormatado
        {
            get { return BaseOT.SIMBOLO_MONETARIO + this._valorPagamento.ToString(BaseOT.SIMBOLO_MONETARIO); }
        }

        /// <summary>
        /// Lê e escreve o valor a pagar do Parcela.
        /// </summary>
        public string ValorParcelaFormatado
        {
            get { return BaseOT.SIMBOLO_MONETARIO + this._valorParcela.ToString(BaseOT.SIMBOLO_MONETARIO); }
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e escreve o código do lancaçamento.
        /// </summary>
        public int CodigoLancamentoConta
        {
            get { return _codigoLancamentoConta; }
            set { _codigoLancamentoConta = value; }
        }

        /// <summary>
        /// Lê e escreve se é troca.
        /// </summary>
        public bool Troca
        {
            get { return _troca; }
            set { _troca = value; }
        }

        /// <summary>
        /// Lê e escreve o valor das parcelas pagamento.
        /// </summary>
        public decimal ValorParcela
        {
            get { return _valorParcela; }
            set { _valorParcela = value; }
        }

        /// <summary>
        /// Lê e escreve o valor do pagamento.
        /// </summary>
        public decimal ValorPagamento
        {
            get { return _valorPagamento; }
            set { _valorPagamento = value; }
        }

        /// <summary>
        /// Lê e escreve a quantidade de parcelas pagamento
        /// </summary>
        public int QuantidadeParcelas
        {
            get { return _quantidadeParcelas; }
            set { _quantidadeParcelas = value; }
        }

        /// <summary>
        /// Lê e escreve a observação pagamento
        /// </summary>
        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

        /// <summary>
        /// Lê e escreve a data do pagamento
        /// </summary>
        public DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }

        /// <summary>
        /// Lê e escreve o tipo de pagamento
        /// </summary>
        public TipoPagamentoOT TipoPagamentoOT
        {
            get { return _tipoPagamentoOT = _tipoPagamentoOT ?? new TipoPagamentoOT(); }
            set { _tipoPagamentoOT = value; }
        }

        /// <summary>
        /// Lê e escreve o subtipo de pagamento
        /// </summary>
        public SubTipoPagamentoOT SubTipoPagamento
        {
            get { return _subTipoPagamentoOT = _subTipoPagamentoOT ?? new SubTipoPagamentoOT(); }
            set { _subTipoPagamentoOT = value; }
        }

        /// <summary>
        /// Lê e escreve a descrição do pagamento.
        /// </summary>
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }


        #endregion

        #region Métodos

        /// <summary>
        /// Calcula o troco.
        /// </summary>
        /// <param name="pValorTotal">Valor Total</param>
        /// <param name="pValorRecebido">Valor Recebido</param>
        /// <returns>Retorna o troco calculado.</returns>
        public static decimal CalcularTroco(decimal pValorTotal, decimal pValorRecebido)
        {
            decimal troco = 0;

            troco = pValorRecebido - pValorTotal;

            if (troco > 0)
            {
                return troco;
            }
            else
            {
                return 0;
            }


        }
        #endregion
    }
}
