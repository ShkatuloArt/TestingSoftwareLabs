using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using TestAutomation.Models;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Pages
{
    public class CheckFieldsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/form/div[2]/div/div[3]/div/div[2]/div/div[1]")]
        private IWebElement NamePassanger { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/form/div[2]/div/div[3]/div/div[2]/div/div[2]/div")]
        private IWebElement PassangerNumberDocument { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/form/div[3]/div[2]/div[1]/div")]
        private IWebElement PassangerNumberPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='body']/div[2]/div/form/div[3]/div[2]/div[2]/div")]
        private IWebElement PassangerEmail { get; set; }

        private IWebDriver driver;

        public CheckFieldsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public bool CompareDisplayedDataWithInputData(Passanger passanger)
        {
            if (NamePassanger.Text.Contains(passanger.PassangerFirstName + " " + passanger.PassangerLastName))
                if (PassangerNumberDocument.Text.Equals(passanger.PassangerDocumentNumber))
                    if (PassangerNumberPhone.Text.Contains(passanger.PassangerPhoneNumber))
                        if (PassangerEmail.Text.Contains(passanger.PassangerEmail))
                            return true;
            return false;
        }
    }
}
