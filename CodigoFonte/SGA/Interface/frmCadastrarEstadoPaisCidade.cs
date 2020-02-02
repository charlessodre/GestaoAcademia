using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitarios;
using ObjetoOT;
using Controle;
using Comum;

namespace Interface
{
    public partial class frmCadastrarEstadoPaisCidade : frmBase
    {
        #region Construtores


        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarEstadoPaisCidade(UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pTipoFormulario">Tipo do Formulário.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmCadastrarEstadoPaisCidade(TipoFormulario pTipoFormulario,UsuarioCTRL pUsuarioCTRL)
        {
            InitializeComponent();
            this._tipoFormulario = pTipoFormulario;
            base.ControladorUsuarioSistema = pUsuarioCTRL;

        }

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pTipoFormulario">Tipo do Formulário.</param>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        /// <param name="pCodigo">Codigo do Objeto a se alterado.</param>
        public frmCadastrarEstadoPaisCidade(TipoFormulario pTipoFormulario, UsuarioCTRL pUsuarioCTRL,int pCodigo)
        {
            InitializeComponent();
            this._tipoFormulario = pTipoFormulario;
            this._codigo = pCodigo;
            base.ControladorUsuarioSistema = pUsuarioCTRL;

        }

        #endregion

        #region Enumeradores

        public enum TipoFormulario
        {
            Pais,
            Estado,
            Cidade
        }

        #endregion

        #region Atributos

        private TipoFormulario _tipoFormulario;
        private int _codigo;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos Fomulário

        /// <summary>
        /// frmCadastrarEstado_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarEstado_Load(object sender, EventArgs e)
        {
            this.ConfigurarTipoFormulario();
        }

        /// <summary>
        /// frmCadastrarEstadoPaisCidade_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarEstadoPaisCidade_KeyDown(object sender, KeyEventArgs e)
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
            this.Dispose();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpa os dados do formulário.
        /// </summary>
        private void LimparDadosFormulario()
        {
            this._codigo = 0;
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.txtSigla.Text = string.Empty;
        }

        /// <summary>
        /// Configura o tipo de formulário.
        /// </summary>
        private void ConfigurarTipoFormulario()
        {
            switch (this._tipoFormulario)
            {
                case TipoFormulario.Pais:
                    this.Text = TituloJanelas.CadastroPais;
                    this.lblDadosCadastro.Text = "Dados País";
                    this.lblSilga.Visible = this.txtSigla.Visible = true;
                    this.RecuperarDadosPais();
                    break;
                case TipoFormulario.Estado:
                    this.lblDadosCadastro.Text = "Dados Estado";
                    this.Text = TituloJanelas.CadastroEstado;
                    this.lblSilga.Visible = this.txtSigla.Visible = true;
                    this.RecuperarDadosEstado();
                    break;
                case TipoFormulario.Cidade:
                    this.lblDadosCadastro.Text = "Dados Cidade";
                    this.Text = TituloJanelas.CadastroCidade;
                    this.lblSilga.Visible = this.txtSigla.Visible = false;
                    this.RecuperarDadosCidade();
                    break;
                default:
                    break;
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
            if (this.lblSilga.Visible)
            {
                if (this.txtSigla.Text.Trim().Length == 0)
                {
                    base.ExibirMessagemGeral(Mensagem.SiglaObrigatorio, TituloJanelas.CampoObrigatorio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    this.txtSigla.Focus();
                    return false;
                }
            }

            return true;
        }

         /// <summary>
        /// Salva o Registro no banco
        /// </summary>
        /// <returns>Retorna o Tipo de Operação Efetuada</returns>
        private void SalvarRegistro()
        {
            switch (this._tipoFormulario)
            {
                case TipoFormulario.Pais:
                    this.Salvar(this.ConstruirObjetoPais());
                    break;
                case TipoFormulario.Estado:
                    this.Salvar(this.ConstruirObjetoEstado());
                    break;
                case TipoFormulario.Cidade:
                    this.Salvar(this.ConstruirObjetoCidade());
                    break;
                default:
                    break;
            }

            base.ExibirMensagemOperacao(base.ResultadoOperacao);


            //if (base.ResultadoOperacao.Resultado != Enumeradores.Resultados.Sucesso)
            //{

            //    if (base.ResultadoOperacao.TipoOperacao == Enumeradores.TipoOperacao.Alteracao)
            //    {
            //        base.ExibirMessagemGeral(Mensagem.ErroAlterar, TituloJanelas.AlteracaoGeral,
            //                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            //    }
            //    else
            //    {
            //        base.ExibirMessagemGeral(Mensagem.ErroInserir, TituloJanelas.AlteracaoGeral,
            //                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            //    }

            //}
            //else
            //{
            //    if (base.ResultadoOperacao.TipoOperacao == Enumeradores.TipoOperacao.Alteracao)
            //    {
            //        base.ExibirMessagemGeral(Mensagem.AlteradoSucesso, TituloJanelas.CadastroGeral,
            //                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            //    }
            //    else
            //    {
            //        base.ExibirMessagemGeral(Mensagem.InseridoSucesso, TituloJanelas.CadastroGeral,
            //                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            //    }
            //}
        }
        #endregion

        #region Métodos Pais

        /// <summary>
        /// Recupera os dados do país
        /// </summary>
        private void RecuperarDadosPais()
        {
            if (this._codigo > 0)
            {
                PaisCTRL paisCTRL = new PaisCTRL();

               base.ResultadoOperacao = paisCTRL.ConsultarCodigo(this._codigo);

                if (base.ResultadoOperacao.TemObjeto)
                {
                    this.PreencherControles((PaisOT)base.ResultadoOperacao.ListaObjetos[0]);
                }
            }

        }

        private PaisOT ConstruirObjetoPais()
        {
            PaisOT paisOT = new PaisOT();

            paisOT.Nome = this.txtNome.Text.Trim();
            paisOT.Sigla = this.txtSigla.Text.Trim();

            return paisOT;
        }

        private void PreencherControles(PaisOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString();
            this.txtNome.Text = pObjetoOT.Nome;
            this.txtSigla.Text = pObjetoOT.Sigla;
        }

        private void Salvar(PaisOT pObjetoOT)
        {
            if (this._codigo > 0)
            {
                pObjetoOT.Codigo = this._codigo;
            }

            PaisCTRL paisCTRL = new PaisCTRL(pObjetoOT);

           base.ResultadoOperacao = paisCTRL.Salvar();

        }

        #endregion

        #region Métodos Estado

        private EstadoOT ConstruirObjetoEstado()
        {
            EstadoOT estadoOT = new EstadoOT();

            estadoOT.Nome = this.txtNome.Text.Trim();
            estadoOT.Sigla = this.txtSigla.Text.Trim();

            return estadoOT;
        }

        private void PreencherControles(EstadoOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString();
            this.txtNome.Text = pObjetoOT.Nome;
            this.txtSigla.Text = pObjetoOT.Sigla;
        }

        private void Salvar(EstadoOT pObjetoOT)
        {
            if (this._codigo > 0)
            {
                pObjetoOT.Codigo = this._codigo;
            }

            EstadoCTRL estadoCTRL = new EstadoCTRL(pObjetoOT);

           base.ResultadoOperacao = estadoCTRL.Salvar();
        }

        /// <summary>
        /// Recupera os dados do estado
        /// </summary>
        private void RecuperarDadosEstado()
        {
            if (this._codigo > 0)
            {
                EstadoCTRL estadoCTRL = new EstadoCTRL();

               base.ResultadoOperacao = estadoCTRL.ConsultarCodigo(this._codigo);

                if (base.ResultadoOperacao.TemObjeto)
                {
                    this.PreencherControles((EstadoOT)base.ResultadoOperacao.ListaObjetos[0]);
                }
            }
        }


        #endregion

        #region Métodos Cidade

        private CidadeOT ConstruirObjetoCidade()
        {
            CidadeOT cidadeOT = new CidadeOT();

            cidadeOT.Nome = this.txtNome.Text.Trim();

            return cidadeOT;
        }

        private void PreencherControles(CidadeOT pObjetoOT)
        {
            this.txtCodigo.Text = pObjetoOT.Codigo.ToString();
            this.txtNome.Text = pObjetoOT.Nome;
        }

        private void Salvar(CidadeOT pObjetoOT)
        {
            if (this._codigo > 0)
            {
                pObjetoOT.Codigo = this._codigo;
            }

            CidadeCTRL cidadeCTRL = new CidadeCTRL(pObjetoOT);

           base.ResultadoOperacao = cidadeCTRL.Salvar();
        }


        /// <summary>
        /// Recupera os dados da cidade
        /// </summary>
        private void RecuperarDadosCidade()
        {
            if (this._codigo > 0)
            {
                CidadeCTRL cidadeCTRL = new CidadeCTRL();

               base.ResultadoOperacao = cidadeCTRL.ConsultarCodigo(this._codigo);

                if (base.ResultadoOperacao.TemObjeto)
                {
                    this.PreencherControles((CidadeOT)base.ResultadoOperacao.ListaObjetos[0]);
                }
            }
        }



        #endregion

    }
}
