using NUnit.Framework;
using OpenQA.Selenium;

namespace QATechTest
{

    [TestFixture]
    class LogInPageTest : Tests
    {
        LogInPage pagetest;
        // Sets up a new login page and loads the login page
        [SetUp]
        public override void Setuppage()
        {
            pagetest = new LogInPage();
            pagetest.PageLoad();
        }
        // Passes in the correct login details from Data.xml file, verifies login by presence of employee list.
        [Test, Order(2)]
        public void ShouldLogIn()
        {
            Helper.GetLoginDetails(1, 2);
            pagetest.LogIn(Helper.Username, Helper.Password);
            Helper.WaitForElement(By.Id("employee-list-container"));
            Assert.IsTrue(Helper.elementexists(By.CssSelector("#employee-list-container")));
        }
        // Attempts to pass both incorrect user and password to a login attempt.
        [Test, Order(1)]
        public void IncorrectUserLogin()
        {
            ShouldNotLogIn(5, 6);
        }
        // Attempts a log in with a blank username
        [Test]
        public void NoUserNameLogin()
        {
            ShouldNotLogIn(24, 2);
        }
        // Attempts a log in with a blank password
        [Test]
        public void NoPasswordLogin()
        {
            ShouldNotLogIn(1, 24);
        }
        // Clients a logout button present on all logged in pages, and verifies that the user is returned to the login URL.
        [Test, Order(9)]
        public void ShouldLogOut()
        {
            Helper.GetLoginDetails(1, 2);
            pagetest.LogIn(Helper.Username, Helper.Password);
            Helper.WaitForElement(EmployeePage.EmployeeList);
            IWebElement logOutButton = Setup.cDriver.FindElement(By.CssSelector("body > div > header > div > p.main-button"));
            logOutButton.Click();
            string currentURL = Setup.cDriver.Url;
            Helper.GetURL(3);
            Assert.AreEqual(currentURL, Helper.URL);
        }
        // Passes in an incorrect set of log in details, attempts to login and verifies that the employeelist is not present.
        public void ShouldNotLogIn(int un, int pw)
        {
            Helper.GetLoginDetails(un, pw);
            pagetest.LogIn(Helper.Username, Helper.Password);
            Assert.IsFalse(Helper.elementexists(By.Id("employee-list-container")));
        }
    }
}
