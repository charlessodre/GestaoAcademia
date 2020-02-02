using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
using Controle;
using Comum;
using Utilitarios;

namespace Interface
{
    public partial class frmBase : Form
    {

        #region Construtores

        public frmBase()
        {
            InitializeComponent();
        }

        #endregion

        #region Constantes

        #endregion

        #region Atributos

        private Logger _logger = LogManager.GetCurrentClassLogger();
        private UsuarioCTRL _controladorUsuarioSistema = null;
        private bool _modoCadastro = false;
        private ResultadoOperacao _resultadoOperacao;
        private bool _fecharFormulario = false;


        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e Escreve as informações em que modo o fomulário está.
        /// </summary>
        public bool ModoCadastro
        {
            get { return _modoCadastro; }
            set { _modoCadastro = value; }
        }


        /// <summary>
        /// Lê e Escreve as informações do usuário logado no sistema.
        /// </summary>
        public UsuarioCTRL ControladorUsuarioSistema
        {
            get { return _controladorUsuarioSistema; }
            set { _controladorUsuarioSistema = value; }
        }

        /// <summary>
        ///  Lê e Escreve o resultado da operação realizada.
        /// </summary>
        public ResultadoOperacao ResultadoOperacao
        {
            get { return _resultadoOperacao; }
            set { _resultadoOperacao = value; }
        }

        /// <summary>
        /// Lê e Escreve a informação se é para fechar o fomulário.
        /// </summary>
        public bool FecharFormulario
        {
            get { return _fecharFormulario; }
            set { _fecharFormulario = value; }
        }

        #endregion

        #region Eventos

        #endregion

        #region Métodos Privados

        private void ExibirMensagemErro(ResultadoOperacao pResultadoOperacao)
        {
            string mensagem = string.Format("{0} {1}", Mensagem.MensagemResultadoOperacao(pResultadoOperacao.Resultado, pResultadoOperacao.TipoOperacao), pResultadoOperacao.Excecao.Message);

            this.ExibirMessagemGeral(mensagem, TituloJanelas.ErroGeral, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);


        }

        /// <summary>
        /// Exibe a mensagem de sucesso na operação.
        /// </summary>
        /// <param name="pResultadoOperacao">Resultado da operação.</param>
        private void ExibirMensagemSucesso(ResultadoOperacao pResultadoOperacao)
        {
            string mensagem = Mensagem.MensagemResultadoOperacao(pResultadoOperacao.Resultado, pResultadoOperacao.TipoOperacao);

            this.ExibirMessagemGeral(mensagem, TituloJanelas.SucessoGeral, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);


        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Retona a instância da classe de log do sistema.
        /// </summary>
        public Logger RegistarLog()
        {
            return this._logger;
        }

        /// <summary>
        /// Exibe a mensagem de retorno da operação realizada.
        /// </summary>
        /// <param name="pResultadoOperacao">Resultado da operação.</param>
        public void ExibirMensagemOperacao(ResultadoOperacao pResultadoOperacao)
        {
            if (pResultadoOperacao.Resultado != Enumeradores.Resultados.Sucesso)
            {
                this.ExibirMensagemErro(pResultadoOperacao);
                this._logger.Error(pResultadoOperacao.TipoOperacao.ToString(), pResultadoOperacao.Excecao);

            }
            else
            {
                this.ExibirMensagemSucesso(pResultadoOperacao);
            }

        }

        /// <summary>
        ///  Exibe a mensagem qualquer.
        /// </summary>
        /// <param name="pMensagem">Mensagem a ser exibida.</param>
        /// <param name="pTituloJanela">Título da janela de mensagem.</param>
        /// <param name="pTipoBotao">Tipo do botão.</param>
        /// <param name="pTipoIcone">Tipo de icone da mensagem</param>
        /// <param name="pBotaoSelecioando">Botão selecioando</param>
        /// <returns>Retorna o resultado.</returns>
        public DialogResult ExibirMessagemGeral(string pMensagem, string pTituloJanela, MessageBoxButtons pTipoBotao, MessageBoxIcon pTipoIcone, MessageBoxDefaultButton pBotaoSelecioando)
        {
            return MessageBox.Show(pMensagem, pTituloJanela, pTipoBotao, pTipoIcone, pBotaoSelecioando);
        }

        #endregion


    }
}
