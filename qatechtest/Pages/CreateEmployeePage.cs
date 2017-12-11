using OpenQA.Selenium;


namespace QATechTest
{
    class CreateEmployeePage : EmployeeDetailsPage
    {
        //Elements

        //Add Button
        public static By AddButton
        {
            get
            {
                return By.CssSelector("body > div > div > div > form > fieldset > div > button:nth-child(2)");
            }
        }
        //Cancel Button
        public static IWebElement CancelButton
        {
            get
            {
                IWebElement cancelButton = (Setup.cDriver.FindElements(By.Id("sub-nav"))[1])
                    .FindElement(By.TagName("a"));
                return cancelButton;
            }
        }

        //Methods

        // Creates a user given a set of details
        public static void CreateUser(string firstname, string lastname, string startdate, string email)
        {
            //Wait for First Name Box
            Helper.WaitForElement(By.XPath("/html/body/div/div/div/form/fieldset/label[1]/input"));
            //Enter First Name
            FirstNameElement.SendKeys(firstname);
            //Enter Last Name
            LastNameElement.SendKeys(lastname);
            //Enter Start Date           
            StartDateElement.SendKeys(startdate);
            //Enter Email Address
            EmailElement.SendKeys(email);
            //Click Create Button
            Setup.cDriver.FindElement(AddButton).Click();
        }
    }
}