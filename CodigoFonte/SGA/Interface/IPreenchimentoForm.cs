using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace Interface
{
    /// <summary>
    /// Interface que padroniza o preenchimento e a leitura de dados das telas do sistema.
    /// </summary>
    public interface IPreenchimentoForm<T> where T : BaseOT
    {
        /// <summary>
        /// Método que Lê os dados e retorna um objeto contendo esses dados.
        /// </summary>
        /// <returns>Objeto com os dados da tela.</returns>
        T ConstruirObjeto();

        /// <summary>
        /// Método que recebe um objeto e preenche a tela com os dados desse objeto.
        /// </summary>
        /// <param name="pObjetoOT">Objeto que contém os dados a serem inseridos na tela.</param>
        void PreencherFomulario(T pObjetoOT);
    }
}
