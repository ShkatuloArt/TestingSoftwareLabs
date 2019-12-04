using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://belavia.by/");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void SignInToAccount()
        {
            StartPage startPage = new StartPage(webDriver)
                .ClickSignInAccountButton(webDriver)
                .FillInLoginAndPassword("10012476876", "V7H4C6");            
            AuthorizedPage authorizedPage = new AuthorizedPage(webDriver);
            Assert.AreEqual("ARTSIOM SHKATULA", authorizedPage.textSignInButton.Text);
        }

        [Test]
        public void InputInvalidReservationCodeWhenViewingReservationStatus()
        {
            StartPage startPage = new StartPage(webDriver)
                .GoToTabReservation(webDriver);
            ReservationPage reservationPage = new ReservationPage(webDriver)
                .FillInReservationCodeAndPassengerName("123456", "SHKATULO");
            ReservationSearchResultsPage reservationSearchResultsPage = new ReservationSearchResultsPage(webDriver);
            Assert.AreEqual("Бронирование не найдено", reservationSearchResultsPage.errorMessage.Text);
        }
    }
}
