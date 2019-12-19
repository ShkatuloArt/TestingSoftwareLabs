using System;
using System.IO;
using TestAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using log4net;
using log4net.Config;

namespace TestAutomation.Utils
{
    public class TestListener : Logger
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Logger.Log.Warn("Start driver initializing.");
            Driver = DriverSingleton.GetDriver();
            Logger.Log.Info("Driver initialized.");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                Logger.WhenTestSuccess();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                Logger.WhenTestFails();
                Logger.Log.Error("Test failed. Taking screenshot.");
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Info("Took screenshot.");
            }
            DriverSingleton.CloseDriver();
        }
    }
}
