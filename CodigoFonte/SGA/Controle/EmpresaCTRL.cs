using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using Negocio;
using Utilitarios;
using Comum;

namespace Controle
{
    /// <summary>
    /// Classe de Controle da Empresa.
    /// </summary>
    public class EmpresaCTRL : BaseCTRL
    {
        #region Construtores

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public EmpresaCTRL()
        {
            this._empresaOT = new EmpresaOT();
        }


        /// <summary>
        /// Construtor a classe
        /// </summary>
        /// <param name="pEmpresaOT">Objeto de transferência EmpresaOT</param>
        public EmpresaCTRL(EmpresaOT pEmpresaOT)
        {
            this._empresaOT = pEmpresaOT;
        }

        #endregion

        #region Atributos

        private EmpresaN _empresaN = new EmpresaN();
        private EmpresaOT _empresaOT = null;

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Calcula o debito do aluno
        /// </summary>
        /// <returns>Retorna o valor total do debito</returns>
        private decimal CalcularDebito()
        {
            decimal debito = 0;

            return debito;
        }

        /// <summary>
        /// Carrega as informações Empresa
        /// </summary>
        /// <param name="pEmpresaOT">Objeto Transferência Empresa</param>
        /// <returns>Retorna o Objeto Transferência do Empresa Carregado</returns>
        public ResultadoOperacao CarregarEmpresa()
        {
            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);

            if (base.ResultadoOperacao.Resultado == Enumeradores.Resultados.Sucesso)
            {
                List<EmpresaOT> _empresaList = (List<EmpresaOT>)base.ResultadoOperacao.ListaObjetos;

                if (_empresaList.Count > 0)
                {

                    //_empresaList[0].Debito = this.CalcularDebito();
                }
            }

            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        /// <summary>
        /// Consulta um Empresa pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do Empresa</param>
        /// <param name="pStatus">Status do Empresa</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da empresa</param>
        /// <param name="pStatus">Status do empresa</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Empresa pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Empresa</param>
        /// <param name="pMatricula">Código do Empresa</param>
        /// <param name="pStatus">Status do Empresa</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._empresaOT = new EmpresaOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._empresaOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._empresaOT.Codigo = pCodigo;
            }

            this._empresaOT.Status = pStatus;

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o Empresa pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Empresa</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._empresaOT = new EmpresaOT();

            this._empresaOT.Status = pStatus;

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta a empresa que possue a licença do sistema.
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarEmpresaSitema()
        {
            this._empresaOT = new EmpresaOT();
            this._empresaOT.EmpresaSistema = true;

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._empresaOT.Codigo = pCodigo;

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;

        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            this._empresaOT.Nome = pNome;

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._empresaOT = new EmpresaOT();

            base.ResultadoOperacao = this._empresaN.Consultar(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao = this._empresaN.Excluir(this._empresaOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._empresaOT.Codigo == 0)
            {
                base.ResultadoOperacao = this._empresaN.Inserir(this._empresaOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao = this._empresaN.Alterar(this._empresaOT);
                base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao;
        }

        #endregion

    }
}
