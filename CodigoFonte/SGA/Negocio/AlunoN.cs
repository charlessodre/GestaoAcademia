using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaDAO.DML;
using ObjetoOT;
using Utilitarios;
using Comum;
using PersistenciaDAO;

namespace Negocio
{
    /// <summary>
    ///  Classe de negócio do Aluno
    /// </summary>
    public class AlunoN : BaseN, IAcaoN<AlunoOT>
    {

        #region Construtores

        public AlunoN() { }

        #endregion

        #region Atributos

        private AlunoDAO _alunoDAO = new AlunoDAO();
        private AlunoOT _AlunoOT = new AlunoOT();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Valida o Aluno
        /// </summary>
        /// <param name="pAlunoOT">Objeto Transferência Aluno</param>
        /// <returns>Retorna o Objeto Transferência do Aluno Carregado</returns>
        public AlunoOT CarregarAluno(AlunoOT pAlunoOT)
        {
            AlunoOT _AlunoOT = (AlunoOT)this.Consultar(pAlunoOT).ListaObjetos[0];

            if (_AlunoOT != null && _AlunoOT.Status == Enumeradores.Status.Ativo)
            {
                _AlunoOT.AcessoPermitido = this.VerificaSenha(pAlunoOT.Senha, _AlunoOT.Senha);
            }

            return _AlunoOT;
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
        /// <param name="pAlunoOT">Objeto Transferência Aluno</param>
        public ResultadoOperacao Bloquear(AlunoOT pAlunoOT)
        {
            return base.TratarRetornoOperacao(this._alunoDAO.Update(pAlunoOT));
        }


        #endregion

        #region IAcaoN<AlunoOT> Members

        public ResultadoOperacao Consultar(AlunoOT pObjetoOT)
        {
          return base.TratarRetornoOperacao(this._alunoDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(AlunoOT pObjetoOT)
        {
            if (pObjetoOT.Senha != null)
            {
                pObjetoOT.Senha = Criptografia.GeraHashSenha(pObjetoOT.Senha);
            }

            return base.TratarRetornoOperacao(this._alunoDAO.Insert(pObjetoOT)); ;
        }

        public ResultadoOperacao Alterar(AlunoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._alunoDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(AlunoOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._alunoDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
