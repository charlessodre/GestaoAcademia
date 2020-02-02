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
    public partial class frmConsultarEmpresa : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarEmpresa(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private EmpresaCTRL _empresaCTRL;
        private List<EmpresaOT> _empresaList;


        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarEmpresa_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEmpresa_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarEmpresa;
            this.lblTitulo.Text = TituloJanelas.ConsultarEmpresa;

            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConsultarEmpresa();
        }

        /// <summary>
        /// frmConsultarEmpresa_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarEmpresa_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEmpresa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ConsultarEmpresa();
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsultaEmpresa_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaEmpresa_SelectionChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// dgvConsultaEmpresa_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaEmpresa_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsultaEmpresa.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaEmpresa.SelectedRows[0].Cells["colCodigo"].Value);


                if (e.KeyCode == Keys.Enter)
                {
                    this.ExibirFormCadastro(codigo);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirEmpresa(codigo);
                }

            }
        }

        /// <summary>
        /// dgvConsultaEmpresa_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsultaEmpresa_DoubleClick(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvConsultaEmpresa.SelectedRows[0].Cells["colCodigo"].Value);

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
            this.ConsultarEmpresa();
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
            if (this.dgvConsultaEmpresa.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaEmpresa.SelectedRows[0].Cells["colCodigo"].Value);

                this.ExcluirEmpresa(codigo);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvConsultaEmpresa.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsultaEmpresa.SelectedRows[0].Cells["colCodigo"].Value);

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
                this.ConsultarEmpresa();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta as empresas.
        /// </summary>
        private void ConsultarEmpresa()
        {
            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            this._empresaCTRL = new EmpresaCTRL();

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = this._empresaCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = this._empresaCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = this._empresaCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._empresaList = (List<EmpresaOT>)base.ResultadoOperacao.ListaObjetos;
                this.AtualizarDataGridView();
            }
            else
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }


        }

        /// <summary>
        /// Atualiza os dados do data grid view.
        /// </summary>
        private void AtualizarDataGridView()
        {
            this.dgvConsultaEmpresa.AutoGenerateColumns = false;
            this.dgvConsultaEmpresa.DataSource = this._empresaList;
            this.dgvConsultaEmpresa.Select();
        }

        /// <summary>
        /// Exibe o formulário de cadastro do empresa.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastro(int pCodigo)
        {
            frmCadastrarEmpresa frmCadastrarEmpresa = new frmCadastrarEmpresa(pCodigo, base.ControladorUsuarioSistema);
            frmCadastrarEmpresa.ShowDialog();
            this.ConsultarEmpresa();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do empresa.
        /// </summary>
        private void ExibirFormCadastro()
        {
            frmCadastrarEmpresa frmCadastrarEmpresa = new frmCadastrarEmpresa(base.ControladorUsuarioSistema);
            frmCadastrarEmpresa.ShowDialog();
            this.ConsultarEmpresa();
        }

        /// <summary>
        /// Exclui uma empresa
        /// </summary>
        /// <param name="pCodigo">Código da empresa</param>
        private void ExcluirEmpresa(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                EmpresaOT empresaOT = new EmpresaOT();

                empresaOT.Codigo = pCodigo;

                this._empresaCTRL = new EmpresaCTRL(empresaOT);

                base.ResultadoOperacao = this._empresaCTRL.Excluir();


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

                this.ConsultarEmpresa();
            }


        }

        #endregion

    }
}
