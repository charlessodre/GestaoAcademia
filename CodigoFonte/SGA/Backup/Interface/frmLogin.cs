using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitarios;
using ObjetoOT;
using Controle;
using Comum;

namespace Interface
{
    public partial class frmLogin : frmBase
    {
        #region Construtores

        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Enumeradores


        #endregion

        #region Atributos

        private int _numerosTentativasLogin;
        private UsuarioOT _usuarioSistema;
        private UsuarioCTRL _usuarioCTRL;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Fomulário

        /// <summary>
        /// frmLogin_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// frmLogin_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// btnEntrar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {

            if (this.ValidarPreenchimentoCampos())
            {
                if (this.ValidarUsuario())
                {
                    this.Hide();
                    frmPrincipal frmPrincipal = new frmPrincipal(this._usuarioCTRL);
                    frmPrincipal.ShowDialog();
                    this.LimparDadosFormulario();
                    this.Show();
                    this.txtSenha.Focus();

                }
                else if (base.ResultadoOperacao.Resultado != Enumeradores.Resultados.Sucesso)
                {
                    if (base.ResultadoOperacao.TipoOperacao == Enumeradores.TipoOperacao.Alteracao)
                    {
                        base.ExibirMessagemGeral(string.Format("{0} - {1}", Mensagem.MensagemResultadoOperacao(base.ResultadoOperacao.Resultado, Enumeradores.TipoOperacao.Consulta),base.ResultadoOperacao.Excecao.Message)
                                , TituloJanelas.FalhaLogin, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    this.VerificarTentativasLogin();
                }
            }


        }

        /// <summary>
        /// btnFechar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
           base.ResultadoOperacao = null;
            this._numerosTentativasLogin = 0;
            this._usuarioSistema = null;
            this._usuarioCTRL = null;
            this.txtLogin.Text = string.Empty;
            this.txtSenha.Text = string.Empty;
        }

        /// <summary>
        /// Verifica as tentativa de Login do usuário.
        /// </summary>
        private void VerificarTentativasLogin()
        {
            if (this._usuarioSistema != null && this._usuarioSistema.Status == Enumeradores.Status.Ativo)
            {
                this._numerosTentativasLogin++;

                if (this._numerosTentativasLogin == this._usuarioSistema.NumeroTentativasLogin)
                {
                    this.BloquearUsuario();
                    this._numerosTentativasLogin = 0;
                    base.RegistarLog().Warn(Mensagem.UsuarioBloqueadoLog(this._usuarioSistema.Login));
                }
            }
        }

        /// <summary>
        /// Bloqueia o usuário no Banco de dados
        /// </summary>
        private void BloquearUsuario()
        {
            if (this._usuarioSistema.Codigo != 0)
            {
                this._usuarioCTRL = new UsuarioCTRL(this._usuarioSistema);
                this._usuarioCTRL.Bloquear();
            }
        }

        /// <summary>
        /// Valida o acesso do usuário
        /// </summary>
        /// <returns></returns>
        private bool ValidarUsuario()
        {
            bool _retorno = false;
            this._usuarioSistema = new UsuarioOT();
            //
            this._usuarioSistema.Login = this.txtLogin.Text.Trim();
            this._usuarioSistema.Senha = this.txtSenha.Text;
            //
            this._usuarioCTRL = new UsuarioCTRL(this._usuarioSistema);
            //
           base.ResultadoOperacao = _usuarioCTRL.CarregarUsuario();

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                if (base.ResultadoOperacao.ListaObjetos.Count > 0)
                {
                    this._usuarioSistema = (UsuarioOT)base.ResultadoOperacao.ListaObjetos[0];

                    if (this._usuarioSistema.AcessoPermitido)
                    {
                        this._numerosTentativasLogin = 0;
                        _retorno = true;
                    }
                    else
                    {
                        if (this._usuarioSistema.Status == Enumeradores.Status.Inativo)
                        {
                            base.ExibirMessagemGeral(Mensagem.UsuarioBloqueado, TituloJanelas.FalhaLogin, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                            base.RegistarLog().Warn(Mensagem.UsuarioDesativadoTentouLoginLog(this._usuarioSistema.Login));
                        }
                        else
                        {
                            base.ExibirMessagemGeral(Mensagem.UsuarioInvalido, TituloJanelas.FalhaLogin, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        }
                    }
                }
                else
                {
                    base.ExibirMessagemGeral(Mensagem.UsuarioInvalido, TituloJanelas.FalhaLogin, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

            }
            else
            {
                base.RegistarLog().ErrorException(Mensagem.ErroValidarUsuarioLog(this._usuarioSistema.Login),base.ResultadoOperacao.Excecao);
            }

            return _retorno;

        }

        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            if (this.txtLogin.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.LoginObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtLogin.Focus();
                return false;
            }

            if (this.txtSenha.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.SenhaObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtSenha.Focus();
                return false;
            }


            return true;
        }

        #endregion


    }
}
