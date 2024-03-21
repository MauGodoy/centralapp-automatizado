using OpenQA.Selenium.Appium.Android;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.IncluirPonto
{
    [TestClass]
    public class IncluirPonto
    {
        private Utilitarios? m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void IncluirPontoComComprovante()
        {
            m_Utilitarios = new Utilitarios();

            var androidDriver = m_Utilitarios.EfetuarProcessoLogin();

            Thread.Sleep(3000);
            var botaoCadastrarEmailAgoraNao = m_Utilitarios.BuscarElementoPorIdSecullum("aviso-cadastrar-email-botao-agora-nao");

            //Não cadastramos o email nesse teste
            if (botaoCadastrarEmailAgoraNao != null)
            {
                botaoCadastrarEmailAgoraNao.Click();
            }

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("botao-hamburguer").Click();

            Thread.Sleep(1000);
            m_Utilitarios.BuscarAccessibilityId("menu-incluir-ponto").Click();

            Thread.Sleep(4000);
            m_Utilitarios.BuscarAccessibilityId("localizacao-incluir-ponto").Click();

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("modal-inclusao-ponto-suspeita-botao-concluir").Click();

            Thread.Sleep(2000);
            var msgInclusaoEfetuadaComSucesso = m_Utilitarios.ObterMensagemErro("localizacao-sucesso");

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("localizacao-sucesso").Click();

            Thread.Sleep(4000);
            m_Utilitarios.BuscarAccessibilityId("botao-hamburguer").Click();

            Thread.Sleep(2000);
            m_Utilitarios.RolarTela("Sair");

            Assert.AreEqual("Inclusão de ponto efetuada com êxito.\r\n\r\nDentro de alguns instantes estará disponível em seu Cartão Ponto.", msgInclusaoEfetuadaComSucesso);

        }

        [TestCleanup]
        public void LimparTeste()
        {
            // Fechar o driver após o teste
            if (m_AndroidDriver != null)
            {
                m_AndroidDriver.Quit();
            }
        }
    }
}