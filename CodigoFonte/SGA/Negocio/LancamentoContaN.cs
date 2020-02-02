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
    /// Classe de negócio de LancamentoConta
    /// </summary>
    public class LancamentoContaN : BaseN, IAcaoN<LancamentoContaOT>
    {
        #region Construtores

        public LancamentoContaN() { }

        #endregion

        #region Atributos

        private LancamentoContaDAO _lancamentoContaDAO = new LancamentoContaDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        #endregion

        #region IAcaoN<LancamentoContaOT> Members

        public ResultadoOperacao Consultar(LancamentoContaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._lancamentoContaDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(LancamentoContaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._lancamentoContaDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(LancamentoContaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._lancamentoContaDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(LancamentoContaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._lancamentoContaDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
