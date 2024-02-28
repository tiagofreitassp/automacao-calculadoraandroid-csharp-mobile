using System;
using OpenQA.Selenium.Appium.Android;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidEmulador
{
    public class CalcMobileVariables
    {
        public AndroidDriver<AndroidElement> _driver;

        public CalcMobileVariables(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public AndroidElement BtnUm => _driver.FindElementById("com.android.calculator2:id/digit_1");
        public AndroidElement BtnDois => _driver.FindElementById("com.android.calculator2:id/digit_2");
        public AndroidElement BtnTres => _driver.FindElementById("com.android.calculator2:id/digit_3");
        public AndroidElement BtnQuatro => _driver.FindElementById("com.android.calculator2:id/digit_4");
        public AndroidElement BtnCinco => _driver.FindElementById("com.android.calculator2:id/digit_5");
        public AndroidElement BtnSeis => _driver.FindElementById("com.android.calculator2:id/digit_6");
        public AndroidElement BtnSete => _driver.FindElementById("com.android.calculator2:id/digit_7");
        public AndroidElement BtnOito => _driver.FindElementById("com.android.calculator2:id/digit_8");
        public AndroidElement BtnNove => _driver.FindElementById("com.android.calculator2:id/digit_9");
        public AndroidElement BtnZero => _driver.FindElementById("com.android.calculator2:id/digit_0");

        public AndroidElement BtnVirgula => _driver.FindElementById("com.android.calculator2:id/dec_point");
        public AndroidElement BtnIgual => _driver.FindElementById("com.android.calculator2:id/eq");

        public AndroidElement BtnLimpar => _driver.FindElementById("com.android.calculator2:id/del");
        public AndroidElement BtnExcluir => _driver.FindElementById("com.android.calculator2:id/del");
        public AndroidElement BtnDividir => _driver.FindElementById("com.android.calculator2:id/op_div");
        public AndroidElement BtnMultiplicar => _driver.FindElementById("com.android.calculator2:id/op_mul");
        public AndroidElement BtnSubtrair => _driver.FindElementById("com.android.calculator2:id/op_sub");
        public AndroidElement BtnSomar => _driver.FindElementById("com.android.calculator2:id/op_add");

        public AndroidElement TxtResultado => _driver.FindElementById("com.android.calculator2:id/result");
    }
}