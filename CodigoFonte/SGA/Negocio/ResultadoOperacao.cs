using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ResultadoOperacao
    {
        #region Construtores

        #endregion

        #region Atributos

        private string _mensagem;
        private SCCVE_Utilitarios.Enumeradores.Resultados _resultado;



        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve a mensagem.
        /// </summary>
        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
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
