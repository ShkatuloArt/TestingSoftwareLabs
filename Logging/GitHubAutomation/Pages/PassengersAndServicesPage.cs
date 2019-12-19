using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestAutomation.Models;
using TestAutomation.Utils;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Pages
{
    public class PassengersAndServicesPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "passenger-0.dateOfBirth")]
        private IWebElement DateOfBirthAdultField { get; set; }
      
        [FindsBy(How = How.Id, Using = "passenger-1.dateOfBirth")]
        private IWebElement DateOfBirthInfantField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button btn-large btn btn-b2-green btn-b2-green-fixed ui-corner-all']")]
        private IWebElement ButtonNextToTabServices { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='wrapper has-text']/span[@class='field-validation-error']")]
        private IWebElement TextErrorDateOfBirth{ get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-mb-12 col-6 form-group']//span[@class='field-validation-error'][contains(text(),'.')]")]
        private IWebElement TextErrorPhoneNumber { get; set; }

        [FindsBy(How = How.Id, Using = "passenger-0.title")]
        private IWebElement PassengerTitle { get; set; }

        [FindsBy(How = How.Id, Using = "passenger-0.firstName")]
        private IWebElement PassangerFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "passenger-0.lastName")]
        private IWebElement PassangerLastName { get; set; }

        [FindsBy(How = How.Id, Using = "passenger-0.documentNumber")]
        private IWebElement PassangerDocumentNumber { get; set; }

        [FindsBy(How = How.ClassName, Using = "non-expiry")]
        private IWebElement PassengerDocumentExpirationDate { get; set; }

        [FindsBy(How = How.Id, Using = "contact-0.phoneNumber")]
        private IWebElement PassangerPhoneNumber { get; set; }

        [FindsBy(How = How.Id, Using = "contact-0.email")]
        private IWebElement PassangerEmail { get; set; }

        [FindsBy(How = How.Id, Using = "contact-0.emailConfirm")]
        private IWebElement PassangerEmailConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/div[2]/form/div[3]/div/div[2]/button")]
        private IWebElement ButtonNextToFinishTab { get; set; }

        private IWebDriver driver;

        public PassengersAndServicesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
  
        public PassengersAndServicesPage FillDateOfBirthAdultField(Passanger passanger)
        {
            WaitWebElementLoad(driver, 20, ButtonNextToTabServices);
            DateOfBirthAdultField.SendKeys(passanger.PassangerDateOfBirth);
            return this;
        }

        public PassengersAndServicesPage FillDateOfBirthInfantField(Passanger passanger)
        {
            WaitWebElementLoad(driver, 20, ButtonNextToTabServices);
            DateOfBirthInfantField.SendKeys(passanger.PassangerDateOfBirth);
            return this;
        }

        public PassengersAndServicesPage FillInformationAboutPassanger(Passanger passanger)
        {
            WaitWebElementLoad(driver, 20, ButtonNextToTabServices);
            PassengerTitle.Click();
            PassengerTitle.SendKeys(Keys.Enter);
            PassangerFirstName.SendKeys(passanger.PassangerFirstName);
            PassangerLastName.SendKeys(passanger.PassangerLastName);
            DateOfBirthAdultField.SendKeys(passanger.PassangerDateOfBirth);
            PassangerDocumentNumber.SendKeys(passanger.PassangerDocumentNumber);
            PassengerDocumentExpirationDate.Click();
            PassangerPhoneNumber.SendKeys(passanger.PassangerPhoneNumber);
            PassangerEmail.SendKeys(passanger.PassangerEmail);
            PassangerEmailConfirm.SendKeys(passanger.PassangerEmailConfirm);
            ButtonNextToTabServices.Click();
            return this;
        }

        public PassengersAndServicesPage ClickButtonNextToFinishTab()
        {
            WaitWebElementLoad(driver, 20, ButtonNextToFinishTab);
            ButtonNextToFinishTab.Click();
            return this;
        }
        public string GetTextErrorDateOfBirth()
        {
            return TextErrorDateOfBirth.Text;
        }
        public string GetTextErrorPhoneNumber()
        {
            return TextErrorPhoneNumber.Text;
        }
    }
}
