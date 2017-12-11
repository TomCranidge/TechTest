using NUnit.Framework;
using OpenQA.Selenium;

namespace QATechTest
{
    [TestFixture]
    class CreateEmployeePageTest : Tests
    {

        // Creates a new employee based on data provided in Data.xml, then verifies that the employee exists in the employee list.
        [Test, Order(11)]
        public void ShouldCreateNewStaff()
        {
            EmployeePage.CreateUserPage();
            Helper.GetStaffDetails(10, 11, 12, 13);
            CreateEmployeePage.CreateUser(Helper.FirstName, Helper.LastName, Helper.StartDate, Helper.Email);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Assert.IsTrue(Helper.VerifyEmployee(EmployeePage.EmployeeList, Helper.FirstName, Helper.LastName));
        }
        // Attmepts to create a new employee with an invalid Email provided in Data.xml
        [Test]
        public void InvalidEmailCreate()
        {
            ShouldNotCreateNewStaff(10, 11, 21, 13);
        }
        // Attmepts to create a new employee with an invalid start date provided in Data.xml
        [Test]
        public void InvalidStartDateCreate()
        {
            ShouldNotCreateNewStaff(10, 11, 12, 22);
        }
        // Attmepts to create a new employee with an empty first name provided in Data.xml
        [Test]
        public void EmptyFirstName()
        {
            ShouldNotCreateNewStaff(23, 11, 12, 13);
        }
        // Attmepts to create a new employee with an empty last name provided in Data.xml
        [Test]
        public void EmptyLastName()
        {
            ShouldNotCreateNewStaff(10, 24, 12, 13);
        }
        // Removes the employee created in the should ShouldCreateNewStaff method, this unfortunately means the GetStaffDetails would need to change if a change was made to the ShouldCreateNewStaff method.
        [OneTimeTearDown]
        public void CleanUp()
        {
            Helper.GetStaffDetails(10, 11, 12, 13);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Helper.SearchEmployees(EmployeePage.EmployeeList, (Helper.FirstName), Helper.LastName);
            EmployeePage.DeleteUser();
        }
        
        // Attemps to create a staff member with the assumtion that it will fail due to invalid or incomplete data. 
        public void ShouldNotCreateNewStaff(int un, int pw, int startdate, int email)
        {
            try
            {
                EmployeePage.CreateUserPage();
                Helper.GetStaffDetails(un, pw, startdate, email);
                string currentURL = Setup.cDriver.Url;
                CreateEmployeePage.CreateUser(Helper.FirstName, Helper.LastName, Helper.StartDate, Helper.Email);
                Helper.GetURL(14);
                Assert.AreEqual(currentURL, Helper.URL);
                Setup.cDriver.Navigate().Back();
            }
            catch(UnhandledAlertException)
            {
                Setup.cDriver.SwitchTo().Alert().Accept();
                Setup.cDriver.Navigate().Back();
            }

        }
        
    }
}
