using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class ReservationPage
    {
        public ReservationPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "tripCasePnr")]
        private IWebElement reservationCodeInput;

        [FindsBy(How = How.Id, Using = "tripCaseLastName")]
        private IWebElement passengerNameInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-group form-group'][2]/div[@class='col-mb-12 col-4 col-offset-8']/button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement searchButton;

        public ReservationPage FillInReservationCodeAndPassengerName(string reservationCode, string passengerName)
        {
            reservationCodeInput.SendKeys(reservationCode);
            passengerNameInput.SendKeys(passengerName);
            searchButton.Click();
            return this;
        }
    }
}
