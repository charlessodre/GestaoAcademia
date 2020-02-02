using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using Negocio;
using Utilitarios;
using Comum;

namespace Controle
{
    /// <summary>
    /// Interface que provê os métodos de controle.
    /// </summary>
    /// <typeparam name="T">Objeto Tranferência</typeparam>
    public interface IAcaoCTRL<T> where T : BaseOT
    {

        /// <summary>
        /// Insere um novo Objeto.
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência.</param>
        /// <returns>Retorna o resultado da operação</returns>
        ResultadoOperacao Inserir(T pObjetoOT);

        /// <summary>
        /// Consulta um Objeto.
        /// </summary>
        /// <param name="pT">Objeto Transferência.</param>
        /// <returns>Retorna o resultado da operação</returns>
        ResultadoOperacao Consultar(T pObjetoOT);

        /// <summary>
        /// Consulta todos os Objetos
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        ResultadoOperacao ConsultarTodos();

        /// <summary>
        /// Altera um Objeto.
        /// </summary>
        /// <param name="pT">Objeto Transferência.</param>
        /// <returns>Retorna o resultado da operação</returns>
        ResultadoOperacao Alterar(T pObjetoOT);

        /// <summary>
        /// Exclui um Objeto.
        /// </summary>
        /// <param name="pT">Objeto Transferência.</param>
        /// <returns>Retorna o resultado da operação</returns>
        ResultadoOperacao Excluir(T pObjetoOT);
    }
}
