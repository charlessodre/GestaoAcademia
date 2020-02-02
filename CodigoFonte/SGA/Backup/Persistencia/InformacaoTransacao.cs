using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PersistenciaDAO
{
    public class InformacaoTransacao
    {
        #region Construtores

        public InformacaoTransacao()
        {

        }

        #endregion

        #region Atributos

        private TipoTransacao tipoTransacao;
        private string transacao;
       // private ResultadoTransacao resultadoTrasacao = null;
        private List<SqlParameter>_parametrosList;
        private CommandType tipoComando = CommandType.StoredProcedure;

        #endregion

        #region Propriedades

        //internal ResultadoTransacao ResultadoTransacao
        //{
        //    get { return this.resultadoTrasacao; }
        //}

        private CommandType TipoComando
        {
            get { return this.tipoComando; }

        }

        internal string nomeTransacao
        {
            get { return this.transacao; }
        }

        internal TipoTransacao TipoTransacao
        {
            get { return this.tipoTransacao; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// ObterParametrosSaida
        /// </summary>
        /// <param name="pSqlCommand"></param>
        /// <returns></returns>
        internal DataSet ObterParametrosSaida(SqlCommand pSqlCommand)
        {
            DataSet dataSetParametos = new DataSet("Parametros");
            DataTable dataTableParametros = new DataTable("Tabela_Parametros");
            //
            dataTableParametros.Columns.Add("Nome");
            dataTableParametros.Columns.Add("Valor");
            //
            foreach (SqlParameter sqlParameterItem in pSqlCommand.Parameters)
            {
                if ((sqlParameterItem.Direction == ParameterDirection.Output) || (sqlParameterItem.Direction == ParameterDirection.InputOutput))
                {
                    dataTableParametros.Rows.Add(new object[] { sqlParameterItem.ParameterName, sqlParameterItem.Value });
                }
            }
            dataSetParametos.Tables.Add(dataTableParametros);
            //
            return dataSetParametos;
        }

        /// <summary>
        /// ObterSqlCommand
        /// </summary>
        /// <returns></returns>
        internal SqlCommand ObterSqlCommand()
        {
            if (this.tipoTransacao == TipoTransacao.Procedure)
            {
                return this.ObterSqlCommandSP();
            }
            else
            {
                return this.ObterSqlCommandSQL();
            }
        }

        /// <summary>
        /// ObterSqlCommandSQL
        /// </summary>
        /// <returns></returns>
        private SqlCommand ObterSqlCommandSQL()
        {
            SqlCommand sqlCommand = new SqlCommand(this.transacao);

            this.tipoComando = CommandType.Text;
            sqlCommand.CommandType = this.TipoComando;

            return sqlCommand;
        }

        /// <summary>
        /// ObterSqlCommandSP
        /// </summary>
        /// <returns></returns>
        private SqlCommand ObterSqlCommandSP()
        {
            SqlCommand sqlCommand = new SqlCommand(this.transacao);
            SqlParameter sqlParameter = null;

            this.tipoComando = CommandType.StoredProcedure;

            foreach (SqlParameter sqlParameterItem in this._parametrosList)
            {
                sqlParameter = sqlCommand.Parameters.AddWithValue(sqlParameterItem.ParameterName, sqlParameterItem.Value);
                sqlParameter.Direction = sqlParameterItem.Direction;
            }

            sqlCommand.CommandType = this.tipoComando;

            return sqlCommand;
        }
              
        /// <summary>
        /// SetDelete
        /// </summary>
        /// <param name="pSql"></param>
        public void SetDelete(string pSql)
        {
            this.SetTransaction(pSql, null, TipoTransacao.Delete);
        }

        /// <summary>
        /// SetSelect
        /// </summary>
        /// <param name="pSql"></param>
        public void SetSelect(string pSql)
        {
            this.SetTransaction(pSql, null, TipoTransacao.Select);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetInsert(string pSql)
        {
            this.SetTransaction(pSql, null, TipoTransacao.Insert);
        }

        /// <summary>
        /// SetUpdate
        /// </summary>
        /// <param name="pSql"></param>
        public void SetUpdate(string pSql)
        {
            this.SetTransaction(pSql, null, TipoTransacao.Update);
        }

        /// <summary>
        /// SetSelect
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetSelect(string pSql, List<SqlParameter>pSqlParameterList)
        {
            this.SetTransaction(pSql, pSqlParameterList, TipoTransacao.Select);
        }

        /// <summary>
        /// SetUpdate
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetUpdate(string pSql, List<SqlParameter>pSqlParameterList)
        {
            this.SetTransaction(pSql, pSqlParameterList, TipoTransacao.Update);
        }

        /// <summary>
        /// SetDelete
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetDelete(string pSql, List<SqlParameter>pSqlParameterList)
        {
            this.SetTransaction(pSql, pSqlParameterList, TipoTransacao.Delete);
        }

        /// <summary>
        /// SetInsert
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetInsert(string pSql, List<SqlParameter>pSqlParameterList)
        {
            this.SetTransaction(pSql, pSqlParameterList, TipoTransacao.Insert);
        }

        /// <summary>
        /// SetProcedure
        /// </summary>
        /// <param name="pProcedure"></param>
        /// <param name="pSqlParameterList"></param>
        public void SetProcedure(string pProcedure, List<SqlParameter> pSqlParameterList)
        {
            this.SetTransaction(pProcedure, pSqlParameterList, TipoTransacao.Procedure);
        }

        /// <summary>
        /// SetTransaction
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        private void SetTransaction(string pSql, List<SqlParameter>pSqlParameterList)
        {
            this.transacao = pSql;
            this._parametrosList = pSqlParameterList;
        }

        /// <summary>
        /// SetTransaction
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pSqlParameterList"></param>
        /// <param name="pTypeTransaction"></param>
        private void SetTransaction(string pSql, List<SqlParameter>pSqlParameterList, TipoTransacao pTipoTransacao)
        {
            this.tipoTransacao = pTipoTransacao;
            this.SetTransaction(pSql, pSqlParameterList);
        }

        #endregion
    }
}
