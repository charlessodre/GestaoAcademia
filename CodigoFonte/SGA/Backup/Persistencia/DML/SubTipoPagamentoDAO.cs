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
    public class SubTipoPagamentoDAO : BaseDAO, IAcessoDados<SubTipoPagamentoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto SubTipoPagamentoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherSubTipoPagamentoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<SubTipoPagamentoOT> _subTipoPagamentoList = new List<SubTipoPagamentoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    SubTipoPagamentoOT _subTipoPagamentoOT = new SubTipoPagamentoOT();
                    //
                    _subTipoPagamentoOT.Codigo = Convert.ToInt32(_item["CD_SUB_TIPO_PAGAMENTO"]);
                    _subTipoPagamentoOT.Nome = _item["NM_SUB_TIPO_PAGAMENTO"].ToString();

                    _subTipoPagamentoList.Add(_subTipoPagamentoOT);
                }

                pResultadoTransacao.ListaObjetos = _subTipoPagamentoList;
            }
            return pResultadoTransacao ;
        }

        #endregion

        #region IAcessoDados<SubTipoPagamentoOT> Members

        public ResultadoTransacao Select(SubTipoPagamentoOT pSubTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pSubTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_SUB_TIPO_PAGAMENTO", base.TratarString(pSubTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_SUB_TIPO_PAGAMENTO", _parametrosList);

            return this.PreencherSubTipoPagamentoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(SubTipoPagamentoOT pSubTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_SUB_TIPO_PAGAMENTO", base.TratarString(pSubTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_SUB_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(SubTipoPagamentoOT pSubTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pSubTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_SUB_TIPO_PAGAMENTO", base.TratarString(pSubTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_SUB_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(SubTipoPagamentoOT pSubTipoPagamentoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pSubTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_SUB_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
