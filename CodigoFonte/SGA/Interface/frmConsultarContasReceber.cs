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
using Interface.FormsRelatorio;

namespace Interface
{
    public partial class frmConsultarContasReceber : frmBase, IPreenchimentoForm<AlunoOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarContasReceber(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pCodigo">Código da usuário selecionado.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarContasReceber(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }


        #endregion

        #region Atributos

        private int _codigo;
        private LancamentoContaCTRL _lancamentoContaCTRL = null;
        private List<LancamentoContaOT> _lancamentoContaList = null;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmConsultarContasReceber_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarContasReceber_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.ConsultarContasReceber;
            this.lblTitulo.Text = TituloJanelas.ConsultarContasReceber;
            this.pnlPeriodo.Visible = false;
            this.rbAluno.Checked = true;
            this._lancamentoContaCTRL = new LancamentoContaCTRL();
        }

        /// <summary>
        /// frmConsultarContasReceber_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarContasReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                base.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmConsultarContasReceber_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarContasReceber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// btnConsultarMatricula_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultarMatricula_Click(object sender, EventArgs e)
        {
            frmRecuperarAluno frmRecuperarAluno = new frmRecuperarAluno(base.ControladorUsuarioSistema);
            frmRecuperarAluno.ShowDialog();
            this.PreencherFomulario(frmRecuperarAluno.ObterAlunoSelecionado());
            frmRecuperarAluno.Dispose();
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
        /// btnExcluir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);
                bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

                this.ExcluirLancamento(codigoLancamento, pago);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);

                bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

