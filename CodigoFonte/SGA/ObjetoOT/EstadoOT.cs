using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class EstadoOT : BaseOT, IEquatable<EstadoOT>
    {
        #region Atributos
               
        private string _sigla;

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve o a sigla do estado.
        /// </summary>
        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

       
        #endregion

        #region Métodos


        #endregion

        #region IEquatable<EstadoOT> Members

          /// <summary>
        /// Verifica se o objetos são iguais.
        /// </summary>
        /// <param name="other">Objeto para comparação</param>
        /// <returns>Retorna TRUE se os objetos forem iguais e FALSE se forem diferentes</returns>
        public bool Equals(EstadoOT other)
        {
           return (other as object) != null && (this.Codigo == other.Codigo &&
                                               this.Nome == other.Nome &&
                                               this.Status == other.Status);
       
        }

        #endregion
    }
}
