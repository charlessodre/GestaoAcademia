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
    /// Classe de negócio de Recibo
    /// </summary>
    public class ReciboN : BaseN, IAcaoN<ReciboOT>
    {
        #region Construtores

        public ReciboN() { }

        #endregion

        #region Atributos

        private ReciboDAO _reciboDAO = new ReciboDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<ReciboOT> Members

        public ResultadoOperacao Consultar(ReciboOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._reciboDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(ReciboOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._reciboDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(ReciboOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._reciboDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(ReciboOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._reciboDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
