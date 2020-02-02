using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;
using Utilitarios;

namespace ObjetoOT
{
    public class EmpresaOT : BaseOT
    {
        #region Atributos

      
        private CidadeOT _cidade;
        private EstadoOT _estado;
        private PaisOT _pais;
        
        private string _endereco;
        private string _bairro;
        private string _fax;
        private string _telefoneComercial;
        private string _email;
        private double _cnpj;
       
        private double _cep;
        private string _nomeContato;
        private string _observacao;
        private Decimal _debito;
        private DateTime _dataCadastro;
        private byte[] _logo;
        private string _site;
        private string _razaoSocial;
        private bool _empresaSistema;

       
        #endregion

        #region Propriedades

        /// <summary>
        ///  Lê e escreve se empresa é a que possue a licença do sitema.
        /// </summary>
        public bool EmpresaSistema
        {
            get { return _empresaSistema; }
            set { _empresaSistema = value; }
        }



        /// <summary>
        ///  Lê e escreve a Razão Social
        /// </summary>
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = value; }
        }

       

        /// <summary>
        /// Lê e escreve o site
        /// </summary>
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }


        /// <summary>
        ///  Lê e escreve a logo
        /// </summary>
        public byte[] Logo
        {
            get { return _logo; }
            set { _logo = value; }
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
        ///  Lê e Escreve a data a observação.
        /// </summary>
        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }
       

        /// <summary>
        ///  Lê e Escreve o nome do Contato.
        /// </summary>
        public string NomeContato
        {
            get { return _nomeContato; }
            set { _nomeContato = value; }
        }

       
        /// <summary>
        ///  Lê e Escreve o CEP.
        /// </summary>
        public double  CEP
        {
            get { return _cep; }
            set { _cep = value; }
        }

        

        /// <summary>
        ///  Lê e Escreve o CNPJ.
        /// </summary>
        public double CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value; }
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
        ///  Lê e Escreve o telefone do fax.
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
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
        ///  Lê e Escreve a data de Cadastro da empresa.
        /// </summary>
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; }
        }

      
              

        #endregion

        #region Métodos


        #endregion
    }
}
