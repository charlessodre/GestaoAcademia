using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcessoDados.DML;
using ObjetoOT;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;

namespace PersistenciaDAO.DML
{
    public class CidadeDAO : BaseDAO, IAcessoDados<CidadeOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto CidadeOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherCidadeOT(ResultadoTransacao pResultadoTransacao)
        {
            List<CidadeOT> _cidadeList = new List<CidadeOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    CidadeOT _cidadeOT = new CidadeOT();
                    //
                    _cidadeOT.Codigo = Convert.ToInt32(_item["CD_CIDADE"]);
                    _cidadeOT.Nome = _item["NM_CIDADE"].ToString();

                    _cidadeList.Add(_cidadeOT);
                }

                pResultadoTransacao.ListaObjetos = _cidadeList;
            }
            return pResultadoTransacao ;
        }

        #endregion

        #region IAcessoDados<CidadeOT> Members

        public ResultadoTransacao Select(CidadeOT pCidadeOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pCidadeOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_CIDADE", base.TratarString(pCidadeOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_CIDADE", _parametrosList);

            return this.PreencherCidadeOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(CidadeOT pCidadeOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_CIDADE", base.TratarString(pCidadeOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_CIDADE", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(CidadeOT pCidadeOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pCidadeOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_CIDADE", base.TratarString(pCidadeOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_CIDADE", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(CidadeOT pCidadeOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pCidadeOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_CIDADE", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
