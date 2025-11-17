using AdvanceProjectMars_Task5.BaseClass;
using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Notification.NotificationTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [Parallelizable]
    [TestFixture]
    public class Notification_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
            
            
        }
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Emailaddress != null && data.Password != null)
                {
                    yield return new TestCaseData(data.Emailaddress, data.Password);
                }

                else if (data.Emailaddress != null && data.Password != null && data.Notification != null && data.NewNotification != null)
                {
                    yield return new TestCaseData(data.Emailaddress, data.Password, data.Notification, data.NewNotification);
                }

                else if (data.searchSkill != null && data.selectSeller != null && data.selectSkill != null && data.messageToSeller != null && data.Emailaddress != null && data.Password != null && data.Sender != null)
                {
                    yield return new TestCaseData(data.searchSkill, data.selectSeller, data.selectSkill, data.messageToSeller, data.Emailaddress, data.Password, data.Sender);
                }
                
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Notification_SendSkillSwapRequest.json", "SendSkillSwapRequest" })]
        public void SendSkillSwapRequest(string searchSkill, string selectSeller, string selectSkill, string messageToSeller, string Emailaddress, string Password, string Sender)
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
            NotificationPage notificationPageObj = new NotificationPage();
            notificationPageObj.SendSkillSwapRequest(searchSkill, selectSeller, selectSkill, messageToSeller, Emailaddress, Password, Sender);
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Notification_LoadMoreandShowLess.json", "LoadMoreandShowLessNotification" })]
        public void LoadMoreandShowLessNotification(string Emailaddress, string Password, string Notification, string NewNotification)
        {
            NotificationPage notificationPageObj = new NotificationPage();
            notificationPageObj.NotificationLoadMoreandShowLess(Emailaddress, Password, Notification, NewNotification);
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Notification_MarkAllasRead.json", "MarkallasRead" })]
        public void MarkallasRead(string Emailaddress, string Password)
        {
            NotificationPage notificationPageObj = new NotificationPage();
            notificationPageObj.MarkAllAsRead(Emailaddress, Password);
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Notification_SelectandUnselect.json", "SelectandUnSelectNotification" })]
        public void SelectandUnSelectNotification(string Emailaddress, string Password)
        {
            NotificationPage notificationPageObj = new NotificationPage();
            notificationPageObj.SelectandUnselect(Emailaddress, Password);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
