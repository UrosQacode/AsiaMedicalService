using MedicalService.Driver;
using MedicalService.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalService.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;
        string AssertText = "Login failed! Please ensure the username and password are valid.";
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();    

        }

        [TearDown]

        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_EnterInvalidUserName_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("Uros", "ThisIsNotAPassword");
            Assert.That(AssertText,  Is.EqualTo(loginPage.UserNotLogin.Text));

            
        }
        [Test]
        public void TC02_EnterInvalidPassword_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "Uros");
            Assert.That(AssertText, Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC03_EnterNoData_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login(" ", " ");
            Assert.That(AssertText, Is.EqualTo(loginPage.UserNotLogin.Text));
        }
    }
}
    


