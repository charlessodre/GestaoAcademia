using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utilitarios;
using System.Collections;

namespace PersistenciaDAO
{
    /// <summary>
    /// Classe que guarda o resultado da operação no banco de dados.
    /// </summary>
    public class ResultadoTransacao
    {
        #region Atributos

        private DataSet _dataSetRetono;
        private string _nome;
        private int _registrosAfetados;
        private Utilitarios.Enumeradores.Resultados _resultado;
        private DataSet _parametrosSaida;
        private IList _listaObjetos;
        private Exception _excecao;




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
            this._nome = pName;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve a exceção gerada.
        /// </summary>
        public Exception Excecao
        {
            get { return _excecao; }
            set { _excecao = value; }
        }


        /// <summary>
        /// Lê e Escreve uma lista de objetos.
        /// </summary>
        public IList ListaObjetos
        {
            get { return _listaObjetos; }
            set { _listaObjetos = value; }
        }

        /// <summary>
        /// Lê e Escreve o DataSet de Retorno.
        /// </summary>
        public DataSet DataSetRetono
        {
            get
            {
                if (this._dataSetRetono != null)
                {
                    if ((this._dataSetRetono.Tables.Count == 0) && (this._parametrosSaida.Tables.Count > 0))
                    {
                        return this._parametrosSaida;
                    }
                }
                return this._dataSetRetono;
            }
            set { this._dataSetRetono = value; }

        }

        /// <summary>
        /// Lê e Escreve os Parâmetros de Saída.
        /// </summary>
        public DataSet ParametrosSaida
        {
            get { return this._parametrosSaida; }
            set { this._parametrosSaida = value; }
        }

        /// <summary>
        ///  Lê e Escreve o nome do Resultado.
        /// </summary>
        public string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        /// <summary>
        ///  Lê se o Dataset possui dados.
        /// </summary>
        public bool ExisteDados
        {
            get
            {
                if (this._dataSetRetono.Tables.Count > 0)
                {
                    return this._dataSetRetono.Tables[0].Rows.Count > 0;
                }
                return false;
            }
        }

        /// <summary>
        /// Lê se a quantidade de registros afetados.
        /// </summary>
        public int RegistrosAfetados
        {
            get { return _registrosAfetados; }
        }

        /// <summary>
        /// Lê o resultado da transação.
        /// </summary>
        public Utilitarios.Enumeradores.Resultados Resultado
        {
            get { return _resultado; }
        }

       

        #endregion

        #region Métodos

        /// <summary>
        /// Marca a exceção retonada na transação.
        /// </summary>
        /// <param name="pException">Exceção da transação.</param>
        internal void MarcarExcecao(Exception pException)
        {
            this._excecao = pException;
        }

        /// <summary>
        /// Marca o resultado da transação.
        /// </summary>
        /// <param name="pResultado">Resultado da transação.</param>
        internal void MarcarResultado(Utilitarios.Enumeradores.Resultados pResultado)
        {
            this._resultado = pResultado;
        }

        /// <summary>
        /// Marca a quantidade de resgistros afetados na operação.
        /// </summary>
        /// <param name="pRegistrosAfetados">Quantidade de registros afetados na operação</param>
        internal void MarcarRegistrosAfetados(int pRegistrosAfetados)
        {
            this._registrosAfetados = pRegistrosAfetados;
        }

        /// <summary>
        /// Marca o Dataset com os dados da operação.
        /// </summary>
        /// <param name="pDataSet">DataSet com os dados da operação.</param>
        internal void MarcarDataSet(DataSet pDataSet)
        {
            this._dataSetRetono = pDataSet;
        }

        /// <summary>
        ///  Marca os Parâmetros de Saida.
        /// </summary>
        /// <param name="pParametrosSaida"></param>
        internal void MarcarParametrosSaida(DataSet pParametrosSaida)
        {
            this._parametrosSaida = pParametrosSaida;
        }

        #endregion
    }
}
