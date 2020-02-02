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
    public class AlunoDAO : BaseDAO, IAcessoDados<AlunoOT>
    {
        #region Métodos

        /// <summary>
        /// Preenche o Objeto Menu com os dados da consulta.
        /// </summary>
        /// <param name="pResultadoTransacao">Objeto Resultado Transação</param>
        /// <returns>O resultado da transação com a Lista de Usuários</returns>
        private ResultadoTransacao PreencherAlunoOT(ResultadoTransacao pResultadoTransacao)
        {
            List<AlunoOT> _alunoList = new List<AlunoOT>();

            if (pResultadoTransacao.Resultado == Enumeradores.Resultados.Sucesso)
            {

                foreach (DataRow _itemAluno in pResultadoTransacao.DataSetRetono.Tables[0].Rows)
                {
                    AlunoOT pAlunoOT = new AlunoOT();

                    if (!_itemAluno["CD_ALUNO"].Equals(DBNull.Value))
                    {
                        pAlunoOT.Codigo = Convert.ToInt32(_itemAluno["CD_ALUNO"]);
                        pAlunoOT.Nome = _itemAluno["NM_ALUNO"].ToString();

                        if (!_itemAluno["CD_CIDADE"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Cidade.Codigo = Convert.ToInt32(_itemAluno["CD_CIDADE"]);
                            pAlunoOT.Cidade.Nome = _itemAluno["NM_CIDADE"].ToString();
                        }

                        if (!_itemAluno["CD_ESTADO"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Estado.Codigo = Convert.ToInt32(_itemAluno["CD_ESTADO"]);
                            pAlunoOT.Estado.Nome = _itemAluno["NM_ESTADO"].ToString();
                            pAlunoOT.Estado.Sigla = _itemAluno["DS_SIGLA"].ToString();
                        }

                        if (!_itemAluno["CD_PAIS"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Pais.Codigo = Convert.ToInt32(_itemAluno["CD_PAIS"]);
                            pAlunoOT.Pais.Nome = _itemAluno["NM_PAIS"].ToString();
                            pAlunoOT.Pais.Sigla = _itemAluno["DS_SIGLA"].ToString();
                        }
                        pAlunoOT.Endereco = _itemAluno["DS_ENDERECO"].ToString();
                        pAlunoOT.Bairro = _itemAluno["DS_BAIRRO"].ToString();
                        pAlunoOT.TelefoneResidencial = _itemAluno["DS_TELEFONE_RES"].ToString();
                        pAlunoOT.TelefoneCelular = _itemAluno["DS_TELEFONE_CEL"].ToString();
                        pAlunoOT.TelefoneComercial = _itemAluno["DS_TELEFONE_COM"].ToString();
                        pAlunoOT.Email = _itemAluno["DS_EMAIL"].ToString();

                        if (!_itemAluno["CPF"].Equals(DBNull.Value))
                        {
                            pAlunoOT.CPF = Convert.ToDouble(_itemAluno["CPF"]);
                        }

                        pAlunoOT.Status = _itemAluno["CD_STATUS"].Equals(DBNull.Value) ? Enumeradores.Status.Todos : Enumeradores.ConverterShortStatus(Convert.ToInt16(_itemAluno["CD_STATUS"]));
                        pAlunoOT.RG = _itemAluno["RG"].ToString();

                        if (!_itemAluno["CD_ESTADO_RG"].Equals(DBNull.Value))
                        {
                            pAlunoOT.EstadoRG.Codigo = Convert.ToInt32(_itemAluno["CD_ESTADO_RG"]);
                            pAlunoOT.EstadoRG.Nome = _itemAluno["NM_ESTADO_RG"].ToString();
                            pAlunoOT.EstadoRG.Sigla = _itemAluno["DS_SIGLA_RG"].ToString();
                        }

                        pAlunoOT.DataNascimento = _itemAluno["DT_NASCIMENTO"].Equals(DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(_itemAluno["DT_NASCIMENTO"]);

                        if (!_itemAluno["CEP"].Equals(DBNull.Value))
                        {
                            pAlunoOT.CEP = Convert.ToInt32(_itemAluno["CEP"]);
                        }

                        pAlunoOT.Sexo = _itemAluno["SEXO"].Equals(DBNull.Value) ? Enumeradores.Sexo.Todos : Enumeradores.ConverterShortSexo(Convert.ToInt16(_itemAluno["SEXO"]));
                        pAlunoOT.NomePai = _itemAluno["NM_PAI"].ToString();
                        pAlunoOT.NomeMae = _itemAluno["NM_MAE"].ToString();
                        pAlunoOT.NomeResponsavel = _itemAluno["NM_RESPONSAVEL"].ToString();
                        pAlunoOT.TelefoneResponsavel = _itemAluno["DS_TELEFONE_RESPONSAVEL"].ToString();
                        pAlunoOT.EstadoCivil = _itemAluno["CD_ESTADO_CIVIL"].Equals(DBNull.Value) ? Enumeradores.EstadoCivil.Todos : Enumeradores.ConverterShortEstadoCivil(Convert.ToInt16(_itemAluno["CD_ESTADO_CIVIL"]));
                        pAlunoOT.Observacao = _itemAluno["DS_OBSERVACAO"].ToString();
                        pAlunoOT.Senha = _itemAluno["CD_SENHA"].ToString();

                        pAlunoOT.DataAlteracaoSenha = _itemAluno["DT_ALTERACAO_SENHA"].Equals(DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(_itemAluno["DT_ALTERACAO_SENHA"]);
                        pAlunoOT.DataExpiracaoSenha = _itemAluno["DT_EXPIRACAO_SENHA"].Equals(DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(_itemAluno["DT_EXPIRACAO_SENHA"]);
                        pAlunoOT.DataAlteracao = _itemAluno["DT_ALTERACAO"].Equals(DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(_itemAluno["DT_ALTERACAO"]);

                        if (!_itemAluno["CD_USUARIO_ALTERACAO"].Equals(DBNull.Value))
                        {
                            pAlunoOT.UsuarioAlteracao.Codigo = Convert.ToInt32(_itemAluno["CD_USUARIO_ALTERACAO"]);
                            pAlunoOT.UsuarioAlteracao.Nome = _itemAluno["NM_USUARIO_ALTERACAO"].ToString();
                        }

                        if (!_itemAluno["IMG_FOTO"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Foto = (byte[])_itemAluno["IMG_FOTO"];
                        }

                        if (!_itemAluno["CD_EMPRESA"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Empresa.Codigo = Convert.ToInt32(_itemAluno["CD_EMPRESA"]);
                            pAlunoOT.Empresa.Nome = _itemAluno["NM_EMPRESA"].ToString();

                        }

                        pAlunoOT.Objetivo = _itemAluno["DS_OBJETIVO"].ToString();

                        if (!_itemAluno["CD_PROFISSAO"].Equals(DBNull.Value))
                        {
                            pAlunoOT.Profissao.Codigo = Convert.ToInt32(_itemAluno["CD_PROFISSAO"]);
                            pAlunoOT.Profissao.Nome = _itemAluno["NM_PROFISSAO"].ToString();

                        }
                    }
                    _alunoList.Add(pAlunoOT);
                }

                pResultadoTransacao.ListaObjetos = _alunoList;
            }

            return pResultadoTransacao;
        }


        #endregion

        #region IAcessoDados<AlunoOT> Members

        public ResultadoTransacao Select(AlunoOT pAlunoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pAlunoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pAlunoOT.Cidade.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pAlunoOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pAlunoOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pAlunoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_ALUNO", base.TratarString(pAlunoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CPF", base.TratarNumero(pAlunoOT.CPF), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_CEL", base.TratarString(pAlunoOT.TelefoneCelular), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_RES", base.TratarString(pAlunoOT.TelefoneResidencial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_COM", base.TratarString(pAlunoOT.TelefoneComercial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pAlunoOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_BAIRRO", base.TratarString(pAlunoOT.Bairro), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pAlunoOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));


            _informacaoTransacao.SetProcedure("STP_CONSULTAR_ALUNO", _parametrosList);

            return this.PreencherAlunoOT(base.Executar(_informacaoTransacao));
        }

        public ResultadoTransacao Insert(AlunoOT pAlunoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();
            //
            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pAlunoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pAlunoOT.Cidade.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pAlunoOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pAlunoOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_ALUNO", base.TratarString(pAlunoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_ENDERECO", base.TratarString(pAlunoOT.Endereco), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_BAIRRO", base.TratarString(pAlunoOT.Bairro), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_CEL", base.TratarString(pAlunoOT.TelefoneCelular), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_RES", base.TratarString(pAlunoOT.TelefoneResidencial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_COM", base.TratarString(pAlunoOT.TelefoneComercial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pAlunoOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CPF", base.TratarNumero(pAlunoOT.CPF), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pAlunoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_RG", base.TratarString(pAlunoOT.RG), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO_RG", base.TratarNumero(pAlunoOT.EstadoRG.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_NASCIMENTO", base.TratarData(pAlunoOT.DataNascimento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CEP", base.TratarNumero(pAlunoOT.CEP), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_SEXO", base.TratarNumero(Enumeradores.ConverterSexoShort(pAlunoOT.Sexo)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PAI", base.TratarString(pAlunoOT.NomePai), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_MAE", base.TratarString(pAlunoOT.NomeMae), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_RESPONSAVEL", base.TratarString(pAlunoOT.NomeResponsavel), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_RESPONSAVEL", base.TratarString(pAlunoOT.TelefoneResponsavel), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO_CIVIL", base.TratarNumero(Enumeradores.ConverterEstadoShort(pAlunoOT.EstadoCivil)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pAlunoOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SENHA", base.TratarString(pAlunoOT.Senha), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO_SENHA", base.TratarData(pAlunoOT.DataAlteracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_EXPIRACAO_SENHA", base.TratarData(pAlunoOT.DataExpiracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pAlunoOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pAlunoOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_IMG_FOTO", base.TratarImagem(pAlunoOT.Foto), System.Data.ParameterDirection.Input, System.Data.DbType.Binary));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBJETIVO", base.TratarString(pAlunoOT.Objetivo), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PROFISSAO", base.TratarNumero(pAlunoOT.Profissao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));


            _informacaoTransacao.SetProcedure("STP_INSERIR_ALUNO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Update(AlunoOT pAlunoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pAlunoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_CIDADE", base.TratarNumero(pAlunoOT.Cidade.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO", base.TratarNumero(pAlunoOT.Estado.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PAIS", base.TratarNumero(pAlunoOT.Pais.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_ALUNO", base.TratarString(pAlunoOT.Nome), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_ENDERECO", base.TratarString(pAlunoOT.Endereco), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_BAIRRO", base.TratarString(pAlunoOT.Bairro), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_CEL", base.TratarString(pAlunoOT.TelefoneCelular), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_RES", base.TratarString(pAlunoOT.TelefoneResidencial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_COM", base.TratarString(pAlunoOT.TelefoneComercial), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_EMAIL", base.TratarString(pAlunoOT.Email), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CPF", base.TratarNumero(pAlunoOT.CPF), System.Data.ParameterDirection.Input, System.Data.DbType.Double));
            _parametrosList.Add(base.GetSqlParameter("p_CD_STATUS", base.TratarNumero(Enumeradores.ConverterStatusShort(pAlunoOT.Status)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_RG", base.TratarString(pAlunoOT.RG), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO_RG", base.TratarNumero(pAlunoOT.EstadoRG.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DT_NASCIMENTO", base.TratarData(pAlunoOT.DataNascimento), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CEP", base.TratarNumero(pAlunoOT.CEP), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_SEXO", base.TratarNumero(Enumeradores.ConverterSexoShort(pAlunoOT.Sexo)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_NM_PAI", base.TratarString(pAlunoOT.NomePai), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_MAE", base.TratarString(pAlunoOT.NomeMae), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_NM_RESPONSAVEL", base.TratarString(pAlunoOT.NomeResponsavel), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DS_TELEFONE_RESPONSAVEL", base.TratarString(pAlunoOT.TelefoneResponsavel), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_ESTADO_CIVIL", base.TratarNumero(Enumeradores.ConverterEstadoShort(pAlunoOT.EstadoCivil)), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBSERVACAO", base.TratarString(pAlunoOT.Observacao), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_SENHA", base.TratarString(pAlunoOT.Senha), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO_SENHA", base.TratarData(pAlunoOT.DataAlteracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_EXPIRACAO_SENHA", base.TratarData(pAlunoOT.DataExpiracaoSenha), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_DT_ALTERACAO", base.TratarData(pAlunoOT.DataAlteracao), System.Data.ParameterDirection.Input, System.Data.DbType.DateTime));
            _parametrosList.Add(base.GetSqlParameter("p_CD_USUARIO_ALTERACAO", base.TratarNumero(pAlunoOT.UsuarioAlteracao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));
            _parametrosList.Add(base.GetSqlParameter("p_IMG_FOTO", base.TratarImagem(pAlunoOT.Foto), System.Data.ParameterDirection.Input, System.Data.DbType.Binary));
            _parametrosList.Add(base.GetSqlParameter("p_DS_OBJETIVO", base.TratarString(pAlunoOT.Objetivo), System.Data.ParameterDirection.Input, System.Data.DbType.String));
            _parametrosList.Add(base.GetSqlParameter("p_CD_PROFISSAO", base.TratarNumero(pAlunoOT.Profissao.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_ALTERAR_ALUNO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        public ResultadoTransacao Delete(AlunoOT pAlunoOT)
        {
            List<SqlParameter> _parametrosList = new List<SqlParameter>();
            InformacaoTransacao _informacaoTransacao = new InformacaoTransacao();

            _parametrosList.Add(base.GetSqlParameter("p_CD_ALUNO", base.TratarNumero(pAlunoOT.Codigo), System.Data.ParameterDirection.Input, System.Data.DbType.Int32));

            _informacaoTransacao.SetProcedure("STP_EXCLUIR_ALUNO", _parametrosList);

            return base.Executar(_informacaoTransacao);
        }

        #endregion

    }
}
