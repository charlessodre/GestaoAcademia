using System;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Utilitarios
{
    public class Criptografia
    {

        #region Atributos

        private const string PROVIDER = "DataProtectionConfigurationProvider";

        #endregion

        #region Propriedades

        /// <summary>
        /// Enumerador para listar tipos possíveis
        /// </summary>
        private enum TipoAmbiente { Web, Windows }

        /// <summary>
        /// Propriedade que indica se a alicação é Web ou Windows.
        /// </summary>
        private static TipoAmbiente Ambiente
        {
            get
            {
                return HttpContext.Current != null ? TipoAmbiente.Web : TipoAmbiente.Windows;
            }
        }

        #endregion

        #region Métodos Publicos

        /// <summary>
        /// Gera Hash da Senha para verificar se a senha do Login é uma senha válida
        /// </summary>
        /// <param name="pSenha">Senha que terá o hash</param>
        /// <returns></returns>
        public static string GeraHashSenha(string pSenha)
        {
            if (pSenha != null)
            {
                System.Security.Cryptography.SHA1CryptoServiceProvider sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] buffer = sha.ComputeHash(Encoding.ASCII.GetBytes(pSenha));
                string senhaHash = Convert.ToBase64String(buffer);
                return senhaHash;
            }
            else
            {
                throw new InvalidCastException("Não é possíver gerar o Hash de uma senha nula.");
            }
        }

        /// <summary>
        /// Criptografa / Decriptografa a string recebida
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public static string Criptografar(String pString)
        {
            if (pString == null) return null;

            int mCodAscResult = 0;
            char[] mBytes = pString.ToCharArray();
            char[] mBytesResult = new char[pString.Length];

            for (int i = 0; i < mBytes.Length; i++)
            {
                mCodAscResult = mBytes[i] ^ 16;
                mBytesResult[i] = (char)mCodAscResult;
            }
            return new string(mBytesResult);
        }

        /// <summary>
        ///  Criptografa as seções do arquivo de configuração.
        /// </summary>
        /// <param name="pAppSettings">Criptografar a seção AppSettings</param>
        /// <param name="pConnectionStrings">Criptografar a seção ConnectionStrings</param>
        public static void Criptografar(bool pAppSettings, bool pConnectionStrings)
        {
            if (pAppSettings && pConnectionStrings)
            {
                Criptografia.CriptografarAppSettings();
                Criptografia.CriptografarConnectionStrings();
            }
            else if (pAppSettings)
            {
                Criptografia.CriptografarAppSettings();
            }
            else if (pConnectionStrings)
            {
                Criptografia.CriptografarConnectionStrings();
            }
        }

        /// <summary>
        ///  Descriptografa as seções do arquivo de configuração.
        /// </summary>
        /// <param name="pAppSettings">Criptografar a seção AppSettings</param>
        /// <param name="pConnectionStrings">Criptografar a seção ConnectionStrings</param>
        public static void Descriptografar(bool pAppSettings, bool pConnectionStrings)
        {
            if (pAppSettings && pConnectionStrings)
            {
                Criptografia.DescriptografarAppSettings();
                Criptografia.DescriptografarConnectionStrings();
            }
            else if (pAppSettings)
            {
                Criptografia.DescriptografarAppSettings();
            }
            else if (pConnectionStrings)
            {
                Criptografia.DescriptografarConnectionStrings();
            }
        }


        #endregion

        #region Métodos Privados


        /// <summary>
        /// Abri o arquivo de configuração
        /// </summary>
        private static Configuration AbrirArquivoConfiguracao()
        {
            switch (Criptografia.Ambiente)
            {
                case TipoAmbiente.Windows:
                    return ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                case TipoAmbiente.Web:
                    return WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                default:
                    return null;
            }

        }

        #region AppSettings

        /// <summary>
        /// Criptografa as seções AppSettings do arquivo de configuração.
        /// </summary>
        private static void CriptografarAppSettings()
        {
            Configuration configuracao = Criptografia.AbrirArquivoConfiguracao();

            //Abre um seção do arquivo
            AppSettingsSection secao = configuracao.AppSettings;

            //Verifica se a seção está protegida
            if (!secao.SectionInformation.IsProtected)
            {
                secao.SectionInformation.ProtectSection(Criptografia.PROVIDER);
                //Grava as alterações no arquivo.
                configuracao.Save(ConfigurationSaveMode.Modified);
            }
        }

        /// <summary>
        /// Descriptografa as AppSettings seções do arquivo de configuração.
        /// </summary>
        private static void DescriptografarAppSettings()
        {
            Configuration configuracao = Criptografia.AbrirArquivoConfiguracao();

            //Abre um seção do arquivo
            AppSettingsSection secao = configuracao.AppSettings;

            //Verifica se a seção está protegida
            if (secao.SectionInformation.IsProtected)
            {
                secao.SectionInformation.UnprotectSection();
                //Grava as alterações no arquivo.
                configuracao.Save(ConfigurationSaveMode.Modified);
            }
        }

        #endregion

        #region ConnectionStrings

        /// <summary>
        /// Criptografa as seções ConnectionStrings do arquivo de configuração.
        /// </summary>
        private static void CriptografarConnectionStrings()
        {
            Configuration configuracao = Criptografia.AbrirArquivoConfiguracao();

            //Abre um seção do arquivo
            ConnectionStringsSection secao = configuracao.ConnectionStrings;

            //Verifica se a seção está protegida
            if (!secao.SectionInformation.IsProtected)
            {
                secao.SectionInformation.ProtectSection(Criptografia.PROVIDER);
                //Grava as alterações no arquivo.
                configuracao.Save(ConfigurationSaveMode.Modified);
            }
        }

        /// <summary>
        /// Descriptografa as ConnectionStrings seções do arquivo de configuração.
        /// </summary>
        private static void DescriptografarConnectionStrings()
        {
            Configuration configuracao = Criptografia.AbrirArquivoConfiguracao();

            //Abre um seção do arquivo
            ConnectionStringsSection secao = configuracao.ConnectionStrings;

            //Verifica se a seção está protegida
            if (secao.SectionInformation.IsProtected)
            {
                secao.SectionInformation.UnprotectSection();
                //Grava as alterações no arquivo.
                configuracao.Save(ConfigurationSaveMode.Modified);
            }
        }

        #endregion

        #endregion

    }
}
