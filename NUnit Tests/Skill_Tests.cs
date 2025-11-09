using AdvanceProjectMars_Task5.BaseClass;
using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Skill.SkillTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    [Category("Skill")]
    public class Skill_Tests : BaseTest
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
            HomeToSkillPage homeToSkillPageObj = new HomeToSkillPage();
            homeToSkillPageObj.NavigateToSkill();
        }
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Skill != null && data.Level != null && data.NewSkill != null && data.NewLevel != null)
                {
                    yield return new TestCaseData(data.Skill, data.Level, data.NewSkill, data.NewLevel);
                }
                else if (data.Skill != null && data.Level != null && data.EditSkill != null)
                {
                    yield return new TestCaseData(data.Skill, data.Level, data.EditSkill);
                }
                else if (data.Skill != null && data.Level != null)
                {
                    yield return new TestCaseData(data.Skill, data.Level);
                }

            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_validskillandlevel.json", "Createvalidskillandlevelrecord" })]
        public void Createvalidskillandlevelrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newSkill.Text == Skill && newLevel.Text == Level)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }

        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_invalidskillandlevel.json", "Createinvalidskillandlevelrecord" })]
        public void Createinvalidskillandlevelrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newSkill.Text == Skill && newLevel.Text == Level)
            {
                Assert.Pass("System is accepting invalid data, which is incorrect.");
            }
            else
            {
                Assert.Fail("System is not accepting invalid data, which is correct.");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_blankskill.json", "Createblankskillrecord" })]
        public void Createblankskillrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (popupAlert.Text == "Please enter skill and experience level")
            {
                Assert.Pass("Blank skill record not accepted");
            }
            else
            {
                Assert.Fail("Blank skill record accepted");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_blanklevel.json", "Createblanklevelrecord" })]
        public void Createblanklevelrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (popupAlert.Text == "Please enter skill and experience level")
            {
                Assert.Pass("Blank level record not accepted");
            }
            else
            {
                Assert.Fail("Blank level record accepted");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_duplicateskillandlevel.json", "Createduplicateskillrecord" })]
        public void Createduplicateskilllrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            Thread.Sleep(3000);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newSkill.Text == Skill && newLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string prromptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + prromptText);
            if (poopupAlert.Text == "This skill is already exist in your skill list.")
            {
                Assert.Pass("Duplicate record not accepted");
            }
            else
            {
                Assert.Fail("Duplicate record accepted");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_editexistingskillandlevel.json", "Editexistingskillandlevelrecord" })]
        public void Editexistingskillandlevelrecord(string Skill, string Level, string NewSkill, string NewLevel)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement CreatedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement CreatedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (CreatedSkill.Text == Skill && CreatedLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            skillPageObj.EditSkillRecord(NewSkill, NewLevel);
            Console.WriteLine($"Selected {NewSkill} {NewLevel}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string proomptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);
            IWebElement EditedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement EditedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (EditedSkill.Text == NewSkill && EditedLevel.Text == NewLevel)
            {
                Assert.Pass("record edited successfully");
            }
            else
            {
                Assert.Fail("record edited unsuccessful");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_cancellingeditoperation.json", "Cancelaneditoperationshouldcorrectlydiscardthedata" })]
        public void Cancelaneditoperationshouldcorrectlydiscardthedata(string Skill, string Level, string EditSkill)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newSkill.Text == Skill && newLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            skillPageObj.CancellingAnEditOperation(EditSkill);
            Console.WriteLine($"Selected {EditSkill}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement ppopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string ppromptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + ppromptText);
            if (ppopupAlert.Text == "Calligraphy has been updated to your skills")
            {
                Assert.Pass("Cancelling an edit operation should discard the data but the system is not doing this Skill should be Yoga but here it show Calligraphy");
            }
            else
            {
                Assert.Fail("Cancelling an edit operation should discard the data yes the system is doing this");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "skill_deleteexistingskillandlevel.json", "Deleteexistingskillandlevelrecord" })]
        public void Deleteexistingskillandlevelrecord(string Skill, string Level)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.CreateSkillRecord(Skill, Level);
            Console.WriteLine($"Selected {Skill} {Level}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            if (newSkill.Text == Skill && newLevel.Text == Level)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            skillPageObj.DeleteSkillRecord();
            Console.WriteLine($"Selected {Skill} {Level}");
            bool testPassed = false;
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
                IWebElement poppupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string prompptText = poppupAlert.Text;
                Console.WriteLine("Alert text: " + prompptText);
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


    }
}
