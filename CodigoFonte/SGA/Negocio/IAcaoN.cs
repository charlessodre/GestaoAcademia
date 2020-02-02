using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaDAO;
using ObjetoOT;
using Utilitarios;
using Comum;

namespace Negocio
{
    public interface IAcaoN<T> where T : BaseOT
    {
        /// <summary>
        /// Executa uma operação de consulta no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Operação</returns>
        ResultadoOperacao Consultar(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de inserção no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Operação</returns>
        ResultadoOperacao Inserir(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de alteração no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Operação</returns>
        ResultadoOperacao Alterar(T pObjetoOT);

        /// <summary>
        /// Executa uma operação de exclusão no banco de dados
        /// </summary>
        /// <param name="pObjetoOT">Objeto Transferência</param>
        /// <returns>Retorna o Resultado da Operação</returns>
        ResultadoOperacao Excluir(T pObjetoOT);

    }
}
