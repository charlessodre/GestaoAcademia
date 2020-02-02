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
    public class LancamentoContaDAO : BaseDAO, IAcessoDados<LancamentoContaOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto LancamentoContaOT com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Menus</returns>
        private ResultadoTransacao PreencherLancamentoContaOT(ResultadoTransacao pResultadoTransacao)
        {
            List<LancamentoContaOT> _lancamentoContaList = new List<LancamentoContaOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _item in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    LancamentoContaOT _lancamentoContaOT = new LancamentoContaOT();
                    //
                    _lancamentoContaOT.Codigo = Convert.ToInt32(_item["CD_LANCAMENTO_CONTA"]);
                    _lancamentoContaOT.ValorLancamento = Convert.ToDecimal(_item["VL_LANCAMENTO"]);
                    _lancamentoContaOT.DataVencimento = Convert.ToDateTime(_item["DT_VENCIMENTO"]);
                    _lancamentoContaOT.DataVencimento = Convert.ToDateTime(_item["DT_LANCAMENTO_CONTA"]);
                    _lancamentoContaOT.Descricao = _item["DS_OBSERVACAO"].ToString();
                    _lancamentoContaOT.Pago = Convert.ToBoolean(_item["BL_PAGO"]);

                    //Aluno
                    _lancamentoContaOT.Aluno.Codigo = Convert.ToInt32(_item["CD_ALUNO"]);
                    _lancamentoContaOT.Aluno.Nome = _item["NM_ALUNO"].ToString();
                    _lancamentoContaOT.Aluno.TelefoneResidencial = _item["DS_TELEFONE_RES"].ToString();

                    if (!_item["IMG_FOTO"].Equals(DBNull.Value))
                    {
                        _lancamentoContaOT.Aluno.Foto = (byte[])_item["IMG_FOTO"];
                    }

                    //Serviço
                    _lancamentoContaOT.ServicoRealizado.Codigo = Convert.ToInt32(_item["CD_SERVICO"]);
                    _lancamentoContaOT.ServicoRealizado.Nome = _item["NM_SERVICO"].ToString();

                    if (!_item["CD_USUARIO"].Equals(DBNull.Value))
                    {
                        _lancamentoContaOT.UsuarioAlteracao.Codigo = Convert.ToInt32(_item["CD_USUARIO"]);
                        _lancamentoContaOT.UsuarioAlteracao.Nome = _item["NM_USUARIO"].ToString();
                        _lancamentoContaOT.DataAlteracao = Convert.ToDateTime(_item["DT_ALTERACAO"]);
                    }

                    if (!_item["CD_PAGAMENTO"].Equals(DBNull.Value))
                    {
                        _lancamentoContaOT.Pagamento.Codigo = Convert.ToInt32(_item["CD_PAGAMENTO"]);
                        _lancamentoContaOT.Pagamento.ValorPagamento = Convert.ToDecimal(_item["VL_PAGAMENTO"]);
                        _lancamentoContaOT.Pagamento.DataPagamento = Convert.ToDateTime(_item["DT_PAGAMENTO"]);
                        _lancamentoContaOT.Pagamento.UsuarioPagamento.Codigo = Convert.ToInt32(_item["CD_USUARIO_PAGAMENTO"]);
                        _lancamentoContaOT.Pagamento.UsuarioPagamento.Nome = _item["NM_USUARIO_PAGAMENTO"].ToString();
                    }

                    //Recibo
                    if (!_item["CD_RECIBO_PAGAMENTO"].Equals(DBNull.Value))
                    {
                        _lancamentoContaOT.Recibo.Codigo = Convert.ToInt32(_item["CD_RECIBO_PAGAMENTO"]);
                    }

                    _lancamentoContaList.Add(_lancamentoContaOT);
                }

                pResultadoTransacao.ListaObjetos = _lancamentoContaList;
            }
            return pResultadoTransacao;
        }

        #endregion

        #region IAcessoDados<LancamentoContaOT> Members

        public ResultadoTransacao Select(LancamentoContaOT pLancamentoContaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pLancamentoContaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pLancamentoContaOT.Aluno.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pLancamentoContaOT.ServicoRealizado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_LANCAMENTO", base.TratarDecimal(pLancamentoContaOT.ValorLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_DT_VENCIMENTO", base.TratarData(pLancamentoContaOT.DataVencimento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_LANCAMENTO_CONTA", base.TratarData(pLancamentoContaOT.DataLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_INICIO_LANCAMENTO_CONTA", base.TratarData(pLancamentoContaOT.DataInicioLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_FIM_LANCAMENTO_CONTA", base.TratarData(pLancamentoContaOT.DataFimLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));

            if (pLancamentoContaOT.StatusPagamento != Enumeradores.StatusPagamento.Todos)
            {
                _parametrosList.Add(base.GetSqlParameter("p_BL_PAGO", base.TratarBooleano(pLancamentoContaOT.Pago), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));
            }

            _informacaoTransacao.SetProcedure("STP_CONSULTAR_LANCAMENTO_CONTA", _parametrosList);

            return this.PreencherLancamentoContaOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(LancamentoContaOT pLancamentoContaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pLancamentoContaOT.Aluno.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pLancamentoContaOT.ServicoRealizado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_LANCAMENTO", base.TratarDecimal(pLancamentoContaOT.ValorLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_DT_VENCIMENTO", base.TratarData(pLancamentoContaOT.DataVencimento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_LANCAMENTO_CONTA", base.TratarData(pLancamentoContaOT.DataLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pLancamentoContaOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pLancamentoContaOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pLancamentoContaOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_BL_PAGO", base.TratarBooleano(pLancamentoContaOT.Pago), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));

            _informacaoTransacao.SetProcedure("STP_INSERIR_LANCAMENTO_CONTA", _parametrosList);

            return base.Executar(_informacaoTransacao);

        }

        public ResultadoTransacao Update(LancamentoContaOT pLancamentoContaOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pLancamentoContaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pLancamentoContaOT.Aluno.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SERVICO", base.TratarNumero(pLancamentoContaOT.ServicoRealizado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_VL_LANCAMENTO", base.TratarDecimal(pLancamentoContaOT.ValorLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.Decimal));
            _parametrosList.Add(base.GetSqlParameter("p_DT_VENCIMENTO", base.TratarData(pLancamentoContaOT.DataVencimento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_LANCAMENTO_CONTA", base.TratarData(pLancamentoContaOT.DataLancamento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pLancamentoContaOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pLancamentoContaOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pLancamentoContaOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_BL_PAGO", base.TratarBooleano(pLancamentoContaOT.Pago), System.Data.ParameterDirection.Input, System.Data.DbType.Boolean));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_LANCAMENTO_CONTA", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(LancamentoContaOT pLancamentoContaOT)
        {

            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //

            _parametrosList.Add(base.GetSqlParameter("p_CD_LANCAMENTO_CONTA", base.TratarNumero(pLancamentoContaOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_LANCAMENTO_CONTA", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion
    }
}
