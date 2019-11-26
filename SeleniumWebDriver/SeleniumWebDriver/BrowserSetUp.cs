using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;

namespace SeleniumWebDriver
{
    abstract class BrowserSetUp
    {
        private IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://belavia.by/");
        }
        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
        protected IWebElement GetElementById(string elementId)
        {
            return webDriver.FindElement(By.Id(elementId));
        }
        protected IWebElement GetElementByClassName(string elementClassName)
        {
            return webDriver.FindElement(By.ClassName(elementClassName));
        }
        protected IWebElement GetElementByXPath(string elementXPath)
        {
            return webDriver.FindElement(By.XPath(elementXPath));
        }
        protected ReadOnlyCollection<IWebElement> GetElementsByClassName(string elementClassName)
        {
            return webDriver.FindElements(By.ClassName(elementClassName));
        }
        protected IWebElement GetElementByName(string elementName)
        {
            return webDriver.FindElement(By.Name(elementName));
        }

        protected ReadOnlyCollection<IWebElement> GetElementsByTagName(string tagName)
        {
            return webDriver.FindElements(By.TagName(tagName));
        }        
    }
}
