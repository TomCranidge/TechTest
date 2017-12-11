using NUnit.Framework;

namespace QATechTest
{
    [TestFixture]
    class Tests
    {
        protected LogInPage pageTest;
        // Opens the login page for the website and logs in using the correct credentials provided in Data.xml file.
        [OneTimeSetUp]
        public virtual void Setuppage()
        {
            pageTest = new LogInPage();
            pageTest.PageLoad();
            Helper.GetLoginDetails(1,2);
            pageTest.LogIn(Helper.Username, Helper.Password);
        }
        // Closes the driver to end the test
        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
          Setup.cDriver.Quit();
        }


    }
}
