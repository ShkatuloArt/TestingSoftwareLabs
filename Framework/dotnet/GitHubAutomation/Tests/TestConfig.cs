using System;
using System.IO;
using GitHubAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetDriver()
        {
            Driver = DriverInstance.GetInstance();
            Driver.Navigate().GoToUrl("https://belavia.by/");
        }

        protected void TakeScreenshotWhenTestFailed(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                throw;
            }
        }

        [TearDown]
        public void QuitDriver()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
