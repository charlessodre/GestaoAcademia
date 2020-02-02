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
    public class ProfissaoDAO : BaseDAO, IAcessoDados<ProfissaoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto ProfissaoOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherProfissaoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<ProfissaoOT> _profissaoList = new List<ProfissaoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    ProfissaoOT _profissaoOT = new ProfissaoOT();
                    //
                    _profissaoOT.Codigo = Convert.ToInt32(_item["CD_PROFISSAO"]);
                    _profissaoOT.Nome = _item["NM_PROFISSAO"].ToString();

                    _profissaoList.Add(_profissaoOT);
                }

                pResultadoTransacao.ListaObjetos = _profissaoList;
            }
            return pResultadoTransacao ;
        }

        #endregion

        #region IAcessoDados<ProfissaoOT> Members

        public ResultadoTransacao Select(ProfissaoOT pProfissaoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_PROFISSAO", base.TratarNumero(pProfissaoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PROFISSAO", base.TratarString(pProfissaoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_PROFISSAO", _parametrosList);

            return this.PreencherProfissaoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(ProfissaoOT pProfissaoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_PROFISSAO", base.TratarString(pProfissaoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_PROFISSAO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(ProfissaoOT pProfissaoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PROFISSAO", base.TratarNumero(pProfissaoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PROFISSAO", base.TratarString(pProfissaoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_PROFISSAO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(ProfissaoOT pProfissaoOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_PROFISSAO", base.TratarNumero(pProfissaoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_PROFISSAO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
