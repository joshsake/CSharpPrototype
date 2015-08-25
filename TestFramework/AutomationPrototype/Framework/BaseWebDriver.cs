using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using NUnit;
using NUnit.Framework;

// Joshua Esquivel
// This is the base class that the test classes and any other class can inherit from.
// It's main purpose is to handle the creation of WebDriver instances, test setup, and test results. 

namespace AutomationPrototype.Framework
{
    class BaseWebDriver
    {
        private string environmentUnderTest = "";
        private string browserUnderTest = "";
        private string userUnderTest = "";      
        private string hostName = Environment.GetEnvironmentVariable("COMPUTERNAME");
        
        public IWebDriver prototypeDriver;
        public string currentTestRunning = "";

        protected BaseWebDriver(string browser)
        {
            browserUnderTest = browser;
        }


        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            // Instantiate the webdriver instance with the correct browser driver
            if (browserUnderTest == "Chrome")
                prototypeDriver = new ChromeDriver(); // need to add the path for the chromedriver as a parameter
            else if (browserUnderTest == "IE")
                prototypeDriver = new InternetExplorerDriver();
            else
                prototypeDriver = new FirefoxDriver();

            prototypeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            logMessages("Starting test fixture with browser " + browserUnderTest);
        }

        [SetUp]
        public void SetupTest()
        {
            currentTestRunning = TestContext.CurrentContext.Test.Name;
            logMessages("This is the current test running: " + currentTestRunning);

        }

        // We can check for test issues here
        [TearDown]
        public void TearDownTest()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                // Handle a test failure
            }
            else
                logMessages(currentTestRunning + "test was successful");
        }

        [TestFixtureTearDown]
        public void TearDownFixture()
        {
            // Perform fixture result reporting here

            logMessages("All tests have finished running");
            prototypeDriver.Quit();
        }

        // Write a log message to the console or any other logger
        public void logMessages(string message)
        {
            Console.WriteLine(message);
        }

    }
}
