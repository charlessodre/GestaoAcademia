using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;

namespace ObjetoOT
{
    /// <summary>
    /// Classe Base das Classe de Objetos Transferência.
    /// </summary>
    public abstract class BaseOT
    {
        #region Constantes

        /// <summary>
        /// Constante que define a formatação dos valores moedas.
        /// </summary>
        public const string FOMATACAO_VALOR_MOEDA = "#,##0.00";

        /// <summary>
        /// Constante que define o símbolo monetário.
        /// </summary>
        public const string SIMBOLO_MONETARIO = "R$ ";

        #endregion

        #region Atributos

        private int _codigo;
        private string _nome;
        private UsuarioOT _usuarioAlteracao;
        private DateTime _dataAlteracao;
        private Enumeradores.Status _status;

        #endregion

        #region Propriedades


        /// <summary>
        ///  Lê e Escreve o Status do usuário.
        /// </summary>
        public Enumeradores.Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        ///  Lê e Escreve o usuário responsável pela alteração.
        /// </summary>
        public UsuarioOT UsuarioAlteracao
        {
            get { return _usuarioAlteracao = _usuarioAlteracao ?? new UsuarioOT(); }
            set { _usuarioAlteracao = value; }
        }

        /// <summary>
        ///  Lê e Escreve a data de alteração do objeto.
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return _dataAlteracao; }
            set { _dataAlteracao = value; }
        }


        /// <summary>
        /// Lê e Escreve o nome  do objeto.
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        /// <summary>
        /// Lê e Escreve o código  do objeto.
        /// </summary>
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        

        #endregion



    }
}
