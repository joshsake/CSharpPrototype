using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;

// Joshua Esquivel

namespace AutomationPrototype.Browser
{
    class BrowserActions
    {

        private IWebDriver browserDriver;

        public BrowserActions(IWebDriver driver)
        {
            browserDriver = driver;
        }

        public void BingSearch(string search)
        {

        }

        public void GoogleSearch(string search)
        {
            IWebElement browserElement = null;

            browserDriver.Navigate().GoToUrl("https://www.google.com/");
            browserDriver.FindElement(By.ClassName("gsfi")).Clear();
            browserDriver.FindElement(By.ClassName("gsfi")).SendKeys(search);
            browserDriver.FindElement(By.ClassName("gsfi")).SendKeys(Keys.Enter);

            Thread.Sleep(3000);

            browserElement = browserDriver.FindElement(By.ClassName("_Tgc"));
            Console.WriteLine("The element was found with this text: " + browserElement.Text);


        }

        public void YahooSearch(string search)
        {
            IWebElement browserElement = null;

            browserDriver.Navigate().GoToUrl("https://search.yahoo.com/");
            browserDriver.FindElement(By.Id("yschsp")).Clear();
            browserDriver.FindElement(By.Id("yschsp")).SendKeys(search);
            browserDriver.FindElement(By.ClassName("sbb")).Click();

            Thread.Sleep(3000);

            browserElement = browserDriver.FindElement(By.XPath("//b[.='what is test automation']"));
            Console.WriteLine("The element was found with this text: " + browserElement.Text);
           
        }
    }
}
