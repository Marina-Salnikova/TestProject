using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace TestProject
{
    public class UserPageOjects
    {
        public string newUserBtn = "#new-user-btn";
        public string userNameField = "#username";
        public string emailField = "#email";
        public string approvedCheckbox = "#approved";
        public string passwordField = "#password";
        public string confirmPasswordField = "#password-2";
        public string submitBtn = "input[type='submit']";
        public string saveBtn = ".save";
        public string deleteBtn = "#delete-user-btn";
        public string accountMenu = "#AccountMenu";
        public string userNameInTable = "#usertable [data-bind$='userName']";
        public string editUserBtn = "#usertable [title='Edit']";
        public string usertable = "#usertable";

        public void Login(string username, string password,ChromeDriver crome)
        {
            FillUserName(username, crome); 
            FillPassword(password, crome);
            Submit(crome);
            WaitForLoadingPage(crome);
        }

        public void OpenCreateUserForm(ChromeDriver crome)
        {
            IWebElement CreateUserBtn = crome.FindElementByCssSelector(newUserBtn);
            CreateUserBtn.Click();
        }

        public void OpenEditUserForm(int indexOfUser, ChromeDriver crome)
        {
            IWebElement EditUserBtn = crome.FindElementsByCssSelector(editUserBtn)[indexOfUser];
            EditUserBtn.Click();
        }

        public void FillUserName(string username, ChromeDriver crome)
        {
            IWebElement UserName = crome.FindElementByCssSelector(userNameField);
            UserName.SendKeys(username);
        }
        public void FillPassword(string password, ChromeDriver crome, bool confirm=false)
        {
            IWebElement Password = crome.FindElementByCssSelector(confirm ? confirmPasswordField : passwordField);
            Password.SendKeys(password);
        }

        public void FillEmail(string useremail, ChromeDriver crome)
        {
            IWebElement Email = crome.FindElementByCssSelector(emailField);
            Email.Click();
            Email.Clear();
            Email.SendKeys(useremail);
        }

        public void SetApproved(ChromeDriver crome)
        {
            IWebElement Approved = crome.FindElementByCssSelector(approvedCheckbox);
            Approved.Click();
        }

        public void Submit(ChromeDriver crome)
        {
            IWebElement SubmitBtn = crome.FindElementByCssSelector(submitBtn);
            SubmitBtn.Click();
        }

        public void SaveUser(ChromeDriver crome)
        {
            IWebElement SubmitBtn = crome.FindElementByCssSelector(saveBtn);
            SubmitBtn.Click();
            crome.FindElementByCssSelector(".message-table"); 
        }

        public void DeleteUser(ChromeDriver crome)
        {
            IWebElement SubmitBtn = crome.FindElementByCssSelector(deleteBtn);
            SubmitBtn.Click();
            crome.SwitchTo().Alert().Accept();
            crome.FindElementByCssSelector(".message-table");
        }

        public int IndexOfUserInTable(string userename, ChromeDriver crome)
        {
            var users = crome.FindElementsByCssSelector(userNameInTable);
            for (int i = 0; i < users.Count; i++)
                if (users[i].Text == userename)
                    return i;
            return -1;
        }

        public void WaitForLoadingPage(ChromeDriver crome) 
        {
            WebDriverWait wait = new WebDriverWait(crome, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(accountMenu)));
        }

        public void CreateNewUser(string user,string password, ChromeDriver crome)
        {
            OpenCreateUserForm(crome);
            FillUserName(user, crome);
            FillPassword(password, crome);
            FillPassword(password, crome, true);
            SaveUser(crome);
        }
    }
}
