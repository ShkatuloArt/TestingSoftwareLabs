using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Service;
using GitHubAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class Tests : TestConfig
    {
        [Test]
        public void SignInToAccount()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StartPage startPage = new StartPage(Driver)
                .ClickSignInAccountButton(Driver)
                .FillInLoginAndPassword(CreatorSignIn.WithUserProperties());
                AuthorizedPage authorizedPage = new AuthorizedPage(Driver);
                Assert.AreEqual("ARTSIOM SHKATULA", authorizedPage.textSignInButton.Text);
            });
        }

        [Test]
        public void InputInvalidReservationCodeWhenViewingReservationStatus()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StartPage startPage = new StartPage(Driver)
               .GoToTabReservation(Driver);
                ReservationPage reservationPage = new ReservationPage(Driver)
                    .FillInReservationCodeAndPassengerName(CreatingReservationModel.WithReservationProperties());
                ReservationSearchResultsPage reservationSearchResultsPage = new ReservationSearchResultsPage(Driver);
                Assert.AreEqual("Бронирование не найдено", reservationSearchResultsPage.errorMessage.Text);
            });           
        }
    }
}
