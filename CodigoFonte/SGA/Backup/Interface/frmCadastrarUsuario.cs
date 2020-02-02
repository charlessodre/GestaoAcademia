using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjetoOT;
using Comum;
using Controle;
using Utilitarios;
using System.Drawing.Imaging;
using Controle.Auxiliares;

namespace Interface
{
    public partial class frmCadastrarUsuario : frmBase, IPreenchimentoForm<UsuarioOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarUsuario(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pCodigo">Código da usuário selecionado.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarUsuario(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }


        #endregion

        #region Atributos

        private UsuarioOT _usuario;
        private UsuarioCTRL _usuarioCTRL;
        private int _codigo;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmCadastrarUsuario_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarUsuario_Load(object sender, EventArgs e)
        {
            PreencherControle.PreencherDropDownStatus(this.cboStatus, base.ModoCadastro);
            this.PreecherComboGrupoUsuario();

            if (this._codigo > 0)
            {
                this.Text = TituloJanelas.AlterarUsuario;
                this.ConsultarDadosUsuario();
            }
            else
            {
                this.Text = TituloJanelas.CadastroUsuario;
                this.dtpExpiracaoSenha.Value = DateTime.Today.AddDays(Comum.ConstantesSitema.DIAS_ESPIRACAO_SENHA);
            }
        }

        /// <summary>
        /// frmCadastrarUsuario_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                base.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmCadastrarUsuario_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// btnGravar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (this.ValidarPreenchimentoCampos())
            {
                this.SalvarRegistro();

                if (this._codigo > 0)
                {
                    this.Dispose();
                }
                else
                {
                    this.LimparDadosFormulario();
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
            this.Close();
        }

        /// <summary>
        /// btnNovoGrupoUsuario_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovoGrupoUsuario_Click(object sender, EventArgs e)
        {
            frmCadastrarGrupoUsuario frmCadastrarGrupoUsuario = new frmCadastrarGrupoUsuario(base.ControladorUsuarioSistema);
            frmCadastrarGrupoUsuario.ShowDialog();
            this.PreecherComboGrupoUsuario();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this._codigo = 0;
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.txtMatricula.Text = string.Empty;
            this.txtLogin.Text = string.Empty;
            this.cboStatus.SelectedIndex = 0;
            this.cboGrupoUsuario.SelectedIndex = 0;
            this.txtEmail.Text = string.Empty;
            this.nupwNTentativasLogin.Value = 1;
            this.dtpExpiracaoSenha.Value = DateTime.Today.AddDays(Comum.ConstantesSitema.DIAS_ESPIRACAO_SENHA);
        }

        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            if (this.txtNome.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.NomeObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtNome.Focus();
                return false;
            }

            if (this.txtLogin.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.TelefoneObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtLogin.Focus();
                return false;
            }

            if (this.cboStatus.SelectedIndex < 1)
            {
                base.ExibirMessagemGeral(Mensagem.StatusObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.cboStatus.Focus();
                return false;
            }

            if (this.txtMatricula.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.LoginObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtMatricula.Focus();
                return false;
            }

            if (this.dtpExpiracaoSenha.Value < DateTime.Today)
            {
                base.ExibirMessagemGeral(Mensagem.DataExpiracaoSenha, TituloJanelas.DataInvalida, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.dtpExpiracaoSenha.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Consulta os dados do usuário.
        /// </summary>
        /// <param name="pCodigo">Código do usuário.</param>
        private void ConsultarDadosUsuario()
        {
            this._usuarioCTRL = new UsuarioCTRL(this._usuario);
            this._usuario = (UsuarioOT)this._usuarioCTRL.ConsultarCodigo(this._codigo).ListaObjetos[0];

            this.PreencherFomulario(this._usuario);
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            UsuarioOT usuarioNovo = this.ConstruirObjeto();

            if (this._codigo > 0)
            {
                usuarioNovo.Codigo = this._codigo;
            }

            this._usuarioCTRL = new UsuarioCTRL(usuarioNovo);

            base.ResultadoOperacao = this._usuarioCTRL.Salvar();

            base.ExibirMensagemOperacao(base.ResultadoOperacao);


        }

        /// <summary>
        /// Preenche o Combobox de Grupos Usuarios
        /// </summary>
        private void PreecherComboGrupoUsuario()
        {
            GrupoUsuarioCTRL grupoUsuarioCTRL = new GrupoUsuarioCTRL();

            base.ResultadoOperacao = grupoUsuarioCTRL.ConsultarTodos();

            if (base.ResultadoOperacao.TemObjeto)
            {
                PreencherControle.PreencherComboBox<GrupoUsuarioOT>(this.cboGrupoUsuario, (List<GrupoUsuarioOT>)base.ResultadoOperacao.ListaObjetos, "Nome", "Codigo", base.ModoCadastro);
            }
        }

        #endregion

        #region IPreenchimentoForm<UsuarioOT> Members

        public UsuarioOT ConstruirObjeto()
        {
            UsuarioOT usuario = new UsuarioOT();

            if (this.txtCodigo.Text.Trim().Length > 0)
            {
                usuario.Codigo = Convert.ToInt32(this.txtCodigo.Text);
                usuario.DataAlteracao = DateTime.Now;
                usuario.UsuarioAlteracao.Codigo = base.ControladorUsuarioSistema.UsuarioSistema.Codigo;
            }

            usuario.Matricula = this.txtMatricula.Text.Trim().Replace("'", " ");
            usuario.Login = this.txtLogin.Text.Trim().Replace("'", " ");
            usuario.Nome = this.txtNome.Text.Trim().Replace("'", " ");
            usuario.Email = this.txtEmail.Text.Trim().Replace("'", " "); ;
            usuario.DataExpiracaoSenha = this.dtpExpiracaoSenha.Value;
            usuario.NumeroTentativasLogin = (int)this.nupwNTentativasLogin.Value;


            if (this.cboStatus.SelectedIndex > Comum.ConstantesSitema.INDICE_INICIAL_COMBO)
            {
                usuario.GrupoUsuarioOT.Codigo = Convert.ToInt32(this.cboGrupoUsuario.SelectedValue);
            }

            return usuario;
        }

        public void PreencherFomulario(UsuarioOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString("00000");
            this.txtNome.Text = pObjetoOT.Nome;
            this.txtMatricula.Text = pObjetoOT.Matricula;
            this.txtLogin.Text = pObjetoOT.Login;
            this.cboStatus.SelectedValue = pObjetoOT.Status;
            this.cboGrupoUsuario.SelectedValue = pObjetoOT.GrupoUsuarioOT.Codigo;
            this.txtEmail.Text = pObjetoOT.Email;

        }

        #endregion



    }
}
