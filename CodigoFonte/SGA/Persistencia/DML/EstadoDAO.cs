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
    public class EstadoDAO : BaseDAO, IAcessoDados<EstadoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto EstadoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Estados</returns>
        private ResultadoTransacao PreencherEstadoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<EstadoOT> _estadoList = new List<EstadoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    EstadoOT _estadoOT = new EstadoOT();
                    //
                    _estadoOT.Codigo = Convert.ToInt32(_item["CD_ESTADO"]);
                    _estadoOT.Nome = _item["NM_ESTADO"].ToString();
                    _estadoOT.Sigla = _item["DS_SIGLA"].ToString();

                    _estadoList.Add(_estadoOT);
                }

                pResultadoTransacao.ListaObjetos = _estadoList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<EstadoOT> Members

        public ResultadoTransacao Select(EstadoOT pEstadoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEstadoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_ESTADO", base.TratarString(pEstadoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pEstadoOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_ESTADO", _parametrosList);

            return this.PreencherEstadoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(EstadoOT pEstadoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_ESTADO", base.TratarString(pEstadoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pEstadoOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_ESTADO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(EstadoOT pEstadoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEstadoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_ESTADO", base.TratarString(pEstadoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pEstadoOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_ESTADO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(EstadoOT pEstadoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEstadoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_ESTADO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
