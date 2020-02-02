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
    public partial class frmRecuperarAluno : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmRecuperarAluno(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private AlunoCTRL _alunoCTRL;
        private List<AlunoOT> _alunosList;
        private AlunoOT _alunoSelecionado;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmRecuperarAluno_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecuperarAluno_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarAluno;
            this.ConsultarAlunos();
        }

        /// <summary>
        /// frmRecuperarAluno_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecuperarAluno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmRecuperarAluno_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecuperarAluno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarAlunos();
            }
        }

        #endregion

        #region Eventos Data Grid View


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
                    this._alunoSelecionado = this.ConsultarAluno(matricula);
                }

                this.Close();

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

            this._alunoSelecionado = this.ConsultarAluno(matricula);

            this.Close();
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
            this.ConsultarAlunos();
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
        private void ConsultarAlunos()
        {
            this._alunoCTRL = new AlunoCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                   base.ResultadoOperacao = this._alunoCTRL.ConsultarNome(this.txtProcurar.Text.Trim().Replace("'", ""));
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                       base.ResultadoOperacao = this._alunoCTRL.ConsultarMatricula(codigo);
                    }
                }
            }
            else
            {
               base.ResultadoOperacao = this._alunoCTRL.ConsultarTodos();

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
        /// Consulta os dados do Aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do Aluno.</param>
        private AlunoOT ConsultarAluno(int pMatricula)
        {
            AlunoOT aluno = new AlunoOT();
            aluno.Codigo = pMatricula;

            this._alunoCTRL = new AlunoCTRL(aluno);

           base.ResultadoOperacao = this._alunoCTRL.CarregarAluno();

            if (base.ResultadoOperacao.TemObjeto)
            {
                aluno = (AlunoOT)base.ResultadoOperacao.ListaObjetos[0];
            }

            return aluno;
        }


        /// <summary>
        /// Obtêm os dados do aluno selecionado.
        /// </summary>
        /// <returns></returns>
        public AlunoOT ObterAlunoSelecionado()
        {
            return this._alunoSelecionado;
        }

        #endregion

    }
}
