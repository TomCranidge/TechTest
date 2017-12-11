using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Reflection;

namespace QATechTest
{
    class Helper
    {
        // Setup for the tests, publicly available throughout the solution.
        public static string Username;
        public static string Password;
        public static string FirstName;
        public static string LastName;
        public static string StartDate;
        public static string Email;
        public static string URL;

        // Waits for the element to be present
        public static void WaitForElement(By waitElement)
        {
            new WebDriverWait(Setup.cDriver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"]))).Until(ExpectedConditions.ElementExists(waitElement));
        }
        // Checks for specified element on the webpage
        public static bool elementexists(By Element)
        {
            bool elementDisplayed;
            try
            {
                Setup.cDriver.FindElement(Element);
                elementDisplayed = true;
            }
            catch (NoSuchElementException)
            {
                elementDisplayed = false;
            }
            return elementDisplayed;
        }
        // Gets username and password from Data.XML (used for both Valid and Invalid details)
        public static void GetLoginDetails(int UserIndex, int PassIndex)
        {
            Username = "";
            Password = "";
            try
            {
                XmlDocument XMLFile = new XmlDocument();
                XMLFile.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config\\Data.xml");

                XmlNode credentials = XMLFile.SelectSingleNode("Config");
                Username = credentials.ChildNodes[UserIndex].InnerText;
                Password = credentials.ChildNodes[PassIndex].InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read Config/Data.xml file: " + e.Message);
                return;
            }
        }
        // Gets test staff details from Data.XML (used for both Valid and Invalid details)
        public static void GetStaffDetails(int FNameIndex, int LNameIndex, int DateIndex, int EmailIndex)
        {
            FirstName = "";
            LastName = "";
            StartDate = "";
            Email = "";

            try
            {
                XmlDocument XMLFile = new XmlDocument();
                XMLFile.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config\\Data.xml");

                XmlNode details = XMLFile.SelectSingleNode("Config");
                FirstName = details.ChildNodes[FNameIndex].InnerText;
                LastName = details.ChildNodes[LNameIndex].InnerText;
                StartDate = details.ChildNodes[DateIndex].InnerText;
                Email = details.ChildNodes[EmailIndex].InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read Config/Data.xml file: " + e.Message);
                return;
            }
        }
        // Gets the URL for a specified page
        public static void GetURL(int UrlIndex)
        {
            URL = "";
            try
            {
                XmlDocument XMLFile = new XmlDocument();
                XMLFile.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config\\Data.xml");
                XmlNode urls = XMLFile.SelectSingleNode("Config");
                URL = urls.ChildNodes[UrlIndex].InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read Config/Data.xml file: " + e.Message);
                return;
            }            
        }
        // Searches for an employee in the employee list, using provided firstname and last name.
        public static void SearchEmployees(By searchElement, string firstname, string lastname)
        {
            var employeelist = Setup.cDriver.FindElement(searchElement);
            var staffList = employeelist.FindElements(By.TagName("li"));
            string search = (firstname + " " + lastname).ToString();
            foreach (IWebElement staffmember in staffList)
            {
                if (staffmember.Text == search)
                {
                   var staff = staffmember;
                    staff.Click();
                }
            }
        }
        // Checks that there is an employee in the list with a specified Name. 
        public static bool VerifyEmployee(By searchElement, string firstname, string lastname)
        {
            var employeelist = Setup.cDriver.FindElement(searchElement);
            var staffList = employeelist.FindElements(By.TagName("li"));
            string search = (firstname + " " + lastname).ToString();
            bool located = false;
            foreach (IWebElement staffmember in staffList)
            {
                if (staffmember.Text == search)
                {
                    located = true;
                }
            }
            return located;
        }
    }
}
