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
    /// Classe de negócio de TipoPagamento
    /// </summary>
    public class TipoPagamentoN : BaseN, IAcaoN<TipoPagamentoOT>
    {
        #region Construtores

        public TipoPagamentoN() { }

        #endregion

        #region Atributos

        private TipoPagamentoDAO _tipoPagamentoDAO = new TipoPagamentoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<TipoPagamentoOT> Members

        public ResultadoOperacao Consultar(TipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._tipoPagamentoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(TipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._tipoPagamentoDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(TipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._tipoPagamentoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(TipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._tipoPagamentoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
