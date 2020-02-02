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
    public partial class frmConfigurarSistema : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConfigurarSistema(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        #endregion

        #region Atributos

        private EmpresaOT _empresa;
        private EmpresaCTRL _EmpresaCTRL;

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
            this.PreecherComboCidade();
            this.PreecherComboEstado();
            this.ConsultarDadosEmpresa();

            if (this._empresa != null)
            {
                this.Text = TituloJanelas.AlterarEmpresa;

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
        /// frmConfigurarSistema_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConfigurarSistema_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.tbcConfiguracoesSistema.SelectedTab = this.tbpDadosEmpresa;
                    break;
                case Keys.F2:
                    this.tbcConfiguracoesSistema.SelectedTab = this.tbpConfiguracoesGerais;
                    break;
                case Keys.Escape:
                    this.Dispose();
                    break;
                default:
                    break;
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

        /// <summary>
        /// btnProcurarImagem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcurarImagem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.ofdFoto.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (ofdFoto.CheckFileExists && !string.IsNullOrEmpty(this.ofdFoto.FileName))
                {
                    this.pbxLogoEmpresa.Image = Image.FromFile(this.ofdFoto.FileName);
                }
            }
        }

        /// <summary>
        /// btnExcluirImagem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluirImagem_Click(object sender, EventArgs e)
        {
            if (base.ExibirMessagemGeral(Mensagem.ExcluirImagem, TituloJanelas.ExcluirImagem,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.pbxLogoEmpresa.Image = rsxImagens.indisponivel200x200;
            }
        }


        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this.txtNomeFantasia.Text = string.Empty;
            this.txtRazaoSocial.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtBairro.Text = string.Empty;
            this.txtmCEP.Text = string.Empty;
            this.cboCidade.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.cboUF.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO; ;
            this.txtmTelefone.Text = string.Empty;
            this.txtmFax.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtSite.Text = string.Empty;
            this.txtmFax.Text = string.Empty;

        }

        /// <summary>
        /// Valida o preenchimento dos campos da tela.
        /// </summary>
        /// <returns>Retorna True se o campos foram preenchidos corretamente e False caso contrário</returns>
        private bool ValidarPreenchimentoCampos()
        {
            if (this.txtNomeFantasia.Text.Trim().Length == 0)
            {
                base.ExibirMessagemGeral(Mensagem.NomeObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                this.txtNomeFantasia.Focus();
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
            this._EmpresaCTRL = new EmpresaCTRL();
            base.ResultadoOperacao = this._EmpresaCTRL.ConsultarEmpresaSitema();

            if (base.ResultadoOperacao.TemObjeto)
            {
                this._empresa = (EmpresaOT)base.ResultadoOperacao.ListaObjetos[0];
                this.PreencherDadosEmpresa(this._empresa);
            }

        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        /// <returns>Retorna o Tipo de Operação Efetuada</returns>
        private void SalvarRegistro()
        {
            EmpresaOT empresaNovo = this.ConstruirObjEmpresa();

            if (this._empresa != null)
            {
                empresaNovo.Codigo = this._empresa.Codigo;
            }

            empresaNovo.Logo = Util.ConvertImageByteArray(this.pbxLogoEmpresa.Image, ImageFormat.Jpeg);

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

        #region Métodos Empresa

        public EmpresaOT ConstruirObjEmpresa()
        {
            EmpresaOT novoEmpresa = new EmpresaOT();

            novoEmpresa.Status = Enumeradores.Status.Ativo;
            novoEmpresa.EmpresaSistema = true;

            //if (this.txtCodigo.Text.Trim().Length > 0)
            //{
            //    novoEmpresa.Codigo = Convert.ToInt32(this.txtCodigo.Text);
            //}

            novoEmpresa.Nome = this.txtNomeFantasia.Text.Trim();
            novoEmpresa.Endereco = this.txtEndereco.Text.Trim();
            novoEmpresa.Bairro = this.txtBairro.Text.Trim();

            if (this.txtmCEP.Text.Trim().Length > 0)
            {
                novoEmpresa.CEP = Convert.ToInt32(this.txtmCEP.Text);
            }

            if (this.cboCidade.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoEmpresa.Cidade.Codigo = Convert.ToInt32(this.cboCidade.SelectedValue);
            }

            if (this.cboUF.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoEmpresa.Estado.Codigo = Convert.ToInt32(this.cboUF.SelectedValue);
            }

            if (this.txtmCNPJ.Text.Trim().Length > 0)
            {
                novoEmpresa.CNPJ = Convert.ToDouble(this.txtmCNPJ.Text);
            }

            novoEmpresa.TelefoneComercial = this.txtmTelefone.Text.Trim();
            novoEmpresa.Fax = this.txtmFax.Text.Trim();
            novoEmpresa.Email = this.txtEmail.Text.Trim();

            novoEmpresa.Site = this.txtSite.Text.Trim();
            novoEmpresa.RazaoSocial = this.txtRazaoSocial.Text.Trim();


            return novoEmpresa;
        }

        public void PreencherDadosEmpresa(EmpresaOT pObjetoOT)
        {
            this.txtNomeFantasia.Text = pObjetoOT.Nome;
            this.txtEndereco.Text = pObjetoOT.Endereco;
            this.txtBairro.Text = pObjetoOT.Bairro;

            if (pObjetoOT.CEP > 0)
            {
                this.txtmCEP.Text = pObjetoOT.CEP.ToString();
            }

            this.cboCidade.SelectedValue = pObjetoOT.Cidade.Codigo;
            this.cboUF.SelectedValue = pObjetoOT.Estado.Codigo;

            if (pObjetoOT.CNPJ > 0)
            {
                this.txtmCNPJ.Text = pObjetoOT.CNPJ.ToString();
            }

            if (pObjetoOT.Logo == null)
            {
                this.pbxLogoEmpresa.Image = rsxImagens.indisponivel200x200;
            }
            else
            {
                this.pbxLogoEmpresa.Image = Util.ConverterByteArrayImagem(pObjetoOT.Logo);
            }

            this.txtmTelefone.Text = pObjetoOT.TelefoneComercial;
            this.txtmFax.Text = pObjetoOT.Fax;
            this.txtEmail.Text = pObjetoOT.Email;
            this.txtSite.Text = pObjetoOT.Site;
            this.txtRazaoSocial.Text = pObjetoOT.RazaoSocial;

        }

        #endregion

    }
}
