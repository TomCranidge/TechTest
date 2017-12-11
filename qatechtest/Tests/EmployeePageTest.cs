using NUnit.Framework;
using OpenQA.Selenium;

namespace QATechTest
{

    [TestFixture]
    class EmployeePageTest : Tests
    {
        EmployeePage testingpage;
        // Clicks on the create button
        [Test, Order(7)]
        public void ShouldOpenCreatePage()
        {
            EmployeePage.CreateUserPage();
            Helper.GetURL(14);
            string currentURL = Setup.cDriver.Url;
            Assert.AreEqual(currentURL, Helper.URL);
            Setup.cDriver.Navigate().Back();
        }
        // Creates a user based on details provided by Data.xml then attempts to select and delete that user from the employee list, finally verifying if the user is present in the employee list.
        // Note: Currently failing due to display issue on website when deleting staff. (Staff member will remain present after selecting and clicking delete on employee page)
        [Test, Order(14)]
        public void DeleteUserFromList()
        {
            EmployeePage.CreateUserPage();
            Helper.GetStaffDetails(10, 11, 12, 13);
            CreateEmployeePage.CreateUser(("Delete" + Helper.FirstName), Helper.LastName, Helper.StartDate, Helper.Email);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Helper.SearchEmployees(EmployeePage.EmployeeList, ("Delete" + Helper.FirstName), Helper.LastName);
            EmployeePage.DeleteUser();
            Assert.IsFalse(Helper.VerifyEmployee(EmployeePage.EmployeeList, ("Delete" + Helper.FirstName), Helper.LastName));
        }
        // Selects the first employee in the list and opens the edit page, verifying that the update button is present.
        [Test, Order(15)]
        public void OpenEditPage()
        {
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Setup.cDriver.FindElement(EmployeePage.EmployeeElement).Click();
            EmployeePage.EditUserPage();
            Helper.WaitForElement(EditEmployeePage.UpdateButton);
            Assert.IsTrue(Helper.elementexists(EditEmployeePage.UpdateButton));
            Setup.cDriver.Navigate().Back();
        }
        // Clicks the Back button on the page then checks that the user has been navigated back to the Employees Page (8 = http://cafetownsend-angular-rails.herokuapp.com/employees from XML file)
        [Test, Order(9)]
        public void ShouldGoBackFromEdit()
        {
            Helper.WaitForElement(By.CssSelector("#employee-list > li:nth-child(3)"));
            Setup.cDriver.FindElement(EmployeePage.EmployeeElement).Click();
            Setup.cDriver.FindElement(EmployeePage.EditButton).Click();
            Helper.WaitForElement(By.CssSelector("body > div > div > div > form > fieldset > div > p"));
            EditEmployeePage.BackButton.Click();
            string currentURL = Setup.cDriver.Url;
            Helper.GetURL(8);
            Assert.AreEqual(currentURL, Helper.URL);

        }
        // Clicks the cancel button on the page then checks that the user has been navigated back to the Employees Page (8 = http://cafetownsend-angular-rails.herokuapp.com/employees from XML file)
        [Test, Order(10)]
        public void ShouldGoBackFromCreate()
        {
            Helper.WaitForElement(By.CssSelector("#employee-list > li:nth-child(3)"));
            Setup.cDriver.FindElement(EmployeePage.CreateButton).Click();
            Helper.WaitForElement(By.CssSelector("body > div > div > div > form > fieldset > div > button:nth-child(2)"));
            CreateEmployeePage.CancelButton.Click();
            string currentURL = Setup.cDriver.Url;
            Helper.GetURL(8);
            Assert.AreEqual(currentURL, Helper.URL);
        }


    }
}
