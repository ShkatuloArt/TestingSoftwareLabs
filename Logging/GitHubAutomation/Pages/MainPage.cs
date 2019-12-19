using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using TestAutomation.Models;
using TestAutomation.Utils;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Pages
{
    public class MainPage : BasePage
    {
        private const string BASE_URL = "https://belavia.by/";

        [FindsBy(How = How.Id, Using = "next-trigger")]
        private IWebElement ButtonSearch { get; set; }

        [FindsBy(How = How.Id, Using = "OriginLocation_Combobox")]
        private IWebElement DepartureCityField { get; set; }

        [FindsBy(How = How.Id, Using = "DestinationLocation_Combobox")]
        private IWebElement ArrivalCityField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='content']//div[@class='col-mb-12']//label[1]")]
        private IWebElement JourneyType { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='ibe']//div[@class='col-group form-group']//div[1]//div[1]//a[1]")]
        private IWebElement CalendarField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='calendar']//a[@class='ui-state-default'][contains(text(),'16')]")]
        private IWebElement DepartureDateField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement SearchButtonClass { get; set; }

        [FindsBy(How = How.Id, Using = "ui-id-1")]
        private IWebElement TravellersField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Passengers']/div/div[1]/a[2]")]
        private IWebElement PlusOneAdultButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Passengers']/div/div[1]/a[1]")]
        private IWebElement MinusOneAdultButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Passengers']/div/div[1]/span/span[1]")]
        private IWebElement FieldValuesForAdults { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Passengers']/div/div[3]/a[2]")]
        private IWebElement PlusOneInfantButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Passengers']/div/div[3]/span/span[1]")]
        private IWebElement FieldValuesForInfants { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/div[2]/div[4]/div[1]/div[1]/div[2]")]
        private IWebElement ButtonTypeOfClass { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='brand es']")]
        private IWebElement ButtonTypeOfFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement ButtonNextToTabChoiceOfFlights { get; set; }

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

        [FindsBy(How = How.XPath, Using = "//div[@class='container container-abs']//li[2]//a[1]")]
        private IWebElement RegestrationStatusTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='select-member']/span[@class='text-bar visible-md']")]
        public IWebElement TextSignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "tripCasePnr")]
        private IWebElement ReservationCodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "tripCaseLastName")]
        private IWebElement PassengerNameInputReservation { get; set; }

        [FindsBy(How = How.Id, Using = "wciPnr")]
        private IWebElement RegestrationCodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "wciLastName")]
        private IWebElement PassengerNameInputRegestration { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='trip-case']//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement SearchReservationButton { get; set; }

        [FindsBy(How = How.Id, Using = "wciButton")]
        private IWebElement SearchRegestrationButton { get; set; }

        [FindsBy(How = How.Id, Using = "modal_btn_78")]
        private IWebElement ModalButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='.']")]
        private IWebElement ConfirmationOfAgreementWithTermsCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='wrapper']/span[@class='field-validation-error']")]
        public IWebElement ReservationErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "modal-content")]
        public IWebElement RegestrationErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn-large btn btn-b2-green ui-corner-all']")]
        private IWebElement ButtonNext { get; set; }

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public MainPage OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            return this;
        }

        public string GetCountOfAdults()
        {
            return FieldValuesForAdults.Text;
        }

        public string GetCountOfInfants()
        {
            return FieldValuesForInfants.Text;
        }    

        public PassengersAndServicesPage FillChoiceOfFlights()
        {
            WaitWebElementLoad(driver, 20, ButtonTypeOfClass);
            ButtonTypeOfClass.Click();
            ButtonTypeOfFlight.Click();
            ButtonNextToTabChoiceOfFlights.Click();
            return new PassengersAndServicesPage(driver);
        }

        public MainPage FillFieldsSearch(Search search)
        {
            DepartureCityField.SendKeys(search.DepartureCity + Keys.Enter);            
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            ArrivalCityField.SendKeys(search.ArrivalCity + Keys.Enter);
            JourneyType.Click();
            CalendarField.Click();
            DepartureDateField.Click();
            return this;
        }              

        public MainPage ClickSearchButton()
        {
            SearchButtonClass.Click();
            return this;
        }

        public MainPage MinusAdultsToTravellers(int countAdults)
        {
            for (int i = 1; i <= countAdults; i++)
                MinusOneAdultButton.Click();
            return this;
        }

        public MainPage AddAdultsToTravellers(int countAdults)
        {
            for (int i = 0; i <= countAdults; i++)
                PlusOneAdultButton.Click();
            return this;
        }
              
        public MainPage AddInfantsToTravellers(int countInfants)
        {
            for (int i = 1; i <= countInfants; i++)           
                PlusOneInfantButton.Click();
            return this;
        }
        public MainPage OpenMoreInfoFields()
        {
            ButtonSearch.Click();
            return this;
        }

        public MainPage ClickSignInAccountButton()
        {
            SignInButton.Click();
            WaitWebElementLoad(driver, 20, EnterButton);
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
            WaitWebElementLoad(driver, 20, SearchReservationButton);
            ReservationCodeInput.SendKeys(reservation.ReservationCode);
            PassengerNameInputReservation.SendKeys(reservation.PassengerName);         
            SearchReservationButton.Click();
            WaitWebElementLoad(driver, 20, ButtonNext);
            return this;
        }

        public MainPage GoToTabRegestrationAndFill(Reservation reservation)
        {
            RegestrationStatusTab.Click();
            WaitWebElementLoad(driver, 20, ConfirmationOfAgreementWithTermsCheckBox);
            RegestrationCodeInput.SendKeys(reservation.ReservationCode);
            PassengerNameInputRegestration.SendKeys(reservation.PassengerName);
            ConfirmationOfAgreementWithTermsCheckBox.Click();
            SearchRegestrationButton.Click();
            WaitWebElementLoad(driver, 20, ModalButton);
            return this;
        }

        public MainPage MoveToTravellers()
        {
            WaitWebElementLoad(driver, 20, TravellersField);
            TravellersField.Click();            
            return this;
        }
    }
}
