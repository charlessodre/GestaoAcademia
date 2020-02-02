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
    public partial class frmConsultarEstadoPaisCidade : frmBase
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="pUsuarioCTRL">Controlador do Usuário logado no sistema.</param>
        public frmConsultarEstadoPaisCidade(UsuarioCTRL pUsuarioCTRL, frmCadastrarEstadoPaisCidade.TipoFormulario pTipoFormulario)
        {
            InitializeComponent();
            base.ControladorUsuarioSistema = pUsuarioCTRL;
            base.ModoCadastro = false;
            this._tipoFormulario = pTipoFormulario;
        }

        #endregion

        #region Atributos

        private frmCadastrarEstadoPaisCidade.TipoFormulario _tipoFormulario;

        #endregion

        #region Propriedades

        #endregion

        #region Eventos do Formulário

        /// <summary>
        /// frmConsultarEstadoPaisCidade_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEstadoPaisCidade_Load(object sender, EventArgs e)
        {
            PreencherControle.PreencherDropDownStatus(this.cboSituacao, !base.ModoCadastro);
            this.ConfigurarTipoFormulario();
        }

        /// <summary>
        /// frmConsultarEstadoPaisCidade_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEstadoPaisCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// frmConsultarEstadoPaisCidade_KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultarEstadoPaisCidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (this._tipoFormulario)
                {
                    case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:

                        break;
                    case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                        break;
                    case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Eventos DataGridView


        /// <summary>
        /// dgvConsulta_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsulta_SelectionChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// dgvConsulta_PreviewKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsulta_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.dgvConsulta.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsulta.SelectedRows[0].Cells["colCodigo"].Value);


                if (e.KeyCode == Keys.Enter)
                {
                    this.SelecionarFormularioCadastro(codigo);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    this.ExcluirItem(codigo);
                }

            }
        }

        /// <summary>
        /// dgvConsulta_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvConsulta_DoubleClick(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvConsulta.SelectedRows[0].Cells["colCodigo"].Value);

            this.SelecionarFormularioCadastro(codigo);
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
            this.ConsultarDados();
        }

        /// <summary>
        /// btnNovo_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.SelecionarFormularioCadastro();
        }

        /// <summary>
        /// btnExcluir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvConsulta.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsulta.SelectedRows[0].Cells["colCodigo"].Value);

                this.ExcluirItem(codigo);
            }
        }

        /// <summary>
        /// btnAlterar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvConsulta.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(this.dgvConsulta.SelectedRows[0].Cells["colCodigo"].Value);

                this.SelecionarFormularioCadastro(codigo);
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
                this.ConsultarDados();
            }
        }

        #endregion

        #region Métodos


        /// <summary>
        /// Configura o tipo de formulário.
        /// </summary>
        private void ConfigurarTipoFormulario()
        {
            switch (this._tipoFormulario)
            {
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:
                    this.Text = TituloJanelas.ConsultarPais;
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarPais; ;
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarEstado; ;
                    this.Text = TituloJanelas.ConsultarEstado;
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarCidade;
                    this.Text = TituloJanelas.ConsultarCidade;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Consulta os grupos de usuaários.
        /// </summary>
        private void ConsultarDados()
        {
            switch (this._tipoFormulario)
            {
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarPais; ;
                    this.Text = TituloJanelas.ConsultarPais;
                    this.ConsultarPais();
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarEstado; ;
                    this.Text = TituloJanelas.ConsultarEstado;
                    this.ConsultarEstado();
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                    this.lblDadosCadastro.Text = TituloJanelas.ConsultarCidade;
                    this.Text = TituloJanelas.ConsultarCidade;
                    this.ConsultarCidade();
                    break;
                default:
                    break;
            }


        }

        /// <summary>
        /// Excluir um item
        /// </summary>
        /// <param name="pCodigo">Código do objeto a ser excluído.</param>
        private void ExcluirItem(int pCodigo)
        {

            switch (this._tipoFormulario)
            {
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:
                    this.ExcluirPais(pCodigo);
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                    this.ExcluirEstado(pCodigo);
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                    this.ExcluirCidade(pCodigo);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Seleciona o formulário de cadastro a ser exibido.
        /// </summary>
        /// <param name="pCodigo">Codigo do objeto selecioando.</param>
        private void SelecionarFormularioCadastro(int pCodigo)
        {
            switch (this._tipoFormulario)
            {
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:
                    this.ExibirFormCadastroPais(pCodigo);
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                    this.ExibirFormCadastroEstado(pCodigo);
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                    this.ExibirFormCadastroCidade(pCodigo);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Seleciona o formulário de cadastro a ser exibido.
        /// </summary>
        private void SelecionarFormularioCadastro()
        {
            switch (this._tipoFormulario)
            {
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Pais:
                    this.ExibirFormCadastroPais();
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Estado:
                    this.ExibirFormCadastroEstado();
                    break;
                case frmCadastrarEstadoPaisCidade.TipoFormulario.Cidade:
                    this.ExibirFormCadastroCidade();
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region Métodos Pais

        /// <summary>
        /// Recupera os dados do país
        /// </summary>
        private void ConsultarPais()
        {

            PaisCTRL paisCTRL = new PaisCTRL();
            List<PaisOT> paisList;

            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = paisCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = paisCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = paisCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                paisList = (List<PaisOT>)base.ResultadoOperacao.ListaObjetos;
                this.AtualizarDataGridView(paisList);
            }
            else
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }

        }

        /// <summary>
        /// Exclui um grupo de usuário.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExcluirPais(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PaisOT paisOT = new PaisOT();

                paisOT.Codigo = pCodigo;

                PaisCTRL paisCTRL = new PaisCTRL(paisOT);

                base.ResultadoOperacao = paisCTRL.Excluir();


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

                this.ConsultarDados();
            }


        }

        /// <summary>
        /// Exibe o formulário de cadastro do país.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastroPais(int pCodigo)
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario, base.ControladorUsuarioSistema, pCodigo);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarDados();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do país.
        /// </summary>
        private void ExibirFormCadastroPais()
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario, base.ControladorUsuarioSistema);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarDados();
        }

        /// <summary>
        ///  Atualiza os dados do data grid view.
        /// </summary>
        /// <param name="pLista">Lista</param>
        private void AtualizarDataGridView(List<PaisOT> pLista)
        {
            this.dgvConsulta.AutoGenerateColumns = false;
            this.dgvConsulta.DataSource = pLista;
            this.dgvConsulta.Select();
        }


        #endregion

        #region Métodos Estado

        /// <summary>
        /// Consultar Estados
        /// </summary>
        private void ConsultarEstado()
        {

            EstadoCTRL estadoCTRL = new EstadoCTRL();
            List<EstadoOT> estadoList;

            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = estadoCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = estadoCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = estadoCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                estadoList = (List<EstadoOT>)base.ResultadoOperacao.ListaObjetos;
                this.AtualizarDataGridView(estadoList);
            }
            else
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }

        }

        /// <summary>
        /// Exclui um Estado.
        /// </summary>
        /// <param name="pCodigo">Código do Estado</param>
        private void ExcluirEstado(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                EstadoOT estadoOT = new EstadoOT();

                estadoOT.Codigo = pCodigo;

                EstadoCTRL estadoCTRL = new EstadoCTRL(estadoOT);

                base.ResultadoOperacao = estadoCTRL.Excluir();


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

                this.ConsultarDados();
            }


        }

        /// <summary>
        /// Exibe o formulário de cadastro do Estado.
        /// </summary>
        /// <param name="pCodigo">Código do Grupo</param>
        private void ExibirFormCadastroEstado(int pCodigo)
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario, base.ControladorUsuarioSistema, pCodigo);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarDados();

        }

        /// <summary>
        /// Exibe o formulário de cadastro do Estado.
        /// </summary>
        private void ExibirFormCadastroEstado()
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario, base.ControladorUsuarioSistema);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarDados();
        }


        /// <summary>
        ///  Atualiza os dados do data grid view.
        /// </summary>
        /// <param name="pLista">Lista</param>
        private void AtualizarDataGridView(List<EstadoOT> pLista)
        {
            this.dgvConsulta.AutoGenerateColumns = false;
            this.dgvConsulta.DataSource = pLista;
            this.dgvConsulta.Select();
        }


        #endregion

        #region Métodos Cidade

        /// <summary>
        /// Constar Cidade
        /// </summary>
        private void ConsultarCidade()
        {

            CidadeCTRL cidadeCTRL = new CidadeCTRL();
            List<CidadeOT> cidadeList;

            Utilitarios.Enumeradores.Status status = Utilitarios.Enumeradores.ConverterStringStatus(this.cboSituacao.SelectedValue.ToString());

            if (this.txtProcurar.Text.Trim().Length > 0)
            {
                if (this.rbNome.Checked)
                {
                    base.ResultadoOperacao = cidadeCTRL.ConsultarNomeStatus(this.txtProcurar.Text.Trim().Replace("'", ""), status);
                }
                else
                {
                    int codigo = 0;

                    if (int.TryParse(this.txtProcurar.Text, out codigo))
                    {
                        base.ResultadoOperacao = cidadeCTRL.ConsultarCodigoStatus(codigo, status);
                    }
                }
            }
            else
            {
                base.ResultadoOperacao = cidadeCTRL.ConsultarStatus(status);
            }

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                cidadeList = (List<CidadeOT>)base.ResultadoOperacao.ListaObjetos;
                this.AtualizarDataGridView(cidadeList);
            }
            else
            {
                base.ExibirMensagemOperacao(base.ResultadoOperacao);
            }

        }

        /// <summary>
        /// Exclui uma Cidade.
        /// </summary>
        /// <param name="pCodigo">Código da Cidade</param>
        private void ExcluirCidade(int pCodigo)
        {

            if (base.ExibirMessagemGeral(Mensagem.ExcluirRegistro(pCodigo.ToString()), TituloJanelas.ExcluirRegistro,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                CidadeOT cidadeOT = new CidadeOT();

                cidadeOT.Codigo = pCodigo;

                CidadeCTRL cidadeCTRL = new CidadeCTRL(cidadeOT);

                base.ResultadoOperacao = cidadeCTRL.Excluir();


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

                this.ConsultarCidade();
            }


        }

        /// <summary>
        /// Exibe o formulário de cadastro de Cidade.
        /// </summary>
        /// <param name="pCodigo">Código da Cidade</param>
        private void ExibirFormCadastroCidade(int pCodigo)
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario, base.ControladorUsuarioSistema, pCodigo);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarCidade();

        }

        /// <summary>
        /// Exibe o formulário de cadastro da Cidade.
        /// </summary>
        private void ExibirFormCadastroCidade()
        {
            frmCadastrarEstadoPaisCidade frmCadastrarEstadoPaisCidade = new frmCadastrarEstadoPaisCidade(this._tipoFormulario,base.ControladorUsuarioSistema);
            frmCadastrarEstadoPaisCidade.ShowDialog();
            this.ConsultarCidade();
        }

        /// <summary>
        ///  Atualiza os dados do data grid view.
        /// </summary>
        /// <param name="pLista">Lista</param>
        private void AtualizarDataGridView(List<CidadeOT> pLista)
        {
            this.dgvConsulta.AutoGenerateColumns = false;
            this.dgvConsulta.DataSource = pLista;
            this.dgvConsulta.Select();
        }

        #endregion

    }
}
