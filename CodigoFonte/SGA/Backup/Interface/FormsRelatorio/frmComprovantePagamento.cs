using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controle;
using Interface.Relatorios;
using Comum;
using ObjetoOT;

namespace Interface.FormsRelatorio
{
    public partial class frmComprovantePagamento : frmBase, IPreenchimentoForm<ReciboOT>
    {
        #region Construtores

        /// <summary>
        /// COnstrutor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        /// <param name="pCodigoLancamentoConta">Código do lançamento da conta</param>
        public frmComprovantePagamento(UsuarioCTRL pUsuarioCTRL, int pCodigoLancamentoConta, bool pReciboGerado)
        {
            InitializeComponent();

            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;

            this._reciboGerado = pReciboGerado;
            this._codigoLancamentoConta = pCodigoLancamentoConta;

        }

        #endregion

        #region Atributos

        private crComprovantePagamento _crComprovantePagamento = null;
        private LancamentoContaOT _lancamentoContaOT = null;
        private EmpresaOT _empresaSistema = null;
        private int _codigoLancamentoConta = 0;
        private bool _reciboGerado = false;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmComprovantePagamento_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmComprovantePagamento_Load(object sender, EventArgs e)
        {
            if (!this._reciboGerado)
            {
                this.CriarRecibo();
            }

            this.ConsultarLancamentoConta();
            this.ConsultarEmpresaSistema();
            this.InicializarRelatorio();

        }

        #endregion

        #region Eventos

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta os dados do lançamento
        /// </summary>
        private void ConsultarLancamentoConta()
        {
            LancamentoContaCTRL lancamentoContaCTRL = new LancamentoContaCTRL();
            //
            base.ResultadoOperacao = lancamentoContaCTRL.ConsultarCodigo(this._codigoLancamentoConta);

            if (base.ResultadoOperacao.TemObjeto)
            {
                this._lancamentoContaOT = (LancamentoContaOT)base.ResultadoOperacao.ListaObjetos[0];
            }

        }

        /// <summary>
        /// Consulta os dados da empresa que possui lincença do sistema.
        /// </summary>
        private void ConsultarEmpresaSistema()
        {
            EmpresaCTRL empresaCTRL = new EmpresaCTRL();

            this._empresaSistema = (EmpresaOT)empresaCTRL.ConsultarEmpresaSitema().ListaObjetos[0];
        }

        /// <summary>
        /// Inicializa o relatório
        /// </summary>
        private void InicializarRelatorio()
        {
            this.PreencherDadosRelatorio();
            //
            this.crvComprovantePagamento.ReportSource = this._crComprovantePagamento;
            this.crvComprovantePagamento.Zoom(ConstantesSitema.ZOOM_INICIAL_REL);
        }

        /// <summary>
        /// Preenche os dados do relatório.
        /// </summary>
        private void PreencherDadosRelatorio()
        {
            this._crComprovantePagamento = new crComprovantePagamento();
            //
            //
            this._crComprovantePagamento.SetParameterValue("txtNomeEstabelecimento", this._empresaSistema.Nome);
            this._crComprovantePagamento.SetParameterValue("txtEnderecoEmpresa", this._empresaSistema.Endereco);
            this._crComprovantePagamento.SetParameterValue("txtCidade", this._empresaSistema.Cidade.Nome);
            this._crComprovantePagamento.SetParameterValue("txtEstado", this._empresaSistema.Estado.Sigla);
            this._crComprovantePagamento.SetParameterValue("txtCEP", this._empresaSistema.CEP);
            this._crComprovantePagamento.SetParameterValue("txtTelefone", this._empresaSistema.TelefoneComercial);
            this._crComprovantePagamento.SetParameterValue("txtFax", this._empresaSistema.Fax);
            this._crComprovantePagamento.SetParameterValue("txtEmail", this._empresaSistema.Email);
            this._crComprovantePagamento.SetParameterValue("txtSite", this._empresaSistema.Site);
            //
            this._crComprovantePagamento.SetParameterValue("txtMatriculaAluno", this._lancamentoContaOT.Aluno.Codigo);
            this._crComprovantePagamento.SetParameterValue("txtNomeAluno", this._lancamentoContaOT.Aluno.Nome);
            this._crComprovantePagamento.SetParameterValue("txtTelefoneAluno", this._lancamentoContaOT.Aluno.TelefoneResidencial);
            //
            this._crComprovantePagamento.SetParameterValue("txtMatriculaFuncionario", this._lancamentoContaOT.Pagamento.UsuarioPagamento.Codigo);
            this._crComprovantePagamento.SetParameterValue("txtNomeFuncionario", this._lancamentoContaOT.Pagamento.UsuarioPagamento.Nome);
            //
            this._crComprovantePagamento.SetParameterValue("txtDataVencimento", this._lancamentoContaOT.DataVencimento);
            this._crComprovantePagamento.SetParameterValue("txtDescricaoConta", this._lancamentoContaOT.ServicoRealizado.Nome);
            this._crComprovantePagamento.SetParameterValue("txtValor", this._lancamentoContaOT.Pagamento.ValorPagamento);
            //
            this._crComprovantePagamento.SetParameterValue("txtNumeroRecibo", this._lancamentoContaOT.Recibo.Codigo.ToString(ConstantesSitema.FOMATACAO_DIGITOS_MATRICULA));



        }

        /// <summary>
        /// Cria o recibo no banco de dados.
        /// </summary>
        private void CriarRecibo()
        {
            ReciboCTRL reciboCTRL = new ReciboCTRL(this.ConstruirObjeto());
            base.ResultadoOperacao = reciboCTRL.Salvar();

            if (base.ResultadoOperacao.Resultado != Utilitarios.Enumeradores.Resultados.Sucesso)
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }
        }

        #endregion



        #region IPreenchimentoForm<ReciboOT> Members

        public ReciboOT ConstruirObjeto()
        {
            ReciboOT reciboOT = new ReciboOT();

            reciboOT.DataAlteracao = DateTime.Now;
            reciboOT.UsuarioAlteracao = base.ControladorUsuarioSistema.UsuarioSistema;
            reciboOT.CodigoLancamentoConta = _codigoLancamentoConta;

            return reciboOT;
        }

        public void PreencherFomulario(ReciboOT pObjetoOT)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
