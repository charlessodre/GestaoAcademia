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
    /// Classe de Controle da Pagamento.
    /// </summary>
    public class PagamentoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public PagamentoCTRL()
        {
            this._pagamentoOT = new PagamentoOT();
            this._pagamentoN = new PagamentoN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pPagamentoOT">Objeto de transferência PagamentoOT</param>
        public PagamentoCTRL(PagamentoOT pPagamentoOT)
        {
            this._pagamentoOT = pPagamentoOT;
            this._pagamentoN = new PagamentoN();
        }

        #endregion

        #region Atributos

        private PagamentoN _pagamentoN = null;
        private PagamentoOT _pagamentoOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._pagamentoOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._pagamentoN.Consultar(this._pagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._pagamentoOT.Nome = pNome;

            base.ResultadoOperacao  = this._pagamentoN.Consultar(this._pagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._pagamentoOT = new PagamentoOT();

            base.ResultadoOperacao  = this._pagamentoN.Consultar(this._pagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._pagamentoN.Excluir(this._pagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._pagamentoOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._pagamentoN.Inserir(this._pagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._pagamentoN.Alterar(this._pagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
