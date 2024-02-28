using System;
using OpenQA.Selenium.Appium.Android;

namespace automacao_calculadoraandroid_csharp_mobile.CalculadoraAndroidEmulador
{
    public class MobileBasePage : MobileDriver
    {
        public AndroidDriver<AndroidElement> _driver;
        public CalcMobileVariables calcMobileVariables;
        public MobileUtils mobileUtils;
        public GeradorPDF geradorPDF;

        public MobileBasePage(AndroidDriver<AndroidElement> driver, string cenario)
        {
            _driver = driver;
            calcMobileVariables = new CalcMobileVariables(_driver);
            mobileUtils = new MobileUtils(_driver);

            string nomeDaEvidencia = "Evidencias Calculadora Android_" + cenario + "_" + mobileUtils.GerarDataHoraFormatada();
            geradorPDF = new GeradorPDF(_driver, nomeDaEvidencia, cenario);
        }

        public void finishPdf()
        {
            try
            {
                geradorPDF.finishPdf();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo FinishPdf: " + e.Message);
            }
        }

        public void Soma()
        {
            try
            {
                Thread.Sleep(3);
                geradorPDF.evidenciaElemento("Digitar números");
                mobileUtils.Clicar(calcMobileVariables.BtnUm);
                mobileUtils.Clicar(calcMobileVariables.BtnCinco);
                mobileUtils.Clicar(calcMobileVariables.BtnNove);

                mobileUtils.Clicar(calcMobileVariables.BtnSomar);
                geradorPDF.evidenciaElemento("Clicar em somar");

                mobileUtils.Clicar(calcMobileVariables.BtnNove);
                mobileUtils.Clicar(calcMobileVariables.BtnSeis);
                mobileUtils.Clicar(calcMobileVariables.BtnTres);
                geradorPDF.evidenciaElemento("Clicar em igual");

                mobileUtils.Clicar(calcMobileVariables.BtnIgual);

                geradorPDF.evidenciaElemento("Validar resultado");
                mobileUtils.ValidarTextoDoElemento(calcMobileVariables.TxtResultado, "1.122");

                geradorPDF.SetStatus("__PASSED");
            }
            catch (Exception e)
            {
                geradorPDF.SetStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Soma: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Subtracao()
        {
            try
            {
                Thread.Sleep(3);
                geradorPDF.evidenciaElemento("Digitar números");
                mobileUtils.Clicar(calcMobileVariables.BtnDois);
                mobileUtils.Clicar(calcMobileVariables.BtnZero);
                mobileUtils.Clicar(calcMobileVariables.BtnDois);
                mobileUtils.Clicar(calcMobileVariables.BtnUm);

                mobileUtils.Clicar(calcMobileVariables.BtnSubtrair);
                geradorPDF.evidenciaElemento("Clicar em subtrair");

                mobileUtils.Clicar(calcMobileVariables.BtnUm);
                mobileUtils.Clicar(calcMobileVariables.BtnNove);
                mobileUtils.Clicar(calcMobileVariables.BtnOito);
                mobileUtils.Clicar(calcMobileVariables.BtnOito);
                geradorPDF.evidenciaElemento("Clicar em igual");

                mobileUtils.Clicar(calcMobileVariables.BtnIgual);

                geradorPDF.evidenciaElemento("Validar resultado");
                mobileUtils.ValidarTextoDoElemento(calcMobileVariables.TxtResultado, "33");

                geradorPDF.SetStatus("__PASSED");
            }
            catch (Exception e)
            {
                geradorPDF.SetStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Subtracao: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Multiplicacao()
        {
            try
            {
                Thread.Sleep(4);
                geradorPDF.evidenciaElemento("Digitar números");
                mobileUtils.Clicar(calcMobileVariables.BtnUm);
                mobileUtils.Clicar(calcMobileVariables.BtnSeis);
                mobileUtils.Clicar(calcMobileVariables.BtnZero);

                mobileUtils.Clicar(calcMobileVariables.BtnMultiplicar);
                geradorPDF.evidenciaElemento("Clicar em multiplicar");

                mobileUtils.Clicar(calcMobileVariables.BtnCinco);
                mobileUtils.Clicar(calcMobileVariables.BtnSeis);
                mobileUtils.Clicar(calcMobileVariables.BtnZero);
                geradorPDF.evidenciaElemento("Clicar em igual");

                mobileUtils.Clicar(calcMobileVariables.BtnIgual);

                geradorPDF.evidenciaElemento("Validar resultado");
                mobileUtils.ValidarTextoDoElemento(calcMobileVariables.TxtResultado, "89.600");

                geradorPDF.SetStatus("__PASSED");
            }
            catch (Exception e)
            {
                geradorPDF.SetStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Multiplicacao: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Divisao()
        {
            try
            {
                Thread.Sleep(3);
                geradorPDF.evidenciaElemento("Digitar números");
                mobileUtils.Clicar(calcMobileVariables.BtnSete);
                mobileUtils.Clicar(calcMobileVariables.BtnDois);

                mobileUtils.Clicar(calcMobileVariables.BtnDividir);
                geradorPDF.evidenciaElemento("Clicar em dividir");

                mobileUtils.Clicar(calcMobileVariables.BtnDois);
                geradorPDF.evidenciaElemento("Clicar em igual");

                mobileUtils.Clicar(calcMobileVariables.BtnIgual);

                geradorPDF.evidenciaElemento("Validar resultado");
                mobileUtils.ValidarTextoDoElemento(calcMobileVariables.TxtResultado, "36");

                geradorPDF.SetStatus("__PASSED");
            }
            catch (Exception e)
            {
                geradorPDF.SetStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Divisao: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }
    }
}