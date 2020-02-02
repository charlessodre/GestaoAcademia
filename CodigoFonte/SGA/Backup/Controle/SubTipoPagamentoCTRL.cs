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
    /// Classe de Controle da SubTipoPagamento.
    /// </summary>
    public class SubTipoPagamentoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public SubTipoPagamentoCTRL()
        {
            this._subTipoPagamentoOT = new SubTipoPagamentoOT();
            this._subTipoPagamentoN = new SubTipoPagamentoN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pSubTipoPagamentoOT">Objeto de transferência SubTipoPagamentoOT</param>
        public SubTipoPagamentoCTRL(SubTipoPagamentoOT pSubTipoPagamentoOT)
        {
            this._subTipoPagamentoOT = pSubTipoPagamentoOT;
            this._subTipoPagamentoN = new SubTipoPagamentoN();
        }

        #endregion

        #region Atributos

        private SubTipoPagamentoN _subTipoPagamentoN = null;
        private SubTipoPagamentoOT _subTipoPagamentoOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._subTipoPagamentoOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._subTipoPagamentoN.Consultar(this._subTipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._subTipoPagamentoOT.Nome = pNome;

            base.ResultadoOperacao  = this._subTipoPagamentoN.Consultar(this._subTipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._subTipoPagamentoOT = new SubTipoPagamentoOT();

            base.ResultadoOperacao  = this._subTipoPagamentoN.Consultar(this._subTipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._subTipoPagamentoN.Excluir(this._subTipoPagamentoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._subTipoPagamentoOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._subTipoPagamentoN.Inserir(this._subTipoPagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._subTipoPagamentoN.Alterar(this._subTipoPagamentoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
