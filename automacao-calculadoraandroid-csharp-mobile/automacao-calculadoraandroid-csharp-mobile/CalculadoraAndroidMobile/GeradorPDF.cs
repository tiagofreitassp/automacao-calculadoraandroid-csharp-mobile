﻿using System;
using automacao_calculadoraandroid_csharp_mobile_CalculadoraAndroidMobile_CalculadoraAndroidMobile;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace automacao_calculadoraandroid_csharp_mobile_CalculadoraAndroidMobile_GeradorPDF
{
    public class GeradorPDF : MobileDriver
    {
        public AndroidDriver<AndroidElement> _driver;
        public Document document;
        public DirectoryInfo evidencias;
        public int contador;
        public string cenario;
        public string arqEvidencia;

        public static string nomeDoUsuario = Environment.UserName;
        public static string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
        public static string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";

        public GeradorPDF(AndroidDriver<AndroidElement> driver, string nomeTeste, string cenario)
        {
            _driver = driver;
            document = new Document();
            contador = 0;
            CriarPastaEvidenciaNoPDF(nomeTeste);
            gerar(nomeTeste);
            addExternalImage();
            addFormatedText("Cenário: " + cenario, FontFactory.HELVETICA, 20, Font.BOLDITALIC,
                    BaseColor.BLUE, Element.ALIGN_CENTER);
            textoInicial();
            document.NewPage();
        }

        //Dicas sobre o iText
        //https://www.codeguru.com/csharp/.net/net_general/generating-a-pdf-document-using-c-.net-and-itext-7.html

        public void gerar(string nomeTeste)
        {
            var nomeDoSO = Environment.OSVersion.Platform;
            Console.WriteLine("Sistema Operacional: " + nomeDoSO);

            string so = nomeDoSO.ToString();

            if (so == "Unix" || so == "Mac")
            {
                arqEvidencia = downloadsMac + "/" + nomeTeste + ".pdf";
            }
            else if (so == "Windows")
            {
                arqEvidencia = downloadsWindows + "/" + nomeTeste + ".pdf";
            }

            PdfWriter.GetInstance(document, new FileStream(arqEvidencia, FileMode.Create));
            document.Open();
            document.Open();
        }

        public void addExternalImage()
        {
            Image image = Image.GetInstance("/Users/" + nomeDoUsuario + "/Downloads/Csharp.png");
            image.ScaleToFit(300f, 300f);
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);
        }

        public void insertPrint()
        {
            ITakesScreenshot ts = (ITakesScreenshot)_driver;
            byte[] imagem = ts.GetScreenshot().AsByteArray;
            Console.WriteLine("Capturado o screenshot!");
            Image image = Image.GetInstance(imagem);
            image.ScaleToFit(520f, 520f);
            document.Add(image);
        }

        public void print(string passo)
        {
            if (contador == 2)
            {
                document.NewPage();
                contador = 0;
            }
            addText(passo);
            insertPrint();
            contador++;
        }

        public void addText(String text)
        {
            try
            {
                document.Add(new Paragraph(text));
            }
            catch (DocumentException ex)
            {
                Console.WriteLine("Erro lancado no metodo addText: " + ex.Message);
            }
        }

        private void addFormatedText(String text, String nameFont, float size, int style, BaseColor color, int align)
        {
            try
            {
                Font font = FontFactory.GetFont(nameFont, size, style, color);
                Paragraph paragraph = new Paragraph(text, font);
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);
            }
            catch (DocumentException ex)
            {
                Console.WriteLine("Erro lancado no metodo addFormatedText: " + ex.Message);
            }
        }

        public void addFormatedText(String text, String nameFont, float size, int style, BaseColor color)
        {
            addFormatedText(text, nameFont, size, style, color, 0);
        }

        public void addFalhaDeValidacao(String text)
        {
            addFormatedText(text, FontFactory.HELVETICA_BOLD, 15f, 1, BaseColor.RED);
        }

        public void addException(Exception ex, String passo)
        {
            try
            {
                addFormatedText("Foi lançada uma exceção durante a execução do passo: " + passo, FontFactory.COURIER_BOLD, 16f,
                        1, BaseColor.RED);
                print("---------ScreenShoot do passo---------");
                StringWriter sw = new StringWriter();
                //PrintWriter pw = new PrintWriter(sw);
                //ex.printStackTrace(pw);
                addFormatedText(sw.ToString(), FontFactory.HELVETICA, 5f, 1, BaseColor.RED);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancaso no metodo addException: " + e.Message);
            }
        }

        public void textoInicial()
        {
            var nomeDoUsuario = Environment.UserName;
            var nomeDoSO = Environment.OSVersion.Platform;
            var nomeDaMaquina = Environment.MachineName;

            addText("Data atual: " + PegarDataFormatada());
            addText("Hora atual: " + PegarHoraFormatada());
            addText("Endereço IP: " + "000.000.0.0");
            addText("Usuário Atual ou de Rede: " + nomeDoUsuario);
            addText("Nome do computador de execução: " + nomeDaMaquina);
            document.NewPage();
        }

        public void finishPdf()
        {
            BaseColor cor = BaseColor.GREEN;
            String resultado = "Evidencias MyStore_" + PegarDataHoraFormatada();
            String novoNome = "Evidencia com novo nome";

            bool status = TestContext.CurrentContext.Result.Equals(TestStatus.Failed);
            if (status)
            {
                cor = BaseColor.RED;
                resultado = "__FAILED";
            }
            else
            {
                resultado = "__PASSED";
            }

            addFormatedText("STATUS DO CENARIO: " + resultado, FontFactory.TIMES_BOLDITALIC, 16f, 1, cor);
            document.Close();
            novoNome = arqEvidencia.Replace(".pdf", resultado + ".pdf");
            //return new File(arqEvidencia).Replace(new File(novoNome));
            File.Move(arqEvidencia, novoNome);
        }

        public void evidenciaElemento(string passo)
        {
            Thread.Sleep(1);
            print(passo);
        }

        public void CriarPastaEvidenciaNoPDF(string nomeDaPastaEvidencia)
        {
            try
            {
                var nomeDoUsuario = Environment.UserName;
                Console.WriteLine("Nome do usuario: " + nomeDoUsuario);

                var nomeDoSO = Environment.OSVersion.Platform;
                Console.WriteLine("Sistema Operacional: " + nomeDoSO);

                string so = nomeDoSO.ToString();

                if (so == "Unix" || so == "Mac")
                {
                    //Verifica se pasta ja existe
                    if (!Directory.Exists(downloadsMac))
                    {
                        //Criar pasta
                        evidencias = Directory.CreateDirectory(downloadsMac + "/" + nomeDaPastaEvidencia);
                        Console.WriteLine("Diretorio criado: " + evidencias);
                    }
                }
                else if (so == "Windows")
                {
                    //Verifica se pasta ja existe
                    if (!Directory.Exists(downloadsWindows))
                    {
                        //Criar pasta
                        evidencias = Directory.CreateDirectory(downloadsWindows + "/" + nomeDaPastaEvidencia);
                    }
                }
                Thread.Sleep(2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo CriarPastaEvidenciaNoPDF: " + e.Message);
            }
        }

        public string PegarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }

        public string PegarDataFormatada()
        {
            string sDataAtual = System.DateTime.Now.ToString("dd-MM-yy");
            Console.WriteLine("Data formatada: " + sDataAtual);
            return sDataAtual;
        }

        public string PegarHoraFormatada()
        {
            string sHoraAtual = System.DateTime.Now.ToString("H-mm-ss");
            Console.WriteLine("Hora formatada: " + sHoraAtual);
            return sHoraAtual;
        }
    }
}
