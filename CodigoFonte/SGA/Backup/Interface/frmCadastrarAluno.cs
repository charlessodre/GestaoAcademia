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
    public partial class frmCadastrarAluno : frmBase, IPreenchimentoForm<AlunoOT>
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarAluno(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pMatricula">Matricula do Aluno.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarAluno(int pMatricula, UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._matricula = pMatricula;
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
        }


        #endregion

        #region Atributos

        private AlunoOT _aluno;
        private AlunoCTRL _alunoCTRL;
        private int _matricula;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Formulário

        /// <summary>
        /// frmCadastroAluno_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastroAluno_Load(object sender, EventArgs e)
        {
            PreencherControle.PreencherDropDownEstadoCivil(this.cboEstadoCivil, base.ModoCadastro);
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, base.ModoCadastro);

            this.PreecherComboCidade();
            this.PreecherComboEstado();
            this.PreecherComboEmpresa();
            this.PreecherComboProfissao();

            if (this._matricula > 0)
            {
                this.Text = TituloJanelas.AlterarAluno;
                this.ConsultarDadosAluno();
            }
            else
            {
                this.Text = TituloJanelas.CadastroAluno;
            }
        }

        /// <summary>
        /// frmCadastroAluno_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastroAluno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                base.FecharFormulario = true;
                this.Dispose();
            }
        }

        /// <summary>
        /// frmCadastrarAluno_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarAluno_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.tbcCadastroAluno.SelectedTab = this.tbpDadosCadastrais;
                    break;
                case Keys.F2:
                    this.tbcCadastroAluno.SelectedTab = this.tbpAdicionais;
                    break;
                case Keys.F3:
                    this.tbcCadastroAluno.SelectedTab = this.tbpHorario;
                    break;
                case Keys.F4:
                    this.tbcCadastroAluno.SelectedTab = this.tbpAcesso;
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

                if (this._matricula > 0)
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
                    this.pbxFotoAluno.Image = Image.FromFile(this.ofdFoto.FileName);
                }
            }
        }

        /// <summary>
        /// btnNovaImagem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovaImagem_Click(object sender, EventArgs e)
        {

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
                this.pbxFotoAluno.Image = rsxImagens.indisponivel200x200;
            }
        }

        /// <summary>
        /// dtpNascimento_Validated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpNascimento_Validated(object sender, EventArgs e)
        {
            this.lblIdade.Text = Util.CalcularIdade(this.dtpNascimento.Value).ToString();
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
        /// btnNovaProfissao_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovaProfissao_Click(object sender, EventArgs e)
        {
            frmCadastrarProfissao frmCadastrarProfissao = new frmCadastrarProfissao(base.ControladorUsuarioSistema);
            frmCadastrarProfissao.ShowDialog();
            this.PreecherComboProfissao();
        }


        /// <summary>
        /// btnNovaEmpresa_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovaEmpresa_Click(object sender, EventArgs e)
        {
            frmCadastrarEmpresa frmCadastroEmpresa = new frmCadastrarEmpresa(base.ControladorUsuarioSistema);
            frmCadastroEmpresa.ShowDialog();
            this.PreecherComboEmpresa();
        }


        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this._matricula = 0;
            this.txtNome.Text = string.Empty;
            this.txtMatricula.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtBairro.Text = string.Empty;
            this.txtmCEP.Text = string.Empty;
            this.cboCidade.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.cboUF.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO; ;
            this.txtmCPF.Text = string.Empty;
            this.txtIdentidade.Text = string.Empty;
            this.cboUFRG.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.txtmTelefone.Text = string.Empty;
            this.txtmCelular.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.dtpNascimento.Value = DateTime.Today;
            this.lblIdade.Text = string.Empty;
            this.rbMasculino.Checked = false;
            this.rbFeminino.Checked = false;
            this.txtSituacao.Text = string.Empty;
            this.txtDebito.Text = string.Empty;
            this.txtObservacao.Text = string.Empty;
            this.pbxFotoAluno.Image = rsxImagens.indisponivel200x200;
            this.txtObjetivo.Text = string.Empty;
            this.cboProfissao.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.cboEstadoCivil.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.cboEmpresa.SelectedValue = Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO;
            this.txtmTelefoneCom.Text = string.Empty;
            this.txtNomePai.Text = string.Empty;
            this.txtNomeMae.Text = string.Empty;
            this.txtResponsavel.Text = string.Empty;
            this.txtmTelefoneResp.Text = string.Empty;

        }

        /// <summary>
        /// Consulta os dados do Aluno.
        /// </summary>
        /// <param name="pMatricula">Matricula do Aluno.</param>
        private void ConsultarDadosAluno()
        {
            this._aluno = new AlunoOT();
            this._aluno.Codigo = this._matricula;

            this._alunoCTRL = new AlunoCTRL(this._aluno);
            this._aluno = (AlunoOT)this._alunoCTRL.CarregarAluno().ListaObjetos[0];

            this.PreencherFomulario(this._aluno);
        }

        /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        private void SalvarRegistro()
        {
            AlunoOT alunoNovo = this.ConstruirObjeto();

            if (this._aluno != null)
            {
                alunoNovo.Codigo = this._aluno.Codigo;
            }

            this._alunoCTRL = new AlunoCTRL(alunoNovo);

            base.ResultadoOperacao = this._alunoCTRL.Salvar();

            base.ExibirMensagemOperacao(base.ResultadoOperacao);

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
            PreencherControle.PreencherComboBoxEstado(this.cboUFRG, base.ModoCadastro);

        }

        /// <summary>
        /// Preenche o Comboox de Profissao
        /// </summary>
        private void PreecherComboProfissao()
        {
            ProfissaoCTRL profissaoCTRL = new ProfissaoCTRL();

            base.ResultadoOperacao = profissaoCTRL.ConsultarTodos();

            if (base.ResultadoOperacao.TemObjeto)
            {
                PreencherControle.PreencherComboBox<ProfissaoOT>(this.cboProfissao, (List<ProfissaoOT>)base.ResultadoOperacao.ListaObjetos, "Nome", "Codigo", base.ModoCadastro);
            }

        }

        /// <summary>
        /// Preenche o Comboox de Empresa
        /// </summary>
        private void PreecherComboEmpresa()
        {
            EmpresaCTRL empresaCTRL = new EmpresaCTRL();

            base.ResultadoOperacao = empresaCTRL.ConsultarTodos();

            if (base.ResultadoOperacao.TemObjeto)
            {
                PreencherControle.PreencherComboBox<EmpresaOT>(this.cboEmpresa, (List<EmpresaOT>)base.ResultadoOperacao.ListaObjetos, "Nome", "Codigo", base.ModoCadastro);
            }

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


        #endregion

        #region IPreenchimentoForm<AlunoOT> Members

        public AlunoOT ConstruirObjeto()
        {
            AlunoOT novoAluno = new AlunoOT();

            if (this.txtMatricula.Text.Trim().Length > 0)
            {
                novoAluno.Codigo = Convert.ToInt32(this.txtMatricula.Text);
            }

            novoAluno.Nome = this.txtNome.Text.Trim();
            novoAluno.Endereco = this.txtEndereco.Text.Trim();
            novoAluno.Bairro = this.txtBairro.Text.Trim();

            if (this.txtmCEP.Text.Trim().Length > 0)
            {
                novoAluno.CEP = Convert.ToInt32(this.txtmCEP.Text);
            }

            if (this.cboCidade.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.Cidade.Codigo = Convert.ToInt32(this.cboCidade.SelectedValue);
            }

            if (this.cboUF.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.Estado.Codigo = Convert.ToInt32(this.cboUF.SelectedValue);
            }

            if (this.txtmCPF.Text.Trim().Length > 0)
            {
                novoAluno.CPF = Convert.ToDouble(this.txtmCPF.Text);
                novoAluno.RG = this.txtIdentidade.Text.Trim();
            }

            if (this.cboSituacao.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.Status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());
            }

            if (this.cboUFRG.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.EstadoRG.Codigo = Convert.ToInt32(this.cboUFRG.SelectedValue);
            }

            novoAluno.TelefoneResidencial = this.txtmTelefone.Text.Trim();

            novoAluno.TelefoneCelular = this.txtmCelular.Text.Trim();
            novoAluno.Email = this.txtEmail.Text.Trim();
            novoAluno.DataNascimento = this.dtpNascimento.Value;

            novoAluno.Idade = Convert.ToInt32(this.lblIdade.Text);

            if (this.rbMasculino.Checked)
            {
                novoAluno.Sexo = Enumeradores.Sexo.Masculino;
            }
            else if (this.rbFeminino.Checked)
            {
                novoAluno.Sexo = Enumeradores.Sexo.Feminino;
            }

            novoAluno.Observacao = this.txtObservacao.Text.Trim();

            novoAluno.Foto = Util.ConvertImageByteArray(this.pbxFotoAluno.Image, ImageFormat.Jpeg);

            novoAluno.Objetivo = this.txtObjetivo.Text.Trim();

            if (this.cboProfissao.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.Profissao.Codigo = Convert.ToInt32(this.cboProfissao.SelectedValue);
            }

            if (this.cboEmpresa.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.Empresa.Codigo = Convert.ToInt32(this.cboEmpresa.SelectedValue);
            }

            if (this.cboEstadoCivil.SelectedIndex > Comum.ConstantesSitema.PRIMEIRO_VALOR_COMBO)
            {
                novoAluno.EstadoCivil = Enumeradores.ConverterStringEstadoCivil(this.cboEstadoCivil.SelectedValue.ToString());
            }
            novoAluno.TelefoneComercial = this.txtmTelefoneCom.Text.Trim();
            novoAluno.NomePai = this.txtNomePai.Text.Trim();
            novoAluno.NomeMae = this.txtNomeMae.Text.Trim();
            novoAluno.NomeResponsavel = this.txtResponsavel.Text.Trim();
            novoAluno.TelefoneResponsavel = this.txtmTelefoneResp.Text.Trim();

            return novoAluno;
        }

        public void PreencherFomulario(AlunoOT pObjetoOT)
        {
            this.txtMatricula.Text = pObjetoOT.Codigo.ToString(Comum.ConstantesSitema.FOMATACAO_DIGITOS_MATRICULA);
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


            if (pObjetoOT.CPF > 0)
            {
                this.txtmCPF.Text = pObjetoOT.CPF.ToString();
            }

            this.txtIdentidade.Text = pObjetoOT.RG;
            this.cboUFRG.SelectedValue = pObjetoOT.EstadoRG.Codigo;
            this.txtmTelefone.Text = pObjetoOT.TelefoneResidencial;
            this.txtmCelular.Text = pObjetoOT.TelefoneCelular;
            this.txtEmail.Text = pObjetoOT.Email;

            if (pObjetoOT.DataNascimento.Equals(DateTime.MinValue))
            {
                this.dtpNascimento.Value = DateTime.Today;
            }
            else
            {
                this.dtpNascimento.Value = pObjetoOT.DataNascimento;
            }

            this.lblIdade.Text = pObjetoOT.Idade.ToString();

            switch (pObjetoOT.Sexo)
            {
                case Utilitarios.Enumeradores.Sexo.Masculino:
                    this.rbMasculino.Checked = true;
                    break;
                case Utilitarios.Enumeradores.Sexo.Feminino:
                    this.rbFeminino.Checked = true;
                    break;
                default:
                    this.rbMasculino.Checked = false;
                    this.rbFeminino.Checked = false;
                    break;
            }

            this.txtSituacao.Text = pObjetoOT.Status.ToString();
            this.txtDebito.Text = pObjetoOT.Debito.ToString(Comum.ConstantesSitema.FOMATACAO_VALOR_MOEDA);
            this.txtObservacao.Text = pObjetoOT.Observacao;

            if (pObjetoOT.Foto == null)
            {
                this.pbxFotoAluno.Image = rsxImagens.indisponivel200x200;
            }
            else
            {
                this.pbxFotoAluno.Image = Util.ConverterByteArrayImagem(pObjetoOT.Foto);
            }

            this.txtObjetivo.Text = pObjetoOT.Objetivo;
            this.cboProfissao.SelectedValue = pObjetoOT.Profissao.Codigo;
            this.cboEstadoCivil.SelectedValue = pObjetoOT.EstadoCivil;
            this.cboEmpresa.SelectedValue = pObjetoOT.Empresa.Codigo;
            this.txtmTelefoneCom.Text = pObjetoOT.TelefoneComercial;
            this.txtNomePai.Text = pObjetoOT.NomePai;
            this.txtNomeMae.Text = pObjetoOT.NomeMae;
            this.txtResponsavel.Text = pObjetoOT.NomeResponsavel;
            this.txtmTelefoneResp.Text = pObjetoOT.TelefoneResponsavel;

        }

        #endregion


    }
}
