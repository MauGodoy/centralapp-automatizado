using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.AjustarPonto
{
    [TestClass]
    public class AjustarPonto
    {
        private Utilitarios? m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void AjustarCartaoPonto()
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

            Thread.Sleep(4000);
            m_Utilitarios.BuscarAccessibilityId("menu-ajustar-ponto").Click();

            Thread.Sleep(4000);
            m_Utilitarios.BuscarAccessibilityId("botao-hamburguer").Click();

            Thread.Sleep(2000);
            m_Utilitarios.RolarTela("Sair");
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

        private AndroidElement BuscarElementoPorIdSecullum(string idElemento)
        {
            return m_AndroidDriver.FindElement(By.Id($"com.secullum.pontoweb.centraldofuncionario:id/{idElemento}"));
        }
    }
}
