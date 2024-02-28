using System;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidEmulador
{
    public class CalcAndroidEmuladorTest : MobileDriver
    {
        public required MobileBasePage mobileBasePage;

        [SetUp]
        public void Setup()
        {
            CriarDriverAndroidEmulador();
        }

        [Test]
        public void Test1_Soma()
        {
            mobileBasePage = new MobileBasePage(driver, "Realizar uma soma");
            mobileBasePage.Soma();
        }

        [Test]
        public void Test2_Subtracao()
        {
            mobileBasePage = new MobileBasePage(driver, "Realizar uma subtracao");
            mobileBasePage.Subtracao();
        }

        [Test]
        public void Test3_Multiplicacao()
        {
            mobileBasePage = new MobileBasePage(driver, "Realizar uma multiplicacao");
            mobileBasePage.Multiplicacao();
        }

        [Test]
        public void Test4_Divisao()
        {
            mobileBasePage = new MobileBasePage(driver, "Realizar uma divisao");
            mobileBasePage.Divisao();
        }

        [TearDown]
        public void TearDown()
        {
            FecharDriverWeb();
            mobileBasePage.finishPdf();
        }
    }
}

