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
    /// Classe de Controle da Recibo.
    /// </summary>
    public class ReciboCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public ReciboCTRL()
        {
            this._reciboOT = new ReciboOT();
            this._reciboN = new ReciboN();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pReciboOT">Objeto de transferência ReciboOT</param>
        public ReciboCTRL(ReciboOT pReciboOT)
        {
            this._reciboOT = pReciboOT;
            this._reciboN = new ReciboN();
        }

        #endregion

        #region Atributos

        private ReciboN _reciboN = null;
        private ReciboOT _reciboOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._reciboOT.Codigo = pCodigo;

            base.ResultadoOperacao = this._reciboN.Consultar(this._reciboOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._reciboOT.Nome = pNome;

            base.ResultadoOperacao = this._reciboN.Consultar(this._reciboOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._reciboOT = new ReciboOT();

            base.ResultadoOperacao = this._reciboN.Consultar(this._reciboOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao = this._reciboN.Excluir(this._reciboOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._reciboOT.Codigo == 0)
            {
                base.ResultadoOperacao = this._reciboN.Inserir(this._reciboOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao = this._reciboN.Alterar(this._reciboOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao;
        }

        #endregion

    }
}
