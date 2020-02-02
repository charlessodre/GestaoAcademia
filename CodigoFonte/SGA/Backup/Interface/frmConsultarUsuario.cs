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
    public partial class frmConsultarUsuario : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarUsuario(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private UsuarioCTRL _usuarioCTRL;
        private List<UsuarioOT> _usuarioList;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarUsuario_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarUsuario_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarUsuario;
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConsultarUsuarios();
        }

        /// <summary>
        /// frmConsultarUsuario_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarUsuario_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarUsuarios();
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsultaUsuario_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaUsuario_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// dgvConsultaUsuario_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaUsuario_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsultaUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaUsuario.SelectedRows[0].Cells["colCodigo"].Value);


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
        /// dgvConsultaUsuario_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaUsuario_DoubleClick(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvConsultaUsuario.SelectedRows[0].Cells["colCodigo"].Value);

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
            this.ConsultarUsuarios();
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
            if (this.dgvConsultaUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaUsuario.SelectedRows[0].Cells["colCodigo"].Value);

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
            if (this.dgvConsultaUsuario.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaUsuario.SelectedRows[0].Cells["colCodigo"].Value);

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
                this.ConsultarUsuarios();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta os usuários.
        /// </summary>
        private void ConsultarUsuarios()
        {
            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            this._usuarioCTRL = new UsuarioCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = this._usuarioCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = this._usuarioCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = this._usuarioCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._usuarioList = (List<UsuarioOT>)base.ResultadoOperacao.ListaObjetos;
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
            this.dgvConsultaUsuario.AutoGenerateColumns = false;
            this.dgvConsultaUsuario.DataSource = this._usuarioList;
            this.dgvConsultaUsuario.Select();
        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastro(int pCodigo)
        {
            frmCadastrarGrupoUsuario frmCadastrarGrupoUsuario = new frmCadastrarGrupoUsuario(pCodigo, base.ControladorUsuarioSistema);
            frmCadastrarGrupoUsuario.ShowDialog();
            this.ConsultarUsuarios();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        private void ExibirFormCadastro()
        {
            frmCadastrarGrupoUsuario frmCadastrarGrupoUsuario = new frmCadastrarGrupoUsuario(base.ControladorUsuarioSistema);
            frmCadastrarGrupoUsuario.ShowDialog();
            this.ConsultarUsuarios();
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
                UsuarioOT UsuarioOT = new UsuarioOT();

                UsuarioOT.Codigo = pCodigo;

                this._usuarioCTRL = new UsuarioCTRL(UsuarioOT);

                base.ResultadoOperacao = this._usuarioCTRL.Excluir();


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

                this.ConsultarUsuarios();
            }


        }

        #endregion

    }
}
