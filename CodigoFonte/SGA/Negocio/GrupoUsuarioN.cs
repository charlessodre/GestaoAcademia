using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaDAO;
using ObjetoOT;
using PersistenciaDAO.DML;
using Utilitarios;
using Comum;

namespace Negocio
{
    /// <summary>
    /// Classe de negócio do Grupo de Usuário
    /// </summary>
    public class GrupoUsuarioN : BaseN, IAcaoN<GrupoUsuarioOT>
    {
        #region Construtores

        public GrupoUsuarioN() { }

        #endregion

        #region Atributos

        private IAcessoDados<GrupoUsuarioOT> _grupoUsuarioDAO = new GrupoUsuarioDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<GrupoUsuario> Members

        public ResultadoOperacao Consultar(GrupoUsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._grupoUsuarioDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(GrupoUsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._grupoUsuarioDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(GrupoUsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._grupoUsuarioDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(GrupoUsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._grupoUsuarioDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
