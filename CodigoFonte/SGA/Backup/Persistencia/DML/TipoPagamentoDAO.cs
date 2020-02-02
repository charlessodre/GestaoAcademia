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
    public class TipoPagamentoDAO : BaseDAO, IAcessoDados<TipoPagamentoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto TipoPagamentoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherTipoPagamentoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<TipoPagamentoOT> _tipoPagamentoList = new List<TipoPagamentoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    TipoPagamentoOT _tipoPagamentoOT = new TipoPagamentoOT();
                    //
                    _tipoPagamentoOT.Codigo = Convert.ToInt32(_item["CD_TIPO_PAGAMENTO"]);
                    _tipoPagamentoOT.Nome = _item["NM_TIPO_PAGAMENTO"].ToString();
                    _tipoPagamentoOT.Status = Enumeradores.ConverterStringStatus(_item["CD_STATUS_TIPO"].ToString());

                    //Dados do subtipo
                    if (!_item["CD_SUB_TIPO_PAGAMENTO"].Equals(DBNull.Value))
                    {
                        _tipoPagamentoOT.SubTipoPagamento.Codigo = Convert.ToInt32(_item["CD_SUB_TIPO_PAGAMENTO"]);
                        _tipoPagamentoOT.SubTipoPagamento.Nome = _item["NM_SUB_TIPO_PAGAMENTO"].ToString();
                        _tipoPagamentoOT.SubTipoPagamento.Status = Enumeradores.ConverterStringStatus(_item["CD_STATUS_SUB_TIPO"].ToString());
                    }
                    //Dados da forma de pagamento
                    _tipoPagamentoOT.CodigoFP = _item["CODIGO_FP"].ToString();
                    _tipoPagamentoOT.NomeFormaPagamento = _item["FORMA_PAGAMENTO"].ToString();

                    _tipoPagamentoList.Add(_tipoPagamentoOT);
                }

                pResultadoTransacao.ListaObjetos = _tipoPagamentoList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<TipoPagamentoOT> Members

        public ResultadoTransacao Select(TipoPagamentoOT pTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_TIPO_PAGAMENTO", base.TratarString(pTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_TIPO_PAGAMENTO", _parametrosList);

            return this.PreencherTipoPagamentoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(TipoPagamentoOT pTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_TIPO_PAGAMENTO", base.TratarString(pTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(TipoPagamentoOT pTipoPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_TIPO_PAGAMENTO", base.TratarString(pTipoPagamentoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(TipoPagamentoOT pTipoPagamentoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pTipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_TIPO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
