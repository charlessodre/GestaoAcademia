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
    /// Classe de Controle do Grupo de Usuário.
    /// </summary>
    public class GrupoUsuarioCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public GrupoUsuarioCTRL()
        {
            this._grupoUsuarioN = new GrupoUsuarioN();
            this._grupoUsuarioOT = new GrupoUsuarioOT();
        }

        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pGrupoUsuarioOT">Objeto de transferência GrupoUsuarioOT</param>
        public GrupoUsuarioCTRL(GrupoUsuarioOT pGrupoUsuarioOT)
        {
            this._grupoUsuarioOT = pGrupoUsuarioOT;
            this._grupoUsuarioN = new GrupoUsuarioN();
        }

        #endregion

        #region Atributos

        private GrupoUsuarioN _grupoUsuarioN = null;
        private GrupoUsuarioOT _grupoUsuarioOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta um Grupo pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        /// <param name="pStatus">Status do Grupo</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome do grupo</param>
        /// <param name="pStatus">Status do grupo</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Grupo pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Grupo</param>
        /// <param name="pMatricula">Código do Grupo</param>
        /// <param name="pStatus">Status do Grupo</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._grupoUsuarioOT = new GrupoUsuarioOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._grupoUsuarioOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._grupoUsuarioOT.Codigo = pCodigo;
            }

            this._grupoUsuarioOT.Status = pStatus;

            base.ResultadoOperacao = this._grupoUsuarioN.Consultar(this._grupoUsuarioOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o Grupo pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Grupo</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._grupoUsuarioOT = new GrupoUsuarioOT();

            this._grupoUsuarioOT.Status = pStatus;

            base.ResultadoOperacao = this._grupoUsuarioN.Consultar(this._grupoUsuarioOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._grupoUsuarioOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._grupoUsuarioN.Consultar(this._grupoUsuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._grupoUsuarioOT.Nome = pNome;

            base.ResultadoOperacao  = this._grupoUsuarioN.Consultar(this._grupoUsuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            base.ResultadoOperacao  = this._grupoUsuarioN.Consultar(this._grupoUsuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._grupoUsuarioN.Excluir(this._grupoUsuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._grupoUsuarioOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._grupoUsuarioN.Inserir(this._grupoUsuarioOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._grupoUsuarioN.Alterar(this._grupoUsuarioOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
