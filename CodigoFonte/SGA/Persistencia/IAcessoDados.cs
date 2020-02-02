
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace PersistenciaDAO
{
    /// <summary>
    /// Interface que provê os métodos de acesso ao banco de dados.
    /// </summary>
    /// <typeparam name="T">Objeto Tranferência</typeparam>
    public interface IAcessoDados<T> where T : BaseOT
    {
        /// <summary>
        /// Executa uma operação de consulta no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Transação</returns>
        ResultadoTransacao Select(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de inserção no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Transação</returns>
        ResultadoTransacao Insert(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de alteração no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Transação</returns>
        ResultadoTransacao Update(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de exclusão no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Transação</returns>
        ResultadoTransacao Delete(T pObjetoOT);

    }
}
