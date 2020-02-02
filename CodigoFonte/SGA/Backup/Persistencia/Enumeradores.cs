using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenciaDAO
{
    /// <summary>
    /// Tipo de Transação
    /// </summary>
    public enum TipoTransacao : short
    {
        Select = 1,
        Update = 2,
        Insert = 3,
        Delete = 4,
        Procedure = 5
       
    }

    /// <summary>
    /// Tipo de Comparação
    /// </summary>
    public enum TipoComparacao : short
    {
        Igual = 1,
        Maior = 2,
        Menor = 3,
        MaiorOuIgual = 4,
        MenorOuIgual = 5,
        Like = 6
    }
}
