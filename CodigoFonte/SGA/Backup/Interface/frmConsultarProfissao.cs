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
    public partial class frmConsultarProfissao : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarProfissao(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private ProfissaoCTRL _profissaoCTRL;
        private List<ProfissaoOT> _profissaoList;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarProfissao_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarProfissao_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarProfissao;
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConsultarProfissao();
        }

        /// <summary>
        /// frmConsultarProfissao_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarProfissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarProfissao_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarProfissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarProfissao();
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsultaProfissao_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaProfissao_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// dgvConsultaProfissao_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaProfissao_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsultaProfissao.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaProfissao.SelectedRows[0].Cells["colCodigo"].Value);


                if (e.KeyCode == Keys.Enter)
                {
                    this.ExibirFormCadastro(codigo);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirProfissao(codigo);
                }

            }
        }

        /// <summary>
        /// dgvConsultaProfissao_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaProfissao_DoubleClick(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvConsultaProfissao.SelectedRows[0].Cells["colCodigo"].Value);

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
            this.ConsultarProfissao();
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
            if (this.dgvConsultaProfissao.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaProfissao.SelectedRows[0].Cells["colCodigo"].Value);

                this.ExcluirProfissao(codigo);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvConsultaProfissao.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaProfissao.SelectedRows[0].Cells["colCodigo"].Value);

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
                this.ConsultarProfissao();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta os grupos de profissao.
        /// </summary>
        private void ConsultarProfissao()
        {
            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            this._profissaoCTRL = new ProfissaoCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = this._profissaoCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = this._profissaoCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = this._profissaoCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._profissaoList = (List<ProfissaoOT>)base.ResultadoOperacao.ListaObjetos;
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
            this.dgvConsultaProfissao.AutoGenerateColumns = false;
            this.dgvConsultaProfissao.DataSource = this._profissaoList;
            this.dgvConsultaProfissao.Select();
        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastro(int pCodigo)
        {
            frmCadastrarProfissao frmCadastrarProfissao = new frmCadastrarProfissao(pCodigo, base.ControladorUsuarioSistema);
            frmCadastrarProfissao.ShowDialog();
            this.ConsultarProfissao();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do aluno.
        /// </summary>
        private void ExibirFormCadastro()
        {
            frmCadastrarProfissao frmCadastrarProfissao = new frmCadastrarProfissao(base.ControladorUsuarioSistema);
            frmCadastrarProfissao.ShowDialog();
            this.ConsultarProfissao();
        }

        /// <summary>
        /// Exclui um grupo de usuário.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExcluirProfissao(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ProfissaoOT ProfissaoOT = new ProfissaoOT();

                ProfissaoOT.Codigo = pCodigo;

                this._profissaoCTRL = new ProfissaoCTRL(ProfissaoOT);

                base.ResultadoOperacao = this._profissaoCTRL.Excluir();


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

                this.ConsultarProfissao();
            }


        }

        #endregion

    }
}
