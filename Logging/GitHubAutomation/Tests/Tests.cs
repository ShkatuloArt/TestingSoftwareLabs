using NUnit.Framework;
using TestAutomation.Driver;
using TestAutomation.Pages;
using TestAutomation.Service;
using TestAutomation.Utils;
using log4net;
using log4net.Config;

namespace TestAutomation
{
    [TestFixture]
    public class Tests : TestListener
    {
        private const string ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS = "5";
        private const string ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT = "1";
        private const string ACCEPTABLE_NUMBER_OF_INFANTS_WITH_ONE_ADULT = "1";
        private const string ERROR_MESSAGE_CHECK_IN = "Ваше бронирование не найдено. Пожалуйста, убедитесь, что код бронирования (PNR) введен корректно или обратитесь на стойку регистрации «Белавиа» в аэропорту.";

        [Test]
        public void EnterAcceptableMaxCountOfAdults()
        {
            Logger.Log.Info("Start EnterAcceptableMaxCountOfAdult test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddAdultsToTravellers(5);
            Assert.AreEqual(ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterOneInfantsWithOneAdults()
        {
            Logger.Log.Info("Start EnterOneInfantsWithOneAdults test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddInfantsToTravellers(2);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_INFANTS_WITH_ONE_ADULT, mainPage.GetCountOfInfants());
        }

        [Test]
        public void EnterOneInfantsWithoutAdults()
        {
            Logger.Log.Info("StartEnterOneInfantsWithoutAdults test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .OpenMoreInfoFields()
                .MoveToTravellers()
                .AddInfantsToTravellers(1)
                .MinusAdultsToTravellers(1);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterTheDateOfBirthOfTheChildForTheAdult()
        {
            Logger.Log.Info("Start EnterTheDateOfBirthOfTheChildForTheAdult test.");
            PassengersAndServicesPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillDateOfBirthAdultField(CreatingPassanger.OnlyDateofBirthChild());
            Assert.AreEqual("Должна быть от 16.01.1900 до 16.01.2008.", mainPage.GetTextErrorDateOfBirth());
        }

        [Test]
        public void EnterTheDateOfBirthOfTheAdultForTheInfant()
        {
            Logger.Log.Info("Start EnterTheDateOfBirthOfTheAdultForTheInfant test.");
            PassengersAndServicesPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
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
            Logger.Log.Info("Start SignInToAccount test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(CreatingSignIn.WithUserProperties());
            Assert.AreEqual("ARTSIOM SHKATULA", mainPage.TextSignInButton.Text);
        }

        [Test]
        public void EnterInvalidReservationCodeWhenViewingReservationStatus()
        {
            Logger.Log.Info("Start EnterInvalidReservationCodeWhenViewingReservationStatus test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .GoToTabReservationAndFill(CreatingReservationModel.WithReservationProperties());
            Assert.AreEqual("Бронирование не найдено", mainPage.ReservationErrorMessage.Text);
        }

        [Test]
        public void BookingATicketWithoutPhoneNumber()
        {
            Logger.Log.Info("Start BookingATicketWithoutPhoneNumber test.");
            PassengersAndServicesPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillInformationAboutPassanger(CreatingPassanger.WithoutPhoneNumber());
            Assert.AreEqual("Обязательно для заполнения.", mainPage.GetTextErrorPhoneNumber());
        }

        [Test]
        public void CheckingTheCorrectnessOfTheInputData()
        {
            Logger.Log.Info("Start CheckingTheCorrectnessOfTheInputData test.");
            PassengersAndServicesPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .FillFieldsSearch(CreatingSearch.WithAllProperties())
                .ClickSearchButton()
                .FillChoiceOfFlights()
                .FillInformationAboutPassanger(CreatingPassanger.WithAllProperties())
                .ClickButtonNextToFinishTab();
            CheckFieldsPage checkFieldsPage = new CheckFieldsPage(DriverSingleton.GetDriver());
            Assert.IsTrue(checkFieldsPage.CompareDisplayedDataWithInputData(CreatingPassanger.WithAllProperties()));
        }

        [Test]
        public void EnterInvalidReservationCodeWhenCheckingIn()
        {
            Logger.Log.Info("Start EnterInvalidReservationCodeWhenCheckingIn test.");
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .GoToTabRegestrationAndFill(CreatingReservationModel.WithReservationProperties());
            Assert.AreEqual(ERROR_MESSAGE_CHECK_IN, mainPage.RegestrationErrorMessage.Text);
        }
    }
}
