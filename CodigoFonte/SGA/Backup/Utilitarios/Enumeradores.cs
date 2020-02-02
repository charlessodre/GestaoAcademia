using System;

namespace Utilitarios
{
    public static class Enumeradores
    {
        #region Tipo de Operação

        /// <summary>
        /// Tipo de Operaçõão 
        /// </summary>
        public enum TipoOperacao : short
        {
            Alteracao = 1,
            Cadastro = 2,
            Exclusao = 3,
            AlteracaoSenha = 4,
            Consulta = 5,
            Nenhuma = 6
        }


        /// <summary>
        /// Converter a string para o Enum do tipo correspondente.
        /// </summary>
        /// <param name="pString">String do Tipo</param>
        public static TipoOperacao ConverterStringTipoOperacao(string pString)
        {
            TipoOperacao tipoOperacao = TipoOperacao.Nenhuma;
            //
            switch (pString)
            {
                case "Alteracao":
                    tipoOperacao = TipoOperacao.Alteracao;
                    break;
                case "Cadastro":
                    tipoOperacao = TipoOperacao.Cadastro;
                    break;
                case "Exclusao":
                    tipoOperacao = TipoOperacao.Exclusao;
                    break;
                case "AlteracaoSenha":
                    tipoOperacao = TipoOperacao.AlteracaoSenha;
                    break;
            }
            //
            return tipoOperacao;
        }


        #endregion

        #region Status

        /// <summary>
        /// Status
        /// </summary>
        public enum Status : short
        {
            Todos = 0,
            Ativo = 1,
            Inativo = 2

        }

        /// <summary>
        /// Converter um object para o Enum do Status correspondente.
        /// </summary>
        /// <param name="pObject">Object do Status</param>
        public static Status ConverterObjectStatus(object pObject)
        {
            try
            {
                short status = Convert.ToInt16(pObject);
                return Enumeradores.ConverterShortStatus(status);
            }
            catch (InvalidCastException ex)
            {
                throw new Exception("Erro ao Converter o Status. Erro: " + ex.Message);
            }


        }

        /// <summary>
        /// Converter o numero(shot) para o Enum do Status correspondente.
        /// </summary>
        /// <param name="pShort">pShort do Status</param>
        public static Status ConverterShortStatus(short pShort)
        {
            Status status = Status.Todos;
            //
            switch (pShort)
            {
                case 1:
                    status = Status.Ativo;
                    break;
                case 2:
                    status = Status.Inativo;
                    break;
            }
            //
            return status;
        }

        /// <summary>
        /// Converter o Enum do Status para short.
        /// </summary>
        /// <param name="pString">String do Status</param>
        public static short ConverterStatusShort(Status pStatus)
        {
            short status = 0;
            //
            switch (pStatus)
            {
                case Status.Ativo:
                    status = 1;
                    break;
                case Status.Inativo:
                    status = 2;
                    break;

            }
            //
            return status;
        }

        /// <summary>
        /// Converter a string para o Enum do Status correspondente.
        /// </summary>
        /// <param name="pString">String do Status</param>
        public static Status ConverterStringStatus(string pString)
        {
            Status status = Status.Todos;
            //
            switch (pString)
            {
                case "Ativo":
                    status = Status.Ativo;
                    break;
                case "Inativo":
                    status = Status.Inativo;
                    break;

            }
            //
            return status;
        }

        #endregion

        #region Resultados

        /// <summary>
        /// Enum que define o resultado da operação.
        /// </summary>
        public enum Resultados
        {
            Sucesso,
            Duplicado,
            FKConstraint,
            Erro,
            SemConexao
        }

        #endregion

        #region Sexo

        /// <summary>
        /// Sexo
        /// </summary>
        public enum Sexo : short
        {
            Todos = 0,
            Masculino = 1,
            Feminino = 2

        }

        /// <summary>
        /// Converter um object para o Enum do Sexo correspondente.
        /// </summary>
        /// <param name="pObject">Object do Sexo</param>
        public static Sexo ConverterObjectSexo(object pObject)
        {
            try
            {
                short sexo = Convert.ToInt16(pObject);
                return Enumeradores.ConverterShortSexo(sexo);
            }
            catch (InvalidCastException ex)
            {
                throw new Exception("Erro ao Converter o Sexo. Erro: " + ex.Message);
            }


        }

        /// <summary>
        /// Converter o numero(shot) para o Enum do Sexo correspondente.
        /// </summary>
        /// <param name="pShort">pShort do Sexo</param>
        public static Sexo ConverterShortSexo(short pShort)
        {
            Sexo sexo = Sexo.Todos;
            //
            switch (pShort)
            {
                case 1:
                    sexo = Sexo.Masculino;
                    break;
                case 2:
                    sexo = Sexo.Feminino;
                    break;
            }
            //
            return sexo;
        }

