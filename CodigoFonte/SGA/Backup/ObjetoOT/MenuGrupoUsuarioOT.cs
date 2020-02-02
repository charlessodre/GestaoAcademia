using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetoOT;

namespace ObjetoOT
{
    public class MenuGrupoUsuarioOT : BaseOT
    {
        #region Atributos

        
        private MenuOT menuOT;
        private int codigoGrupoUsuario;

        #endregion

        #region Propriedades

      

        /// <summary>
        /// Lê e Escreve o Menu
        /// </summary>
        public MenuOT Menu
        {
            get
            {
                this.menuOT = this.menuOT ?? new MenuOT();
                return this.menuOT;
            }


            set { this.menuOT = value; }
        }

        /// <summary>
        /// Lê e Escreve o código do Usuário
        /// </summary>
        public int CodigoGrupoUsuario
        {
            get { return codigoGrupoUsuario; }
            set { codigoGrupoUsuario = value; }
        }
        #endregion

        #region Métodos


        #endregion
    }
}
