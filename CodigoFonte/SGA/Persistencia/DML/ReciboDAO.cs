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
    public class ReciboDAO : BaseDAO, IAcessoDados<ReciboOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto ReciboOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação</returns>
        private ResultadoTransacao PreencherReciboOT(ResultadoTransacao pResultadoTransacao)
        {
            List<ReciboOT> _reciboList = new List<ReciboOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    ReciboOT _reciboOT = new ReciboOT();
                    //
                    _reciboOT.Codigo = Convert.ToInt32(_item["CD_RECIBO_PAGAMENTO"]);
                    _reciboOT.CodigoLancamentoConta = Convert.ToInt32(_item["CD_LANCAMENTO_CONTA"]);

                    _reciboList.Add(_reciboOT);
                }

                pResultadoTransacao.ListaObjetos = _reciboList;
            }
            return pResultadoTransacao ;
        }

        #endregion

        #region IAcessoDados<ReciboOT> Members

        public ResultadoTransacao Select(ReciboOT pReciboOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_RECIBO_PAGAMENTO", base.TratarNumero(pReciboOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pReciboOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_RECIBO_PAGAMENTO", _parametrosList);

            return this.PreencherReciboOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(ReciboOT pReciboOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pReciboOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_INSERIR_RECIBO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(ReciboOT pReciboOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_RECIBO_PAGAMENTO", base.TratarNumero(pReciboOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pReciboOT.CodigoLancamentoConta), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_RECIBO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(ReciboOT pReciboOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_RECIBO_PAGAMENTO", base.TratarNumero(pReciboOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_RECIBO_PAGAMENTO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
