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
    /// Classe de Controle da Cidade.
    /// </summary>
    public class CidadeCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public CidadeCTRL()
        {
            this._cidadeOT = new CidadeOT();
            this._cidadeN = new CidadeN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pCidadeOT">Objeto de transferência CidadeOT</param>
        public CidadeCTRL(CidadeOT pCidadeOT)
        {
            this._cidadeOT = pCidadeOT;
            this._cidadeN = new CidadeN();
        }

        #endregion

        #region Atributos

        private CidadeN _cidadeN = null;
        private CidadeOT _cidadeOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta um cidade pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do cidade</param>
        /// <param name="pStatus">Status do cidade</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da cidade</param>
        /// <param name="pStatus">Status do cidade</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um cidade pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do cidade</param>
        /// <param name="pMatricula">Código do cidade</param>
        /// <param name="pStatus">Status do cidade</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._cidadeOT = new CidadeOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._cidadeOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._cidadeOT.Codigo = pCodigo;
            }

            this._cidadeOT.Status = pStatus;

            base.ResultadoOperacao = this._cidadeN.Consultar(this._cidadeOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o cidade pelo status.
        /// </summary>
        /// <param name="pStatus">Status do cidade</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._cidadeOT = new CidadeOT();

            this._cidadeOT.Status = pStatus;

            base.ResultadoOperacao = this._cidadeN.Consultar(this._cidadeOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._cidadeOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._cidadeN.Consultar(this._cidadeOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._cidadeOT.Nome = pNome;

            base.ResultadoOperacao  = this._cidadeN.Consultar(this._cidadeOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._cidadeOT = new CidadeOT();

            base.ResultadoOperacao  = this._cidadeN.Consultar(this._cidadeOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._cidadeN.Excluir(this._cidadeOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._cidadeOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._cidadeN.Inserir(this._cidadeOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._cidadeN.Alterar(this._cidadeOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
