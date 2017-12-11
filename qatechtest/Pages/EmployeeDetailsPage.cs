using OpenQA.Selenium;


namespace QATechTest
{
    class EmployeeDetailsPage
    {
        //Elements

        //LogoutButton
        public static IWebElement LogOutButton
        {
            get
            {
                return Setup.cDriver.FindElement(By.CssSelector("body > div > header > div > p.main-button"));               
            }
        }
        //FirstName
        public static IWebElement FirstNameElement
        {
            get
            {
                return Setup.cDriver.FindElement(By.CssSelector("body > div > div > div > form > fieldset > label:nth-child(3) > input"));               
            }
        }
        //LastName
        public static IWebElement LastNameElement
        {
            get
            {
                return Setup.cDriver.FindElement(By.CssSelector("body > div > div > div > form > fieldset > label:nth-child(4) > input"));
            }
        }
        //StartDate
        public static IWebElement StartDateElement
        {
            get
            {
               return Setup.cDriver.FindElement(By.CssSelector("body > div > div > div > form > fieldset > label:nth-child(5) > input"));                
            }
        }
        //Email
        public static IWebElement EmailElement
        {
            get
            {
                return Setup.cDriver.FindElement(By.CssSelector("body > div > div > div > form > fieldset > label:nth-child(6) > input"));                
            }

        }



    }


}
