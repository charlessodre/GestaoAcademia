using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using Negocio;
using Utilitarios;
using Comum;

namespace Controle
{
    /// <summary>
    /// Classe de Controle da TipoPagamento.
    /// </summary>
    public class TipoPagamentoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public TipoPagamentoCTRL()
        {
            this._tipoPagamentoOT = new TipoPagamentoOT();
            this._tipoPagamentoN = new TipoPagamentoN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pTipoPagamentoOT">Objeto de transferência TipoPagamentoOT</param>
        public TipoPagamentoCTRL(TipoPagamentoOT pTipoPagamentoOT)
        {
            this._tipoPagamentoOT = pTipoPagamentoOT;
            this._tipoPagamentoN = new TipoPagamentoN();
        }

        #endregion

        #region Atributos

        private TipoPagamentoN _tipoPagamentoN = null;
        private TipoPagamentoOT _tipoPagamentoOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Obtêm os codigos do Tipo e SubTipo de pagamento da forma de pagamento.
        /// </summary>
        /// <param name="pCodigoFP">Codigo da forma de pagamento.</param>
        /// <returns>Retorna a lista com os código do Tipo e SubTipo de pagamento  </returns>
        public static List<string> ObterCodigoFormasPagamentos(object pCodigoFP)
        {
            List<string> formasPagamentosList = new List<string>();

            if (pCodigoFP is string)
            {
                string codigo = pCodigoFP.ToString();
                if (!string.IsNullOrEmpty(codigo))
                {
                    string[] formasPagamentos = codigo.Split('.');

                    if (formasPagamentos.Length > 0)
                    {
                        formasPagamentosList.Add(formasPagamentos[0]);
                    }
                    else if (formasPagamentos.Length > 1)
                    {
                        formasPagamentosList.Add(formasPagamentos[0]);
                        formasPagamentosList.Add(formasPagamentos[1]);
                    }
                }
            }

            return formasPagamentosList;
        }
        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._tipoPagamentoOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._tipoPagamentoN.Consultar(this._tipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._tipoPagamentoOT.Nome = pNome;

            base.ResultadoOperacao  = this._tipoPagamentoN.Consultar(this._tipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._tipoPagamentoOT = new TipoPagamentoOT();

            base.ResultadoOperacao  = this._tipoPagamentoN.Consultar(this._tipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._tipoPagamentoN.Excluir(this._tipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._tipoPagamentoOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._tipoPagamentoN.Inserir(this._tipoPagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._tipoPagamentoN.Alterar(this._tipoPagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
