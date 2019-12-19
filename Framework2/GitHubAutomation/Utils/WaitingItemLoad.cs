using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomation.Utils
{
    public abstract class WaitingItemLoad
    {
        public IWebElement WaitWebElementLoad(IWebDriver driver, IWebElement webElement)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(webElement)); ;
        }
    }
}
