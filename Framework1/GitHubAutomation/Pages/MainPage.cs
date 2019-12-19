using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using TestAutomation.Models;
using TestAutomation.Utils;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Pages
{
    public class MainPage : WaitingItemLoad
    {
        [FindsBy(How = How.Id, Using = "select-member")]
        private IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "MemberId")]
        private IWebElement MemberIdInput { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn btn-b2-login ui-corner-all']")]
        private IWebElement EnterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='content']//li[3]//a[1]")]
        private IWebElement ReservationStatusTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='select-member']/span[@class='text-bar visible-md']")]
        public IWebElement TextSignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "tripCasePnr")]
        private IWebElement ReservationCodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "tripCaseLastName")]
        private IWebElement PassengerNameInputReservation { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='trip-case']//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement SearchReservationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='wrapper']/span[@class='field-validation-error']")]
        public IWebElement ReservationErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement ButtonNext { get; set; }

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        
        public MainPage ClickSignInAccountButton()
        {
            SignInButton.Click();
            WaitWebElementLoad(driver, EnterButton);
            return this;
        }

        public MainPage FillInLoginAndPassword(SignIn signIn)
        {
            MemberIdInput.SendKeys(signIn.MemberId);
            PasswordInput.SendKeys(signIn.Password);
            EnterButton.Click();
            return this;
        }

        public MainPage GoToTabReservationAndFill(Reservation reservation)
        {
            ReservationStatusTab.Click();
            WaitWebElementLoad(driver, SearchReservationButton);
            ReservationCodeInput.SendKeys(reservation.ReservationCode);
            PassengerNameInputReservation.SendKeys(reservation.PassengerName);         
            SearchReservationButton.Click();
            WaitWebElementLoad(driver, ButtonNext);
            return this;
        }       
    }
}
