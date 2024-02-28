using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidMobile
{
    public class MobileDriver
    {
        public AndroidDriver<AndroidElement> driver;
        public AppiumOptions capabilities = new AppiumOptions();

        public void CriarDriverAndroidMobile()
        {
            try
            {
                capabilities.AddAdditionalCapability("appium:platformName", "Android");
                capabilities.AddAdditionalCapability("appium:platformVersion", "7.0");
                capabilities.AddAdditionalCapability("appium:deviceName", "LGM2504SUKK7S4QC7H");
                capabilities.AddAdditionalCapability("appium:automationName", "uiautomator2");
                capabilities.AddAdditionalCapability("appium:appPackage", "com.google.android.calculator");
                capabilities.AddAdditionalCapability("appium:appActivity", "com.android.calculator2.Calculator");

                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/"), capabilities);
                Console.WriteLine("Driver inicializado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo CriarDriverAndroidMobile: " + e.Message);
            }
        }

        public void FecharDriverWeb()
        {
            driver.Quit();
            Console.WriteLine("Driver finalizado com sucesso!");
        }
    }
}