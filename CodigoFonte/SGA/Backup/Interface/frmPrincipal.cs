using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitarios;
using Controle;
using System.Threading;

namespace Interface
{
    public partial class frmPrincipal : frmBase
    {

        #region Construtores

        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        #endregion

        #region Atributos

        private bool _trocarUsuario = false;
        private Thread _threadHora = null;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmPrincipal_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.PreencherInformacoesBarraStatus();
        }


        /// <summary>
        /// frmPrincipal_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._trocarUsuario)
            {
                if (base.ExibirMessagemGeral(Mensagem.TrocarUsuario, TituloJanelas.TrocarUsuario,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this._trocarUsuario = false;
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;

                }
            }
            else
            {
                if (!base.FecharFormulario)
                {
                    if (base.ExibirMessagemGeral(Mensagem.SairSistema, TituloJanelas.SairSistema,
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        base.FecharFormulario = true;
                        this._threadHora.Abort();
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

        }


        #endregion

        #region Eventos Menu Principal

        /// <summary>
        /// mnuAjuda_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAjuda_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// mnuSair_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// mnuAluno_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAluno_Click(object sender, EventArgs e)
        {
            frmConsultarAluno frmConsultarAluno = new frmConsultarAluno(base.ControladorUsuarioSistema);
            frmConsultarAluno.ShowDialog();
        }


        /// <summary>
        /// mnuContasAReceber_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuContasAReceber_Click(object sender, EventArgs e)
        {
            frmConsultarContasReceber frmConsultarContasReceber = new frmConsultarContasReceber(base.ControladorUsuarioSistema);
            frmConsultarContasReceber.ShowDialog();

        }


        /// <summary>
        /// mnuEstado_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEstado_Click(object sender, EventArgs e)
        {
            frmConsultarEstadoPaisCidade frmConsultarEstadoPaisCidade = new frmConsultarEstadoPaisCidade(base.ControladorUsuarioSistema, frmCadastrarEstadoPaisCidade.TipoFormulario.Estado);
            frmConsultarEstadoPaisCidade.ShowDialog();
        }


        /// <summary>
        /// mnuCidade_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCidade_Click(object sender, EventArgs e)
        {
            frmConsultarEstadoPaisCidade frmConsultarEstadoPaisCidade = new frmConsultarEstadoPaisCidade(base.ControladorUsuarioSistema, frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade);
            frmConsultarEstadoPaisCidade.ShowDialog();

        }


        /// <summary>
        /// mnuEmpresa_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEmpresa_Click(object sender, EventArgs e)
        {
            frmConsultarEmpresa frmConsultarEmpresa = new frmConsultarEmpresa(base.ControladorUsuarioSistema);
            frmConsultarEmpresa.ShowDialog();
        }

        /// <summary>
        /// mnuProfissao_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuProfissao_Click(object sender, EventArgs e)
        {
            frmConsultarProfissao frmConsultarProfissao = new frmConsultarProfissao(base.ControladorUsuarioSistema);
            frmConsultarProfissao.ShowDialog();
        }

        /// <summary>
        /// mnuPais_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPais_Click(object sender, EventArgs e)
        {
            frmConsultarEstadoPaisCidade frmConsultarEstadoPaisCidade = new frmConsultarEstadoPaisCidade(base.ControladorUsuarioSistema, frmCadastrarEstadoPaisCidade.TipoFormulario.Pais);
            frmConsultarEstadoPaisCidade.ShowDialog();
        }

        /// <summary>
        /// mnuSistema_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSistema_Click(object sender, EventArgs e)
        {
            frmConfigurarSistema frmConfigurarSistema = new frmConfigurarSistema(base.ControladorUsuarioSistema);
            frmConfigurarSistema.ShowDialog();
        }

        #endregion

        #region Eventos Botões Principais


        /// <summary>
        /// btnContasReceber_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            frmConsultarContasReceber frmConsultarContasReceber = new frmConsultarContasReceber(base.ControladorUsuarioSistema);
            frmConsultarContasReceber.ShowDialog();
        }

        /// <summary>
        /// btnTrocarUsuario_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrocarUsuario_Click(object sender, EventArgs e)
        {
            this._trocarUsuario = true;
            this.Close();
        }

        /// <summary>
        /// btnSair_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Eventos


        #endregion

        #region Métodos

        /// <summary>
        /// Preenche as informações da barra de status
        /// </summary>
        private void PreencherInformacoesBarraStatus()
        {
            this.stlblUsuarioLogado.Text = this.ControladorUsuarioSistema.UsuarioSistema.Nome;
            this.stDataAtual.Text = DateTime.Today.ToString("dd/MM/yy");

            this._threadHora = new Thread(this.AtualizarHoraBarraStatus);
            _threadHora.Start();
        }

        /// <summary>
        /// Método responsável por atualizar a hora da barra de status.
        /// </summary>
        private void AtualizarHoraBarraStatus()
        {
            while (true)
            {
                this.stlblHora.Text = DateTime.Now.ToString("HH:mm:ss");
                this.ResumeLayout();
                Thread.Sleep(990);
            }
        }

        #endregion

       

       





    }
}
