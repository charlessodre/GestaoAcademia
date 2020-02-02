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
    public class PaisDAO : BaseDAO, IAcessoDados<PaisOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto PaisOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Paises</returns>
        private ResultadoTransacao PreencherPaisOT(ResultadoTransacao pResultadoTransacao)
        {
            List<PaisOT> _paisList = new List<PaisOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    PaisOT _paisOT = new PaisOT();
                    //
                    _paisOT.Codigo = Convert.ToInt32(_item["CD_PAIS"]);
                    _paisOT.Nome = _item["NM_PAIS"].ToString();
                    _paisOT.Sigla = _item["DS_SIGLA"].ToString();

                    _paisList.Add(_paisOT);
                }

                pResultadoTransacao.ListaObjetos = _paisList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<PaisOT> Members

        public ResultadoTransacao Select(PaisOT pPaisOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pPaisOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PAIS", base.TratarString(pPaisOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pPaisOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_PAIS", _parametrosList);

            return this.PreencherPaisOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(PaisOT pPaisOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_PAIS", base.TratarString(pPaisOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pPaisOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_PAIS", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(PaisOT pPaisOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pPaisOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PAIS", base.TratarString(pPaisOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SIGLA", base.TratarString(pPaisOT.Sigla), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_PAIS", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(PaisOT pPaisOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pPaisOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_PAIS", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
