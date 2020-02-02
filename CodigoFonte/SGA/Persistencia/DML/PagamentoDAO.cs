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
    public class PagamentoDAO : BaseDAO, IAcessoDados<PagamentoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto PagamentoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherPagamentoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<PagamentoOT> _pagamentoList = new List<PagamentoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    PagamentoOT _pagamentoOT = new PagamentoOT();
                    //
                    _pagamentoOT.Codigo = Convert.ToInt32(_item["CD_PAGAMENTO"]);
                    _pagamentoOT.DataPagamento = Convert.ToDateTime(_item["DT_PAGAMENTO"]);
                    _pagamentoOT.Descricao = _item["DS_PAGAMENTO"].ToString();

                    if (!_item["QTD_PARCELAS"].Equals(DBNull.Value))
                    {
                        _pagamentoOT.QuantidadeParcelas = Convert.ToInt32(_item["QTD_PARCELAS"]);
                    }

                    if (!_item["VL_PAGAMENTO"].Equals(DBNull.Value))
                    {
                        _pagamentoOT.ValorPagamento = Convert.ToDecimal(_item["VL_PAGAMENTO"]);
                    }

                    if (!_item["VL_PARCELA"].Equals(DBNull.Value))
                    {
                        _pagamentoOT.ValorParcela = Convert.ToDecimal(_item["VL_PARCELA"]);
                    }
                  
                    if (!_item["BL_TROCA"].Equals(DBNull.Value))
                    {
                        _pagamentoOT.Troca = Convert.ToBoolean(_item["BL_TROCA"]);
                    }

                    _pagamentoOT.Observacao = _item["DS_OBSERVACAO"].ToString();
                    
                    //Tipo do Pagamento.
                    _pagamentoOT.TipoPagamentoOT.Codigo = Convert.ToInt32(_item["CD_TIPO_PAGAMENTO"]);
                    _pagamentoOT.TipoPagamentoOT.Nome = _item["NM_TIPO_PAGAMENTO"].ToString();
                    _pagamentoOT.TipoPagamentoOT.CodigoFP = _item["CODIGO_FP"].ToString();

                    //SubTipo do Pagamento.
                    if (!_item["CD_SUB_TIPO_PAGAMENTO"].Equals(DBNull.Value))
                    {
                        _pagamentoOT.SubTipoPagamento.Codigo = Convert.ToInt32(_item["CD_SUB_TIPO_PAGAMENTO"]);
                        _pagamentoOT.Nome = _item["NM_SUB_TIPO_PAGAMENTO"].ToString();
                    }
                    
                    _pagamentoList.Add(_pagamentoOT);
                }

                pResultadoTransacao.ListaObjetos = _pagamentoList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<PagamentoOT> Members

        public ResultadoTransacao Select(PagamentoOT pPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAGAMENTO", base.TratarNumero(pPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.TipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.SubTipoPagamento.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_PAGAMENTO", base.TratarData(pPagamentoOT.DataPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DS_PAGAMENTO", base.TratarString(pPagamentoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_QTD_PARCELAS", base.TratarNumero(pPagamentoOT.QuantidadeParcelas), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PAGAMENTO", base.TratarDecimal(pPagamentoOT.ValorPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PARCELA", base.TratarDecimal(pPagamentoOT.ValorParcela), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_BL_TROCA", base.TratarBooleano(pPagamentoOT.Troca), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pPagamentoOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pPagamentoOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));


            _informacaoTransacao.SetProcedure("STP_CONSULTAR_PAGAMENTO", _parametrosList);

            return this.PreencherPagamentoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(PagamentoOT pPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.TipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.SubTipoPagamento.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_PAGAMENTO", base.TratarData(pPagamentoOT.DataPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DS_PAGAMENTO", base.TratarString(pPagamentoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_QTD_PARCELAS", base.TratarNumero(pPagamentoOT.QuantidadeParcelas), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PAGAMENTO", base.TratarDecimal(pPagamentoOT.ValorPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PARCELA", base.TratarDecimal(pPagamentoOT.ValorParcela), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_BL_TROCA", base.TratarBooleano(pPagamentoOT.Troca), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pPagamentoOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pPagamentoOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_PAGAMENTO", base.TratarNumero(pPagamentoOT.UsuarioPagamento.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            
            _informacaoTransacao.SetProcedure("STP_INSERIR_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(PagamentoOT pPagamentoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PAGAMENTO", base.TratarNumero(pPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.TipoPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SUB_TIPO_PAGAMENTO", base.TratarNumero(pPagamentoOT.SubTipoPagamento.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_PAGAMENTO", base.TratarData(pPagamentoOT.DataPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DS_PAGAMENTO", base.TratarString(pPagamentoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_QTD_PARCELAS", base.TratarNumero(pPagamentoOT.QuantidadeParcelas), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PAGAMENTO", base.TratarDecimal(pPagamentoOT.ValorPagamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_VL_PARCELA", base.TratarDecimal(pPagamentoOT.ValorParcela), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_BL_TROCA", base.TratarBooleano(pPagamentoOT.Troca), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pPagamentoOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pPagamentoOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(PagamentoOT pPagamentoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PAGAMENTO", base.TratarNumero(pPagamentoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
