using OpenQA.Selenium.Appium.Android;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.JustificarAusencia
{
    [TestClass]
    public class JustificarAusencia
    {
        private Utilitarios? m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void TesteJustificarAusencia()
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

            Thread.Sleep(3000);
            m_Utilitarios.BuscarAccessibilityId("menu-justificar-ausencia").Click();

            Thread.Sleep(4000);
            m_Utilitarios.BuscarAccessibilityId("botao-hamburguer").Click();

            Thread.Sleep(3000);
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
    }
}