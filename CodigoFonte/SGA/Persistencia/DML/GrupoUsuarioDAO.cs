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
    public class GrupoUsuarioDAO : BaseDAO, IAcessoDados<GrupoUsuarioOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto GrupoUsuarioOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherGrupoUsuarioOT(ResultadoTransacao pResultadoTransacao)
        {
            List<GrupoUsuarioOT> _gruposUsuariosList = new List<GrupoUsuarioOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _itemGrupoUsuario in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    GrupoUsuarioOT _grupoUsuarioOT = new GrupoUsuarioOT();
                    //
                    _grupoUsuarioOT.Codigo = Convert.ToInt32(_itemGrupoUsuario["CD_GRUPO_USUARIO"]);
                    _grupoUsuarioOT.Nome = _itemGrupoUsuario["NM_GRUPO_USUARIO"].ToString();

                    _gruposUsuariosList.Add(_grupoUsuarioOT);
                }

                pResultadoTransacao.ListaObjetos = _gruposUsuariosList;
            }
            return pResultadoTransacao ;
        }

        #endregion

        #region IAcessoDados<GrupoUsuarioOT> Members

        public ResultadoTransacao Select(GrupoUsuarioOT pGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_GRUPO_USUARIO", base.TratarString(pGrupoUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_GRUPO_USUARIO", _parametrosList);

            return this.PreencherGrupoUsuarioOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(GrupoUsuarioOT pGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_NM_GRUPO_USUARIO", base.TratarString(pGrupoUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_INSERIR_GRUPO_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(GrupoUsuarioOT pGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_GRUPO_USUARIO", base.TratarString(pGrupoUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_GRUPO_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(GrupoUsuarioOT pGrupoUsuarioOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_GRUPO_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
