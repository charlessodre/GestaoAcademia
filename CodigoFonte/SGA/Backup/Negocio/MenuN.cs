using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using PersistenciaDAO.DML;
using PersistenciaDAO;
using Utilitarios;
using Comum;

namespace Negocio
{
    /// <summary>
    /// Classe de Negócio Menu. Mantêm as regra dos _menusList.
    /// </summary>
    public class MenuN : BaseN, IAcaoN<MenuOT>
    {
        #region Construtores

        public MenuN() { }

        #endregion

        #region Atributos

        private MenuDAO _menuDAO = new MenuDAO();

        #endregion

        #region Propriedades


        #endregion

        #region Métodos
      
        #endregion

        #region IAcaoN<MenuOT> Members

        public ResultadoOperacao Consultar(MenuOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._menuDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(MenuOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._menuDAO.Insert(pObjetoOT));
        }

        public ResultadoOperacao Alterar(MenuOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._menuDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(MenuOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._menuDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
