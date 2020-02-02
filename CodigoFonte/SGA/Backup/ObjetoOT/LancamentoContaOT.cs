using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class LancamentoContaOT : BaseOT
    {
        #region Atributos

        private AlunoOT _aluno = null;
        private ServicoRealizadoOT _servicoRealizado = null;
        private PagamentoOT _pagamento;
        private ReciboOT _recibo = null;
        private string _descricao;
        private decimal _valorLancamento;
        private DateTime _dataVencimento;
        private DateTime _dataLancamento;
        private string _observacao;
        private DateTime _dataInicioLancamento;
        private DateTime _dataFimLancamento;
        private bool _pago;
        private Utilitarios.Enumeradores.StatusPagamento _statusPagamento = Utilitarios.Enumeradores.StatusPagamento.Todos;


        #endregion

        #region Propriedades Formatadas

        /// <summary>
        /// Lê e escreve o valor a pagar do lançamento.
        /// </summary>
        public string ValorLancamentoFormatado
        {
            get { return BaseOT.SIMBOLO_MONETARIO + this._valorLancamento.ToString(BaseOT.SIMBOLO_MONETARIO); }

        }

        /// <summary>
        /// Lê o texto do status do pagamento do lançamento.
        /// </summary>
        public string PagoTexto
        {
            get { return _pago ? "SIM" : "NÃO"; }
        }

        #endregion
        
        #region Propriedades



        /// <summary>
        /// Lê e escreve o status do pagamento do lançamento.
        /// </summary>
        public Utilitarios.Enumeradores.StatusPagamento StatusPagamento
        {
            get { return _statusPagamento; }
            set { _statusPagamento = value; }
        }

        /// <summary>
        ///  Lê e escreve o recibo do lançamento.
        /// </summary>
        public ReciboOT Recibo
        {
            get { return _recibo =_recibo ?? new ReciboOT(); }
            set { _recibo = value; }
        }

        /// <summary>
        ///  Lê e escreve se o lançamento foi pago.
        /// </summary>
        public bool Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }

        /// <summary>
        ///  Lê e escreve o pagamento do lançamento..
        /// </summary>
        public PagamentoOT Pagamento
        {
            get { return _pagamento = _pagamento ?? new PagamentoOT(); }
            set { _pagamento = value; }
        }

        /// <summary>
        /// Lê e escreve a data inicio do lançamento.
        /// </summary>
        public DateTime DataInicioLancamento
        {
            get { return _dataInicioLancamento; }
            set { _dataInicioLancamento = value; }
        }

        /// <summary>
        /// Lê e escreve a data fim do lançamento.
        /// </summary>
        public DateTime DataFimLancamento
        {
            get { return _dataFimLancamento; }
            set { _dataFimLancamento = value; }
        }

        /// <summary>
        /// Lê e escreve o serviço realizado no lançamento.
        /// </summary>
        public ServicoRealizadoOT ServicoRealizado
        {
            get { return _servicoRealizado = _servicoRealizado ?? new ServicoRealizadoOT(); }
            set { _servicoRealizado = value; }
        }

        /// <summary>
        /// Lê e escreve a observação do lançamento.
        /// </summary>
        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

        /// <summary>
        /// Lê e escreve a data do lançamento.
        /// </summary>
        public DateTime DataLancamento
        {
            get { return _dataLancamento; }
            set { _dataLancamento = value; }
        }

        /// <summary>
        /// Lê e escreve o valor a pagar do lançamento.
        /// </summary>
        public decimal ValorLancamento
        {
            get { return _valorLancamento; }
            set { _valorLancamento = value; }
        }

        /// <summary>
        /// Lê e escreve a data de vencimento do lançamento.
        /// </summary>
        public DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        /// <summary>
        /// Lê e escreve o aluno do lançamento.
        /// </summary>
        public AlunoOT Aluno
        {
            get { return _aluno = _aluno ?? new AlunoOT(); }
            set { _aluno = value; }
        }

        /// <summary>
        /// Lê e escreve a descrição do lançamento da conta.
        /// </summary>
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        #endregion

        #region Métodos


        #endregion
    }
}
