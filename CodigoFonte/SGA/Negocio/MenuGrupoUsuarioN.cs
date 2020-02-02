using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using PersistenciaDAO.DML;
using Utilitarios;
using Comum;

namespace Negocio
{
    /// <summary>
    ///  Classe de negócio do Menu do Grupo de Usuário
    /// </summary>
    public class MenuGrupoUsuarioN : BaseN, IAcaoN<MenuGrupoUsuarioOT>
    {
        #region Construtores


        #endregion

        #region Atributos

        private MenuGrupoUsuarioDAO _menuGrupoUsuarioDAO = new MenuGrupoUsuarioDAO();

        #endregion

        #region Propriedades


        #endregion

        #region Métodos

        /// <summary>
        /// Inserir uma lista de MenuGrupoUsuario
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOTList">Lista de Objetos Transferência MenuGrupoUsuario</param>
        /// <returns>Retorna o resultado da operação.</returns>
        public ResultadoOperacao InserirLista(List<MenuGrupoUsuarioOT> pMenuGrupoUsuarioOTList)
        {
            return base.TratarRetornoOperacao(this._menuGrupoUsuarioDAO.InsertList(pMenuGrupoUsuarioOTList));
        }

        /// <summary>
        /// Consulta os Menus do Grupo de Usuário.
        /// </summary>
        /// <param name="pObjetoOT">Objeto MenuGrupoUsuarioOT</param>
        /// <returns>Retorna a lista dos menus do grupo de usuário.</returns>
        public ResultadoOperacao ConsultarMenus(MenuGrupoUsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._menuGrupoUsuarioDAO.SelectMenus(pObjetoOT));
        }

        #endregion

        #region IAcaoN<MenuGrupoUsuarioOT> Members

        public ResultadoOperacao Consultar(MenuGrupoUsuarioOT pObjetoOT)
        {
            throw new NotImplementedException();
        }

        public ResultadoOperacao Inserir(MenuGrupoUsuarioOT pObjetoOT)
        {
            return  base.TratarRetornoOperacao(this._menuGrupoUsuarioDAO.Insert(pObjetoOT));
        }

        public ResultadoOperacao Alterar(MenuGrupoUsuarioOT pObjetoOT)
        {
            return  base.TratarRetornoOperacao(this._menuGrupoUsuarioDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(MenuGrupoUsuarioOT pObjetoOT)
        {
           return  base.TratarRetornoOperacao(this._menuGrupoUsuarioDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
