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
    /// Classe de Controle do Menu do Grupo de Usuário.
    /// </summary>
    public class MenuGrupoUsuarioCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe. 
        /// </summary>
        public MenuGrupoUsuarioCTRL()
        {
        }

        /// <summary>
        /// Construtor da classe. 
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOT">Objeto de Transferência MenuGrupoUsuario</param>
        public MenuGrupoUsuarioCTRL(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            this._menuGrupoUsuarioOT = pMenuGrupoUsuarioOT;
        }

        #endregion

        #region Atributos

        private MenuGrupoUsuarioN _menuGrupoUsuarioN = new MenuGrupoUsuarioN();
        private MenuGrupoUsuarioOT _menuGrupoUsuarioOT = null;

        #endregion

        #region Propriedades


        #endregion

        #region Métodos

        /// <summary>
        /// Inserir uma lista de MenuGrupoUsuario
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOTList">Lista de Objetos Transferência MenuGrupoUsuario</param>
        public ResultadoOperacao InserirLista(List<MenuGrupoUsuarioOT> pMenuGrupoUsuarioOTList)
        {
            base.ResultadoOperacao  = this._menuGrupoUsuarioN.InserirLista(pMenuGrupoUsuarioOTList);

            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;

            return base.ResultadoOperacao ;

        }

        /// <summary>
        /// Consulta os Menus do Grupo de Usuário.
        /// </summary>
        /// <param name="pCodigoGrupoUsuario">Código do Grupo do Usuário</param>
        /// <returns>Retorna a lista dos menus do grupo de usuário.</returns>
        public ResultadoOperacao ConsultarMenus(int pCodigoGrupoUsuario)
        {
            this._menuGrupoUsuarioOT = new MenuGrupoUsuarioOT();
            this._menuGrupoUsuarioOT.CodigoGrupoUsuario = pCodigoGrupoUsuario;

            base.ResultadoOperacao  = this._menuGrupoUsuarioN.ConsultarMenus(this._menuGrupoUsuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            throw new NotImplementedException();
        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            throw new NotImplementedException();
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public override ResultadoOperacao Excluir()
        {
            throw new NotImplementedException();
        }

        public override ResultadoOperacao Salvar()
        {
            throw new NotImplementedException();
        }

        #endregion





    }
}
