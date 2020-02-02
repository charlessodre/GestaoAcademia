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
    public partial class frmConsultarAluno : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarAluno(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private AlunoCTRL _alunoCTRL;
        private List<AlunoOT> _alunosList;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarAluno_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarAluno_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarAluno;
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConsultarDadosAlunos();
        }

        /// <summary>
        /// frmConsultarAluno_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarAluno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarAluno_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarAluno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarDadosAlunos();
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsutaAlunos_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsutaAlunos_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvConsutaAlunos.SelectedRows.Count > 0)
            {
                byte[] foto = (byte[])this.dgvConsutaAlunos.SelectedRows[0].Cells["colFoto"].Value;
                if (foto != null && foto.Length > 0)
                {
                    this.pbxFotoAluno.Image = Util.ConverterByteArrayImagem(foto);
                }
                else
                {
                    this.pbxFotoAluno.Image = rsxImagens.indisponivel200x200;
                }
            }

        }

        /// <summary>
        /// dgvConsutaAlunos_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsutaAlunos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsutaAlunos.SelectedRows.Count > 0)
            {
                int matricula = Convert.ToInt32(this.dgvConsutaAlunos.SelectedRows[0].Cells["colMatricula"].Value);


                if (e.KeyCode == Keys.Enter)
                {
                    this.ExibirFormCadastro(matricula);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirAluno(matricula);
                }

            }
        }

        /// <summary>
        /// dgvConsutaAlunos_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsutaAlunos_DoubleClick(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(this.dgvConsutaAlunos.SelectedRows[0].Cells["colMatricula"].Value);

            this.ExibirFormCadastro(matricula);
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
            this.ConsultarDadosAlunos();
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
            if (this.dgvConsutaAlunos.SelectedRows.Count > 0)
            {
                int matricula = Convert.ToInt32(this.dgvConsutaAlunos.SelectedRows[0].Cells["colMatricula"].Value);

                this.ExcluirAluno(matricula);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvConsutaAlunos.SelectedRows.Count > 0)
            {
                int matricula = Convert.ToInt32(this.dgvConsutaAlunos.SelectedRows[0].Cells["colMatricula"].Value);

                this.ExibirFormCadastro(matricula);
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
                this.ConsultarDadosAlunos();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Exibe a foto do aluno.
        /// </summary>
        /// <param name="pFotoAluno">Foto do Aluno</param>
        private void ExibirFotoAluno(Image pFotoAluno)
        {
            this.pbxFotoAluno.Image = pFotoAluno;
        }

        /// <summary>
        /// Consulta os dados do aluno.
        /// </summary>
        private void ConsultarDadosAlunos()
        {
            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            this._alunoCTRL = new AlunoCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                   base.ResultadoOperacao = this._alunoCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                       base.ResultadoOperacao = this._alunoCTRL.ConsultarMatriculaStatus(codigo, status);
                    }
                }
            }
            else
            {
               base.ResultadoOperacao = this._alunoCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._alunosList = (List<AlunoOT>)base.ResultadoOperacao.ListaObjetos;
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
            this.dgvConsutaAlunos.AutoGenerateColumns = false;
            this.dgvConsutaAlunos.DataSource = this._alunosList;
            this.dgvConsutaAlunos.Select();
        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do aluno</param>
        private void ExibirFormCadastro(int pMatricula)
        {
            frmCadastrarAluno frmCadastroAluno = new frmCadastrarAluno(pMatricula, base.ControladorUsuarioSistema);
            frmCadastroAluno.ShowDialog();
            this.ConsultarDadosAlunos();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        private void ExibirFormCadastro()
        {
            frmCadastrarAluno frmCadastroAluno = new frmCadastrarAluno(base.ControladorUsuarioSistema);
            frmCadastroAluno.ShowDialog();
            this.ConsultarDadosAlunos();
        }

        /// <summary>
        /// Exclui um aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do aluno</param>
        private void ExcluirAluno(int pMatricula)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pMatricula.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                AlunoOT alunoOT = new AlunoOT();

                alunoOT.Codigo = pMatricula;

                this._alunoCTRL = new AlunoCTRL(alunoOT);

               base.ResultadoOperacao = this._alunoCTRL.Excluir();


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

                this.ConsultarDadosAlunos();
            }


        }

        #endregion

    }
}
