using OpenQA.Selenium.Appium.Android;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.CartaoPonto
{
    [TestClass]
    public class CartaPonto
    {
        private Utilitarios? m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void TesteCartaoPonto()
        {
            m_Utilitarios = new Utilitarios();

            Thread.Sleep(2000);
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

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("menu-cartao-ponto").Click();

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("calendario-periodo-filtrado-cartao-ponto").Click();

            Thread.Sleep(3000);
            m_Utilitarios.SelecionarIntervaloDatas("1", "31");

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("botao-cartao-ponto-completo").Click();

            //var teta = m_Utilitarios.BuscarAccessibilityId("cartao-ponto-completo-tabela");

            Thread.Sleep(5000);
            m_Utilitarios.BuscarAccessibilityId("botao-hamburguer").Click();

            Thread.Sleep(2000);
            RolarTela("Sair", androidDriver);
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

        private void RolarTela(string elemento, AndroidDriver<AndroidElement> androidDriver)
        {
            var m_AndroidDriver = androidDriver;
            m_AndroidDriver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + elemento + "\").instance(0))").Click();
        }
    }
}
