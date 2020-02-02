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
    /// Classe de Controle de Aluno.
    /// </summary>
    public class AlunoCTRL : BaseCTRL
    {

        #region Construtores

        /// <summary>
        /// Construtor padrão da classe. 
        /// </summary>
        public AlunoCTRL()
        {
        }

        /// <summary>
        /// Construtor da classe. 
        /// </summary>
        /// <param name="pAlunoOT">Objeto de Transferência Aluno</param>
        public AlunoCTRL(AlunoOT pAlunoOT)
        {
            this._AlunoOT = pAlunoOT;
        }

        #endregion

        #region Atributos

        private AlunoOT _AlunoOT = new AlunoOT();
        private AlunoN _alunoN = new AlunoN();

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
            decimal debito = 1000;

            return debito;
        }


        /// <summary>
        /// Valida o Aluno
        /// </summary>
        /// <param name="pAlunoOT">Objeto Transferência Aluno</param>
        /// <returns>Retorna o Objeto Transferência do Aluno Carregado</returns>
        public ResultadoOperacao CarregarAluno()
        {
            base.ResultadoOperacao  = this._alunoN.Consultar(this._AlunoOT);

            if (base.ResultadoOperacao .Resultado == Enumeradores.Resultados.Sucesso)
            {
                List<AlunoOT> _usuariosList = (List<AlunoOT>)base.ResultadoOperacao .ListaObjetos;

                if (_usuariosList.Count > 0)
                {
                    if (!string.IsNullOrEmpty(this._AlunoOT.Senha))
                    {
                        _usuariosList[0].AcessoPermitido = this.VerificaSenha(this._AlunoOT.Senha, _usuariosList[0].Senha);
                    }

                    _usuariosList[0].Idade = Util.CalcularIdade(_usuariosList[0].DataNascimento);
                    _usuariosList[0].Debito = this.CalcularDebito();
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
        ///  Bloquear um Aluno
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao Bloquear()
        {
            this._AlunoOT.Status = Enumeradores.Status.Inativo;
            //
            base.ResultadoOperacao  = this._alunoN.Bloquear(this._AlunoOT);

            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        ///  Desbloquear um Aluno
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao Desbloquear()
        {
            this._AlunoOT.Status = Enumeradores.Status.Ativo;
            //
            base.ResultadoOperacao  = this._alunoN.Bloquear(this._AlunoOT);

            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        /// Consulta um Aluno pelo  código da  matricula
        /// </summary>
        /// <param name="pCodigo">Código do Aluno</param>
        /// <returns>Retorna o resultado da Aluno</returns>
        public ResultadoOperacao ConsultarMatricula(int pCodigo)
        {
            return this.ConsultarNomeMatricula(string.Empty, pCodigo);
        }

        /// <summary>
        /// Consulta um Aluno pelo  código da  matricula
        /// </summary>
        /// <param name="pCodigo">Código do Aluno</param>
        /// <param name="pStatus">Status do Aluno</param>
        /// <returns>Retorna o resultado da Aluno</returns>
        public ResultadoOperacao ConsultarMatriculaStatus(int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeMatriculaStatus(string.Empty, pCodigo, pStatus);
        }

        /// <summary>
        /// Consulta um Aluno pelo nome e pela matricula
        /// </summary>
        /// <param name="pNome">Nome do Aluno</param>
        /// <param name="pMatricula">Matricula do Aluno</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeMatricula(string pNome, int pCodigo)
        {
            this._AlunoOT = new AlunoOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._AlunoOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._AlunoOT.Codigo = pCodigo;
            }

            return this.ConsultarNomeMatriculaStatus(pNome, pCodigo, Utilitarios.Enumeradores.Status.Todos);
        }

        /// <summary>
        /// Consulta um Aluno pelo nome e pelo status.
        /// </summary>
        /// <param name="pNome">Nome do Aluno</param>
        /// <param name="pStatus">Status do Aluno</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeStatus(string pNome, Utilitarios.Enumeradores.Status pStatus)
        {
            return this.ConsultarNomeMatriculaStatus(pNome, 0, pStatus);
        }

        /// <summary>
        /// Consulta um Aluno pelo nome, pela matricula e pelo status
        /// </summary>
        /// <param name="pNome">Nome do Aluno</param>
        /// <param name="pMatricula">Matricula do Aluno</param>
        /// <param name="pStatus">Status do Aluno</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarNomeMatriculaStatus(string pNome, int pCodigo, Utilitarios.Enumeradores.Status pStatus)
        {
            this._AlunoOT = new AlunoOT();

            if (!string.IsNullOrEmpty(pNome))
            {
                this._AlunoOT.Nome = pNome;
            }

            if (pCodigo > 0)
            {
                this._AlunoOT.Codigo = pCodigo;
            }

            this._AlunoOT.Status = pStatus;

            base.ResultadoOperacao  = this._alunoN.Consultar(this._AlunoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        /// <summary>
        /// Consulta o usuário pelo status.
        /// </summary>
        /// <param name="pStatus">Status do Aluno</param>
        /// <returns>Retorna o resultado da operação</returns>
        public ResultadoOperacao ConsultarStatus(Utilitarios.Enumeradores.Status pStatus)
        {
            this._AlunoOT = new AlunoOT();

            this._AlunoOT.Status = pStatus;

            base.ResultadoOperacao  = this._alunoN.Consultar(this._AlunoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        #endregion

        #region Métodos Sobrescritos

        public override ResultadoOperacao ConsultarCodigo(int pCodigo)
        {
            this._AlunoOT = this._AlunoOT ?? new AlunoOT();

            this._AlunoOT.Codigo = pCodigo;

            base.ResultadoOperacao  = this._alunoN.Consultar(this._AlunoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao ConsultarNome(string pNome)
        {
            return this.ConsultarNomeMatricula(pNome, 0);
        }

        public override ResultadoOperacao ConsultarTodos()
        {
            this._AlunoOT = new AlunoOT();

            base.ResultadoOperacao  = this._alunoN.Consultar(this._AlunoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Consulta;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Excluir()
        {
            base.ResultadoOperacao  = this._alunoN.Excluir(this._AlunoOT);
            base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Exclusao;

            return base.ResultadoOperacao ;
        }

        public override ResultadoOperacao Salvar()
        {
            if (this._AlunoOT.Codigo == 0)
            {
                this._AlunoOT.Senha = ConstantesSitema.SENHA_INICIAL_USUARIOS;

                base.ResultadoOperacao  = this._alunoN.Inserir(this._AlunoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Cadastro;
            }
            else
            {
                base.ResultadoOperacao  = this._alunoN.Alterar(this._AlunoOT);
                base.ResultadoOperacao .TipoOperacao = Enumeradores.TipoOperacao.Alteracao;
            }

            return base.ResultadoOperacao ;
        }

        #endregion

    }
}
