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
    /// Classe de negócio de Cidade
    /// </summary>
    public class CidadeN : BaseN, IAcaoN<CidadeOT>
    {
        #region Construtores

        public CidadeN() { }

        #endregion

        #region Atributos

        private CidadeDAO _cidadeDAO = new CidadeDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<CidadeOT> Members

        public ResultadoOperacao Consultar(CidadeOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._cidadeDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(CidadeOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._cidadeDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(CidadeOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._cidadeDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(CidadeOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._cidadeDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
