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
    /// Classe de negócio do País
    /// </summary>
    public class PaisN : BaseN, IAcaoN<PaisOT>
    {
        #region Construtores

        public PaisN() { }

        #endregion

        #region Atributos

        private PaisDAO _paisDAO = new PaisDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<PaisOT> Members

        public ResultadoOperacao Consultar(PaisOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._paisDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(PaisOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._paisDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(PaisOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._paisDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(PaisOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._paisDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
