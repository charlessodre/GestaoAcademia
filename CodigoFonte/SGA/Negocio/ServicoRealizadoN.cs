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
    /// Classe de negócio de ServicoRealizado
    /// </summary>
    public class ServicoRealizadoN : BaseN, IAcaoN<ServicoRealizadoOT>
    {
        #region Construtores

        public ServicoRealizadoN() { }

        #endregion

        #region Atributos

        private ServicoRealizadoDAO _servicoDAO = new ServicoRealizadoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<ServicoOT> Members

        public ResultadoOperacao Consultar(ServicoRealizadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._servicoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(ServicoRealizadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._servicoDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(ServicoRealizadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._servicoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(ServicoRealizadoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._servicoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
