using System.Reflection;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace QATechTest
{
    class Setup
    {
        // Creating a chrome driver.
        public static IWebDriver cDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        // Sets the webpage to the login page for the site if there is no webpage provided, otherwise navigates to the provided webpage.
        public static void SetWebpage(string WebPage)
        {

            if (WebPage == "")
            {
                cDriver.Navigate().GoToUrl("http://cafetownsend-angular-rails.herokuapp.com/login");
            }
            else
            {
                cDriver.Navigate().GoToUrl(WebPage);

            }

        }



    }
}

