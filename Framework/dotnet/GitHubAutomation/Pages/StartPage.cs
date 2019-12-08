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
    public class StartPage
    {
        public StartPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.Id, Using = "select-member")]
        private IWebElement signInButton;

        [FindsBy(How = How.Id, Using = "MemberId")]
        private IWebElement memberIdInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-mb-6']/button[@class='button btn btn-b2-login ui-corner-all']")]
        private IWebElement enterButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='navtab']/ul[@class='nav-tabs']/li[3]/a")]
        private IWebElement reservationStatusTab;      

        public StartPage ClickSignInAccountButton(IWebDriver webDriver)
        {
            signInButton.Click();
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(enterButton));
            return this;
        }

        public StartPage FillInLoginAndPassword(SignIn signIn)
        {
            memberIdInput.SendKeys(signIn.MemberId);          
            passwordInput.SendKeys(signIn.Password);
            enterButton.Click();
            return this;
        }

        public StartPage GoToTabReservation(IWebDriver webDriver)
        {
            reservationStatusTab.Click();
            return this;
        }        
    }
}
