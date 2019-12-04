using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class AuthorizedPage
    {
        public AuthorizedPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='select-member']/span[@class='text-bar visible-md']")]
        public IWebElement textSignInButton;
    }
}
