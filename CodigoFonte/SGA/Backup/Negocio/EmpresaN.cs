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
    /// Classe de negócio de Empresa
    /// </summary>
    public class EmpresaN : BaseN, IAcaoN<EmpresaOT>
    {
        #region Construtores

        public EmpresaN() { }

        #endregion

        #region Atributos

        private EmpresaDAO _empresaDAO = new EmpresaDAO();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region IAcaoN<EmpresaOT> Members

        public ResultadoOperacao Consultar(EmpresaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._empresaDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(EmpresaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._empresaDAO.Insert(pObjetoOT));
        }

        public ResultadoOperacao Alterar(EmpresaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._empresaDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(EmpresaOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._empresaDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
