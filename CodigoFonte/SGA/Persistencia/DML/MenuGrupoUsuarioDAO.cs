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
    public class MenuGrupoUsuarioDAO : BaseDAO, IAcessoDados<MenuGrupoUsuarioOT>
    {

        #region Métodos

        /// <summary>
        /// Preenche a lista de Objetos MenuGrupoUsuarioOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus do Grupo de Usuario</returns>
        private ResultadoTransacao PreencherMenuGrupoUsuarioOT(ResultadoTransacao pResultadoTransacao)
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
            //
            return pResultadoTransacao;
        }

        /// <summary>
        /// Monta uma lista dos menus do grupo de usuarios para inserir no banco de dados.
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOTList">Lista de Objetos transferência.</param>
        /// <returns>Retorna o Resulta da Transação executada.</returns>
        public ResultadoTransacao InsertList(List<MenuGrupoUsuarioOT> pMenuGrupoUsuarioOTList)
        {
            List<InformacaoTransacao> _informacaoTransacaoList = new List<InformacaoTransacao>();
            MenuGrupoUsuarioOT _menuGrupoUsuarioOT = new MenuGrupoUsuarioOT();
            //
            _menuGrupoUsuarioOT.CodigoGrupoUsuario = pMenuGrupoUsuarioOTList[0].CodigoGrupoUsuario;
            //
            _informacaoTransacaoList.Add(this.ObterInformacaoTransacaoDelete(_menuGrupoUsuarioOT));
            //
            foreach (MenuGrupoUsuarioOT ite_menuGrupoUsuarioOT in pMenuGrupoUsuarioOTList)
            {
                List<SqlParameter> _parametrosList = new List<SqlParameter>();
                InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
                //
                _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(ite_menuGrupoUsuarioOT.Menu.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
                _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(ite_menuGrupoUsuarioOT.CodigoGrupoUsuario), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
                //
                _informacaoTransacao.SetProcedure("STP_INSERIR_MENU_GRUPO_USUARIO", _parametrosList);
                //
                _informacaoTransacaoList.Add(_informacaoTransacao);
            }
            return base.ExecutarTransacao(_informacaoTransacaoList);
        }

        /// <summary>
        ///  Monta o comando para excluir o MenuGrupoUsuarioOT no banco de dados.
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOTList">Lista de Obejtos transferência.</param>
        /// <returns>Retorna a Informação da Transação a ser executada.</returns>
        private InformacaoTransacao ObterInformacaoTransacaoDelete(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuGrupoUsuarioOT.Menu.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.CodigoGrupoUsuario), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_MENU_GRUPO_USUARIO", _parametrosList);

            return _informacaoTransacao;
        }

        /// <summary>
        /// Consultar os Menus Ativos do Grupo de Usuario
        /// </summary>
        /// <param name="pMenuGrupoUsuarioOT">Objeto MenuGrupoUsuarioOT </param>
        /// <returns>Retorna um lista de Menus</returns>
        public ResultadoTransacao SelectMenus(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuGrupoUsuarioOT.Menu.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.CodigoGrupoUsuario), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_MENU_GRUPO_USUARIO", _parametrosList);

            return this.PreencherMenuGrupoUsuarioOT(base.Executar(_informacaoTransacao));
        }
        #endregion

        #region IAcessoDados<MenuGrupoUsuarioOT> Members

        public ResultadoTransacao Select(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            throw new NotImplementedException();
        }

        public ResultadoTransacao Insert(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuGrupoUsuarioOT.Menu.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.CodigoGrupoUsuario), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            //
            _informacaoTransacao.SetProcedure("STP_INSERIR_MENU_GRUPO_USUARIO", _parametrosList);

            //
            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_MENU", base.TratarNumero(pMenuGrupoUsuarioOT.Menu.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_GRUPO_USUARIO", base.TratarNumero(pMenuGrupoUsuarioOT.CodigoGrupoUsuario), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            //
            _informacaoTransacao.SetProcedure("STP_ALTERAR_MENU_GRUPO_USUARIO", _parametrosList);


            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(MenuGrupoUsuarioOT pMenuGrupoUsuarioOT)
        {
            return base.Executar(this.ObterInformacaoTransacaoDelete(pMenuGrupoUsuarioOT));
        }

        #endregion
    }
}
