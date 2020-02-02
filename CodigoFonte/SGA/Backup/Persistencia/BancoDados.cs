using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Utilitarios;

namespace PersistenciaDAO
{
    /// <summary>
    /// Classe responsável por Executar as operações de banco de dados.
    /// </summary>
    public class BancoDados
    {
        #region Construtores

        public BancoDados()
        {
            this._resultadoTransacao = new ResultadoTransacao();
        }

        #endregion

        #region Atributos

        private Executor _executor = new Executor();
        private SqlTransaction _sqlTransaction = null;
        private ResultadoTransacao _resultadoTransacao = null;

        #endregion

        #region Operações

        /// <summary>
        /// Executar
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <returns></returns>
        public ResultadoTransacao Executar(InformacaoTransacao pInformacaoTransacao)
        {
            try
            {
                FabricaConexao.ObterInstancia().ObterConexao().Open();
                //
                switch (pInformacaoTransacao.TipoTransacao)
                {
                    case TipoTransacao.Select:
                    case TipoTransacao.Update:
                    case TipoTransacao.Insert:
                    case TipoTransacao.Delete:
                    case TipoTransacao.Procedure:
                        this._resultadoTransacao = this.ExecutarSQL(pInformacaoTransacao);
                        break;
                    default:
                        throw new Exception("Tipo de transação Inválido!");
                }
                return _resultadoTransacao;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    this._resultadoTransacao.MarcarExcecao(ex);
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Duplicado);
                    return this._resultadoTransacao;
                }
                else if (ex.Number == 547)
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.FKConstraint);
                    this._resultadoTransacao.MarcarExcecao(ex);
                    return this._resultadoTransacao;
                }
                else if (ex.Number == -1)
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.SemConexao);
                    this._resultadoTransacao.MarcarExcecao(ex);
                    return this._resultadoTransacao;
                }
                else
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Erro);
                    this._resultadoTransacao.MarcarExcecao(ex);

                    return this._resultadoTransacao;
                }
            }
            catch (System.Exception ex)
            {
                this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Erro);
                this._resultadoTransacao.MarcarExcecao(ex);

                return this._resultadoTransacao;
            }
            finally
            {
                FabricaConexao.ObterInstancia().ObterConexao().Close();
            }
        }

        /// <summary>
        /// ExecutarTransacao
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <returns></returns>
        public ResultadoTransacao ExecutarTransacao(List<InformacaoTransacao> pInformacaoTransacaoList)
        {
            try
            {
                FabricaConexao.ObterInstancia().ObterConexao().Open();

                this._sqlTransaction = FabricaConexao.ObterInstancia().ObterConexao().BeginTransaction();

                foreach (InformacaoTransacao InformacaoTransacao in pInformacaoTransacaoList)
                {
                    //
                    switch (InformacaoTransacao.TipoTransacao)
                    {
                        case TipoTransacao.Select:
                        case TipoTransacao.Update:
                        case TipoTransacao.Insert:
                        case TipoTransacao.Delete:
                        case TipoTransacao.Procedure:
                            this._resultadoTransacao = this.ExecutarSQL(InformacaoTransacao, this._sqlTransaction);
                            break;
                        default:
                            throw new Exception("Tipo de transação Inválido!");

                    }
                }

                this._sqlTransaction.Commit();

                return this._resultadoTransacao;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    this._resultadoTransacao.MarcarExcecao(ex);
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Duplicado);
                    return this._resultadoTransacao;
                }
                else if (ex.Number == 547)
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.FKConstraint);
                    this._resultadoTransacao.MarcarExcecao(ex);
                    return this._resultadoTransacao;
                }
                else if (ex.Number == -1)
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.SemConexao);
                    this._resultadoTransacao.MarcarExcecao(ex);
                    return this._resultadoTransacao;
                }
                else
                {
                    this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Erro);
                    this._resultadoTransacao.MarcarExcecao(ex);

                    return this._resultadoTransacao;
                }
            }
            catch (System.Exception ex)
            {
                this._sqlTransaction.Rollback();

                this._resultadoTransacao.MarcarResultado(Utilitarios.Enumeradores.Resultados.Erro);
                this._resultadoTransacao.MarcarExcecao(ex);

                return this._resultadoTransacao;
            }
            finally
            {
                FabricaConexao.ObterInstancia().ObterConexao().Close();
            }
        }

        /// <summary>
        /// Verifica e executa o instrução SQL
        /// </summary>
        /// <param name="pInformacaoTransacao"></param>
        /// <returns></returns>
        private ResultadoTransacao ExecutarSQL(InformacaoTransacao pInformacaoTransacao)
        {
            try
            {
                switch (pInformacaoTransacao.TipoTransacao)
                {
                    case TipoTransacao.Select:
                        this._resultadoTransacao = this._executor.ExecuteSelect(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        break;
                    case TipoTransacao.Update:
                        this._resultadoTransacao = this._executor.ExecuteUpdate(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        break;
                    case TipoTransacao.Insert:
                        this._resultadoTransacao = this._executor.ExecuteInsert(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        break;
                    case TipoTransacao.Delete:
                        this._resultadoTransacao = this._executor.ExecuteDelete(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        break;
                    case TipoTransacao.Procedure:
                        this._resultadoTransacao = this._executor.ExecuteProcedure(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        break;
                    default:
                        throw new Exception("Tipo de transação Inválida!");

                }

                return this._resultadoTransacao;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica e executa o instrução SQL
        /// </summary>
        /// <param name="pInformacaoTransacaoList"></param>
        /// <returns></returns>
        private ResultadoTransacao ExecutarSQL(InformacaoTransacao pInformacaoTransacao, SqlTransaction pSqlTransaction)
        {
            try
            {
                switch (pInformacaoTransacao.TipoTransacao)
                {
                    case TipoTransacao.Select:
                    //resultadoTransacao = this.executor.ExecuteSelect(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                    //break;
                    case TipoTransacao.Update:
                    //resultadoTransacao = this.executor.ExecuteUpdate(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                    // break;
                    case TipoTransacao.Insert:
                    //resultadoTransacao = this.executor.ExecuteInsert(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                    //break;
                    case TipoTransacao.Delete:
                        //resultadoTransacao = this.executor.ExecuteDelete(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao());
                        //break;
                        throw new Exception("Transação não implementada para esta operação");
                    case TipoTransacao.Procedure:
                        this._resultadoTransacao = this._executor.ExecuteProcedure(pInformacaoTransacao, FabricaConexao.ObterInstancia().ObterConexao(), pSqlTransaction);
                        break;
                    default:
                        throw new Exception("Tipo de transação Inválido!");

                }

                return this._resultadoTransacao;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
