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
    ///  Classe de negócio do Usuário
    /// </summary>
    public class UsuarioN : BaseN, IAcaoN<UsuarioOT>
    {

        #region Construtores

        public UsuarioN() { }

        #endregion

        #region Atributos

        private UsuarioDAO _usuarioDAO = new UsuarioDAO();
        private UsuarioOT _usuarioOT = new UsuarioOT();

        #endregion

        #region Propriedades

        #endregion

        #region Métodos

        /// <summary>
        /// Valida o Usuario
        /// </summary>
        /// <param name="pUsuarioOT">Objeto Transferência Usuario</param>
        /// <returns>Retorna o Objeto Transferência do Usuário Carregado</returns>
        public UsuarioOT CarregarUsuario(UsuarioOT pUsuarioOT)
        {
            UsuarioOT _usuarioOT = (UsuarioOT)this.Consultar(pUsuarioOT).ListaObjetos[0];

            if (_usuarioOT != null && _usuarioOT.Status == Enumeradores.Status.Ativo)
            {
                _usuarioOT.AcessoPermitido = this.VerificaSenha(pUsuarioOT.Senha, _usuarioOT.Senha);
            }

            return _usuarioOT;
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
        /// <param name="pUsuarioOT">Objeto Transferência Usuario</param>
        public ResultadoOperacao Bloquear(UsuarioOT pUsuarioOT)
        {
            return base.TratarRetornoOperacao(this._usuarioDAO.Update(pUsuarioOT));
        }


        #endregion

        #region IAcaoN<UsuarioOT> Members

        public ResultadoOperacao Consultar(UsuarioOT pObjetoOT)
        {
          return base.TratarRetornoOperacao(this._usuarioDAO.Select(pObjetoOT));
        }

        public ResultadoOperacao Inserir(UsuarioOT pObjetoOT)
        {
            if (pObjetoOT.Senha != null)
            {
                pObjetoOT.Senha = Criptografia.GeraHashSenha(pObjetoOT.Senha);
            }

            return base.TratarRetornoOperacao(this._usuarioDAO.Insert(pObjetoOT)); ;
        }

        public ResultadoOperacao Alterar(UsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._usuarioDAO.Update(pObjetoOT));
        }

        public ResultadoOperacao Excluir(UsuarioOT pObjetoOT)
        {
            return base.TratarRetornoOperacao(this._usuarioDAO.Delete(pObjetoOT));
        }

        #endregion
    }
}
