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
    /// Classe de Controle do Menu
    /// </summary>
    public class MenuCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe. 
        /// </summary>
        public MenuCTRL()
        {
        }


        /// <summary>
        /// Construtor da classe. 
        /// </summary>
        /// <param name="pMenuOT">Objeto de Transferência Menu</param>
        public MenuCTRL(MenuOT pMenuOT)
        {
            this._menuOT = pMenuOT;
        }

        #endregion

        #region Atributos

        private MenuN _menuN = new MenuN();
        private MenuOT _menuOT;


        #endregion

        #region Propriedades


        #endregion

        #region Métodos

        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._menuOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._menuN.Consultar(this._menuOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._menuOT.Nome = pNome;

            base.ResultadoOperacao  = this._menuN.Consultar(this._menuOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._menuOT = new MenuOT();

            base.ResultadoOperacao  = this._menuN.Consultar(this._menuOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._menuN.Excluir(this._menuOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._menuOT.Codigo == 0)
            {
                base.ResultadoOperacao  = this._menuN.Inserir(this._menuOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._menuN.Alterar(this._menuOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
