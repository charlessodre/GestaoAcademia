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
    public partial class frmLancarContaReceber : frmBase, IPreenchimentoForm<LancamentoContaOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmLancarContaReceber(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._lancamentoContaOT = new LancamentoContaOT();
            this._lancamentoContaCTRL = new LancamentoContaCTRL();
            base.ControladorUsuarioSistema = pUsuarioCTRL;

        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pCodigo">Código da usuário selecionado.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmLancarContaReceber(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._lancamentoContaCTRL = new LancamentoContaCTRL();
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;


        }


        #endregion

        #region Atributos

        //private PagamentoOT _pagamento;
        //private PagamentoCTRL _pagamentoCTRL;
        private List<ServicoRealizadoOT> _servicoList = null;
        private LancamentoContaOT _lancamentoContaOT = null;
        private LancamentoContaCTRL _lancamentoContaCTRL = null;

        private int _codigo;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmLancarContaReceber_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLancarContaReceber_Load(object sender, EventArgs e)
        {
            this.Text = TituloJanelas.LancarContaReceber;

            this.PreencherComboServico();
            if (this._codigo > 0)
            {
                this.ConsultarLancamento();
            }
        }

        /// <summary>
        /// frmLancarContaReceber_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLancarContaReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.FecharFormulario)
            {
                this.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmLancarContaReceber_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLancarContaReceber_KeyDown(object sender, KeyEventArgs e)
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
            this.PreencherDadosAluno(frmRecuperarAluno.ObterAlunoSelecionado());
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
        /// txtProcurar_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            int matricula;

            if (int.TryParse(this.txtProcurar.Text, out matricula))
            {
                this.PreencherDadosAluno(this.ConsultarAluno(matricula));
            }
        }

        /// <summary>
        /// btnConfirmar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.ValidarPreenchimentoCampos())
            {
                this.SalvarRegistro();
                this.Close();
            }
        }

        /// <summary>
        /// cboServicoRealizado_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboServicoRealizado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboServicoRealizado.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                int codigoServico = Convert.ToInt32(this.cboServicoRealizado.SelectedValue);
                var servicoVAR = this._servicoList.Where<ServicoRealizadoOT>(servico => servico.Codigo == codigoServico);
                this.txtDescricao.Text = servicoVAR.ToList()[0].Descricao;
            }
            else
            {
                this.txtDescricao.Text = string.Empty;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Preenche a combo de serviços.
        /// </summary>
        private void PreencherComboServico()
        {
            ServicoRealizadoCTRL servicoCTRL = new ServicoRealizadoCTRL();
            this._servicoList = (List<ServicoRealizadoOT>)servicoCTRL.ConsultarTodos().ListaObjetos;
            PreencherControle.PreencherComboBox<ServicoRealizadoOT>(this.cboServicoRealizado, this._servicoList, "Nome", "Codigo", base.ModoCadastro);
        }

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this.txtValorRecebido.Text = string.Empty;
            this.cboServicoRealizado.SelectedIndex = 0;
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

            if (this.cboServicoRealizado.SelectedIndex <= Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                base.ExibirMessagemGeral(Mensagem.FormaPagamentoObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.cboServicoRealizado.Focus();
                return false;
            }

            return true;
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

            this.ResultadoOperacao = alunoCTRL.CarregarAluno();

            if (this.ResultadoOperacao.TemObjeto)
            {
                aluno = (AlunoOT)this.ResultadoOperacao.ListaObjetos[0];
            }
            else
            {
                aluno = null;
            }

            return aluno;
        }

        /// <summary>
        /// Consulta um Lancamento
        /// </summary>
        private void ConsultarLancamento()
        {
            base.ResultadoOperacao = this._lancamentoContaCTRL.ConsultarCodigo(this._codigo);

            if (base.ResultadoOperacao.TemObjeto)
            {
                this._lancamentoContaOT = (LancamentoContaOT)base.ResultadoOperacao.ListaObjetos[0];
                this.PreencherFomulario(this._lancamentoContaOT);
            }

        }

        /// <summary>
        /// Obtêm o lançamento atual.
        /// </summary>
        /// <returns>Retorna o lançamento atual</returns>
        public LancamentoContaOT ObterLancamento()
        {
            return this._lancamentoContaOT;
        }

        /// <summary>
        /// Preenhe os campos do formulário com os dados do Aluno.
        /// </summary>
        /// <param name="pObjetoOT">Objeto Aluno.</param>
        public void PreencherDadosAluno(AlunoOT pObjetoOT)
        {
            if (pObjetoOT != null)
            {

                this._lancamentoContaOT.Aluno = pObjetoOT;

                this.txtProcurar.Text = pObjetoOT.Codigo.ToString();
                this.txtNome.Text = pObjetoOT.Nome;
                this.txtMatricula.Text = pObjetoOT.Codigo.ToString(Comum.ConstantesSitema.FOMATACAO_DIGITOS_MATRICULA);
                this.txtmTelefone.Text = pObjetoOT.TelefoneResidencial;
                this.pbxFotoAluno.Image = Util.ConverterByteArrayImagem(pObjetoOT.Foto);
            }
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            this._lancamentoContaOT = this.ConstruirObjeto();

            if (this._codigo > 0)
            {
                this._lancamentoContaOT.Codigo = this._codigo;
            }

            this._lancamentoContaCTRL = new LancamentoContaCTRL(_lancamentoContaOT);

            base.ResultadoOperacao = this._lancamentoContaCTRL.Salvar();

            base.ExibirMensagemOperacao(base.ResultadoOperacao);
        }

        #endregion

        #region IPreenchimentoForm<LancamentoContaOT> Members

        public LancamentoContaOT ConstruirObjeto()
        {
            LancamentoContaOT novolancamentoContaOT = new LancamentoContaOT();

            novolancamentoContaOT.Aluno.Codigo = Convert.ToInt32(this.txtMatricula.Text);
            novolancamentoContaOT.ServicoRealizado.Codigo = Convert.ToInt32(this.cboServicoRealizado.SelectedValue);
            novolancamentoContaOT.ServicoRealizado.Nome = this.cboServicoRealizado.Text;
            novolancamentoContaOT.DataVencimento = this.dtpVencimento.Value;
            novolancamentoContaOT.ValorLancamento = Convert.ToDecimal(this.txtValorRecebido.Text);
            novolancamentoContaOT.DataLancamento = DateTime.Now;
            novolancamentoContaOT.UsuarioAlteracao.Codigo = base.ControladorUsuarioSistema.UsuarioSistema.Codigo;
            novolancamentoContaOT.DataAlteracao = DateTime.Now;

            return novolancamentoContaOT;
        }

        public void PreencherFomulario(LancamentoContaOT pObjetoOT)
        {
            this.txtMatricula.Text = pObjetoOT.Aluno.Codigo.ToString();
            this.cboServicoRealizado.SelectedValue = pObjetoOT.ServicoRealizado.Codigo;
            this.dtpVencimento.Value = pObjetoOT.DataVencimento;
            this.txtValorRecebido.Text = pObjetoOT.ValorLancamento.ToString(ConstantesSitema.FOMATACAO_VALOR_MOEDA);
            this.PreencherDadosAluno(this.ConsultarAluno(pObjetoOT.Aluno.Codigo));
        }

        #endregion
    }
}
