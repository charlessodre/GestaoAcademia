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
    /// Classe de negócio de Profissao
    /// </summary>
    public class ProfissaoN : BaseN, IAcaoN<ProfissaoOT>
    {
        #region Construtores

        public ProfissaoN() { }

        #endregion

        #region Atributos

        private ProfissaoDAO _profissaoDAO = new ProfissaoDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        
        #endregion

        #region IAcaoN<ProfissaoOT> Members

        public ResultadoOperacao Consultar(ProfissaoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._profissaoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(ProfissaoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._profissaoDAO.Insert(pObjetoOT)); 
        }

        public ResultadoOperacao Alterar(ProfissaoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._profissaoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(ProfissaoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._profissaoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
