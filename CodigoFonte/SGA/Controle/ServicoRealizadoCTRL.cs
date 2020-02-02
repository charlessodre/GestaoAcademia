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
    /// Classe de Controle da ServicoRealizado.
    /// </summary>
    public class ServicoRealizadoCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public ServicoRealizadoCTRL()
        {
            this._servicoOT = new ServicoRealizadoOT();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pServicoOT">Objeto de transferência ServicoOT</param>
        public ServicoRealizadoCTRL(ServicoRealizadoOT pServicoOT)
        {
            this._servicoOT = pServicoOT;
        }

        #endregion

        #region Atributos

        private ServicoRealizadoN _servicoN = new ServicoRealizadoN();
        private ServicoRealizadoOT _servicoOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._servicoOT.Codigo = pCodigo;

            base.ResultadoOperacao = this._servicoN.Consultar(this._servicoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._servicoOT.Nome = pNome;

            base.ResultadoOperacao = this._servicoN.Consultar(this._servicoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._servicoOT = new ServicoRealizadoOT();

            base.ResultadoOperacao = this._servicoN.Consultar(this._servicoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao = this._servicoN.Excluir(this._servicoOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._servicoOT.Codigo == 0)
            {
                base.ResultadoOperacao = this._servicoN.Inserir(this._servicoOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao = this._servicoN.Alterar(this._servicoOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao;
        }

        #endregion

    }
}
