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
    /// Classe de negócio de Pagamento
    /// </summary>
    public class PagamentoN : BaseN, IAcaoN<PagamentoOT>
    {
        #region Construtores

        public PagamentoN() { }

        #endregion

        #region Atributos

        private PagamentoDAO _PagamentoDAO = new PagamentoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region IAcaoN<PagamentoOT> Members

        public ResultadoOperacao Consultar(PagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._PagamentoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(PagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._PagamentoDAO.Insert(pObjetoOT));
        }

        public ResultadoOperacao Alterar(PagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._PagamentoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(PagamentoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._PagamentoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
