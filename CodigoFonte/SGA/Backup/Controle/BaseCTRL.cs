using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using Comum;

namespace Controle
{
    /// <summary>
    /// Classe base das classes de Controle.
    /// Padrão MVC - CONTROLLER
    /// </summary>
    public abstract class BaseCTRL
    {
        #region Atributos

        private ResultadoOperacao _resultadoOperacao = null;



        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve o resultado da operação
        /// </summary>
        public ResultadoOperacao ResultadoOperacao
        {
            get { return _resultadoOperacao; }
            set { _resultadoOperacao = value; }
        }


        #endregion

        #region Métodos Abstratos

        /// <summary>
        /// Salva um Objeto.
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public abstract ResultadoOperacao Salvar();

        /// <summary>
        /// Consulta um objeto pelo código.
        /// </summary>
        /// <param name="pCodigo">Código do objeto a ser localizado.</param>
        /// <returns>Retorna o resultado da operação</returns>
        public abstract ResultadoOperacao ConsultarCodigo(int pCodigo);

        /// <summary>
        /// Consulta um objeto pelo nome.
        /// </summary>
        /// <param name="pNome">Nome do objeto a ser localizado.</param>
        /// <returns>Retorna o resultado da operação</returns>
        public abstract ResultadoOperacao ConsultarNome(string pNome);

        /// <summary>
        /// Consulta todos os objetos.
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public abstract ResultadoOperacao ConsultarTodos();

        /// <summary>
        /// Exclui um Objeto.
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public abstract ResultadoOperacao Excluir();

        #endregion

    }
}
