using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.IO;

[TestFixture]
public class Parcial2Test
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    private StreamWriter logWriter;

    [SetUp]
    public void SetUp()
    {
        driver = new FirefoxDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();

        // Crear o abrir el archivo de log en modo escritura
        logWriter = new StreamWriter(@"C:\Users\landa\Downloads\selenium\Program\resultados_selenium.log", true);; // 'true' para agregar al final
        logWriter.WriteLine($"Prueba iniciada: {DateTime.Now}");
    }

    [TearDown]
    protected void TearDown()
    {
        // Cerrar el archivo de log
        logWriter.WriteLine($"Prueba finalizada: {DateTime.Now}");
        logWriter.Close();
        driver.Quit();
    }

    [Test]
    public void Parcial2()
    {
        // Bucle para repetir el test 100 veces
        for (int i = 0; i < 100; i++)
        {
            try
            {
                // Imprimir el número de iteración actual para verificar el progreso
                Console.WriteLine($"Ejecutando iteración: {i + 1}");
                logWriter.WriteLine($"Ejecutando iteración: {i + 1}");

                // Realizar el test (el código original)
                driver.Navigate().GoToUrl("http://localhost/Online-Book-Rental-Store/");
                driver.Manage().Window.Size = new System.Drawing.Size(775, 694);
                driver.FindElement(By.LinkText("Create Account")).Click();
                driver.FindElement(By.Id("fullname")).Click();
                driver.FindElement(By.Id("fullname")).Click();
                {
                    var element = driver.FindElement(By.Id("fullname"));
                    Actions builder = new Actions(driver);
                    builder.DoubleClick(element).Perform();
                }
                driver.FindElement(By.Id("fullname")).SendKeys("Alberto Mario");
                driver.FindElement(By.Id("address")).Click();
                driver.FindElement(By.Id("address")).SendKeys("colonia el calvario,calle la Ermita,pasaje 18, casa #3");
                driver.FindElement(By.Id("mobile")).Click();
                driver.FindElement(By.Id("mobile")).SendKeys("70293992");
                driver.FindElement(By.Id("password")).Click();
                driver.FindElement(By.Id("password")).SendKeys("aranabandolera");
                driver.FindElement(By.Name("submit")).Click();
                driver.FindElement(By.LinkText("Login")).Click();
                {
                    var element = driver.FindElement(By.Name("email"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).ClickAndHold().Perform();
                }
                {
                    var element = driver.FindElement(By.Name("email"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Perform();
                }
                {
                    var element = driver.FindElement(By.Name("email"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Release().Perform();
                }
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.CssSelector(".form")).Click();
                driver.FindElement(By.Name("pwd")).Click();
                driver.FindElement(By.Name("pwd")).SendKeys("aranabandolera");
                driver.FindElement(By.Name("login")).Click();

                // Esperar un tiempo entre iteraciones si es necesario
                System.Threading.Thread.Sleep(1000); // Espera 1 segundo entre cada ciclo

                // Escribir en el log al final de cada iteración
                logWriter.WriteLine($"Iteración {i + 1} completada con éxito.");
            }
            catch (Exception ex)
            {
                // Escribir en el log si ocurre algún error
                logWriter.WriteLine($"Error en iteración {i + 1}: {ex.Message}");
            }
        }

        // Mensaje al finalizar las 100 iteraciones
        Console.WriteLine("Test completado 100 veces.");
        logWriter.WriteLine("Test completado 100 veces.");
    }
}
