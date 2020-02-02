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
    public partial class frmCadastrarProfissao : frmBase, IPreenchimentoForm<ProfissaoOT>
    {
        #region Construtores


        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarProfissao(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;

        }


        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        /// <param name="pCodigo">Código da Profissão</param>
        public frmCadastrarProfissao(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            this._codigo = pCodigo;



        }

        #endregion

        #region Atributos

        private int _codigo;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Fomulário

        /// <summary>
        /// frmCadastrarProfissao_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarProfissao_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.CadastroProfissao;
            this.lblTitulo.Text = TituloJanelas.CadastroProfissao;
            this.RecuperarDadosProfissao();
            this.txtNome.Focus();
        }

        /// <summary>
        /// frmCadastrarProfissao_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarProfissao_KeyDown(object sender, KeyEventArgs e)
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

                base.ExibirMensagemOperacao(base.ResultadoOperacao);

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
            this.txtNome.Focus();
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

        #region Métodos Profissao

        /// <summary>
        /// Recupera os dados do Profissao
        /// </summary>
        private void RecuperarDadosProfissao()
        {
            if (this._codigo > 0)
            {
                ProfissaoCTRL profissaoCTRL = new ProfissaoCTRL();

                base.ResultadoOperacao = profissaoCTRL.ConsultarCodigo(this._codigo);

                if (base.ResultadoOperacao.TemObjeto)
                {
                    this.PreencherFomulario((ProfissaoOT)base.ResultadoOperacao.ListaObjetos[0]);
                }
            }

        }


        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            ProfissaoOT profissaoOT = this.ConstruirObjeto();

            if (this._codigo > 0)
            {
                profissaoOT.Codigo = this._codigo;
            }

            ProfissaoCTRL profissaoCTRL = new ProfissaoCTRL(profissaoOT);

            base.ResultadoOperacao = profissaoCTRL.Salvar();

        }

        #endregion

        #region IPreenchimentoForm<ProfissaoOT> Members

        public ProfissaoOT ConstruirObjeto()
        {
            ProfissaoOT profissaoOT = new ProfissaoOT();

            profissaoOT.Nome = this.txtNome.Text.Trim();

            return profissaoOT;
        }

        public void PreencherFomulario(ProfissaoOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString();
            this.txtNome.Text = pObjetoOT.Nome;
        }

        #endregion
    }
}
