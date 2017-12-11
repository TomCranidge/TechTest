using OpenQA.Selenium;
using System;

namespace QATechTest
{
    class EmployeePage
    {
        //Elements

        // Create Element
        public static By CreateButton
        {
            get
            {
                return By.Id("bAdd");   
            }
        }
        // Edit Element
        public static By EditButton
        {
            get
            {
               return By.Id("bEdit");
            }
        }
        // Delete Button
        public static By DeleteButton
        {
            get
            {
                return By.Id("bDelete");
            }
        }

        // Logout Button
        public static By LogOutButton
        {
            get
            {
                return By.CssSelector("body > div > header > div > p.main-button");
            }
        }

        // Employee Element
        public static By EmployeeElement
        {
            get
            {
                return By.CssSelector("#employee-list > li:nth-child(1)"); 
            }
        }
        // Employee List
        public static By EmployeeList
        {
            get
            {
                return By.Id("employee-list");
            }
        }


        // Methods

        // Waits for the "create" button on the page to be present then clicks the create button.
        public static void CreateUserPage()
        {
            Helper.WaitForElement(CreateButton);
            Setup.cDriver.FindElement(CreateButton).Click();
        }
        // Attempts to edit a user based on First Name and Last Name provided.
        public static void EditUserPage()
        {
            Helper.WaitForElement(EmployeeList);
            Helper.SearchEmployees(EmployeeList, Helper.FirstName, Helper.LastName);
            Setup.cDriver.FindElement(EditButton).Click();
        }
        // Attempts to delete a user based on First Name and Last Name provided.
        public static void DeleteUser()
        {
            try
            {
                Helper.WaitForElement(EmployeeList);
                Helper.SearchEmployees(EmployeeList, Helper.FirstName, Helper.LastName);
                Setup.cDriver.FindElement(DeleteButton).Click();
                Setup.cDriver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No Alert Present, Clean up not able to locate employee.");
            }

        }





    }
}
