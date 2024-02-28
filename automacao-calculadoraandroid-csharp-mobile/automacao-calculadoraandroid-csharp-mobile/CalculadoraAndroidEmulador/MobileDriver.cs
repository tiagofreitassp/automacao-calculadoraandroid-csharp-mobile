using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidEmulador
{
	public class MobileDriver
    {
        public AndroidDriver<AndroidElement> driver;
        public AppiumOptions capabilities = new AppiumOptions();

        public void CriarDriverAndroidEmulador()
        {
            try
            {
                capabilities.AddAdditionalCapability("appium:platformName", "Android");
                capabilities.AddAdditionalCapability("appium:platformVersion", "9");
                capabilities.AddAdditionalCapability("appium:deviceName", "emulator-5554");
                capabilities.AddAdditionalCapability("appium:automationName", "uiautomator2");
                capabilities.AddAdditionalCapability("appium:appPackage", "com.android.calculator2");
                capabilities.AddAdditionalCapability("appium:appActivity", "com.android.calculator2.Calculator");

                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723"), capabilities);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Console.WriteLine("Driver inicializado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo CriarDriverAndroidEmulador: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void FecharDriverWeb()
        {
            driver.Quit();
            Console.WriteLine("Driver finalizado com sucesso!");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}