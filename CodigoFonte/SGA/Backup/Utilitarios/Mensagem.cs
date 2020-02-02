using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilitarios
{
    public static class Mensagem
    {
        #region Mensagens Erro

        public static string ErroExcluir
        {
            get { return "Erro ao Excluir o Registro."; }
        }

        public static string ErroConsultar
        {
            get { return "Erro ao consultar o(s) registro(s)."; }
        }

        public static string ErroAlterar
        {
            get { return "Erro ao Alterar o Registro."; }
        }

        public static string ErroInserir
        {
            get { return "Erro ao Inserir o Registro."; }
        }

        public static string ErroCarregar
        {
            get { return "Erro ao Carregar o Registro."; }
        }

        public static string ErroConstraint
        {
            get { return "Chave não encontrada. Erro de Constraint."; }
        }

        public static string ErroLogar
        {
            get { return "Erro ao efetuar login no sistema."; }
        }

        public static string ErroPagamento
        {
            get { return "Erro ao realizar o pagamento!"; }
        }
        #endregion

        #region Mensagens Aviso

        public static string ExcluidoSucesso
        {
            get { return "Registro excluido com sucesso."; }
        }

        public static string ConsultaSucesso
        {
            get { return "Consulta realizada com sucesso."; }
        }

        public static string AlteradoSucesso
        {
            get { return "Registro alterado com sucesso."; }
        }

        public static string InseridoSucesso
        {
            get { return "Registro inserido com sucesso."; }
        }

        public static string ConsultaVazia
        {
            get { return "A Consulta não retornou o registros."; }
        }

        public static string SenhaAlteradaSucesso
        {
            get { return "Senha Alterada com Sucesso!"; }
        }

        public static string UsuarioBloqueado
        {
            get { return "Usuário Bloqueado! Entre em contato com o administrador dos sistema."; }
        }

        public static string UsuarioDesbloqueado
        {
            get { return "Usuário Desbloqueado com sucesso!"; }
        }

        public static string UsuarioBloqueadoSucesso
        {
            get { return "Usuário Bloqueado com sucesso!"; }
        }

        public static string RegistroDuplicado
        {
            get { return "Já existe um registro cadastrado com esses dados."; }
        }

        public static string UsuarioInativo
        {
            get { return "Usuário desativado tentou logar."; }
        }

        public static string SemConexao
        {
            get { return "Não foi possível estabelecer conexão com o banco de dados."; }
        }

        public static string FecharFormulario
        {
            get { return "Deseja realmente fechar a tela atual?"; }
        }

        public static string SairSistema
        {
            get { return "Deseja realmente sair do sistema?"; }
        }

        public static string ExcluirImagem
        {
            get { return "Deseja realmente excluir a imagem atual?"; }
        }

        public static string ExcluirRegistro(string pMensagem)
        {
            return string.Format("Deseja realmente excluir este registro: {0}?", pMensagem);
        }

        public static string TrocarUsuario
        {
            get { return "Deseja realmente trocar de usuário?"; }
        }

        public static string PagamentoRealizadoSucesso
        {
            get { return "Pagamento realizado com sucesso!"; }
        }

        public static string ContaPagaAlterar
        {
            get { return "Esta conta já foi paga e não pode ser alterada!"; }
        }

        public static string ContaPagaExcluir
        {
            get { return "Esta conta já foi paga e não pode ser excluída!"; }
        }

        #endregion

        #region Mensagens Validação

        public static string UsuarioInvalido
        {
            get { return "Dados do usuário inválidos!"; }
        }


        public static string SenhasDiferentes
        {
            get { return "As senhas informadas não são iguais!"; }
        }

        public static string DataExpiracaoSenha
        {
            get { return "A data de expiração da senha deve ser maior o igual a data de hoje!"; }
        }

        #endregion

        #region Mensagens Cabeçalho

        public static string BoaNoite
        {
            get { return "Boa Noite!"; }
        }

        public static string BoaTarde
        {
            get { return "Boa Tarde!"; }
        }

        public static string BomDia
        {
            get { return "Bom dia!"; }
        }

        public static string BemVindo
        {
            get { return "Bem Vindo!"; }
        }

        #endregion

        #region Mensagens Obrigatoriedades

        public static string LoginObrigatorio
        {
            get { return "O campo login é de preenchimento obrigatório!"; }
        }

        public static string SenhaObrigatorio
        {
            get { return "O campo senha é de preenchimento obrigatório!"; }
        }

        public static string NomeObrigatorio
        {
            get { return "O campo nome é de preenchimento obrigatório!"; }
        }

        public static string TelefoneObrigatorio
        {
            get { return "O campo telefone é de preenchimento obrigatório!"; }
        }

        public static string EnderecoObrigatorio
        {
            get { return "O campo endereço é de preenchimento obrigatório!"; }
        }

        public static string SiglaObrigatorio
        {
            get { return "O campo sigla é de preenchimento obrigatório!"; }
        }

        public static string StatusObrigatorio
        {
            get { return "O campo status é de preenchimento obrigatório!"; }
        }

        public static string GrupoUsuarioObrigatorio
        {
            get { return "O campo grupo usuário é de preenchimento obrigatório!"; }
        }

        public static string ValorRecebidoObrigatorio
        {
            get { return "O campo valor recebido é de preenchimento obrigatório!"; }
        }

        public static string FormaPagamentoObrigatorio
        {
            get { return "Selecione um forma de pagamento!"; }
        }

        public static string CidadeObrigatorio
        {
            get { return "O campo cidade é de preenchimento obrigatório!"; }
        }

        public static string PaisObrigatorio
        {
            get { return "O campo país é de preenchimento obrigatório!"; }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Retorna a mensagem de acordo com o resultado e tipo da operação.
        /// </summary>
        /// <param name="pResultado">Enum do resultado da operação.</param>
        /// <param name="pTipoOperacao">Enum do tipo da operação.</param>
        /// <returns>Retorna a mensagem correspondente.</returns>
        public static string MensagemResultadoOperacao(Utilitarios.Enumeradores.Resultados pResultado, Utilitarios.Enumeradores.TipoOperacao pTipoOperacao)
        {
            switch (pResultado)
            {
                case Enumeradores.Resultados.Sucesso:
                    return Mensagem.MensagemSucessoOperacao(pTipoOperacao);
                case Enumeradores.Resultados.Duplicado:
                    return Mensagem.MensagemDuplicadoOperacao(pTipoOperacao);
                case Enumeradores.Resultados.FKConstraint:
                    return Mensagem.MensagemFKConstraintOperacao(pTipoOperacao);
                case Enumeradores.Resultados.Erro:
                    return Mensagem.MensagemErroOperacao(pTipoOperacao);
                case Enumeradores.Resultados.SemConexao:
                    return Mensagem.SemConexao;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Retorna a mensagem de acordo com o tipo da operação informando o sucesso da operação.
        /// </summary>
        /// <param name="pTipoOperacao">Enum do tipo da operação.</param>
        /// <returns>Retorna a mensagem correspondente.</returns>
        private static string MensagemSucessoOperacao(Utilitarios.Enumeradores.TipoOperacao pTipoOperacao)
        {
            switch (pTipoOperacao)
            {
                case Enumeradores.TipoOperacao.Alteracao:
                    return Mensagem.AlteradoSucesso;
                case Enumeradores.TipoOperacao.Cadastro:
                    return Mensagem.InseridoSucesso;
                case Enumeradores.TipoOperacao.Exclusao:
                    return Mensagem.ExcluidoSucesso;
                case Enumeradores.TipoOperacao.AlteracaoSenha:
                    return Mensagem.SenhaAlteradaSucesso;
                case Enumeradores.TipoOperacao.Consulta:
                    return Mensagem.ConsultaSucesso;
                case Enumeradores.TipoOperacao.Nenhuma:
                default:
                    return string.Empty;
            }

        }

        /// <summary>
        /// Retorna a mensagem de acordo com o tipo da operação informando que um erro ocorreu.
        /// </summary>
        /// <param name="pTipoOperacao">Enum do tipo da operação.</param>
        /// <returns>Retorna a mensagem correspondente.</returns>
        private static string MensagemErroOperacao(Utilitarios.Enumeradores.TipoOperacao pTipoOperacao)
        {
            switch (pTipoOperacao)
            {
                case Enumeradores.TipoOperacao.Alteracao:
                    return Mensagem.ErroAlterar;
                case Enumeradores.TipoOperacao.Cadastro:
                    return Mensagem.ErroInserir;
                case Enumeradores.TipoOperacao.Exclusao:
                    return Mensagem.ErroExcluir;
                case Enumeradores.TipoOperacao.AlteracaoSenha:
                    return Mensagem.ErroAlterar;
                case Enumeradores.TipoOperacao.Consulta:
                    return Mensagem.ErroConsultar;
                case Enumeradores.TipoOperacao.Nenhuma:
                default:
                    return string.Empty;
            }

        }

        /// <summary>
        /// Retorna a mensagem de acordo com o tipo da operação informando que o registro está duplicado.
        /// </summary>
        /// <param name="pTipoOperacao">Enum do tipo da operação.</param>
        /// <returns>Retorna a mensagem correspondente.</returns>
        private static string MensagemDuplicadoOperacao(Utilitarios.Enumeradores.TipoOperacao pTipoOperacao)
        {
            switch (pTipoOperacao)
            {
                case Enumeradores.TipoOperacao.Alteracao:
                case Enumeradores.TipoOperacao.Cadastro:
                case Enumeradores.TipoOperacao.Exclusao:
                case Enumeradores.TipoOperacao.AlteracaoSenha:
                case Enumeradores.TipoOperacao.Nenhuma:
                default:
                    return Mensagem.RegistroDuplicado;
            }

        }

        /// <summary>
        /// Retorna a mensagem de acordo com o tipo da operação informando que um erro de FKConstraint.
        /// </summary>
        /// <param name="pTipoOperacao">Enum do tipo da operação.</param>
        /// <returns>Retorna a mensagem correspondente.</returns>
        private static string MensagemFKConstraintOperacao(Utilitarios.Enumeradores.TipoOperacao pTipoOperacao)
        {
            switch (pTipoOperacao)
            {
                case Enumeradores.TipoOperacao.Alteracao:
                case Enumeradores.TipoOperacao.Cadastro:
                case Enumeradores.TipoOperacao.Exclusao:
                case Enumeradores.TipoOperacao.AlteracaoSenha:
                case Enumeradores.TipoOperacao.Nenhuma:
                default:
                    return Mensagem.ErroConstraint;
            }

        }


        #endregion

        #region Mensagens Log

        public static string UsuarioDesativadoTentouLoginLog(string pLogin)
        {
            return string.Format("Usuário: {0} está desativado, mas tentou logar.", pLogin);
        }

        public static string UsuarioBloqueadoLog(string pLogin)
        {
            return string.Format("O usuário {0} foi bloqueado.", pLogin);
        }

        public static string ErroValidarUsuarioLog(string pLogin)
        {
            return "Erro ao Validar o usuário: " + pLogin;

        }






        #endregion
    }
}
