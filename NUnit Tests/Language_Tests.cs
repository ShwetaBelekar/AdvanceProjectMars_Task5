using AdvanceProjectMars_Task5.BaseClass;
using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Language.LanguageTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [Parallelizable]
    [TestFixture]
    
    public class Language_Tests : BaseTest
    {
        [SetUp]
        public void SetUpSteps()
        {
            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://localhost:5003/Home");
            //driver.Manage().Window.Maximize();
            LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
            HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
            homeToLanguagePageObj.NavigateToLanguage();
        }
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Language != null && data.Level != null && data.DuplicateLanguage != null && data.DuplicateLevel != null)
                {
                    yield return new TestCaseData(data.Language, data.Level, data.DuplicateLanguage, data.DuplicateLevel);
                }
                else if (data.Language != null && data.Level != null && data.NewLanguage != null && data.NewLevel != null)
                {
                    yield return new TestCaseData(data.Language, data.Level, data.NewLanguage, data.NewLevel);
                }
                else if (data.Language != null && data.Level != null && data.EditLanguage != null)
                {
                    yield return new TestCaseData(data.Language, data.Level, data.EditLanguage);
                }
                else if (data.Language != null && data.Level != null)
                {
                    yield return new TestCaseData(data.Language, data.Level);
                }

            }
        }
       
        private bool isDataDrivenTest = false;
        private int dataDrivenTestCount = 0;
        private int totalTestCases = 0;
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_validlanguageandlevel.json", "Createvalidlanguageandlevelrecord" })]
        public void Createvalidlanguageandlevelrecord(string Language, string Level)
        {
            isDataDrivenTest = true;
            dataDrivenTestCount++;
            totalTestCases = GetTestData("language_validlanguageandlevel.json", "Createvalidlanguageandlevelrecord").Count();
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

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
            isDataDrivenTest = true;
            dataDrivenTestCount++;
            totalTestCases = GetTestData("language_invalidlanguage.json", "Createinvalidlanguageandlevelrecord").Count();
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

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
            isDataDrivenTest = true;
            dataDrivenTestCount++;
            totalTestCases = GetTestData("language_ifusercanaddmorethanfourlanguage.json", "Ifusercanaddmorethanfourlanguage").Count();
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.Addmorethanfourlanguage(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_blanklanguage.json", "Createblanklanguagerecord" })]
        public void Createblanklanguagerecord(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);

            if (popupAlert.Text == "Please enter language and level")
            {
                Assert.Pass("Blank language record not accepted");
            }
            else
            {
                Assert.Fail("Blank language record accepted");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_blanklevel.json", "Createblanklevelrecord" })]
        public void Createblanklevelrecord(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);

            if (popupAlert.Text == "Please enter language and level")
            {
                Assert.Pass("Blank level record not accepted");
            }
            else
            {
                Assert.Fail("Blank level record accepted");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_duplicatelanguageandlevelrecord.json", "Createduplicatelanguageandlevelrecord" })]
        public void Createduplicatelanguageandlevelrecord(string Language, string Level, string DuplicateLanguage, string DuplicateLevel)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }

            languagePageObj.CreateDuplicateLanguageRecord(DuplicateLanguage, DuplicateLevel);
            Console.WriteLine($"Selected {DuplicateLanguage} {DuplicateLevel}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement ppopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string prromptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + prromptText);
            if (ppopupAlert.Text == "This language is already exist in your language list.")
            {
                Assert.Pass("Duplicate record not accepted");
            }
            else
            {
                Assert.Fail("Duplicate record accepted");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_Cancellinganeditoperationshouldnotkeeptheunnecessarydatainthesystem.json", "Cancelaneditoperationshouldcorrectlydiscardthedata" })]
        public void Cancelaneditoperationshouldcorrectlydiscardthedata(string Language, string Level, string EditLanguage)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(6000);
            IWebElement newLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newLanguage.Text == Language && newLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }

            languagePageObj.CancellingEditOperation(EditLanguage);
            Console.WriteLine($"Selected {EditLanguage}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement ppopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string prromptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + prromptText);
            if (ppopupAlert.Text == "English has been updated to your languages")
            {
                Assert.Pass("Cancelling an edit operation should discard the data but the system is not doing this language should be German but here it show English");
            }
            else
            {
                Assert.Fail("Cancelling an edit operation should discard the data yes the system is doing this");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_editexistinglanguagerecord.json", "Editexistinglanguageandlevelrecord" })]
        public void Editexistinglanguageandlevelrecord(string Language, string Level, string NewLanguage, string NewLevel)
        {
            isDataDrivenTest = true;
            dataDrivenTestCount++;
            totalTestCases = GetTestData("language_editexistinglanguagerecord.json", "Editexistinglanguageandlevelrecord").Count();
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement createLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement createLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (createLanguage.Text == Language && createLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            languagePageObj.editExistingLanguageRecord(NewLanguage, NewLevel);
            Console.WriteLine($"Selected {NewLanguage} {NewLevel}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string proomptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);
            Wait.WaitToBeClickable(driver.Value, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement editLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement editLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (editLanguage.Text == NewLanguage && editLevel.Text == NewLevel)
            {
                Assert.Pass("edited language is updated successfully");
            }
            else
            {
                Assert.Fail("edited language is not updated");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "language_deleteexistinglanguagerecord.json", "Deleteexistinglanguageandlevelrecord" })]
        public void Deleteexistinglanguageandlevelrecord(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.CreateLanguageRecord(Language, Level);
            Console.WriteLine($"Selected {Language} {Level}");
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement createLanguage = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement createLevel = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (createLanguage.Text == Language && createLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            languagePageObj.deleteExistingLanguageRecord();
            Console.WriteLine($"Selected {Language} {Level}");

            bool testPassed = false;
            try
            {
                Wait.WaitToBeVisible(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 4);
                IWebElement poopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string proomptText = poopupAlert.Text;
                Console.WriteLine("Alert text: " + proomptText);
                testPassed = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);

            }
            if (testPassed)
            {
                Assert.Pass("Test pass");
            }
            else
            {
                Assert.Fail("Test failed");
            }


        }

        [TearDown]
        public new void TearDown()
        {
            if (isDataDrivenTest)
            {
                if (dataDrivenTestCount == totalTestCases)
                {
                    try
                    {
                        HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
                        homeToLanguagePageObj.NavigateToLanguage();
                        Thread.Sleep(2000);
                        var deleteButtons = driver.Value.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                        for (int i = deleteButtons.Count - 1; i >= 0; i--)
                        {
                            deleteButtons[i].Click(); 
                            Thread.Sleep(2000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error during cleanup: {ex.Message}");
                    }
                    isDataDrivenTest = false;
                    dataDrivenTestCount = 0;
                }
            }
            else
            {
                try
                {
                    HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
                    homeToLanguagePageObj.NavigateToLanguage();
                    Thread.Sleep(2000);
                    var deleteButtons = driver.Value.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }
            }
            base.TearDown();

        }

       





    }
}
