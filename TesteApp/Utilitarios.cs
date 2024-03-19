using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace TesteApp
{
    public class Utilitarios
    {
        const string PACKAGE_NAME_APP_CENTRAL = "com.secullum.pontoweb.centraldofuncionario";

        private AndroidDriver<AndroidElement> m_AndroidDriver;

        public AndroidDriver<AndroidElement> EfetuarProcessoLogin()
        {
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("appium:platformName", "Android");
            appiumOptions.AddAdditionalCapability("appium:deviceName", "emulator-5554");
            appiumOptions.AddAdditionalCapability("appium:app", "E:/Repositorios/centralapp-automatizado/Apk/central_alteracao_ID.apk");
            appiumOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability("appium:autoGrantPermissions", true); //Altera todas as permissões do app para true

            m_AndroidDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/"), appiumOptions);

            Thread.Sleep(8000);

            ClicarEPreencherElementoPorId("textbox-banco", "8575");

            ClicarEPreencherElementoPorId("textbox-numero", "1136");

            ClicarEPreencherElementoPorId("textbox-senha", "123");

            ClicarElementoPagina("botao-entrar");

            return m_AndroidDriver;
        }

        public AndroidElement BuscarElementoPorIdSecullum(string idElemento, AndroidDriver<AndroidElement> androidDriver)
        {
            var m_AndroidDriver = androidDriver;
            return m_AndroidDriver.FindElement(By.Id($"{PACKAGE_NAME_APP_CENTRAL}:id/{idElemento}"));
        }

        public void ClicarElementoPagina(string idElemento, AndroidDriver<AndroidElement> androidDriver)
        {
            BuscarElementoPorIdSecullum(idElemento, androidDriver).Click();
        }

        public void ClicarEPreencherElementoPorId(string idElemento, string descricao, AndroidDriver<AndroidElement> androidDriver)
        {
            BuscarElementoPorIdSecullum(idElemento, androidDriver).SendKeys(descricao);
        }

        private void ClicarElementoPagina(string idElemento)
        {
            BuscarElementoPorIdSecullum(idElemento).Click();
        }

        private void ClicarEPreencherElementoPorId(string idElemento, string descricao)
        {
            BuscarElementoPorIdSecullum(idElemento).SendKeys(descricao);
        }

        private AndroidElement BuscarElementoPorIdSecullum(string idElemento)
        {
            return m_AndroidDriver.FindElement(By.Id($"{PACKAGE_NAME_APP_CENTRAL}:id/{idElemento}"));
        }

        public void SelecionarIntervaloDatas(string dataInicio, string dataFim, AndroidDriver<AndroidElement> androidDriver)
        {
           BuscarElementoPorTexto(dataInicio).Click();
           Thread.Sleep(1000);
           ClicarElementoPaginaAndroid("button1");

           Thread.Sleep(2000);

           BuscarElementoPorTexto(dataFim).Click();
           Thread.Sleep(1000);
           ClicarElementoPaginaAndroid("button1");
        }

        private AndroidElement BuscarElementoPorTexto(string elemento)
        {
            return m_AndroidDriver.FindElement(By.XPath($"//*[@text='{elemento}']"));
        }

        private void ClicarElementoPaginaAndroid(string idElemento)
        {
            BuscarElementoPorIdAndroid(idElemento).Click();
        }

        private AndroidElement BuscarElementoPorIdAndroid(string idElemento)
        {
            return m_AndroidDriver.FindElement(By.Id($"android:id/{idElemento}"));
        }

        public string ObterMensagemErro(string idElemento, AndroidDriver<AndroidElement> androidDriver)
        {
            return BuscarElementoPorIdSecullum(idElemento).GetAttribute("text");
        }
    }
}
