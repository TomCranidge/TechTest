using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace QATechTest
{
    [TestFixture]
    class SecurityTest : Tests
    {
        
        // Blank set up to avoid using the log in set up from base class
        [SetUp]
        public override void Setuppage()
        {
            
        }
        // Attempts to navigate to the employee page without logging in
        [Test, Order(4)]
        public static void NoCredsEmployeePage()
        {
            TestPageWithoutLogin(8);
        }
        // Attempts to navigate to the create employee page without logging in
        [Test, Order(5)]
        public static void NoCredsCreatePage()
        {
            TestPageWithoutLogin(14);
        }
        // Opens the employee edit page for the first employee in the list, saves that url, logs out and then attempts to navigate back to the saved url.
        [Test, Order(6)]
        public void NoCredsEditPage()
        {
            pageTest = new LogInPage();
            pageTest.PageLoad();
            Helper.GetLoginDetails(1, 2);
            pageTest.LogIn(Helper.Username, Helper.Password);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Setup.cDriver.FindElement(EmployeePage.EmployeeElement).Click();
            Setup.cDriver.FindElement(EmployeePage.EditButton).Click();
            Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["SleepTimeout"]));
            string employeeURL = Setup.cDriver.Url;
            IWebElement logOutButton = Setup.cDriver.FindElement(By.CssSelector("body > div > header > div > p.main-button"));
            logOutButton.Click();
            Setup.SetWebpage(employeeURL);
            Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["SleepTimeout"]));
            string currentURL = Setup.cDriver.Url;
            Helper.GetURL(3);
            Assert.AreEqual(currentURL, Helper.URL);

        }
        // Attempts to navigate to the provided URL location without logging in.
        public static void TestPageWithoutLogin(int urlLocatotion)
        {
            Helper.GetURL(urlLocatotion);
            Setup.SetWebpage(Helper.URL);
            Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["SleepTimeout"]));
            string currentURL = Setup.cDriver.Url;
            Helper.GetURL(3);
            Assert.AreEqual(currentURL, Helper.URL);
        }


    }

}
