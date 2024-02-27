# automacao-calculadoraandroid-csharp-mobile

Script de automacao para realizar calculos basicos na calculadora do Android usando C Sharp, Selenium, iText e NUnit.

### Cobertura dos testes:  ###
*Descricao: 

Realizar calculos basicos na calculadora do Android no emulador.

Realizar calculos basicos na calculadora do Android no smartphone.

## Tecnologias:
* [Java Jdk 8](https://www.oracle.com/br/java/technologies/javase-downloads.html)
* [Maven](https://maven.apache.org)
* [Appium 2+](http://appium.io)
* [Selenium](https://www.selenium.dev/projects/)
* [Apk Info](https://play.google.com/store/apps/details?id=com.wt.apkinfo&hl=pt_BR)
* [Android Studio](https://developer.android.com/studio)
* [C Sharp](https://docs.microsoft.com/pt-br/dotnet/csharp/)
* [NUnit](https://nunit.org)
* [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)
* [Marketplace Visual Studio](https://marketplace.visualstudio.com)
* [iText](https://itextpdf.com/en)

## Dependências:
* NUnit
* NUnit3TestAdapter 
* Selenium.Support
* Selenium.WebDriver 
* iTextSharp (Para criar evidencias em pdf)
* Docx (Para criar evidencias em docx)
* Appium.Webdriver

## Instruções de execução:

###  - App
*Importante: 

O app da calculadora é nativa do Android, não é necessario instalar desde que a versao do Android que voce vai testar tenha a calculadora instalada. 

Nao é obrigatorio mas recomendado utilizar o APK Info para descobrir as informações como appActivity e appPackage. Tambem nao é obrigado a ter o Gmail configurado no Android, mas é recomendado para atualizações da plataforma.

Este projeto esta construido para executar no Android do Emulador do Android Studio e em algum aparelho fisico.

Utilize a versão 2 do Appium, pois as anteriores foram depreciadas e não possuem suporte do Desenvolvedor.

###  - Plataforma
*Importante:

O projeto foi criado no MacOS, e nao ha impedimento para executar no Windows ou Linux desde que tenha os aplicativos descritos em Dependencias.

Os metodos para criar o driver Mobile estao na classe EmuladorDriver e MobileDriver.

Recomendado utilizar o Visual Studio 2019 ou 2022.

###  - Fluxo
*Descricao: Este script ira executar calculos simples como Soma, Subtracao, Multiplicacao e Divisao.

###  - Massas
*Descricao: 
Nao e necessario criar massas.

###  - Evidencias
*Importante: As evidencias estao sendo salvas na pasta evidencias(automacao-calculadoraandroid-csharp-mobile/automacao-calculadoraandroid-csharp-mobile/automacao-calculadoraandroid-csharp-mobile/bin/Release/netcoreapp3.1).

*Descricao: A classe GeradorPDF.cs tira os screenshots e adiciona-os dentro de um documento em pdf e tambem salva-o dentro de evidencias.

###  - Inicializar a automação
*Descricao:

Execute o Appium e abra o Emulador do AS ou conecte o aparelho no computador.

