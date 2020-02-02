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
    public class EmpresaDAO : BaseDAO, IAcessoDados<EmpresaOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto Menu com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Usuários</returns>
        private ResultadoTransacao PreencherEmpresaOT(ResultadoTransacao pResultadoTransacao)
        {
            List<EmpresaOT> _empresaList = new List<EmpresaOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    EmpresaOT empresaOT = new EmpresaOT();

                    if (!_item["CD_EMPRESA"].Equals(DBNull.Value))
                    {
                        empresaOT.Codigo = Convert.ToInt32(_item["CD_EMPRESA"]);
                        empresaOT.Nome = _item["NM_EMPRESA"].ToString();

                        if (!_item["CD_CIDADE"].Equals(DBNull.Value))
                        {
                            empresaOT.Cidade.Codigo = Convert.ToInt32(_item["CD_CIDADE"]);
                            empresaOT.Cidade.Nome = _item["NM_CIDADE"].ToString();
                        }

                        if (!_item["CD_ESTADO"].Equals(DBNull.Value))
                        {
                            empresaOT.Estado.Codigo = Convert.ToInt32(_item["CD_ESTADO"]);
                            empresaOT.Estado.Nome = _item["NM_ESTADO"].ToString();
                            empresaOT.Estado.Sigla = _item["DS_SIGLA"].ToString();
                        }

                        if (!_item["CD_PAIS"].Equals(DBNull.Value))
                        {
                            empresaOT.Pais.Codigo = Convert.ToInt32(_item["CD_PAIS"]);
                            empresaOT.Pais.Nome = _item["NM_PAIS"].ToString();
                            empresaOT.Pais.Sigla = _item["DS_SIGLA"].ToString();
                        }
                        empresaOT.Endereco = _item["DS_ENDERECO"].ToString();
                        empresaOT.Bairro = _item["DS_BAIRRO"].ToString();
                        empresaOT.TelefoneComercial = _item["DS_TELEFONE_1"].ToString();
                        empresaOT.Fax = _item["DS_TELEFONE_2"].ToString();
                        empresaOT.RazaoSocial = _item["NM_RAZAO_SOCIAL"].ToString();
                        empresaOT.Email = _item["DS_EMAIL"].ToString();
                        empresaOT.Site = _item["DS_SITE"].ToString();
                        empresaOT.EmpresaSistema = Convert.ToBoolean(_item["BL_SISTEMA"]);



                        if (!_item["DS_CNPJ"].Equals(DBNull.Value))
                        {
                            empresaOT.CNPJ = Convert.ToDouble(_item["DS_CNPJ"]);
                        }

                        empresaOT.Status = _item["CD_STATUS"].Equals(DBNull.Value) ? Enumeradores.Status.Todos : Enumeradores.ConverterShortStatus(Convert.ToInt16(_item["CD_STATUS"]));

                        if (!_item["CEP"].Equals(DBNull.Value))
                        {
                            empresaOT.CEP = Convert.ToInt32(_item["CEP"]);
                        }

                        empresaOT.NomeContato = _item["NM_CONTATO"].ToString();
                        empresaOT.Observacao = _item["DS_OBSERVACAO"].ToString();
                        empresaOT.DataAlteracao = _item["DT_ALTERACAO"].Equals(DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(_item["DT_ALTERACAO"]);

                        if (!_item["CD_USUARIO_ALTERACAO"].Equals(DBNull.Value))
                        {
                            empresaOT.UsuarioAlteracao.Codigo = Convert.ToInt32(_item["CD_USUARIO_ALTERACAO"]);
                            empresaOT.UsuarioAlteracao.Nome = _item["NM_USUARIO_ALTERACAO"].ToString();
                        }

                        if (!_item["IMG_LOGO"].Equals(DBNull.Value))
                        {
                            empresaOT.Logo = (byte[])_item["IMG_LOGO"];
                        }

                    }
                    _empresaList.Add(empresaOT);
                }

                pResultadoTransacao.ListaObjetos = _empresaList;
            }

            return pResultadoTransacao;
        }


        #endregion

        #region IAcessoDados<EmpresaOT> Members

        public ResultadoTransacao Select(EmpresaOT pEmpresaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_EMPRESA", base.TratarNumero(pEmpresaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pEmpresaOT.Cidade.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEmpresaOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pEmpresaOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pEmpresaOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_EMPRESA", base.TratarString(pEmpresaOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CNPJ", base.TratarNumero(pEmpresaOT.CNPJ), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pEmpresaOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_CADASTRO", base.TratarData(pEmpresaOT.DataCadastro), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_BL_SISTEMA", base.TratarBooleano(pEmpresaOT.EmpresaSistema), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));


            _informacaoTransacao.SetProcedure("STP_CONSULTAR_EMPRESA", _parametrosList);

            return this.PreencherEmpresaOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(EmpresaOT pEmpresaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pEmpresaOT.Cidade.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEmpresaOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pEmpresaOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_EMPRESA", base.TratarString(pEmpresaOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_ENDERECO", base.TratarString(pEmpresaOT.Endereco), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_BAIRRO", base.TratarString(pEmpresaOT.Bairro), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_1", base.TratarString(pEmpresaOT.TelefoneComercial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_2", base.TratarString(pEmpresaOT.Fax), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pEmpresaOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CNPJ", base.TratarNumero(pEmpresaOT.CNPJ), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pEmpresaOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CEP", base.TratarNumero(pEmpresaOT.CEP), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_CONTATO", base.TratarString(pEmpresaOT.NomeContato), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pEmpresaOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_CADASTRO", base.TratarData(pEmpresaOT.DataCadastro), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pEmpresaOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pEmpresaOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_IMG_LOGO", base.TratarImagem(pEmpresaOT.Logo), System.Data.ParameterDirection.Input, System.Data.DbType.Binary));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SITE", base.TratarString(pEmpresaOT.Site), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_RAZAO_SOCIAL", base.TratarString(pEmpresaOT.RazaoSocial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_BL_SISTEMA", base.TratarBooleano(pEmpresaOT.EmpresaSistema), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));


            _informacaoTransacao.SetProcedure("STP_INSERIR_EMPRESA", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(EmpresaOT pEmpresaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_EMPRESA", base.TratarNumero(pEmpresaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pEmpresaOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pEmpresaOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_EMPRESA", base.TratarString(pEmpresaOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_ENDERECO", base.TratarString(pEmpresaOT.Endereco), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_BAIRRO", base.TratarString(pEmpresaOT.Bairro), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_1", base.TratarString(pEmpresaOT.TelefoneComercial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_2", base.TratarString(pEmpresaOT.Fax), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pEmpresaOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_CNPJ", base.TratarNumero(pEmpresaOT.CNPJ), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pEmpresaOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CEP", base.TratarNumero(pEmpresaOT.CEP), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_CONTATO", base.TratarString(pEmpresaOT.NomeContato), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pEmpresaOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_CADASTRO", base.TratarData(pEmpresaOT.DataCadastro), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pEmpresaOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pEmpresaOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_IMG_LOGO", base.TratarImagem(pEmpresaOT.Logo), System.Data.ParameterDirection.Input, System.Data.DbType.Binary));
            _parametrosList.Add(base.GetSqlParameter("p_DS_SITE", base.TratarString(pEmpresaOT.Site), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_RAZAO_SOCIAL", base.TratarString(pEmpresaOT.RazaoSocial), System.Data.ParameterDirection.Input, System.Data.DbType.String));



            _informacaoTransacao.SetProcedure("STP_ALTERAR_EMPRESA", _parametrosList);


            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(EmpresaOT pEmpresaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_EMPRESA", base.TratarNumero(pEmpresaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_EMPRESA", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion

    }
}
