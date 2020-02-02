using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Utilitarios
{
    public static class Util
    {
        /// <summary>
        /// Converte um Array de bytes em uma imagem.
        /// </summary>
        /// <param name="pArrayBytes">Array de bytes</param>
        /// <returns>Retorna um Image</returns>
        public static Image ConverterByteArrayImagem(byte[] pArrayBytes)
        {
            try
            {
                if (pArrayBytes != null && pArrayBytes.Length > 0)
                {
                    MemoryStream imagemStream = new MemoryStream(pArrayBytes);

                    return Image.FromStream(imagemStream);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Converte uma imagem para um Array de bytes.
        /// </summary>
        /// <param name="pImage">Imagem</param>
        /// <param name="pFormatoImagem">Formato da Imagem</param>
        /// <returns>Retorna um Array de bytes</returns>
        public static byte[] ConvertImageByteArray(Image pImagem, ImageFormat pFormatoImagem)
        {
            byte[] byteArray;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    pImagem.Save(memoryStream, pFormatoImagem);
                    byteArray = memoryStream.ToArray();
                }
            }
            catch (Exception) { throw; }

            return byteArray;
        }

        /// <summary>
        /// Calcula a idade.
        /// </summary>
        /// <param name="pDataNascimento">Data de Nascimento</param>
        /// <returns>Retorna a idade calculada.</returns>
        public static int CalcularIdade(DateTime pDataNascimento)
        {
            int idade = 0;

            if (pDataNascimento != null && !pDataNascimento.Equals(DateTime.MinValue))
            {
                idade = DateTime.Today.Year - pDataNascimento.Year;
            }

            return idade;
        }

    }
}
