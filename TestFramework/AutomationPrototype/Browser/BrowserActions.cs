using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;

// Joshua Esquivel
// This class contains the browser actions that are performed for the test.

namespace AutomationPrototype.Browser
{
    class BrowserActions
    {

        private IWebDriver browserDriver;

        public BrowserActions(IWebDriver driver)
        {
            browserDriver = driver;
        }

        // Perform a search in Bing with the provided text
        public void BingSearch(string search)
        {
            IWebElement browserElement = null;

            browserDriver.Navigate().GoToUrl("https://www.bing.com/");
            browserDriver.FindElement(By.ClassName("b_searchbox")).Clear();
            browserDriver.FindElement(By.ClassName("b_searchbox")).SendKeys(search);
            browserDriver.FindElement(By.ClassName("b_searchboxSubmit")).Click();

            Thread.Sleep(3000);

            browserElement = browserDriver.FindElement(By.ClassName("b_secondaryFocus"));
            Console.WriteLine("The Bing element was found with this text: " + browserElement.Text);            
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
            Console.WriteLine("The Google element was found with this text: " + browserElement.Text);
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
            Console.WriteLine("The Yahoo element was found with this text: " + browserElement.Text);           
        }
    }
}
