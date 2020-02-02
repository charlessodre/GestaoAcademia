using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class ServicoRealizadoOT : BaseOT
    {
        #region Atributos

        private string _descricao;

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e escreve a descrição do serviço.
        /// </summary>
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }


        #endregion

        #region Métodos


        #endregion
    }
}
