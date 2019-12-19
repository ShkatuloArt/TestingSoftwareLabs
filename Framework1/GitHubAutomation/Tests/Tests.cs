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
    }
}
