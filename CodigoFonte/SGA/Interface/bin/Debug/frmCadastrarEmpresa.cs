using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjetoOT;
using Controle;
using Utilitarios;
using System.Drawing.Imaging;
using Controle.Auxiliares;
using Comum;

namespace Interface
{
    public partial class frmCadastrarEmpresa : frmBase, IPreenchimentoForm<EmpresaOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarEmpresa(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pCodigo">Código do Empresa.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarEmpresa(int pCodigo, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }


        #endregion

        #region Atributos

        private EmpresaOT _empresa;
        private EmpresaCTRL _EmpresaCTRL;
        private int _codigo;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmCadastroEmpresa_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastroEmpresa_Load(object sender, EventArgs e)
        {
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, base.ModoCadastro);

            this.PreecherComboCidade();
            this.PreecherComboEstado();

            if (this._codigo > 0)
            {
                this.Text = TituloJanelas.AlterarEmpresa;
                this.ConsultarDadosEmpresa();
            }
            else
            {
                this.Text = TituloJanelas.CadastroEmpresa;
            }
        }

        /// <summary>
        /// frmCadastroEmpresa_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastroEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                base.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmCadastroEmpresa_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastroEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// btnGravar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (this.ValidarPreenchimentoCampos())
            {
                this.SalvarRegistro();
                base.ExibirMensagemOperacao(base.ResultadoOperacao);

                if (this._codigo > 0)
                {
                    this.Dispose();
                }
                else
                {
                    this.LimparDadosFormulario();
                }
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

        /// <summary>
        /// btnNovaCidade_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovaCidade_Click(object sender, EventArgs e)
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade, base.ControladorUsuarioSistema);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.PreecherComboCidade();
        }

        /// <summary>
        /// btnNovoEstado_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovoEstado_Click(object sender, EventArgs e)
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(frmCadastrarEstadoPaisCidade.TipoFormulario.Estado, base.ControladorUsuarioSistema);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.PreecherComboEstado();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this._codigo = 0;
            this.txtNome.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtBairro.Text = string.Empty;
            this.txtmCEP.Text = string.Empty;
            this.cboCidade.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.cboUF.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO; ;
            this.txtmTelefone.Text = string.Empty;
            this.txtmCelular.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtSituacao.Text = string.Empty;
            this.txtDebito.Text = string.Empty;
            this.txtObservacao.Text = string.Empty;
            this.txtContato.Text = string.Empty;

        }


        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            if (this.txtNome.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.NomeObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtNome.Focus();
                return false;
            }

            if (this.cboCidade.SelectedIndex <= ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                base.ExibirMessagemGeral(Mensagem.CidadeObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.cboCidade.Focus();
                return false;
            }

            if (this.cboUF.SelectedIndex <= ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                base.ExibirMessagemGeral(Mensagem.PaisObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.cboUF.Focus();
                return false;
            }


            if (this.txtmTelefone.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.TelefoneObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtmTelefone.Focus();
                return false;
            }

            if (this.txtEndereco.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.EnderecoObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtEndereco.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// Consulta os dados do Empresa.
        /// </summary>
        /// <param name="pMatricula">Matricula do Empresa.</param>
        private void ConsultarDadosEmpresa()
        {
            this._empresa = new EmpresaOT();
            this._empresa.Codigo = this._codigo;

            this._EmpresaCTRL = new EmpresaCTRL(this._empresa);
            this._empresa = (EmpresaOT)this._EmpresaCTRL.CarregarEmpresa().ListaObjetos[0];

            this.PreencherFomulario(this._empresa);
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        /// <returns>Retorna o Tipo de Operação Efetuada</returns>
        private void SalvarRegistro()
        {
            EmpresaOT empresaNovo = this.ConstruirObjeto();

            if (this._empresa != null)
            {
                empresaNovo.Codigo = this._empresa.Codigo;
            }

            this._EmpresaCTRL = new EmpresaCTRL(empresaNovo);

            base.ResultadoOperacao = this._EmpresaCTRL.Salvar();

        }

        /// <summary>
        /// Preenche o Comboox de Cidades
        /// </summary>
        private void PreecherComboCidade()
        {
            CidadeCTRL cidadeCTRL = new CidadeCTRL();

            base.ResultadoOperacao = cidadeCTRL.ConsultarTodos();

            if (base.ResultadoOperacao.TemObjeto)
            {
                PreencherControle.PreencherComboBox<CidadeOT>(this.cboCidade, (List<CidadeOT>)base.ResultadoOperacao.ListaObjetos, "Nome", "Codigo", base.ModoCadastro);
            }
        }

        /// <summary>
        /// Preenche o Comboox de Estados
        /// </summary>
        private void PreecherComboEstado()
        {
            PreencherControle.PreencherComboBoxEstado(this.cboUF, base.ModoCadastro);
        }

        #endregion

        #region IPreenchimentoForm<EmpresaOT> Members

        public EmpresaOT ConstruirObjeto()
        {
            EmpresaOT novoEmpresa = new EmpresaOT();

            novoEmpresa.Status = Enumeradores.Status.Ativo;

            if (this.txtCodigo.Text.Trim().Length > 0)
            {
                novoEmpresa.Codigo = Convert.ToInt32(this.txtCodigo.Text);
            }

            novoEmpresa.Nome = this.txtNome.Text.Trim();
            novoEmpresa.Endereco = this.txtEndereco.Text.Trim();
            novoEmpresa.Bairro = this.txtBairro.Text.Trim();

            if (this.txtmCEP.Text.Trim().Length > 0)
            {
                novoEmpresa.CEP = Convert.ToInt32(this.txtmCEP.Text);
            }

            if (this.cboCidade.SelectedIndex > Comum.ConstantesSitema.INDICE_INICIAL_COMBO)
            {
                novoEmpresa.Cidade.Codigo = Convert.ToInt32(this.cboCidade.SelectedValue);
            }

            if (this.cboSituacao.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoEmpresa.Status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());
            }

            if (this.cboUF.SelectedIndex > Comum.ConstantesSitema.INDICE_INICIAL_COMBO)
            {
                novoEmpresa.Estado.Codigo = Convert.ToInt32(this.cboUF.SelectedValue);
            }

            if (this.txtmCNPJ.Text.Trim().Length > 0)
            {
                novoEmpresa.CNPJ = Convert.ToDouble(this.txtmCNPJ.Text);
            }

            novoEmpresa.TelefoneComercial = this.txtmTelefone.Text.Trim();

            novoEmpresa.Fax = this.txtmCelular.Text.Trim();
            novoEmpresa.Email = this.txtEmail.Text.Trim();


            novoEmpresa.Observacao = this.txtObservacao.Text.Trim();

            novoEmpresa.NomeContato = this.txtContato.Text.Trim();

            return novoEmpresa;
        }

        public void PreencherFomulario(EmpresaOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString("00000");
            this.txtNome.Text = pObjetoOT.Nome;
            this.txtEndereco.Text = pObjetoOT.Endereco;
            this.txtBairro.Text = pObjetoOT.Bairro;

            if (pObjetoOT.CEP > 0)
            {
                this.txtmCEP.Text = pObjetoOT.CEP.ToString();
            }

            this.cboCidade.SelectedValue = pObjetoOT.Cidade.Codigo;
            this.cboUF.SelectedValue = pObjetoOT.Estado.Codigo;
            this.cboSituacao.SelectedValue = pObjetoOT.Status.ToString(); 

            if (pObjetoOT.CNPJ > 0)
            {
                this.txtmCNPJ.Text = pObjetoOT.CNPJ.ToString();
            }


            this.txtmTelefone.Text = pObjetoOT.TelefoneComercial;
            this.txtmCelular.Text = pObjetoOT.Fax;
            this.txtEmail.Text = pObjetoOT.Email;
            this.txtSituacao.Text = pObjetoOT.Status.ToString();
            this.txtDebito.Text = pObjetoOT.Debito.ToString();
            this.txtObservacao.Text = pObjetoOT.Observacao;

            this.txtContato.Text = pObjetoOT.NomeContato;

        }

        #endregion

    }
}
