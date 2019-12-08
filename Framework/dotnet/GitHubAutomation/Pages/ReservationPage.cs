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

        public ReservationPage FillInReservationCodeAndPassengerName(Reservation reservation)
        {
            reservationCodeInput.SendKeys(reservation.ReservationCode);
            passengerNameInput.SendKeys(reservation.PassengerName);
            searchButton.Click();
            return this;
        }
    }
}
