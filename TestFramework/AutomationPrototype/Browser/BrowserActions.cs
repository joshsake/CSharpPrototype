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

        }

        public void YahooSearch(string search)
        {
            browserDriver.Navigate().GoToUrl("https://search.yahoo.com/");

            browserDriver.FindElement(By.Id("yschsp")).Clear();
            browserDriver.FindElement(By.Id("yschsp")).SendKeys(search);
            browserDriver.FindElement(By.ClassName("sbb")).Click();            
            

        }
    }
}
