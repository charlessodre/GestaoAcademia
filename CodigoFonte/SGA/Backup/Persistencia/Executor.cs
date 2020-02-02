using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PersistenciaDAO
{
    public class Executor
    {
        #region Atributos

        private SqlDataAdapter sqlDataAdapter;

        #endregion

        #region Métodos

        /// <summary>
        /// ExecuteSelect
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteSelect(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection)
        {
            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Select");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();
            this.sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();

            sqlCommand.Connection = pSqlConnection;
            sqlCommand.CommandTimeout = 3000;
            this.sqlDataAdapter.SelectCommand = sqlCommand;
            
            resultadoTransacao.MarcarRegistrosAfetados(this.sqlDataAdapter.Fill(dataSet));
            resultadoTransacao.MarcarDataSet(dataSet);
            resultadoTransacao.MarcarParametrosSaida(pInformacaoTransacao.ObterParametrosSaida(this.sqlDataAdapter.SelectCommand));
            
            return resultadoTransacao;
        }

        /// <summary>
        /// ExecuteUpdate
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteUpdate(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection)
        {
            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Update");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();

            sqlCommand.Connection = pSqlConnection;
            resultadoTransacao.MarcarRegistrosAfetados(sqlCommand.ExecuteNonQuery());

            return resultadoTransacao;
        }

        /// <summary>
        /// ExecuteDelete
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteDelete(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection)
        {
            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Delete");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();
            sqlCommand.Connection = pSqlConnection;
            resultadoTransacao.MarcarRegistrosAfetados(sqlCommand.ExecuteNonQuery());

            return resultadoTransacao;
        }

        /// <summary>
        /// ExecuteInsert
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteInsert(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection)
        {

            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Insert");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();
            sqlCommand.Connection = pSqlConnection;
            resultadoTransacao.MarcarRegistrosAfetados(sqlCommand.ExecuteNonQuery());

            return resultadoTransacao;
        }

        /// <summary>
        /// ExecuteProcedure
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteProcedure(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection)
        {
            //TODO: Charles - Verificar Procedure
            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Procedure");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();
            this.sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();

            sqlCommand.Connection = pSqlConnection;
            sqlCommand.CommandTimeout = 3000;
            this.sqlDataAdapter.SelectCommand = sqlCommand;
            //
            resultadoTransacao.MarcarRegistrosAfetados(this.sqlDataAdapter.Fill(dataSet));
            resultadoTransacao.MarcarDataSet(dataSet);
            resultadoTransacao.MarcarParametrosSaida(pInformacaoTransacao.ObterParametrosSaida(this.sqlDataAdapter.SelectCommand));
            //
            return resultadoTransacao;
        }

        /// <summary>
        /// ExecuteProcedure
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <param name="pSqlConnection"></param>
        /// <returns></returns>
        internal ResultadoTransacao ExecuteProcedure(InformacaoTransacao pInformacaoTransacao, SqlConnection pSqlConnection, SqlTransaction pSqlTransaction)
        {
            ResultadoTransacao resultadoTransacao = new ResultadoTransacao("Procedure");
            SqlCommand sqlCommand = pInformacaoTransacao.ObterSqlCommand();
            sqlCommand.Transaction = pSqlTransaction;
            this.sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();

            sqlCommand.Connection = pSqlConnection;
            sqlCommand.CommandTimeout = 3000;
            //
            int registrosAfetados = sqlCommand.ExecuteNonQuery();
            //
            resultadoTransacao.MarcarRegistrosAfetados(registrosAfetados);
            resultadoTransacao.MarcarParametrosSaida(pInformacaoTransacao.ObterParametrosSaida(sqlCommand));
            //
            return resultadoTransacao;
        }

        #endregion
    }
}
