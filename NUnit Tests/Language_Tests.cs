using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.Chrome;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Language.LanguageTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    public class Language_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
            HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
            homeToLanguagePageObj.NavigateToLanguage();
        }
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Language != null && data.Level != null)
                {
                    yield return new TestCaseData(data.Language, data.Level);
                }
                
            }
        }
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    if (!testData.ContainsKey(testName))
        //    {
        //        throw new ArgumentException($"Test data not found for test name: {testName}");
        //    }

        //    return testData[testName]
        //        .Where(data => data.Language != null && data.Level != null)
        //        .Select(data => new TestCaseData(data.Language, data.Level));
        //}
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_validlanguageandlevel.json", "Createvalidlanguageandlevelrecord" })]
        public void Createvalidlanguageandlevelrecord(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_invalidlanguage.json", "Createinvalidlanguageandlevelrecord" })]
        public void Createinvalidlanguageandlevelrecord(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Assert.Pass("System is accepting invalid data, which is incorrect.");
            }
            else
            {
                Assert.Fail("System is not accepting invalid data, which is correct.");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_ifusercanaddmorethanfourlanguage.json", "Ifusercanaddmorethanfourlanguage" })]
        public void Ifusercanaddmorethanfourlanguage(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.Addmorethanfourlanguage(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }
        }
    }
}
