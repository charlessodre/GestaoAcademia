using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcessoDados.DML;
using ObjetoOT;
using System.Data;
using System.Data.SqlClient;
using Utilitarios;

namespace PersistenciaDAO.DML
{
    public class MenuDAO : BaseDAO, IAcessoDados<MenuOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto Menu com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherMenuOT(ResultadoTransacao pResultadoTransacao)
        {
            List<MenuOT> _menusList = new List<MenuOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _itemMenu in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    MenuOT _menu = new MenuOT();
                    //
                    _menu.Codigo = Convert.ToInt32(_itemMenu["CD_MENU"]);
                    _menu.Nome = _itemMenu["NM_MENU"].ToString();
                    _menu.UrlImagem = _itemMenu["URL_IMG_MENU"].ToString();
                    _menu.UrlPagina = _itemMenu["URL_PAGINA"].ToString();
                    _menu.CaminhoMenu = _itemMenu["DS_CAMINHO_MENU"].ToString();
                    _menu.Status = Enumeradores.ConverterObjectStatus(_itemMenu["CD_STATUS"]);
                    _menu.Visivel = Enumeradores.ConverterObjectStatus(_itemMenu["CD_VISIVEL"]);
                    //
                    _menusList.Add(_menu);
                }

                pResultadoTransacao.ListaObjetos = _menusList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<MenuOT> Members

        public ResultadoTransacao Select(MenuOT pMenuOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuOT.Codigo), ParameterDirection.Input, DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_MENU", base.TratarString(pMenuOT.Nome), ParameterDirection.Input, DbType.AnsiString));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CAMINHO_MENU", base.TratarString(pMenuOT.CaminhoMenu), ParameterDirection.Input, DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Status)), ParameterDirection.Input, DbType.Byte));
            _parametrosList.Add(base.GetSqlParameter("p_CD_VISIVEL", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Visivel)), ParameterDirection.Input, DbType.Byte));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_MENU", _parametrosList);

            return this.PreencherMenuOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(MenuOT pMenuOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_NM_MENU", base.TratarString(pMenuOT.Nome), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_URL_IMG_MENU", base.TratarString(pMenuOT.UrlImagem), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_URL_PAGINA", base.TratarString(pMenuOT.UrlPagina), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CAMINHO_MENU", base.TratarString(pMenuOT.CaminhoMenu), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Status)), ParameterDirection.Input, DbType.Byte));
            _parametrosList.Add(base.GetSqlParameter("p_CD_VISIVEL", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Visivel)), ParameterDirection.Input, DbType.Byte));
            //
            _informacaoTransacao.SetProcedure("STP_INSERIR_MENU", _parametrosList);
            //
            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(MenuOT pMenuOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuOT.Codigo), ParameterDirection.Input, DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_MENU", base.TratarString(pMenuOT.Nome), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_URL_IMG_MENU", base.TratarString(pMenuOT.UrlImagem), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_URL_PAGINA", base.TratarString(pMenuOT.UrlPagina), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CAMINHO_MENU", base.TratarString(pMenuOT.CaminhoMenu), ParameterDirection.Input, DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Status)), ParameterDirection.Input, DbType.Byte));
            _parametrosList.Add(base.GetSqlParameter("p_CD_VISIVEL", base.TratarNumero(Utilitarios.Enumeradores.ConverterStatusShort(pMenuOT.Visivel)), ParameterDirection.Input, DbType.Byte));
            //
            _informacaoTransacao.SetProcedure("STP_ALTERAR_MENU", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao  Delete(MenuOT pMenuOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuOT.Codigo), ParameterDirection.Input, DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_MENU", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion

    }
}
