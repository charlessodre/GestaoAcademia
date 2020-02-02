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
    /// Classe de negócio de SubTipoPagamento
    /// </summary>
    public class SubTipoPagamentoN : BaseN, IAcaoN<SubTipoPagamentoOT>
    {
        #region Construtores

        public SubTipoPagamentoN() { }

        #endregion

        #region Atributos

        private SubTipoPagamentoDAO _subTipoPagamentoDAO = new SubTipoPagamentoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<SubTipoPagamentoOT> Members

        public ResultadoOperacao Consultar(SubTipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._subTipoPagamentoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(SubTipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._subTipoPagamentoDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(SubTipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._subTipoPagamentoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(SubTipoPagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._subTipoPagamentoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
