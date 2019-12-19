using NUnit.Framework;
using TestAutomation.Driver;
using TestAutomation.Pages;
using TestAutomation.Service;
using TestAutomation.Utils;

namespace TestAutomation
{
    [TestFixture]
    public class Tests : TestConfig
    {
        private const string ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS = "5";
        private const string ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT = "1";
        private const string ACCEPTABLE_NUMBER_OF_INFANTS_WITH_ONE_ADULT = "1";
        private const string ERROR_MESSAGE_CHECK_IN = "Ваше бронирование не найдено. Пожалуйста, убедитесь, что код бронирования (PNR) введен корректно или обратитесь на стойку регистрации «Белавиа» в аэропорту.";

        [Test]
        public void EnterAcceptableMaxCountOfAdults()
        {
            MainPage mainPage = new MainPage(Driver)
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddAdultsToTravellers(5);
            Assert.AreEqual(ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterOneInfantsWithOneAdults()
        {
            MainPage mainPage = new MainPage(Driver)
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddInfantsToTravellers(2);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_INFANTS_WITH_ONE_ADULT, mainPage.GetCountOfInfants());
        }

        [Test]
        public void EnterOneInfantsWithoutAdults()
        {
            MainPage mainPage = new MainPage(Driver)
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddInfantsToTravellers(1)
                .MinusAdultsToTravellers(1);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterTheDateOfBirthOfTheChildForTheAdult()
        {
            PassengersAndServicesPage mainPage = new MainPage(Driver)
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillDateOfBirthAdultField(CreatingPassanger.OnlyDateofBirthChild());
            Assert.AreEqual("Должна быть от 16.01.1900 до 16.01.2008.", mainPage.GetTextErrorDateOfBirth());
        }

        [Test]
        public void EnterTheDateOfBirthOfTheAdultForTheInfant()
        {
            PassengersAndServicesPage mainPage = new MainPage(Driver)
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .MoveToTravellers()
                .AddInfantsToTravellers(1)
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillDateOfBirthInfantField(CreatingPassanger.OnlyDateofBirth());
            Assert.AreEqual("Должна быть от 16.01.2018 до 16.01.2020.", mainPage.GetTextErrorDateOfBirth());
        }

        [Test]
        public void SignInToAccount()
        {
            MainPage mainPage = new MainPage(Driver)
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(CreatingSignIn.WithUserProperties());
            Assert.AreEqual("ARTSIOM SHKATULA", mainPage.TextSignInButton.Text);
        }

        [Test]
        public void EnterInvalidReservationCodeWhenViewingReservationStatus()
        {
            MainPage mainPage = new MainPage(Driver)
                .GoToTabReservationAndFill(CreatingReservationModel.WithReservationProperties());
            Assert.AreEqual("Бронирование не найдено", mainPage.ReservationErrorMessage.Text);
        }

        [Test]
        public void BookingATicketWithoutPhoneNumber()
        {
            PassengersAndServicesPage mainPage = new MainPage(Driver)
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillInformationAboutPassanger(CreatingPassanger.WithoutPhoneNumber());
            Assert.AreEqual("Обязательно для заполнения.", mainPage.GetTextErrorPhoneNumber());
        }

        [Test]
        public void CheckingTheCorrectnessOfTheInputData()
        {
            PassengersAndServicesPage mainPage = new MainPage(Driver)
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillInformationAboutPassanger(CreatingPassanger.WithAllProperties())
                .ClickButtonNextToFinishTab();
            CheckFieldsPage checkFieldsPage = new CheckFieldsPage(Driver);
            Assert.IsTrue(checkFieldsPage.CompareDisplayedDataWithInputData(CreatingPassanger.WithAllProperties()));
        }

        [Test]
        public void EnterInvalidReservationCodeWhenCheckingIn()
        {
            MainPage mainPage = new MainPage(Driver)
                .GoToTabRegestrationAndFill(CreatingReservationModel.WithReservationProperties());
            Assert.AreEqual(ERROR_MESSAGE_CHECK_IN, mainPage.RegestrationErrorMessage.Text);
        }
    }
}
