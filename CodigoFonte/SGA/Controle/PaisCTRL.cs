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
    /// Classe de Controle do País.
    /// </summary>
    public class PaisCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public PaisCTRL()
        {
            this._paisOT = new PaisOT();
            this._paisN = new PaisN();
        }

        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pPaisOT">Objeto de transferência PaisOT</param>
        public PaisCTRL(PaisOT pPaisOT)
        {
            this._paisOT = pPaisOT;
            this._paisN = new PaisN();
        }

        #endregion

        #region Atributos

        private PaisN _paisN = null;
        private PaisOT _paisOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta um pais pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do pais</param>
        /// <param name="pStatus">Status do pais</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da pais</param>
        /// <param name="pStatus">Status do pais</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um pais pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do pais</param>
        /// <param name="pMatricula">Código do pais</param>
        /// <param name="pStatus">Status do pais</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._paisOT = new PaisOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._paisOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._paisOT.Codigo = pCodigo;
            }

            this._paisOT.Status = pStatus;

            base.ResultadoOperacao = this._paisN.Consultar(this._paisOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o pais pelo status.
        /// </summary>
        /// <param name="pStatus">Status do pais</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._paisOT = new PaisOT();

            this._paisOT.Status = pStatus;

            base.ResultadoOperacao = this._paisN.Consultar(this._paisOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion


        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {

            this._paisOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._paisN.Consultar(this._paisOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._paisOT.Nome = pNome;

            base.ResultadoOperacao  = this._paisN.Consultar(this._paisOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._paisOT = new PaisOT();

            base.ResultadoOperacao  = this._paisN.Consultar(this._paisOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._paisN.Excluir(this._paisOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._paisOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._paisN.Inserir(this._paisOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._paisN.Alterar(this._paisOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
