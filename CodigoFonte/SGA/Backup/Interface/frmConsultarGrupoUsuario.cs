using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comum;
using Controle;
using ObjetoOT;
using Utilitarios;
using Controle.Auxiliares;

namespace Interface
{
    public partial class frmConsultarGrupoUsuario : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarGrupoUsuario(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private GrupoUsuarioCTRL _grupoUsuarioCTRL;
        private List<GrupoUsuarioOT> _grupoUsuarioList;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarGrupoUsuario_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarGrupoUsuario_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarGrupoUsuario;
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConsultarGrupoUsuarios();
        }

        /// <summary>
        /// frmConsultarGrupoUsuario_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarGrupoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarGrupoUsuario_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarGrupoUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarGrupoUsuarios();
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsultaGrupoUsuario_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaGrupoUsuario_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// dgvConsultaGrupoUsuario_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaGrupoUsuario_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsultaGrupoUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaGrupoUsuario.SelectedRows[0].Cells["colCodigo"].Value);


                if (e.KeyCode == Keys.Enter)
                {
                    this.ExibirFormCadastro(codigo);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirGrupoUsuario(codigo);
                }

            }
        }

        /// <summary>
        /// dgvConsultaGrupoUsuario_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaGrupoUsuario_DoubleClick(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvConsultaGrupoUsuario.SelectedRows[0].Cells["colCodigo"].Value);

            this.ExibirFormCadastro(codigo);
        }


        #endregion

        #region Eventos


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            this.ConsultarGrupoUsuarios();
        }

        /// <summary>
        /// btnNovo_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.ExibirFormCadastro();
        }

        /// <summary>
        /// btnExcluir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvConsultaGrupoUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaGrupoUsuario.SelectedRows[0].Cells["colCodigo"].Value);

                this.ExcluirGrupoUsuario(codigo);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvConsultaGrupoUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaGrupoUsuario.SelectedRows[0].Cells["colCodigo"].Value);

                this.ExibirFormCadastro(codigo);
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

        /// <summary>
        /// cboSituacao_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSituacao.SelectedIndex > -1)
            {
                this.ConsultarGrupoUsuarios();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta os grupos de usuaários.
        /// </summary>
        private void ConsultarGrupoUsuarios()
        {
            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            this._grupoUsuarioCTRL = new GrupoUsuarioCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = this._grupoUsuarioCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = this._grupoUsuarioCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = this._grupoUsuarioCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._grupoUsuarioList = (List<GrupoUsuarioOT>)base.ResultadoOperacao.ListaObjetos;
                this.AtualizarDataGridView();
            }
            else
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }


        }

        /// <summary>
        /// Atualiza os dados do data grid vie.
        /// </summary>
        private void AtualizarDataGridView()
        {
            this.dgvConsultaGrupoUsuario.AutoGenerateColumns = false;
            this.dgvConsultaGrupoUsuario.DataSource = this._grupoUsuarioList;
            this.dgvConsultaGrupoUsuario.Select();
        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastro(int pCodigo)
        {
            frmCadastrarGrupoUsuario frmCadastrarGrupoUsuario = new frmCadastrarGrupoUsuario(pCodigo, base.ControladorUsuarioSistema);
            frmCadastrarGrupoUsuario.ShowDialog();
            this.ConsultarGrupoUsuarios();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        private void ExibirFormCadastro()
        {
            frmCadastrarGrupoUsuario frmCadastrarGrupoUsuario = new frmCadastrarGrupoUsuario(base.ControladorUsuarioSistema);
            frmCadastrarGrupoUsuario.ShowDialog();
            this.ConsultarGrupoUsuarios();
        }

        /// <summary>
        /// Exclui um grupo de usuário.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExcluirGrupoUsuario(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                GrupoUsuarioOT grupoUsuarioOT = new GrupoUsuarioOT();

                grupoUsuarioOT.Codigo = pCodigo;

                this._grupoUsuarioCTRL = new GrupoUsuarioCTRL(grupoUsuarioOT);

                base.ResultadoOperacao = this._grupoUsuarioCTRL.Excluir();


                if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
                {
                    if (base.ResultadoOperacao.TipoOperacao == Enumeradores.TipoOperacao.Exclusao)
                    {
                        base.ExibirMessagemGeral(Mensagem.ExcluidoSucesso, TituloJanelas.ExcluirRegistro,
                                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    if (base.ResultadoOperacao.TipoOperacao == Enumeradores.TipoOperacao.Exclusao)
                    {
                        base.ExibirMessagemGeral(Mensagem.ErroExcluir, TituloJanelas.ExcluirRegistro,
                                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }

                this.ConsultarGrupoUsuarios();
            }


        }

        #endregion

    }
}
