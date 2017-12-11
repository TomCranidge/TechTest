using OpenQA.Selenium;


namespace QATechTest
{
    class LogInPage
    {
        private static IWebDriver _driver = Setup.cDriver;

        //Elements

        // Username Element
        public static IWebElement UsernameElement
        {
            get
            {
                IWebElement usernameElement = _driver.FindElement(By.CssSelector("#login-form > fieldset > label:nth-child(3) > input"));
                return usernameElement;
            }
        }
        // Password Element
        public static IWebElement PasswordElement
        {
            get
            {
                IWebElement passwordElement = _driver.FindElement(By.CssSelector("#login-form > fieldset > label:nth-child(4) > input"));
                return passwordElement;
            }
        }
        // Login Button
        public static IWebElement LoginButton
        {
            get
            {
                IWebElement loginButton = _driver.FindElement(By.CssSelector("#login-form > fieldset > button"));
                return loginButton;
            }
        }

        // Methods

        // Opens the webpage and navigates to the url specified by the GetURL function (3: Login page in Data.xml)
        public void PageLoad()
        {
            Helper.GetURL(3);
            _driver.Navigate().GoToUrl(Helper.URL);
        }

        //Passed provided user credentials into appropreate fields, then attempts log in
        public void LogIn(string username, string pwd)
        {
            Helper.WaitForElement(By.CssSelector("#login-form > fieldset > label:nth-child(4) > input"));
            UsernameElement.SendKeys(username);
            PasswordElement.SendKeys(pwd);
            LoginButton.Click();
        }
    }
}

