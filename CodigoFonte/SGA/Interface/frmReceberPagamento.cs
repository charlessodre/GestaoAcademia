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

namespace Interface
{
    public partial class frmReceberPagamento : frmBase, IPreenchimentoForm<LancamentoContaOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmReceberPagamento(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pCodigoLancamento">Código do lançamento selecionado.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmReceberPagamento(int pCodigoLancamento, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._codigoLancamento = pCodigoLancamento;
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            this._lancamentoContaCTRL = new LancamentoContaCTRL();
            this.ConsultarLancamento();
        }


        #endregion

        #region Atributos

        private int _codigoLancamento;
        private LancamentoContaCTRL _lancamentoContaCTRL = null;
        private List<LancamentoContaOT> _lancamentoContaList = null;
        private LancamentoContaOT _lancamentoConta = null;
        private PagamentoCTRL _pagamentoCTRL = null;
        private string _valorAnterior = string.Empty;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmReceberPagamento_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReceberPagamento_Load(object sender, EventArgs e)
        {
            PreencherControle.PreencherDropDownFormasPagamentos(this.cboFormasPagamentos, base.ModoCadastro);
            this.Text = TituloJanelas.ReceberPagamento;
        }

        /// <summary>
        /// frmReceberPagamento_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReceberPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                base.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmReceberPagamento_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReceberPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// btnReceber_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceber_Click(object sender, EventArgs e)
        {
            if (this.ValidarPreenchimentoCampos())
            {
                this.SalvarRegistro();
                this.Close();
            }
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

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this.txtValorRecebido.Text = string.Empty;
            this.cboFormasPagamentos.SelectedIndex = 0;
        }

        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            if (this.txtValorRecebido.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.ValorRecebidoObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtValorRecebido.Focus();
                return false;
            }

            if (this.cboFormasPagamentos.SelectedIndex <= Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                base.ExibirMessagemGeral(Mensagem.FormaPagamentoObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.cboFormasPagamentos.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            LancamentoContaOT lancamentoConta = this.ConstruirObjeto();

            if (this._codigoLancamento > 0)
            {
                lancamentoConta.Codigo = this._codigoLancamento;
            }

            this._pagamentoCTRL = new PagamentoCTRL(lancamentoConta.Pagamento);
            base.ResultadoOperacao = this._pagamentoCTRL.Salvar();

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                this._lancamentoContaCTRL = new LancamentoContaCTRL(lancamentoConta);
                base.ResultadoOperacao = this._lancamentoContaCTRL.Salvar();
                base.ExibirMessagemGeral(Mensagem.PagamentoRealizadoSucesso, TituloJanelas.ReceberPagamento, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                base.ExibirMessagemGeral(Mensagem.ErroPagamento, TituloJanelas.ReceberPagamento, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }


        }

        /// <summary>
        /// Consulta os dados do lancamento.
        /// </summary>
        private void ConsultarLancamento()
        {
            base.ResultadoOperacao = this._lancamentoContaCTRL.ConsultarCodigo(this._codigoLancamento);

            this._lancamentoContaList = (List<LancamentoContaOT>)base.ResultadoOperacao.ListaObjetos;
            this._lancamentoConta = this._lancamentoContaList[0];

            this.AtualizarDataGridView();

            this._lancamentoConta.Aluno = this.ConsultarAluno(this._lancamentoConta.Aluno.Codigo);

            this.PreencherDadosAluno(this._lancamentoConta.Aluno);
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
        /// Preenche o fomulário com s dados do aluno.
        /// </summary>
        /// <param name="pObjetoOT"></param>
        public void PreencherDadosAluno(AlunoOT pObjetoOT)
        {
            if (pObjetoOT != null)
            {
                this.txtNome.Text = pObjetoOT.Nome;
                this.txtMatricula.Text = pObjetoOT.Codigo.ToString(Comum.ConstantesSitema.FOMATACAO_DIGITOS_MATRICULA);
                this.txtmTelefone.Text = pObjetoOT.TelefoneResidencial;
                this.txtmCelular.Text = pObjetoOT.TelefoneCelular;
                this.pbxFotoAluno.Image = Util.ConverterByteArrayImagem(pObjetoOT.Foto);
            }

            this.txtValorTotal.Text = this._lancamentoConta.ValorLancamento.ToString(Comum.ConstantesSitema.FOMATACAO_VALOR_MOEDA);

        }

        /// <summary>
        /// Atualiza os dados do data grid view.
        /// </summary>
        private void AtualizarDataGridView()
        {
            this.dgvPagamentosReceber.AutoGenerateColumns = false;
            this.dgvPagamentosReceber.DataSource = this._lancamentoContaList; ;
        }

        /// <summary>
        /// Cria um objeto pagamento .
        /// </summary>
        /// <returns>Retorna o Objeto pagamento criado.</returns>
        public PagamentoOT ConstruirPagamento()
        {
            PagamentoOT novoPagamento = new PagamentoOT();

            List<string> codigoFP = TipoPagamentoCTRL.ObterCodigoFormasPagamentos(this.cboFormasPagamentos.SelectedValue);

            novoPagamento.TipoPagamentoOT.Codigo = Convert.ToInt32(codigoFP[0]);

            if (codigoFP.Count > 1)
            {
                novoPagamento.SubTipoPagamento.Codigo = Convert.ToInt32(codigoFP[1]);
                novoPagamento.DataAlteracao = DateTime.Now;
                novoPagamento.UsuarioAlteracao.Codigo = base.ControladorUsuarioSistema.UsuarioSistema.Codigo;
            }

            novoPagamento.CodigoLancamentoConta = this._codigoLancamento;
            novoPagamento.ValorPagamento = Convert.ToDecimal(this.txtValorRecebido.Text);
            novoPagamento.DataPagamento = DateTime.Now;
            novoPagamento.UsuarioPagamento.Codigo = base.ControladorUsuarioSistema.UsuarioSistema.Codigo;


            return novoPagamento;
        }

        #endregion

        #region IPreenchimentoForm<LancamentoContaOT> Members

        public LancamentoContaOT ConstruirObjeto()
        {

            LancamentoContaOT novoLancamentoConta = new LancamentoContaOT();

            novoLancamentoConta.Aluno.Codigo = Convert.ToInt32(this.txtMatricula.Text);
            novoLancamentoConta.Pagamento = this.ConstruirPagamento();
            novoLancamentoConta.Pago = true;

            return novoLancamentoConta;
        }

        public void PreencherFomulario(LancamentoContaOT pObjetoOT)
        {

        }

        #endregion

    }
}
