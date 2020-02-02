using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class PaisOT : BaseOT
    {
        #region Atributos

        private string _sigla;

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve o a sigla do Pais.
        /// </summary>
        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

       
        #endregion

        #region Métodos


        #endregion
    }
}
