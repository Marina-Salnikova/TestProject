using NUnit.Framework;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace TestProject
{
    [TestFixture]
    [Category("UITests")]
    [Parallelizable]
    public class UITests : UserPageOjects
    {
        readonly ChromeDriver crome = new ChromeDriver();
        string TestUrl = ConfigurationManager.AppSettings["TestUrl"];
        string TestUserLogin = ConfigurationManager.AppSettings["TestUserLogin"];
        string TestUserPassword = ConfigurationManager.AppSettings["TestUserPassword"];

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            crome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            crome.Navigate().GoToUrl(TestUrl);
            Login(TestUserLogin, TestUserPassword, crome);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            crome.Navigate().GoToUrl(TestUrl);
            WaitForLoadingPage(crome);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            crome.Quit();
        }


        [Test()]
        public void TestCreatingUser()
        {
            //creating of random user
            string password = Helpers.RandomString(10);
            string user = Helpers.RandomString(10)+"@gmail.com";
            CreateNewUser(user, password, crome);

            //then check that new user is creared
            Assert.GreaterOrEqual(IndexOfUserInTable(user, crome), 0, "Created user is not found.");
        }

        [Test()]
        public void TestDeletingUser()
        {
            //preparing data for the test
            //creating of random user
            string password = Helpers.RandomString(10);
            string user = Helpers.RandomString(10) + "@gmail.com";
            CreateNewUser(user, password, crome);

            //then we want to delete the same user
            int index = IndexOfUserInTable(user, crome);
            if (index > -1)
            {
                OpenEditUserForm(index, crome);
                DeleteUser(crome);

                //then check that user is deleted
                Assert.AreEqual(-1, IndexOfUserInTable(user, crome), "User is not deleted.");
            }
            else
                Assert.Fail("Test user is not found.");
        }
    }
}
