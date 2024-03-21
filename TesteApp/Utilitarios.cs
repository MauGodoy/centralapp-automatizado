using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace TesteApp
{
    public class Utilitarios
    {
        private AndroidDriver<AndroidElement>? m_AndroidDriver;

        public AndroidDriver<AndroidElement> EfetuarProcessoLogin()
        {
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("appium:platformName", "Android");
            appiumOptions.AddAdditionalCapability("appium:deviceName", "emulator-5554");
            appiumOptions.AddAdditionalCapability("appium:app", "E:/Repositorios/centralapp-automatizado/Apk/app_central_accessibilityLabel.apk");
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

        public void OcultarTeclado()
        {
            m_AndroidDriver?.HideKeyboard();
        }
        
        public void RolarTela(string elementoId)
        {
            m_AndroidDriver?.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + elementoId + "\").instance(0))").Click();
        }
        
        public AndroidElement BuscarElementoPorIdSecullum(string idElemento)
        {
            return BuscarAccessibilityId(idElemento);
        }
        
        public AndroidElement BuscarAccessibilityId(string idElemento)
        {
            return m_AndroidDriver.FindElementByAccessibilityId(idElemento);
        }
       
        public void ClicarElementoPagina(string idElemento)
        {
            BuscarAccessibilityId(idElemento).Click();
        }
       
        private void ClicarEPreencherElementoPorId(string idElemento, string descricao)
        {
            BuscarAccessibilityId(idElemento).SendKeys(descricao);
        }
        
        private AndroidElement BuscarElementoPorTexto(string elemento)
        {
            return m_AndroidDriver.FindElement(By.XPath($"//*[@text='{elemento}']"));
        }
        
        public string ObterMensagemErro(string idElemento)
        {
            return BuscarAccessibilityId(idElemento).GetAttribute("text");
        }
        
        public void SelecionarIntervaloDatas(string dataInicio, string dataFim)
        {
            BuscarElementoPorTexto(dataInicio).Click();
            Thread.Sleep(1000);
            ClicarElementoPaginaAndroid("button1");

            Thread.Sleep(2000);

            BuscarElementoPorTexto(dataFim).Click();
            Thread.Sleep(1000);
            ClicarElementoPaginaAndroid("button1");
        }
       
        private void ClicarElementoPaginaAndroid(string idElemento)
        {
            BuscarElementoPorIdAndroid(idElemento).Click();
        }
        
        private AndroidElement BuscarElementoPorIdAndroid(string idElemento)
        {
            return m_AndroidDriver.FindElement(By.Id($"android:id/{idElemento}"));
        }
    }
}
