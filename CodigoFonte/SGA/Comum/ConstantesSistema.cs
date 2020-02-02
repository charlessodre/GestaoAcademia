
namespace Comum
{
    /// <summary>
    /// Classe responsável por manter as constantes do sistema. 
    /// </summary>
    public static class ConstantesSitema
    {
        #region Geral

        /// <summary>
        /// Constante que define o indice inicial das combos para verificar se
        /// algum item foi selecionado.
        /// </summary>
        public const int INDICE_INICIAL_COMBO = -1;

        /// <summary>
        /// Constante que define o indice (zero) que indica que o primeiro item foi selecioando.
        ///  </summary>
        public const int PRIMEIRO_VALOR_COMBO = 0;

        /// <summary>
        /// Constante com o nome do grupo de Administradores.
        /// </summary>
        public const string GRUPO_ADMINISTRADORES = "Administradores";

        /// <summary>
        /// Constante com o nome do usuario de Administradores.
        /// </summary>
        public const string USUARIO_ADMINISTRADOR = "Administrador";

        /// <summary>
        /// Constante que define a quantidade de dia para expiração da senha.
        /// </summary>
        public const int DIAS_ESPIRACAO_SENHA = 30;


        /// <summary>
        /// Constante com a senha inicial dos novos usuarios cadastrados.
        /// </summary>
        public const string SENHA_INICIAL_USUARIOS = "123";


        /// <summary>
        /// Constante que define a formatação ds digitos da matricula.
        /// </summary>
        public const string FOMATACAO_DIGITOS_MATRICULA = "000000";

        /// <summary>
        /// Constante que define a formatação dos valores moedas.
        /// </summary>
        public const string FOMATACAO_VALOR_MOEDA = "#,##0.00";

        #endregion

        #region Web


        /// <summary>
        /// Constante com a variavel de resposta usada no query string.
        /// </summary>
        public const string VARIAVEL_RESPOSTA = "rsp";

        /// <summary>
        /// Constante com o sufixo da imagem  de menu disponível.
        /// </summary>
        public const string SUFIXO_IMAGEM_MENU_DISPONIVEL = "lock_off";
        #endregion

        #region Windows
        
        /// <summary>
        /// Constante que define o ZOOM inicial do relatório.
        /// </summary>
        public const int ZOOM_INICIAL_REL = 75;


        #endregion
    }
}
