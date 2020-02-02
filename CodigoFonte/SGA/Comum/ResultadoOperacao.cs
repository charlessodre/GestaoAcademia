using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using System.Collections;
using Utilitarios;

namespace Comum
{
    public class ResultadoOperacao
    {
        #region Construtores

        #endregion

        #region Atributos

        private Exception _excecao;
        private Utilitarios.Enumeradores.Resultados _resultado;
        private IList _objetosList;
        private Enumeradores.TipoOperacao _tipoOperacao;
        private bool _temObjeto;



        #endregion

        #region Propriedades

        /// <summary>
        /// Exceção gerada.
        /// </summary>
        public Exception Excecao
        {
            get { return _excecao; }
            set { _excecao = value; }
        }

        /// <summary>
        /// Indica se a lista de objetos possui algum objeto
        /// </summary>
        public bool TemObjeto
        {
            get { return _temObjeto; }
        }

        /// <summary>
        /// Lê e escreve o tipo da operação realizada.
        /// </summary>
        public Enumeradores.TipoOperacao TipoOperacao
        {
            get { return _tipoOperacao; }
            set { _tipoOperacao = value; }
        }


        /// <summary>
        /// Lê e escreve uma lista de objetos não genérica.
        /// </summary>
        public IList ListaObjetos
        {
            get { return _objetosList; }
            set
            {
                _objetosList = value;

                if (_objetosList != null && _objetosList.Count > 0)
                    this._temObjeto = true;
                else
                    this._temObjeto = false;
            }
        }

        /// <summary>
        /// Lê e Escreve o resultado da operação.
        /// </summary>
        public Utilitarios.Enumeradores.Resultados Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

        #endregion

        #region Métodos

        #endregion

    }
}
