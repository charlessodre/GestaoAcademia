using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using System.Drawing;

namespace ObjetoOT
{
    public class AlunoOT : BaseOT
    {
        #region Atributos

        
        private CidadeOT _cidade;
        private EstadoOT _estado;
        private PaisOT _pais;
        private string _endereco;
        private string _bairro;
        private string _telefoneResidencial;
        private string _telefoneCelular;
        private string _telefoneComercial;
        private string _email;
        private double _cpf;
        private string _rg;
        private EstadoOT _estadoRG;
        private DateTime _dataNascimento;
        private double _cep;
        private Enumeradores.Sexo _sexo;
        private string _nomePai;
        private string _nomeMae;
        private string _nomeResponsavel;
        private string _telefoneResponsavel;
        private Enumeradores.EstadoCivil _estadoCivil;
        private string _Observacao;
        private string _senha;
        private DateTime _dataExpiracaoSenha;
        private DateTime _dataAlteracaoSenha;
        private bool _acessoPermitido = false;
        private int _idade;
        private Decimal _debito;
        private byte[] _foto;
        private string _objetivo;
        private ProfissaoOT _profissao;
        private EmpresaOT _empresa;


        #endregion

        #region Propriedades

        /// <summary>
        /// Lê e escreve a empresa do aluno.
        /// </summary>
        public EmpresaOT Empresa
        {
            get { return _empresa = _empresa ?? new EmpresaOT(); }
            set { _empresa = value; }
        }

        /// <summary>
        /// Lê e escreve a profissão do aluno.
        /// </summary>
        public ProfissaoOT Profissao
        {
            get { return _profissao = _profissao ?? new ProfissaoOT(); }
            set { _profissao = value; }
        }

        /// <summary>
        /// Lê e escreve o objetivo do aluno.
        /// </summary>
        public string Objetivo
        {
            get { return _objetivo; }
            set { _objetivo = value; }
        }

        /// <summary>
        ///  Lê e escreve a foto do aluno.
        /// </summary>
        public byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        /// <summary>
        ///  Lê e escreve o debito.
        /// </summary>
        public Decimal Debito
        {
            get { return _debito; }
            set { _debito = value; }
        }

        /// <summary>
        /// Lê e escreve a idade do aluno.
        /// </summary>
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }

        /// <summary>
        /// Lê o Acesso do aluno.
        /// </summary>
        public bool AcessoPermitido
        {
            get { return _acessoPermitido; }
            set { _acessoPermitido = value; }
        }

        /// <summary>
        ///  Lê e Escreve o estado do RG.
        /// </summary>
        public EstadoOT EstadoRG
        {
            get { return _estadoRG = _estadoRG ?? new EstadoOT(); }
            set { _estadoRG = value; }
        }

        /// <summary>
        /// Lê e Escreve o país. 
        /// </summary>
        public PaisOT Pais
        {
            get { return _pais = _pais ?? new PaisOT(); }
            set { _pais = value; }
        }

        /// <summary>
        /// Lê e Escreve o estado. 
        /// </summary>
        public EstadoOT Estado
        {
            get { return _estado = _estado ?? new EstadoOT(); }
            set { _estado = value; }
        }

        /// <summary>
        /// Lê e Escreve a cidade.
        /// </summary>
        public CidadeOT Cidade
        {
            get { return _cidade = _cidade ?? new CidadeOT(); }
            set { _cidade = value; }
        }

        /// <summary>
        ///  Lê e Escreve o estado civil do aluno.
        /// </summary>
        public Enumeradores.EstadoCivil EstadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }

       
        /// <summary>
        ///  Lê e Escreve a data da alteração da senha.
        /// </summary>
        public DateTime DataAlteracaoSenha
        {
            get { return _dataAlteracaoSenha; }
            set { _dataAlteracaoSenha = value; }
        }

        /// <summary>
        ///  Lê e Escreve a data a observação.
        /// </summary>
        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        /// <summary>
        ///  Lê e Escreve o telefone do responsável.
        /// </summary>
        public string TelefoneResponsavel
        {
            get { return _telefoneResponsavel; }
            set { _telefoneResponsavel = value; }
        }

        /// <summary>
        ///  Lê e Escreve o nome do responsável.
        /// </summary>
        public string NomeResponsavel
        {
            get { return _nomeResponsavel; }
            set { _nomeResponsavel = value; }
        }

        /// <summary>
        ///  Lê e Escreve o nome da mãe..
        /// </summary>
        public string NomeMae
        {
            get { return _nomeMae; }
            set { _nomeMae = value; }
        }

        /// <summary>
        ///  Lê e Escreve o nome do pai.
        /// </summary>
        public string NomePai
        {
            get { return _nomePai; }
            set { _nomePai = value; }
        }

        /// <summary>
        ///  Lê e Escreve o sexo.
        /// </summary>
        public Enumeradores.Sexo Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        /// <summary>
        ///  Lê e Escreve o CEP.
        /// </summary>
        public double CEP
        {
            get { return _cep; }
            set { _cep = value; }
        }

        /// <summary>
        ///  Lê e Escreve a data de nascimento.
        /// </summary>
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        /// <summary>
        ///  Lê e Escreve o RG.
        /// </summary>
        public string RG
        {
            get { return _rg; }
            set { _rg = value; }
        }

        /// <summary>
        ///  Lê e Escreve o CPF.
        /// </summary>
        public double CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        /// <summary>
        ///  Lê e Escreve o e-mail.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        ///  Lê e Escreve o telefone comercial.
        /// </summary>
        public string TelefoneComercial
        {
            get { return _telefoneComercial; }
            set { _telefoneComercial = value; }
        }

        /// <summary>
        ///  Lê e Escreve o telefone Celular.
        /// </summary>
        public string TelefoneCelular
        {
            get { return _telefoneCelular; }
            set { _telefoneCelular = value; }
        }

        /// <summary>
        ///  Lê e Escreve o telefone residencial.
        /// </summary>
        public string TelefoneResidencial
        {
            get { return _telefoneResidencial; }
            set { _telefoneResidencial = value; }
        }

        /// <summary>
        ///  Lê e Escreve o bairro
        /// </summary>
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        /// <summary>
        ///  Lê e Escreve o endereço.
        /// </summary>
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
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
        /// Lê e Escreve a senha do usuário.
        /// </summary>
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }


        #endregion

        #region Métodos



        #endregion
    }
}
