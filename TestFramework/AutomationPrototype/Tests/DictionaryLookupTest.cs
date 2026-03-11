using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using AutomationPrototype.Framework;

using NUnit.Framework;

// Joshua Esquivel
// This test class demonstrates dictionary lookups using [String, IWebElement] pairs
// for efficient element retrieval and management in test automation.

namespace AutomationPrototype.Tests
{
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [TestFixture("IE")]
    class DictionaryLookupTest : BaseWebDriver
    {
        private string _browser;
        private Dictionary<string, IWebElement> elementDictionary;

        public DictionaryLookupTest(string browser)
            : base(browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void SetupDictionary()
        {
            elementDictionary = new Dictionary<string, IWebElement>();
        }

        [Test]
        public void DictionaryLookupByStringKey()
        {
            // Navigate to a page
            prototypeDriver.Navigate().GoToUrl("https://www.google.com");
            
            // Store web elements in dictionary with string keys
            IWebElement searchBox = prototypeDriver.FindElement(By.Name("q"));
            IWebElement searchButton = prototypeDriver.FindElement(By.Name("btnK"));
            
            elementDictionary["searchBox"] = searchBox;
            elementDictionary["searchButton"] = searchButton;
            
            // Fast O(1) lookup by string key
            IWebElement retrievedElement = elementDictionary["searchBox"];
            retrievedElement.SendKeys("dictionary lookup test");
            
            Console.WriteLine("Successfully retrieved element using dictionary key: 'searchBox'");
        }

        [Test]
        public void DictionaryContainsKeyCheck()
        {
            prototypeDriver.Navigate().GoToUrl("https://www.google.com");
            
            IWebElement searchBox = prototypeDriver.FindElement(By.Name("q"));
            elementDictionary["searchBox"] = searchBox;
            
            // Fast O(1) existence check
            if (elementDictionary.ContainsKey("searchBox"))
            {
                Console.WriteLine("Element 'searchBox' found in dictionary");
                elementDictionary["searchBox"].SendKeys("test search");
            }
            else
            {
                Console.WriteLine("Element 'searchBox' not found in dictionary");
            }
        }

        [Test]
        public void DictionaryMultipleElementsLookup()
        {
            prototypeDriver.Navigate().GoToUrl("https://www.google.com");
            
            // Store multiple elements with descriptive string keys
            elementDictionary["searchInput"] = prototypeDriver.FindElement(By.Name("q"));
            elementDictionary["searchButton"] = prototypeDriver.FindElement(By.Name("btnK"));
            elementDictionary["feelingLucky"] = prototypeDriver.FindElement(By.Name("btnI"));
            
            // Perform lookups and operations
            elementDictionary["searchInput"].SendKeys("dictionary test");
            
            Console.WriteLine($"Dictionary contains {elementDictionary.Count} elements");
            Console.WriteLine("Keys in dictionary:");
            foreach (string key in elementDictionary.Keys)
            {
                Console.WriteLine($"  - {key}");
            }
        }

        [Test]
        public void DictionarySafeLookupWithTryGetValue()
        {
            prototypeDriver.Navigate().GoToUrl("https://www.google.com");
            
            IWebElement searchBox = prototypeDriver.FindElement(By.Name("q"));
            elementDictionary["searchBox"] = searchBox;
            
            // Safe lookup that won't throw exception if key doesn't exist
            IWebElement element;
            if (elementDictionary.TryGetValue("searchBox", out element))
            {
                element.SendKeys("safe lookup test");
                Console.WriteLine("Element found using TryGetValue");
            }
            else
            {
                Console.WriteLine("Element not found in dictionary");
            }
            
            // Try to get non-existent key
            if (elementDictionary.TryGetValue("nonExistentElement", out element))
            {
                Console.WriteLine("This shouldn't print");
            }
            else
            {
                Console.WriteLine("Non-existent element correctly not found");
            }
        }

        [Test]
        public void DictionaryElementUpdate()
        {
            prototypeDriver.Navigate().GoToUrl("https://www.google.com");
            
            // Initial element
            IWebElement searchBox = prototypeDriver.FindElement(By.Name("q"));
            elementDictionary["searchBox"] = searchBox;
            
            // Update dictionary with new element reference
            IWebElement updatedSearchBox = prototypeDriver.FindElement(By.Name("q"));
            elementDictionary["searchBox"] = updatedSearchBox;
            
            // Verify update worked
            elementDictionary["searchBox"].SendKeys("updated element test");
            Console.WriteLine("Dictionary element successfully updated");
        }

        [TearDown]
        public void CleanupDictionary()
        {
            if (elementDictionary != null)
            {
                elementDictionary.Clear();
                Console.WriteLine("Dictionary cleared after test");
            }
        }
    }
}
