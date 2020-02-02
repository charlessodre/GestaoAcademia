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
    public class ServicoRealizadoDAO : BaseDAO, IAcessoDados<ServicoRealizadoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto ServicoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherServicoRealizadoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<ServicoRealizadoOT> _servicoList = new List<ServicoRealizadoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    ServicoRealizadoOT _servicoOT = new ServicoRealizadoOT();
                    //
                    _servicoOT.Codigo = Convert.ToInt32(_item["CD_SERVICO"]);
                    _servicoOT.Nome = _item["NM_SERVICO"].ToString();
                    _servicoOT.Descricao = _item["DS_SERVICO"].ToString();
                    _servicoOT.Status = Enumeradores.ConverterShortStatus(Convert.ToInt16(_item["CD_STATUS"]));

                    _servicoList.Add(_servicoOT);
                }

                pResultadoTransacao.ListaObjetos = _servicoList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<ServicoOT> Members

        public ResultadoTransacao Select(ServicoRealizadoOT pServicoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pServicoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_SERVICO", base.TratarString(pServicoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pServicoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SERVICO", base.TratarString(pServicoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));


            _informacaoTransacao.SetProcedure("STP_CONSULTAR_SERVICO", _parametrosList);

            return this.PreencherServicoRealizadoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(ServicoRealizadoOT pServicoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_SERVICO", base.TratarString(pServicoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pServicoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SERVICO", base.TratarString(pServicoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_SERVICO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(ServicoRealizadoOT pServicoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pServicoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_SERVICO", base.TratarString(pServicoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pServicoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SERVICO", base.TratarString(pServicoOT.Descricao), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_SERVICO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(ServicoRealizadoOT pServicoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pServicoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_SERVICO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
