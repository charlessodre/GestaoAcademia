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
    /// Classe de Controle de Usuário.
    /// </summary>
    public class UsuarioCTRL : BaseCTRL
    {

        #region Construtores

        /// <summary>
        /// Construtor padrão da classe. 
        /// </summary>
        public UsuarioCTRL()
        {
            this._usuarioOT = new UsuarioOT();
            this._usuarioN = new UsuarioN();
        }

        /// <summary>
        /// Construtor da classe. 
        /// </summary>
        /// <param name="pMenuOT">Objeto de Transferência Usuário</param>
        public UsuarioCTRL(UsuarioOT pUsuarioOT)
        {
            this._usuarioOT = pUsuarioOT;
            this._usuarioN = new UsuarioN();
        }

        #endregion

        #region Atributos

        private UsuarioOT _usuarioOT = null;
        private UsuarioN _usuarioN = null;

        #endregion

        #region Propriedades

        /// <summary>
        /// Lê o dados do usuário logado no sistema.
        /// </summary>
        public UsuarioOT UsuarioSistema
        {
            get { return _usuarioOT; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Valida o Usuario
        /// </summary>
        /// <param name="pUsuarioOT">Objeto Transferência Usuario</param>
        /// <returns>Retorna o Objeto Transferência do Usuário Carregado</returns>
        public ResultadoOperacao CarregarUsuario()
        {
            base.ResultadoOperacao  = this._usuarioN.Consultar(this._usuarioOT);

            if (base.ResultadoOperacao .Resultado == Enumeradores.Resultados.Sucesso)
            {
                List<UsuarioOT> _usuariosList = (List<UsuarioOT>)base.ResultadoOperacao .ListaObjetos;

                if (_usuariosList.Count > 0)
                {
                    UsuarioOT usuarioCarregado = _usuariosList[0];

                    if (usuarioCarregado.Status == Enumeradores.Status.Ativo)
                    {
                        _usuariosList[0].AcessoPermitido = this.VerificaSenha(this._usuarioOT.Senha, usuarioCarregado.Senha);
                    }

                    this._usuarioOT = usuarioCarregado;
                }
            }


            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;

        }

        /// <summary>
        /// Verifica se as duas senhas são iguais
        /// </summary>
        /// <param name="pSenhaFornecida">Senha que não está criptografada</param>
        /// <param name="pHashSenha">Senha já criptografada</param>
        /// <returns>True para igualdade</returns>
        private bool VerificaSenha(string pSenhaFornecida, string pHashSenha)
        {
            bool _resultado = false;

            string _senhaFonecida = Criptografia.GeraHashSenha(pSenhaFornecida);

            _resultado = _senhaFonecida.Equals(pHashSenha);

            return _resultado;
        }

        /// <summary>
        ///  Bloquear um Usuário
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao Bloquear()
        {
            this._usuarioOT.Status = Enumeradores.Status.Inativo;
            //
            base.ResultadoOperacao  = this._usuarioN.Bloquear(this._usuarioOT);

            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        ///  Desbloquear um Usuário
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao Desbloquear()
        {
            this._usuarioOT.Status = Enumeradores.Status.Ativo;
            //
            base.ResultadoOperacao  = this._usuarioN.Bloquear(this._usuarioOT);

            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        /// Consulta um usuário pelo nome e pela matricula
        /// </summary>
        /// <param name="pNome">Nome do Usuário</param>
        /// <param name="pMatricula">Matricula do Usuário</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeMatricula(string pNome, string pMatricula)
        {
            this._usuarioOT = new UsuarioOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._usuarioOT.Nome = pNome;
            }

            if (!string.IsNullOrEmpty(pMatricula))
            {
                this._usuarioOT.Matricula = pMatricula;
            }

            base.ResultadoOperacao  = this._usuarioN.Consultar(this._usuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        /// Consulta um usuáriopela matricula
        /// </summary>
        /// <param name="pMatricula">Matricula do Usuário</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultaMatricula(string pMatricula)
        {
            return this.ConsultarNomeMatricula(string.Empty, pMatricula);
        }

        /// <summary>
        /// Consulta um Usuario pelo  código e Status
        /// </summary>
        /// <param name="pCodigo">Código do Usuario</param>
        /// <param name="pStatus">Status do Usuario</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarCodigoStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um grupo pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome da Usuario</param>
        /// <param name="pStatus">Status do Usuario</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeCodigoStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Usuario pelo nome, pelo código e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Usuario</param>
        /// <param name="pMatricula">Código do Usuario</param>
        /// <param name="pStatus">Status do Usuario</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeCodigoStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._usuarioOT = new UsuarioOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._usuarioOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._usuarioOT.Codigo = pCodigo;
            }

            this._usuarioOT.Status = pStatus;

            base.ResultadoOperacao = this._usuarioN.Consultar(this._usuarioOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }

        /// <summary>
        /// Consulta o Usuario pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Usuario</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._usuarioOT = new UsuarioOT();

            this._usuarioOT.Status = pStatus;

            base.ResultadoOperacao = this._usuarioN.Consultar(this._usuarioOT);
            base.ResultadoOperacao.TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao;
        }


        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._usuarioOT = this._usuarioOT ?? new UsuarioOT();

            this._usuarioOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._usuarioN.Consultar(this._usuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            return this.ConsultarNomeMatricula(pNome, string.Empty);
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._usuarioOT = new UsuarioOT();

            base.ResultadoOperacao  = this._usuarioN.Consultar(this._usuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._usuarioN.Excluir(this._usuarioOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._usuarioOT.Codigo == 0)
            {
                this._usuarioOT.Senha = ConstantesSitema.SENHA_INICIAL_USUARIOS;

                base.ResultadoOperacao  = this._usuarioN.Inserir(this._usuarioOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._usuarioN.Alterar(this._usuarioOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
