using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
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
