using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutomationPrototype.Browser;
using AutomationPrototype.Framework;

using NUnit.Framework;

// Joshua Esquivel
// This class contains the test methods that will be called by NUnit during testing.

namespace AutomationPrototype.Tests
{
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [TestFixture("IE")]
    class SearchTest : BaseWebDriver
    {
        private string _browser;
        private BrowserActions browserActions;

        public SearchTest(string browser)
            :base(browser)
        {
            _browser = browser;
        }


        [Test]
        public void BingSearchTest()
        {
            browserActions = new BrowserActions(prototypeDriver);
            browserActions.BingSearch("What is test automation");
        }

        [Test]
        public void GoogleSearchTest()
        {
            browserActions = new BrowserActions(prototypeDriver);
            browserActions.GoogleSearch("What is test automation");
        }

        [Test]
        public void YahooSearchTest()
        {
            browserActions = new BrowserActions(prototypeDriver);
            browserActions.YahooSearch("What is test automation");
        }

        [Test]
        public void AllSearchTest()
        {
            browserActions = new BrowserActions(prototypeDriver);
            browserActions.BingSearch("What is test automation");
            browserActions.GoogleSearch("Test automation");
            browserActions.YahooSearch("What is test automation");
        }

    }
}
