using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcessoDados.DML;
using ObjetoOT;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using System.Collections;

namespace PersistenciaDAO.DML
{
    public class UsuarioDAO : BaseDAO, IAcessoDados<UsuarioOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto Menu com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Usuários</returns>
        private ResultadoTransacao PreencherUsuarioOT(ResultadoTransacao pResultadoTransacao)
        {
            List<UsuarioOT> _usuariosList = new List<UsuarioOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _itemUsuario in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    UsuarioOT pUsuarioOT = new UsuarioOT();

                    pUsuarioOT.Codigo = Convert.ToInt32(_itemUsuario["CD_USUARIO"]);
                    pUsuarioOT.GrupoUsuarioOT.Codigo = Convert.ToInt32(_itemUsuario["CD_GRUPO_USUARIO"]);
                    pUsuarioOT.GrupoUsuarioOT.Nome = _itemUsuario["NM_GRUPO_USUARIO"].ToString();
                    pUsuarioOT.Nome = _itemUsuario["NM_USUARIO"].ToString();
                    pUsuarioOT.Login = _itemUsuario["CD_LOGIN"].ToString();
                    pUsuarioOT.Senha = _itemUsuario["CD_SENHA"].ToString();
                    pUsuarioOT.Status = Enumeradores.ConverterShortStatus(Convert.ToInt16(_itemUsuario["CD_STATUS"]));
                    pUsuarioOT.Matricula = _itemUsuario["CD_MATRICULA"].ToString();
                    pUsuarioOT.NumeroTentativasLogin = Convert.ToInt32(_itemUsuario["NUM_TENTATIVAS_LOGIN"]);

                    if (!_itemUsuario["CD_USUARIO_ALTERACAO"].Equals(DBNull.Value))
                    {
                        pUsuarioOT.UsuarioAlteracao.Codigo = Convert.ToInt32(_itemUsuario["CD_USUARIO_ALTERACAO"]);
                        pUsuarioOT.UsuarioAlteracao.Nome = _itemUsuario["NM_USUARIO_ALTERACAO"].ToString();
                    }
                    _usuariosList.Add(pUsuarioOT);
                }

                pResultadoTransacao.ListaObjetos = _usuariosList;
            }

            return pResultadoTransacao;
        }

        /// <summary>
        /// ValidateUser
        /// </summary>
        /// <param name="pDataInfo"></param>
        /// <returns></returns>
        public ResultadoTransacao ValidateUser(UsuarioOT pUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_LOGIN", pUsuarioOT.Login, System.Data.ParameterDirection.Input, System.Data.DbType.String));

            _informacaoTransacao.SetProcedure("STP_VALIDAR_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion

        #region IAcessoDados<UsuarioOT> Members

        public ResultadoTransacao Select(UsuarioOT pUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO", base.TratarNumero(pUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pUsuarioOT.GrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MATRICULA", base.TratarString(pUsuarioOT.Matricula), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_USUARIO", base.TratarString(pUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LOGIN", pUsuarioOT.Login, System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pUsuarioOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_EXPIRACAO_SENHA", base.TratarData(pUsuarioOT.DataExpiracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pUsuarioOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_USUARIO", _parametrosList);

            return this.PreencherUsuarioOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(UsuarioOT pUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pUsuarioOT.GrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MATRICULA", base.TratarString(pUsuarioOT.Matricula), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_USUARIO", base.TratarString(pUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LOGIN", pUsuarioOT.Login, System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SENHA", base.TratarString(pUsuarioOT.Senha), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pUsuarioOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_EXPIRACAO_SENHA", base.TratarData(pUsuarioOT.DataExpiracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pUsuarioOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NUM_TENTATIVAS_LOGIN", base.TratarNumero(pUsuarioOT.NumeroTentativasLogin), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pUsuarioOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_INSERIR_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(UsuarioOT pUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO", base.TratarNumero(pUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pUsuarioOT.GrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MATRICULA", base.TratarString(pUsuarioOT.Matricula), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_USUARIO", base.TratarString(pUsuarioOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_LOGIN", pUsuarioOT.Login, System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SENHA", base.TratarString(pUsuarioOT.Senha), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pUsuarioOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pUsuarioOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_EXPIRACAO_SENHA", base.TratarData(pUsuarioOT.DataExpiracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_NUM_TENTATIVAS_LOGIN", base.TratarNumero(pUsuarioOT.NumeroTentativasLogin), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pUsuarioOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));


            _informacaoTransacao.SetProcedure("STP_ALTERAR_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(UsuarioOT pUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO", base.TratarNumero(pUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_USUARIO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
