using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaDAO;
using ObjetoOT;
using System.Data.SqlClient;
using System.Data;

namespace AcessoDados.DML
{
    /// <summary>
    /// Classe base para as classes de pesistência.
    /// Pradão - DAO
    /// </summary>
    public abstract class BaseDAO
    {
        #region Propriedades

        /// <summary>
        /// Trata o booleano para ser enviado ao banco.
        /// </summary>
        /// <param name="pValor">pValor Booleano</param>
        /// <returns>Retorna o pValor inteiro obtido.</returns>
        protected int TratarBooleano(bool pValor)
        {
            if (pValor == false)
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// Trata o número para ser enviado ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <param name="pPermiteNull"></param>
        /// <returns></returns>
        protected object TratarNumero(double pValor, bool pPermiteNull)
        {
            if (pPermiteNull == true)
                return this.TratarNumero(pValor);
            else
                return pValor;

        }

        /// <summary>
        /// Trata o número para ser enviado ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected object TratarNumero(double pValor)
        {
            if (pValor > 0)
                return pValor;
            else
                return DBNull.Value;
        }

        /// <summary>
        /// Trata o decimal para ser enviado ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected object TratarDecimal(decimal pValor)
        {
            if (pValor > 0)
                return pValor;
            else
                return DBNull.Value;
        }

        /// <summary>
        /// Trata a string para ser enviada ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected object TratarString(string pValor)
        {
            if (!string.IsNullOrEmpty(pValor))
                return pValor;
            else
                return DBNull.Value;
        }

        /// <summary>
        /// Trata a data para ser enviada ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected object TratarData(DateTime pValor)
        {
            try
            {
                if (pValor != DateTime.MinValue & pValor != null)
                    return pValor;
                else
                    return DBNull.Value;

            }
            catch (Exception ex)
            {
                throw new Exception("Data inválida! " + ex.Message);
            }
        }

        /// <summary>
        /// Trata a data para ser enviada ao banco.
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected object TratarImagem(byte[] pValor)
        {
            try
            {
                if (pValor != null && pValor.Length > 0)
                    return pValor;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Imagem inválida! " + ex.Message);
            }
        }


        #endregion

        #region Métodos

        /// <summary>
        /// Executar
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <returns></returns>
        protected ResultadoTransacao Executar(InformacaoTransacao pInformacaoTransacao)
        {
            BancoDados bancoDados = new BancoDados();
            //            
            return bancoDados.Executar(pInformacaoTransacao);
        }

        /// <summary>
        /// ExecutarTransacao
        /// </summary>
        /// <param name="pInformacaoTransacaoList"></param>
        /// <returns></returns>
        protected ResultadoTransacao ExecutarTransacao(List<InformacaoTransacao> pInformacaoTransacaoList)
        {
            BancoDados bancoDados = new BancoDados();
            //            
            return bancoDados.ExecutarTransacao(pInformacaoTransacaoList);
        }

        /// <summary>
        /// GetSQLSelectOrderBy
        /// </summary>
        /// <param name="pSQL"></param>
        /// <param name="pCampo"></param>
        /// <returns></returns>
        protected string GetSQLSelectOrderBy(string pSQL, string pCampo)
        {
            string mSQL = pSQL;
            //
            if (!mSQL.Contains("ORDER"))
            {
                mSQL += " ORDER BY ";
            }
            else
            {
                mSQL += ", ";
            }
            mSQL += " " + pCampo + " ";
            //
            return mSQL;
        }

        /// <summary>
        /// GetSQLWhere
        /// </summary>
        /// <param name="pSQL"></param>
        /// <param name="pCampo"></param>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected string GetSQLWhere(string pSQL, string pCampo, string pValor)
        {
            return this.GetSQLWhere(pSQL, pCampo, pValor, TipoComparacao.Igual);
        }

        /// <summary>
        /// GetValidFormatedNumber
        /// </summary>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected string GetValidFormatedNumber(object pValor)
        {
            if ((pValor != null) && (pValor.ToString().Length > 0) && (int.Parse(pValor.ToString()) > 0))
            {
                return pValor.ToString();
            }
            return " null ";
        }

        /// <summary>
        /// GetSQLWhere
        /// </summary>
        /// <param name="pSQL"></param>
        /// <param name="pCampo"></param>
        /// <param name="pValor"></param>
        /// <param name="pTipoComparacao"></param>
        /// <returns></returns>
        protected string GetSQLWhere(string pSQL, string pCampo, string pValor, TipoComparacao pTipoComparacao)
        {
            //Esta Função é utilizada apenas para consultas onde o valor é inteiro
            string mSQL = pSQL;
            //             
            if ((pValor != null) && (pValor.Trim().Length > 0) && (int.Parse(pValor) > 0) && (pValor.ToString().Trim().ToUpper() != "NULL"))
            {
                if (!mSQL.Contains("WHERE"))
                {
                    mSQL += " WHERE ";
                }
                else
                {
                    mSQL += " AND ";
                }
                mSQL += " " + pCampo + " ";
                mSQL += " " + this.ConverterTipoComparacao(pTipoComparacao) + " " + pValor + " ";
            }
            //  
            return mSQL;
        }

        /// <summary>
        /// GetSQLWhere
        /// </summary>
        /// <param name="pSQL"></param>
        /// <param name="pCampo"></param>
        /// <param name="pValor"></param>
        /// <returns></returns>
        protected string GetSQLWhereString(string pSQL, string pCampo, string pValor)
        {
            return this.GetSQLWhereString(pSQL, pCampo, pValor, TipoComparacao.Like);
        }

        /// <summary>
        /// GetSQLWhere
        /// </summary>
        /// <param name="pSQL"></param>
        /// <param name="pCampo"></param>
        /// <param name="pValor"></param>
        /// <param name="pTipoComparacao"></param>
        /// <returns></returns>
        protected string GetSQLWhereString(string pSQL, string pCampo, string pValor, TipoComparacao pTipoComparacao)
        {
            //Esta Função é utilizada apenas para consultas onde o valor é inteiro
            string mSQL = pSQL;
            //             
            if ((pValor != null) && (pValor.Trim().Length > 0) && (pValor.ToString().Trim().ToUpper() != "NULL"))
            {
                if (!mSQL.Contains("WHERE"))
                {
                    mSQL += " WHERE ";
                }
                else
                {
                    mSQL += " AND ";
                }
                mSQL += " " + pCampo + " ";
                mSQL += " " + this.ConverterTipoComparacao(pTipoComparacao) + " '%" + pValor.Trim().ToUpper() + "%' ";
            }
            //  
            return mSQL;
        }

        /// <summary>
        /// ConverterTipoComparacao
        /// </summary>
        /// <param name="TipoComparacao"></param>
        /// <returns></returns>
        private string ConverterTipoComparacao(TipoComparacao pTipoComparacao)
        {
            switch (pTipoComparacao)
            {
                case TipoComparacao.Igual:
                    return "=";
                case TipoComparacao.Maior:
                    return ">";
                case TipoComparacao.Menor:
                    return "<";
                case TipoComparacao.MaiorOuIgual:
                    return ">=";
                case TipoComparacao.MenorOuIgual:
                    return "<=";
                case TipoComparacao.Like:
                    return "LIKE";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Retorna a colection de parametros da procedure
        /// </summary>
        /// <param name="pNomeParametro"></param>
        /// <param name="pValor"></param>
        /// <param name="pDirecao"></param>
        /// <param name="pTipo"></param>
        /// <returns></returns>
        protected SqlParameter GetSqlParameter(string pNomeParametro, object pValor, ParameterDirection pDirecao, DbType pTipo)
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = pNomeParametro;
            sqlParameter.Value = pValor;
            sqlParameter.Direction = pDirecao;
            sqlParameter.DbType = pTipo;

            return sqlParameter;
        }

        /// <summary>
        /// Retorna a colection de parametros da procedure
        /// </summary>
        /// <param name="pNomeParametro"></param>
        /// <param name="pValor"></param>
        /// <param name="pDirecao"></param>
        /// <param name="pTipo"></param>
        /// <returns></returns>
        protected SqlParameter GetSqlParameter(string pNomeParametro, object pValor, ParameterDirection pDirecao, SqlDbType pTipo)
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = pNomeParametro;
            sqlParameter.Value = pValor;
            sqlParameter.Direction = pDirecao;
            sqlParameter.SqlDbType = pTipo;

            return sqlParameter;
        }

        #endregion
    }
}