                this.ExibirFormPagamento(codigoLancamento, pago);

            }
        }

        /// <summary>
        /// btnRecibo_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecibo_Click(object sender, EventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);
                bool reciboGerado = !string.IsNullOrEmpty(this.dgvPagamentosReceber.SelectedRows[0].Cells["colRecibo"].Value.ToString());

                frmComprovantePagamento frmComprovantePagamento = new frmComprovantePagamento(base.ControladorUsuarioSistema, codigoLancamento, reciboGerado);
                frmComprovantePagamento.ShowDialog();

                this.AtualizarLancamentos();
            }
        }

        /// <summary>
        /// btnReceber_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceber_Click(object sender, EventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);

                bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

                this.ExibirFormPagamento(codigoLancamento, pago);
            }
        }

        /// <summary>
        /// rbAluno_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAluno_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlMatricula.Visible = true;
            this.pnlPeriodo.Visible = false;
            this.LimparDadosFormulario();
        }

        /// <summary>
        /// rbPeriodo_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlMatricula.Visible = false;
            this.pnlPeriodo.Visible = true;
            this.LimparDadosFormulario();
        }

        /// <summary>
        /// dtpFim_CloseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFim_CloseUp(object sender, EventArgs e)
        {
            this.ConsultarLancamentosPeriodo();

        }

        /// <summary>
        /// dtpInicio_CloseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpInicio_CloseUp(object sender, EventArgs e)
        {
            this.ConsultarLancamentosPeriodo();

        }

        /// <summary>
        /// dtpInicio_Validated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpInicio_Validated(object sender, EventArgs e)
        {

            this.ConsultarLancamentosPeriodo();

        }

        /// <summary>
        /// dtpFim_Validated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFim_Validated(object sender, EventArgs e)
        {

            this.ConsultarLancamentosPeriodo();

        }

        /// <summary>
        /// txtProcurar_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            int matricula;

            if (int.TryParse(this.txtProcurar.Text, out matricula))
            {
                this.PreencherFomulario(this.ConsultarAluno(matricula));

            }
        }

        /// <summary>
        /// btnNovoLancamento_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovoLancamento_Click(object sender, EventArgs e)
        {
            this.ExibirFormLancamento();
        }


        #endregion

        #region Eventos DataGridView

        /// <summary>
        /// dgvPagamentosReceber_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPagamentosReceber_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

                this.btnRecibo.Enabled = pago;
                this.btnReceber.Enabled = !pago;
                this.btnAlterar.Enabled = !pago;
                this.btnExcluir.Enabled = !pago;
            }
        }

        /// <summary>
        /// dgvPagamentosReceber_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPagamentosReceber_DoubleClick(object sender, EventArgs e)
        {
            int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);

            bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

            this.ExibirFormPagamento(codigoLancamento, pago);

        }

        /// <summary>
        /// dgvPagamentosReceber_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPagamentosReceber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvPagamentosReceber.SelectedRows.Count > 0)
            {
                int codigoLancamento = Convert.ToInt32(this.dgvPagamentosReceber.SelectedRows[0].Cells["colCodigo"].Value);
                bool pago = Convert.ToBoolean(this.dgvPagamentosReceber.SelectedRows[0].Cells["colPago"].Value);

                if (e.KeyCode == Keys.Enter)
                {
                    this.ExibirFormPagamento(codigoLancamento, pago);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirLancamento(codigoLancamento, pago);
                }

            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this.txtNome.Text = string.Empty;
            this.txtDebito.Text = string.Empty;
            this.txtmTelefone.Text = string.Empty;
            this.txtmCelular.Text = string.Empty;
            this.pbxFotoAluno.Image = null;
            this.dgvPagamentosReceber.DataSource = null;
        }

        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            return true;
        }

        /// <summary>
        /// Consulta os Lancamentos do periodo.
        /// </summary>
        private void ConsultarLancamentosPeriodo()
        {
            base.ResultadoOperacao = this._lancamentoContaCTRL.ConsultarPorPeriodo(this.dtpInicio.Value.Date, this.dtpFim.Value.Date);

            this._lancamentoContaList = (List<LancamentoContaOT>)base.ResultadoOperacao.ListaObjetos;

            this.AtualizarDataGridView();
        }

        /// <summary>
        /// onsulta os Lancamentos por aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do Aluno.</param>
        private void ConsultarLancamentosPorAluno(int pMatricula)
        {
            base.ResultadoOperacao = this._lancamentoContaCTRL.ConsultarPorAluno(pMatricula);
            this._lancamentoContaList = (List<LancamentoContaOT>)base.ResultadoOperacao.ListaObjetos;
            this.AtualizarDataGridView();

        }

        /// <summary>
        /// Consulta os dados do Aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do Aluno.</param>
        private AlunoOT ConsultarAluno(int pMatricula)
        {
            AlunoOT aluno = new AlunoOT();
            aluno.Codigo = pMatricula;

            AlunoCTRL alunoCTRL = new AlunoCTRL(aluno);

            base.ResultadoOperacao = alunoCTRL.CarregarAluno();

            if (base.ResultadoOperacao.TemObjeto)
            {
                aluno = (AlunoOT)base.ResultadoOperacao.ListaObjetos[0];
            }

            return aluno;
        }

        /// <summary>
        /// Atualiza os lançamentos do grid view.
        /// </summary>
        private void AtualizarLancamentos()
        {
            if (this.rbPeriodo.Checked)
            {
                this.ConsultarLancamentosPeriodo();
            }
            else
            {
                int matricula;

                if (int.TryParse(this.txtProcurar.Text, out matricula))
                {
                    this.ConsultarLancamentosPorAluno(matricula);
                }
            }
        }

        /// <summary>
        /// Atualiza os dados do data grid view.
        /// </summary>
        private void AtualizarDataGridView()
        {
            this.dgvPagamentosReceber.AutoGenerateColumns = false;
            this.dgvPagamentosReceber.DataSource = this.PreencherDataTable(); ;
        }

        /// <summary>
        /// Preenche o DataTable com os dados da consulta.
        /// </summary>
        /// <returns>Retona o DataTable preenchido.</returns>
        private DataTable PreencherDataTable()
        {
            DataTable dtLancamentoConta = new DataTable();

            DataColumn colCodigo = new DataColumn("Codigo");
            DataColumn colNomeAluno = new DataColumn("NomeAluno");
            DataColumn colNomeServicoRealizado = new DataColumn("NomeServicoRealizado");
            DataColumn colDataVencimento = new DataColumn("DataVencimento");
            DataColumn colValorAPagar = new DataColumn("ValorLancamento");
            DataColumn colDataPagamento = new DataColumn("DataPagamento");
            DataColumn colValorPago = new DataColumn("ValorPagamento");
            DataColumn colCodigoRecibo = new DataColumn("CodigoRecibo");
            DataColumn colPagoTexto = new DataColumn("PagoTexto");
            DataColumn colPago = new DataColumn("Pago");

            dtLancamentoConta.Columns.Add(colCodigo);
            dtLancamentoConta.Columns.Add(colNomeAluno);
            dtLancamentoConta.Columns.Add(colNomeServicoRealizado);
            dtLancamentoConta.Columns.Add(colDataVencimento);
            dtLancamentoConta.Columns.Add(colValorAPagar);
            dtLancamentoConta.Columns.Add(colDataPagamento);
            dtLancamentoConta.Columns.Add(colValorPago);
            dtLancamentoConta.Columns.Add(colCodigoRecibo);
            dtLancamentoConta.Columns.Add(colPagoTexto);
            dtLancamentoConta.Columns.Add(colPago);

            foreach (LancamentoContaOT item in this._lancamentoContaList)
            {
                DataRow row = dtLancamentoConta.NewRow();

                row[colCodigo] = item.Codigo;
                row[colNomeAluno] = item.Aluno.Nome;
                row[colNomeServicoRealizado] = item.ServicoRealizado.Nome;

                if (!item.DataVencimento.Equals(DateTime.MinValue))
                {
                    row[colDataVencimento] = item.DataVencimento.ToShortDateString();
                }

                row[colValorAPagar] = item.ValorLancamento;

                if (item.Pagamento.Codigo > 0)
                {
                    row[colDataPagamento] = item.Pagamento.DataPagamento;
                    row[colValorPago] = item.Pagamento.ValorPagamento;
                }

                if (item.Recibo.Codigo > 0)
                {
                    row[colCodigoRecibo] = item.Recibo.Codigo.ToString();
                }

                row[colPagoTexto] = item.PagoTexto;
                row[colPago] = item.Pago;

                dtLancamentoConta.Rows.Add(row);
            }

            return dtLancamentoConta;
        }



        /// <summary>
        /// Exibe o formulário de pagamento.
        /// </summary>
        /// <param name="pCodigoLancamento">Código do Lancamento</param>
        /// <param name="pPago">Lancamento Pago</param>
        private void ExibirFormPagamento(int pCodigoLancamento, bool pPago)
        {
            if (pPago)
            {
                base.ExibirMessagemGeral(Mensagem.ContaPagaAlterar, TituloJanelas.RecebimentoConta, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                frmReceberPagamento frmReceberPagamento = new frmReceberPagamento(pCodigoLancamento, base.ControladorUsuarioSistema);
                frmReceberPagamento.ShowDialog();
                this.AtualizarLancamentos();
            }
        }

        /// <summary>
        /// Exibe o formulário de pagamento.
        /// </summary>
        /// <param name="pCodigoLancamento">Código do Lancamento</param>
        private void ExibirFormLancamento(int pCodigoLancamento)
        {
            frmLancarContaReceber frmLancarContaReceber = new frmLancarContaReceber(pCodigoLancamento, base.ControladorUsuarioSistema);
            frmLancarContaReceber.ShowDialog();
            this.AtualizarLancamentos();
        }

        /// <summary>
        /// Exibe o formulário de pagamento.
        /// </summary>
        private void ExibirFormLancamento()
        {
            frmLancarContaReceber frmLancarContaReceber = new frmLancarContaReceber(base.ControladorUsuarioSistema);
            frmLancarContaReceber.ShowDialog();
            this.AtualizarLancamentos();
        }

        /// <summary>
        /// Exclui um aluno.
        /// </summary>
        /// <param name="pCodigoLancamento">Código do lançamento</param>
        /// <param name="pPago">Lancamento Pago</param>
        private void ExcluirLancamento(int pCodigoLancamento, bool pPago)
        {
            if (pPago)
            {
                base.ExibirMessagemGeral(Mensagem.ContaPagaExcluir, TituloJanelas.RecebimentoConta, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigoLancamento.ToString()), TituloJanelas.ExcluirRegistro,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    LancamentoContaOT lancamentoContaOT = new LancamentoContaOT();

                    lancamentoContaOT.Codigo = pCodigoLancamento;

                    this._lancamentoContaCTRL = new LancamentoContaCTRL(lancamentoContaOT);

                    base.ResultadoOperacao = this._lancamentoContaCTRL.Excluir();


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

                    this.AtualizarLancamentos();
                }
            }

        }


        #endregion

        #region IPreenchimentoForm<AlunoOT> Members

        public AlunoOT ConstruirObjeto()
        {
            throw new NotImplementedException();
        }

        public void PreencherFomulario(AlunoOT pObjetoOT)
        {
            if (pObjetoOT != null)
            {
                this.txtProcurar.Text = pObjetoOT.Codigo.ToString();
                this.txtNome.Text = pObjetoOT.Nome;
                this.txtMatricula.Text = pObjetoOT.Codigo.ToString(Comum.ConstantesSitema.FOMATACAO_DIGITOS_MATRICULA);
                this.txtDebito.Text = pObjetoOT.Debito.ToString(Comum.ConstantesSitema.FOMATACAO_VALOR_MOEDA);
                this.txtmTelefone.Text = pObjetoOT.TelefoneResidencial;
                this.txtmCelular.Text = pObjetoOT.TelefoneCelular;
                this.pbxFotoAluno.Image = Util.ConverterByteArrayImagem(pObjetoOT.Foto);

                this.ConsultarLancamentosPorAluno(pObjetoOT.Codigo);
            }


        }

        #endregion


    }
}
