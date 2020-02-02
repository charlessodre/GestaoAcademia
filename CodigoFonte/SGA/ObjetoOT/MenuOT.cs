using Utilitarios;
using ObjetoOT;
using System;


namespace ObjetoOT
{
    public class MenuOT : BaseOT, IEquatable<MenuOT>
    {
        #region Atributos

      
        private string urlImagem;
        private string urlPagina;
        private string caminhoMenu;
        private Enumeradores.Status visivel = Enumeradores.Status.Ativo;


        #endregion

        #region Propriedades

        /// <summary>
        /// Indica se o menu é visível.
        /// </summary>
        public Enumeradores.Status Visivel
        {
            get { return visivel; }
            set { visivel = value; }
        }
            

        /// <summary>
        /// Lê e Escreve o CaminhoMenu do menu.
        /// </summary>
        public string CaminhoMenu
        {
            get { return caminhoMenu; }
            set { caminhoMenu = value; }
        }

        /// <summary>
        /// Lê e Escreve a URL da Página.
        /// </summary>
        public string UrlPagina
        {
            get { return urlPagina; }
            set { urlPagina = value; }
        }

        /// <summary>
        /// Lê e Escreve a URL da imagem.
        /// </summary>
        public string UrlImagem
        {
            get { return urlImagem; }
            set { urlImagem = value; }
        }

   
        #endregion

        #region Métodos

        #region IEquatable<MenuOT> Members

        /// <summary>
        /// Verifica se o objetos são iguais.
        /// </summary>
        /// <param name="other">Objeto para comparação</param>
        /// <returns>Retorna TRUE se os objetos forem iguais e FALSE se forem diferentes</returns>
        public bool Equals(MenuOT other)
        {
            return (other as object) != null && (this.Codigo == other.Codigo &&
                                               this.Nome == other.Nome &&
                                               this.urlImagem == other.urlImagem &&
                                               this.urlPagina == other.urlPagina &&
                                               this.caminhoMenu == other.caminhoMenu &&
                                               this.Status == other.Status);
        }


        #endregion

        #endregion
    }
}
