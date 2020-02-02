using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PersistenciaDAO
{
    /// <summary>
    /// Classe que guarda o resultado da operação no banco de dados.
    /// </summary>
    public class ResultadoTransacao
    {
        #region Atributos

        private DataSet dataSetRetono;
        private string nome;
        private int registrosAfetados;
        private DataSet parametrosSaida;

        #endregion

        #region Construtores
        /// <summary>
        /// Construtor.
        /// </summary>
        public ResultadoTransacao()
        {

        }

        /// <summary>
        /// Construtor com o nome do resultado.
        /// </summary>
        /// <param name="pName">Nemo do resultado.</param>
        public ResultadoTransacao(string pName)
        {
            this.nome = pName;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve o DataSet de Retorno.
        /// </summary>
        public DataSet DataSetRetono
        {
            get
            {
                if (this.dataSetRetono != null)
                {
                    if ((this.dataSetRetono.Tables.Count == 0) && (this.parametrosSaida.Tables.Count > 0))
                    {
                        return this.parametrosSaida;
                    }
                }
                return this.dataSetRetono;
            }
            set { this.dataSetRetono = value; }

        }

        /// <summary>
        /// Lê e Escreve os Parâmetros de Saída.
        /// </summary>
        public DataSet ParametrosSaida
        {
            get { return this.parametrosSaida; }
            set { this.parametrosSaida = value; }
        }

        /// <summary>
        ///  Lê e Escreve o nome do Resultado.
        /// </summary>
        public string Nome
        {
            get {return this.nome;}
            set {this.nome = value;}
        }
             
        /// <summary>
        ///  Lê se o Dataset possui dados.
        /// </summary>
        public bool ExisteDados
        {
            get
            {
                if (this.dataSetRetono.Tables.Count > 0)
                {
                    return this.dataSetRetono.Tables[0].Rows.Count > 0;
                }
                return false;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Marca a quantidade de resgistros afetados na operação.
        /// </summary>
        /// <param name="pRegistrosAfetados">Quantidade de registros afetados na operação</param>
        internal void MarcarRegistrosAfetados(int pRegistrosAfetados)
        {
            this.registrosAfetados = pRegistrosAfetados;
        }

        /// <summary>
        /// Marca o Dataset com os dados da operação.
        /// </summary>
        /// <param name="pDataSet">DataSet com os dados da operação.</param>
        internal void MarcarDataSet(DataSet pDataSet)
        {
            this.dataSetRetono = pDataSet;
        }

        /// <summary>
        ///  Marca os Parâmetros de Saida.
        /// </summary>
        /// <param name="pParametrosSaida"></param>
        internal void MarcarParametrosSaida(DataSet pParametrosSaida)
        {
            this.parametrosSaida = pParametrosSaida;
        }

        #endregion
    }
}
