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
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    public class ReservationSearchResultsPage
    {
        public ReservationSearchResultsPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[@class='wrapper']/span[@class='field-validation-error']")]
        public IWebElement errorMessage;
    }
}
