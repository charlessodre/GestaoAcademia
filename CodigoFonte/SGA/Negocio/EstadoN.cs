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
    /// Classe de negócio do Estado
    /// </summary>
    public class EstadoN : BaseN, IAcaoN<EstadoOT>
    {
        #region Construtores

        public EstadoN() { }

        #endregion

        #region Atributos

        private EstadoDAO _estadoDAO = new EstadoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<EstadoOT> Members

        public ResultadoOperacao Consultar(EstadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._estadoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(EstadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._estadoDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(EstadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._estadoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(EstadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._estadoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
