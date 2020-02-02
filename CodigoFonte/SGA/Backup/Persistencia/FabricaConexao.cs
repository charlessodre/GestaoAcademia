using System;
using System.Data.SqlClient;
using System.Configuration;


namespace PersistenciaDAO
{
    /// <summary>
    /// Classe Responsável por efetuar a conexão com o banco de dados Microsoft SQL Server.
    /// Aplicado o padrão de projeto Singleton.
    /// </summary>
    public class FabricaConexao
    {
        #region Atributos

        private static readonly FabricaConexao _instancia = new FabricaConexao();
        private SqlConnection _sqlConnection = null;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor Privado.
        /// </summary>
        private FabricaConexao() { }

        #endregion

        #region Métodos

        /// <summary>
        /// Retorna uma instacia da classe FabricaConexao.
        /// </summary>
        /// <returns>Retorna a instacia criada.</returns>
        public static FabricaConexao ObterInstancia()
        {
            return _instancia;
        }

        /// <summary>
        /// Retorna uma conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection ObterConexao()
        {
            if (_sqlConnection == null)
            {
                this._sqlConnection = new SqlConnection();
                this.ConfigurarConexao();
            }

            return this._sqlConnection;
        }

        /// <summary>
        /// Configura a string de conexão com o Banco de Dados.
        /// </summary>
        private void ConfigurarConexao()
        {
            this._sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }


        #endregion

    }
}
