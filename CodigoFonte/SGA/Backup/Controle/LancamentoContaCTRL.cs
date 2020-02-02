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
    /// Classe de Controle da LancamentoConta.
    /// </summary>
    public class LancamentoContaCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public LancamentoContaCTRL()
        {
            this._lancamentoContaOT = new LancamentoContaOT();
            this._lancamentoContaN = new LancamentoContaN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pLancamentoContaOT">Objeto de transferência LancamentoContaOT</param>
        public LancamentoContaCTRL(LancamentoContaOT pLancamentoContaOT)
        {
            this._lancamentoContaOT = pLancamentoContaOT;
            this._lancamentoContaN = new LancamentoContaN();
        }

        #endregion

        #region Atributos

        private LancamentoContaN _lancamentoContaN = null;
        private LancamentoContaOT _lancamentoContaOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta os lançamento pelo código do aluno.
        /// </summary>
        /// <param name="pCodigoUsuario">Código do aluno.</param>
        /// <returns>Retorna o resultado da operação.</returns>
        public ResultadoOperacao ConsultarPorAluno(int pCodigoUsuario)
        {
            this._lancamentoContaOT = new LancamentoContaOT();

            this._lancamentoContaOT.Aluno.Codigo = pCodigoUsuario;

            base.ResultadoOperacao = this._lancamentoContaN.Consultar(this._lancamentoContaOT);

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta os lançamento por um período.
        /// </summary>
        /// <param name="pDataInicio"></param>
        /// <param name="pDataFim"></param>
        /// <returns>Retorna o resultado da operação.</returns>
        public ResultadoOperacao ConsultarPorPeriodo(DateTime pDataInicio, DateTime pDataFim)
        {
            this._lancamentoContaOT = new LancamentoContaOT();

            this._lancamentoContaOT.DataInicioLancamento = pDataInicio;
            this._lancamentoContaOT.DataFimLancamento = pDataFim;

            base.ResultadoOperacao = this._lancamentoContaN.Consultar(this._lancamentoContaOT);

            return base.ResultadoOperacao;
        }

        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._lancamentoContaOT = new LancamentoContaOT();

            this._lancamentoContaOT.Codigo = pCodigo;

            base.ResultadoOperacao = this._lancamentoContaN.Consultar(this._lancamentoContaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._lancamentoContaOT = new LancamentoContaOT();

            this._lancamentoContaOT.Nome = pNome;

            base.ResultadoOperacao = this._lancamentoContaN.Consultar(this._lancamentoContaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._lancamentoContaOT = new LancamentoContaOT();

            base.ResultadoOperacao = this._lancamentoContaN.Consultar(this._lancamentoContaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao = this._lancamentoContaN.Excluir(this._lancamentoContaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._lancamentoContaOT.Codigo == 0)
            {
                base.ResultadoOperacao = this._lancamentoContaN.Inserir(this._lancamentoContaOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao = this._lancamentoContaN.Alterar(this._lancamentoContaOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao;
        }

        #endregion

    }
}
