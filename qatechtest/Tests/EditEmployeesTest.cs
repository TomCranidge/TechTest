using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QATechTest
{
    [TestFixture]
    class EditEmployeesTest : Tests
    {
        
        //Selects the first employee in the employee list, then opens the edit page and updates the employee to reflect details provided in Data.xml. Verifys edited employee is displayed in List.
        [Test, Order(12)]
        public void ShouldUpdateUserDetails()
        {
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Setup.cDriver.FindElement(EmployeePage.EmployeeElement).Click();
            EmployeePage.EditUserPage();
            Helper.GetStaffDetails(16, 17, 18, 19);
            EditEmployeePage.UpdateUser(Helper.FirstName, Helper.LastName, Helper.StartDate, Helper.Email);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Assert.IsTrue(Helper.VerifyEmployee(EmployeePage.EmployeeList, Helper.FirstName, Helper.LastName));

        }
        // Creates user bases on details provided in Data.xml, amends first name to include "Delete" then finds created user, selects and opens edit page. Deletes user from Edit page and Verifies it is no longer present in List.
        [Test, Order(13)]
        public void  ShouldDeleteUser()
        {
            EmployeePage.CreateUserPage();
            Helper.GetStaffDetails(10, 11, 12, 13);
            CreateEmployeePage.CreateUser(("Delete" + Helper.FirstName), Helper.LastName, Helper.StartDate, Helper.Email);
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Helper.SearchEmployees(EmployeePage.EmployeeList, ("Delete" + Helper.FirstName), Helper.LastName);
            Setup.cDriver.FindElement(EmployeePage.EditButton).Click();
            Helper.WaitForElement(EditEmployeePage.DeleteButton);
            Setup.cDriver.FindElement(EditEmployeePage.DeleteButton).Click();
            Setup.cDriver.SwitchTo().Alert().Accept();
            Helper.WaitForElement(EmployeePage.EmployeeElement);
            Assert.IsFalse(Helper.VerifyEmployee(EmployeePage.EmployeeList, ("Delete" + Helper.FirstName), Helper.LastName));
        }
        // Searches Employee list for updated staff member from ShouldUpdateUserDetails and deletes them. Cleaning up for the test to be run again. 
        [OneTimeTearDown]
        public void CleanUp()
        {
            try
            {
                Helper.GetStaffDetails(16, 17, 18, 19);
                Helper.SearchEmployees(EmployeePage.EmployeeList, (Helper.FirstName), Helper.LastName);
                Setup.cDriver.FindElement(EmployeePage.EditButton).Click();
                Helper.WaitForElement(EditEmployeePage.DeleteButton);
                Setup.cDriver.FindElement(EditEmployeePage.DeleteButton).Click();
                Setup.cDriver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No Alert Present, Clean up not able to locate employee.");
            }
        }
    }
}
