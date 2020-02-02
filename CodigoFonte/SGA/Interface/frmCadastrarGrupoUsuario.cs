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
    public partial class frmCadastrarGrupoUsuario : frmBase, IPreenchimentoForm<GrupoUsuarioOT>
    {
        #region Construtores


       /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarGrupoUsuario(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        /// <param name="pCodigo">Código do tipo de usuário.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarGrupoUsuario(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;

        }

        #endregion

        #region Atributos

        private int _codigo;
        private GrupoUsuarioCTRL _grupoUsuarioCTRL = null;
        private GrupoUsuarioOT _grupoUsuarioOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Fomulário

        /// <summary>
        /// frmCadastrarGrupoUsuario_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarGrupoUsuario_Load(object sender, EventArgs e)
        {
            if (this._codigo > 0)
            {
                this.Text = TituloJanelas.CadastroGrupoUsuario;
                this.ConsultarDadoGrupoUsuario();
            }
            else
            {
                this.Text = TituloJanelas.AlterarGrupoUsuario;
            }
        }

        /// <summary>
        /// frmCadastrarGrupoUsuario_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarGrupoUsuario_KeyDown(object sender, KeyEventArgs e)
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
            this.Dispose();
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


            return true;
        }


        #endregion

        #region Métodos GrupoUsuario

        /// <summary>
        /// Consulta os dados do GrupoUsuario
        /// </summary>
        private void ConsultarDadoGrupoUsuario()
        {
            this._grupoUsuarioOT = new GrupoUsuarioOT();
            this._grupoUsuarioOT = (GrupoUsuarioOT)this._grupoUsuarioCTRL.ConsultarCodigo(this._codigo).ListaObjetos[0];

            this.PreencherFomulario(this._grupoUsuarioOT);
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            GrupoUsuarioOT grupoUsuarioNovo = this.ConstruirObjeto();

            if (this._codigo > 0)
            {
                grupoUsuarioNovo.Codigo = this._codigo;
            }

            GrupoUsuarioCTRL grupoUsuarioCTRL = new GrupoUsuarioCTRL(grupoUsuarioNovo);

           base.ResultadoOperacao = grupoUsuarioCTRL.Salvar();

            base.ExibirMensagemOperacao(base.ResultadoOperacao);
        }

        #endregion

        #region IPreenchimentoForm<GrupoUsuarioOT> Members

        public GrupoUsuarioOT ConstruirObjeto()
        {
            GrupoUsuarioOT grupoUsuarioOT = new GrupoUsuarioOT();

            grupoUsuarioOT.Nome = this.txtNome.Text.Trim();

            return grupoUsuarioOT;
        }

        public void PreencherFomulario(GrupoUsuarioOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString();
            this.txtNome.Text = pObjetoOT.Nome;
        }

        #endregion

    }
}
