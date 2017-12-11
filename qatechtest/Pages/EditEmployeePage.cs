using OpenQA.Selenium;


namespace QATechTest
{
    class EditEmployeePage : EmployeeDetailsPage
    {
        //Elements

        //Update Button
        public static By UpdateButton
        {
            get
            {
                return By.CssSelector("body > div > div > div > form > fieldset > div > button:nth-child(1)");
            }
        }
        // Back Button
        public static IWebElement BackButton
        {
            get
            {
                IWebElement backButton = (Setup.cDriver.FindElements(By.Id("sub-nav"))[0])
                    .FindElement(By.TagName("a"));
                return backButton;
            }
        }

        //Delete Button
        public static By DeleteButton
        {
            get
            {
                return By.CssSelector("body > div > div > div > form > fieldset > div > p");
            }
        }

        // Methods

        // Edits User to hold new values
        public static void UpdateUser(string firstname, string lastname, string startdate, string email)
        {
            //Wait for Email Box
            Helper.WaitForElement(By.CssSelector("body > div > div > div > form > fieldset > label:nth-child(6) > input"));
            //Enter First Name
            FirstNameElement.Clear();
            FirstNameElement.SendKeys(firstname);
            //Enter Last Name
            LastNameElement.Clear();
            LastNameElement.SendKeys(lastname);
            //Enter Start Date      
            StartDateElement.Clear();
            StartDateElement.SendKeys(startdate);
            //Enter Email Address
            EmailElement.Clear();
            EmailElement.SendKeys(email);
            //Click update Button
            Setup.cDriver.FindElement(UpdateButton).Click();
        }
    }
}
