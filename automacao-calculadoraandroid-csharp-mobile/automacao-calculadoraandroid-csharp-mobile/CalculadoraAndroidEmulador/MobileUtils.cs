using System;
using OpenQA.Selenium.Appium.Android;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidEmulador
{
    public class MobileUtils : MobileDriver
    {
        public AndroidDriver<AndroidElement> _driver;

        public MobileUtils(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public void Clicar(AndroidElement elemento)
        {
            VerificarElementoVisivel(elemento);
            elemento.Click();
        }

        public bool VerificarElementoVisivel(AndroidElement elemento)
        {
            return elemento.Displayed;
        }

        public void EsperaImplicita()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public string ObterTextoDoElemento(AndroidElement elemento)
        {
            string txt = elemento.Text;
            Console.WriteLine("Texto obtido: " + txt);
            return txt;
        }

        public void ValidarTextoDoElemento(AndroidElement elemento, string texto)
        {
            Thread.Sleep(1);
            string txtElement = ObterTextoDoElemento(elemento);
            Assert.AreEqual(txtElement, texto);
        }

        public DateTime PegarDataHoraAtual()
        {
            DateTime dataEntrada = DateTime.Now;
            Console.WriteLine("Data e Hora atual: " + dataEntrada);
            Console.WriteLine("The current date and time: {0:MM-dd-yy H-mm-ss zzz}", dataEntrada);
            return dataEntrada;
        }

        public string GerarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }
    }
}