        /// <summary>
        /// Converter o Enum do Sexo para short.
        /// </summary>
        /// <param name="pString">String do Sexo</param>
        public static short ConverterSexoShort(Sexo pSexo)
        {
            short sexo = 0;
            //
            switch (pSexo)
            {
                case Sexo.Masculino:
                    sexo = 1;
                    break;
                case Sexo.Feminino:
                    sexo = 2;
                    break;

            }
            //
            return sexo;
        }

        /// <summary>
        /// Converter a string para o Enum do Sexo correspondente.
        /// </summary>
        /// <param name="pString">String do Sexo</param>
        public static Sexo ConverterStringSexo(string pString)
        {
            Sexo sexo = Sexo.Todos;
            //
            switch (pString)
            {
                case "Masculino":
                    sexo = Sexo.Masculino;
                    break;
                case "Feminino":
                    sexo = Sexo.Feminino;
                    break;

            }
            //
            return sexo;
        }

        #endregion

        #region EstadoCivil

        /// <summary>
        /// EstadoCivil
        /// </summary>
        public enum EstadoCivil : short
        {
            Todos = 0,
            Solteiro = 1,
            Casado = 2,
            Separado = 3,
            Divorciado = 4,
            Viuvo = 5

        }

        /// <summary>
        /// Converter um object para o Enum do EstadoCivil correspondente.
        /// </summary>
        /// <param name="pObject">Object do EstadoCivil</param>
        public static EstadoCivil ConverterObjectEstadoCivil(object pObject)
        {
            try
            {
                short estadoCivil = Convert.ToInt16(pObject);
                return Enumeradores.ConverterShortEstadoCivil(estadoCivil);
            }
            catch (InvalidCastException ex)
            {
                throw new Exception("Erro ao Converter o EstadoCivil. Erro: " + ex.Message);
            }


        }

        /// <summary>
        /// Converter o numero(shot) para o Enum do EstadoCivil correspondente.
        /// </summary>
        /// <param name="pShort">pShort do EstadoCivil</param>
        public static EstadoCivil ConverterShortEstadoCivil(short pShort)
        {
            EstadoCivil estadoCivil = EstadoCivil.Todos;
            //
            switch (pShort)
            {
                case 1:
                    estadoCivil = EstadoCivil.Solteiro;
                    break;
                case 2:
                    estadoCivil = EstadoCivil.Casado;
                    break;
                case 3:
                    estadoCivil = EstadoCivil.Separado;
                    break;
                case 4:
                    estadoCivil = EstadoCivil.Divorciado;
                    break;
                case 5:
                    estadoCivil = EstadoCivil.Viuvo;
                    break;
            }
            //
            return estadoCivil;
        }

        /// <summary>
        /// Converter o Enum do EstadoCivil para short.
        /// </summary>
        /// <param name="pString">String do EstadoCivil</param>
        public static short ConverterEstadoShort(EstadoCivil pEstadoCivil)
        {
            short estadoCivil = 0;
            //
            switch (pEstadoCivil)
            {
                case EstadoCivil.Solteiro:
                    estadoCivil = 1;
                    break;
                case EstadoCivil.Casado:
                    estadoCivil = 2;
                    break;
                case EstadoCivil.Separado:
                    estadoCivil = 3;
                    break;
                case EstadoCivil.Divorciado:
                    estadoCivil = 4;
                    break;
                case EstadoCivil.Viuvo:
                    estadoCivil = 5;
                    break;

            }
            //
            return estadoCivil;
        }

        /// <summary>
        /// Converter a string para o Enum do EstadoCivil correspondente.
        /// </summary>
        /// <param name="pString">String do EstadoCivil</param>
        public static EstadoCivil ConverterStringEstadoCivil(string pString)
        {
            EstadoCivil estadoCivil = EstadoCivil.Todos;
            //
            switch (pString)
            {
                case "Solteiro":
                    estadoCivil = EstadoCivil.Solteiro;
                    break;
                case "Casado":
                    estadoCivil = EstadoCivil.Casado;
                    break;
                case "Separado":
                    estadoCivil = EstadoCivil.Separado;
                    break;
                case "Divorciado":
                    estadoCivil = EstadoCivil.Divorciado;
                    break;
                case "Viuvo":
                    estadoCivil = EstadoCivil.Viuvo;
                    break;
            }
            //
            return estadoCivil;
        }

        #endregion

        #region StatusPagamento

        /// <summary>
        /// StatusPagamento
        /// </summary>
        public enum StatusPagamento : short
        {
            Todos, 
            Pago ,
            NaoPago 

        }

        #endregion

    }
}
