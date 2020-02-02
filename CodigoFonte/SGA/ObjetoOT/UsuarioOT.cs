using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;

namespace ObjetoOT
{
    public class UsuarioOT : BaseOT
    {
        #region Atributos


        private string _matricula;
        private string _login;
        private string _senha;
        private bool _acessoPermitido = false;
        private GrupoUsuarioOT _grupoUsuarioOT;
        private DateTime _dataExpiracaoSenha;
        private int _numeroTentativasLogin;
        private string _email;




        #endregion

        #region Propriedades



        /// <summary>
        ///  Lê e Escreve o e-mail.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        ///  Lê e Escreve a quantidade de tentativas de login.
        /// </summary>
        public int NumeroTentativasLogin
        {
            get { return _numeroTentativasLogin; }
            set { _numeroTentativasLogin = value; }
        }


        /// <summary>
        ///  Lê e Escreve a data de expiração da senha.
        /// </summary>
        public DateTime DataExpiracaoSenha
        {
            get { return _dataExpiracaoSenha; }
            set { _dataExpiracaoSenha = value; }
        }


        /// <summary>
        /// Lê e Excreve o Grupo do usuário
        /// </summary>
        public GrupoUsuarioOT GrupoUsuarioOT
        {
            get
            {
                this._grupoUsuarioOT = this._grupoUsuarioOT ?? new GrupoUsuarioOT();
                return this._grupoUsuarioOT;
            }
            set { this._grupoUsuarioOT = value; }
        }

        /// <summary>
        /// Lê o Acesso do usuário
        /// </summary>
        public bool AcessoPermitido
        {
            get { return _acessoPermitido; }
            set { _acessoPermitido = value; }
        }

        /// <summary>
        /// Lê e Escreve a senha do usuário.
        /// </summary>
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        /// <summary>
        /// Lê e Escreve o login do usuário.
        /// </summary>
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }


        /// <summary>
        /// Lê e Escreve a matrícula do usuário.
        /// </summary>
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        #endregion

        #region Métodos



        #endregion
    }
}
