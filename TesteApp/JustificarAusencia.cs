﻿using OpenQA.Selenium.Appium.Android;
using TesteApp;

namespace Secullum.Central.App.Teste.Automatizado.JustificarAusencia
{
    [TestClass]
    public class JustificarAusencia
    {
        private Utilitarios m_Utilitarios;

        public required AndroidDriver<AndroidElement> m_AndroidDriver;

        [TestMethod]
        public void TesteJustificarAusencia()
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

            Thread.Sleep(3000);
            m_Utilitarios.ClicarElementoPagina("menu-justificar-ausencia", androidDriver);

            Thread.Sleep(4000);
            m_Utilitarios.ClicarElementoPagina("botao-hamburguer", androidDriver);

            Thread.Sleep(3000);
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