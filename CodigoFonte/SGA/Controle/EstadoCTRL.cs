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
    /// Classe de Controle do Estado.
    /// </summary>
    public class EstadoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public EstadoCTRL()
        {
            this._estadoOT = new EstadoOT();
            this._estadoN = new EstadoN();
        }

        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pEstadoOT">Objeto de transferência EstadoOT</param>
        public EstadoCTRL(EstadoOT pEstadoOT)
        {
            this._estadoOT = pEstadoOT;
            this._estadoN = new EstadoN();
        }

        #endregion

        #region Atributos

        private EstadoN _estadoN = null;
        private EstadoOT _estadoOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta um Estado pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do Estado</param>
        /// <param name="pStatus">Status do Estado</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da Estado</param>
        /// <param name="pStatus">Status do Estado</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Estado pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Estado</param>
        /// <param name="pMatricula">Código do Estado</param>
        /// <param name="pStatus">Status do Estado</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._estadoOT = new EstadoOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._estadoOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._estadoOT.Codigo = pCodigo;
            }

            this._estadoOT.Status = pStatus;

            base.ResultadoOperacao = this._estadoN.Consultar(this._estadoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o Estado pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Estado</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._estadoOT = new EstadoOT();

            this._estadoOT.Status = pStatus;

            base.ResultadoOperacao = this._estadoN.Consultar(this._estadoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._estadoOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._estadoN.Consultar(this._estadoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._estadoOT.Nome = pNome;

            base.ResultadoOperacao  = this._estadoN.Consultar(this._estadoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._estadoOT = new EstadoOT();

            base.ResultadoOperacao  = this._estadoN.Consultar(this._estadoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._estadoN.Excluir(this._estadoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._estadoOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._estadoN.Inserir(this._estadoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._estadoN.Alterar(this._estadoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
