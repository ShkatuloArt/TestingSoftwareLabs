using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWebDriver
{
    [TestFixture]
    class Tests : BrowserSetUp
    {
        const string RIGHT_TEXT_WHEN_LOGGING_IN_TO_ACCOUNT = "ARTSIOM SHKATULA";
        const string ERROR_TEXT_WHEN_INPUT_INVALID_RESERVATION_CODE_WHEN_VIEW_RESERVATION_STATUS = "Бронирование не найдено";
        const string correctTypeofClass = "Эконом";

        [Test]
        public void SignInToAccount()
        {
            var signInButton = GetElementById("select-member");
            signInButton.Click();

            var memberIdInput = GetElementById("MemberId");
            memberIdInput.SendKeys("10012476876");

            var passwordInput = GetElementById("Password");
            passwordInput.SendKeys("V7H4C6");

            var getElementWithClassName = GetElementsByClassName("col-mb-6");
            var enterButton = getElementWithClassName[0];
            enterButton.Click();

            var getTags_span = GetElementsByTagName("span");
            var textSignInButton = getTags_span[7];

            Assert.AreEqual(RIGHT_TEXT_WHEN_LOGGING_IN_TO_ACCOUNT, textSignInButton.Text);
        }

        [Test]
        public void InputInvalidReservationCodeWhenViewingReservationStatus()
        {
            var getTags_li = GetElementsByTagName("li");
            var reservationStatusTab = getTags_li[80];
            reservationStatusTab.Click();

            var reservationCodeInput = GetElementById("tripCasePnr");
            reservationCodeInput.SendKeys("123456");

            var passengerNameInput = GetElementById("tripCaseLastName");
            passengerNameInput.SendKeys("SHKATULO");

            var getTags_button = GetElementsByTagName("button");
            var searchButton = getTags_button[5];
            searchButton.Click();

            var getElementWithClassName = GetElementsByClassName("field-validation-error");
            var errorMessage = getElementWithClassName[0];

            Assert.AreEqual(ERROR_TEXT_WHEN_INPUT_INVALID_RESERVATION_CODE_WHEN_VIEW_RESERVATION_STATUS, errorMessage.Text);
        }

        [Test]
        public void CheckingTheCorrectnessOfTheInputData()
        {
            var departureCityInput = GetElementById("OriginLocation_Combobox");
            departureCityInput.SendKeys("Минск (MSQ), BY" + Keys.Enter);

            var arrivalCityInput = GetElementById("DestinationLocation_Combobox");
            arrivalCityInput.SendKeys("Москва (MOW), RU" + Keys.Enter);

            var getTags_label = GetElementsByTagName("label");
            var journeyType = getTags_label[5];
            journeyType.Click();

            var getElementWithClassName_trigger = GetElementsByClassName("trigger");
            var leaveDateInput = getElementWithClassName_trigger[2];
            leaveDateInput.Click();

            var getElementWithClassName_uiStateDefault = GetElementsByClassName("ui-state-default");
            var leaveDateButton = getElementWithClassName_uiStateDefault[33];
            leaveDateButton.Click();

            var getTags_button = GetElementsByTagName("button");
            var searchButton = getTags_button[3];
            searchButton.Click();        

            var getTags_div = GetElementsByTagName("div");
            var selectTypeOfClass = getTags_div[94];
            selectTypeOfClass.Click();

            var getElementWithClassName_price = GetElementsByClassName("price");
            var selectTypeOfFlight = getElementWithClassName_price[11];
            selectTypeOfFlight.Click();

            getTags_button = GetElementsByTagName("button");
            var buttonNext = getTags_button[2];
            buttonNext.Click();
            
            getTags_div = GetElementsByTagName("div");
            var appeal = getTags_div[36];
            appeal.Click();

            var getTags_li = GetElementsByTagName("li");
            var mr = getTags_li[2];
            mr.Click();

            var firstNameInput = GetElementById("passenger-0.firstName");
            firstNameInput.SendKeys("ARTEM");

            var lastNameInput = GetElementById("passenger-0.lastName");
            lastNameInput.SendKeys("SHKATULO");

            var dateOfBirthInput = GetElementById("passenger-0.dateOfBirth");
            dateOfBirthInput.SendKeys("28042000");

            var documentNumberInput = GetElementById("passenger-0.documentNumber");
            documentNumberInput.SendKeys("2222222");

            var periodOfValidityInput = getTags_div[54];
            periodOfValidityInput.Click();

            var numberPhoneInput = GetElementById("contact-0.phoneNumber");
            numberPhoneInput.SendKeys("1020617");

            var emailInput = GetElementById("contact-0.email");
            emailInput.SendKeys("shkatulo.2017@gmail.com");

            var emailConfirmInput = GetElementById("contact-0.emailConfirm");
            emailConfirmInput.SendKeys("shkatulo.2017@gmail.com");

            getTags_button = GetElementsByTagName("button");
            buttonNext = getTags_button[1];
            buttonNext.Click();

            getTags_button = GetElementsByTagName("button");
            buttonNext = getTags_button[1];
            buttonNext.Click();           

            var typeOfClass = GetElementByClassName("cabin");
            
            Assert.AreEqual(correctTypeofClass, typeOfClass.Text);
        }
    }
}
