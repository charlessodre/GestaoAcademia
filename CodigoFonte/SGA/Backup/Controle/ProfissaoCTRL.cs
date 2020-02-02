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
    /// Classe de Controle da Profissao.
    /// </summary>
    public class ProfissaoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public ProfissaoCTRL()
        {
            this._profissaoOT = new ProfissaoOT();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pProfissaoOT">Objeto de transferência ProfissaoOT</param>
        public ProfissaoCTRL(ProfissaoOT pProfissaoOT)
        {
            this._profissaoOT = pProfissaoOT;
        }

        #endregion

        #region Atributos

        private ProfissaoN _profissaoN = new ProfissaoN();
        private ProfissaoOT _profissaoOT = null;
        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta um Profissao pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do Profissao</param>
        /// <param name="pStatus">Status do Profissao</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da Profissao</param>
        /// <param name="pStatus">Status do Profissao</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Profissao pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Profissao</param>
        /// <param name="pMatricula">Código do Profissao</param>
        /// <param name="pStatus">Status do Profissao</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._profissaoOT = new ProfissaoOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._profissaoOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._profissaoOT.Codigo = pCodigo;
            }

            this._profissaoOT.Status = pStatus;

            base.ResultadoOperacao = this._profissaoN.Consultar(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o Profissao pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Profissao</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._profissaoOT = new ProfissaoOT();

            this._profissaoOT.Status = pStatus;

            base.ResultadoOperacao = this._profissaoN.Consultar(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._profissaoOT.Codigo = pCodigo;

            base.ResultadoOperacao = this._profissaoN.Consultar(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._profissaoOT.Nome = pNome;

            base.ResultadoOperacao = this._profissaoN.Consultar(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._profissaoOT = new ProfissaoOT();

            base.ResultadoOperacao = this._profissaoN.Consultar(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao = this._profissaoN.Excluir(this._profissaoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._profissaoOT.Codigo == 0)
            {
                base.ResultadoOperacao = this._profissaoN.Inserir(this._profissaoOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao = this._profissaoN.Alterar(this._profissaoOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao;
        }

        #endregion

    }
}
