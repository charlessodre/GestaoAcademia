using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaDAO;
using Utilitarios;
using Comum;
using ObjetoOT;


namespace Negocio
{
    /// <summary>
    /// Classe base das classes de Negócio.
    /// Padrão MVC - MODEL
    /// </summary>
    public abstract class BaseN
    {
        #region Atributos

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        /// <summary>
        /// Efetua o tratamento do retorno do banco de dados.
        /// </summary>
        /// <param name="pResultadoTransacao">Resultado da transação efetuada</param>
        /// <returns>Resultado da operação realizada.</returns>
        internal ResultadoOperacao TratarRetornoOperacao(ResultadoTransacao pResultadoTransacao)
        {
            ResultadoOperacao _resultadoOperacao = new ResultadoOperacao();

            if (pResultadoTransacao.Resultado != Enumeradores.Resultados.Sucesso)
            {
                _resultadoOperacao.Excecao = pResultadoTransacao.Excecao;
            }
            else if (pResultadoTransacao.ListaObjetos != null)
            {
                _resultadoOperacao.ListaObjetos = pResultadoTransacao.ListaObjetos;
            }

            _resultadoOperacao.Resultado = pResultadoTransacao.Resultado;


            return _resultadoOperacao;
        }


        #endregion
    }
}
