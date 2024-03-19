using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.InclusaoDePonto
{
    [TestClass]
    public class InclusaoDePonto
    {
        private Utilitarios m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void LogarEIncluirPonto()
        {
            m_Utilitarios = new Utilitarios();

            var androidDriver = m_Utilitarios.EfetuarProcessoLogin();

            Thread.Sleep(3000);
            var botaoCadastrarEmailAgoraNao = m_Utilitarios.BuscarElementoPorIdSecullum("aviso-cadastrar-email-botao-agora-nao", androidDriver);

            //Não cadastramos o email nesse teste
            if (botaoCadastrarEmailAgoraNao != null)
            {
                botaoCadastrarEmailAgoraNao.Click();
            }

            Thread.Sleep(3000);
            m_Utilitarios.ClicarElementoPagina("botao-hamburguer", androidDriver);

            Thread.Sleep(1000);
            m_Utilitarios.ClicarElementoPagina("menu-incluir-ponto", androidDriver);

            Thread.Sleep(4000);
            m_Utilitarios.ClicarElementoPagina("localizacao-incluir-ponto", androidDriver);

            Thread.Sleep(2000);
            m_Utilitarios.ClicarElementoPagina("modal-inclusao-ponto-suspeita-botao-concluir", androidDriver);

            Thread.Sleep(2000);
            var msgInclusaoEfetuadaComSucesso = m_Utilitarios.ObterMensagemErro("localizacao-sucesso", androidDriver);

            // Clica na mensagem de sucesso
            Thread.Sleep(2000);
            m_Utilitarios.ClicarElementoPagina("localizacao-sucesso", androidDriver);

            Thread.Sleep(4000);
            m_Utilitarios.ClicarElementoPagina("botao-hamburguer", androidDriver);

            Thread.Sleep(2000);
            RolarTela("Sair", androidDriver);

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

        private void OcultarTeclado()
        {
            m_AndroidDriver.HideKeyboard();
        }

        private void RolarTela(string elemento, AndroidDriver<AndroidElement> androidDriver)
        {
            var m_AndroidDriver = androidDriver;
            m_AndroidDriver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + elemento + "\").instance(0))").Click();
        }
    }
}