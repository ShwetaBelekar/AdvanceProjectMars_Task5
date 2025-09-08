using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.ProfLoc_Ava_Hrs_ErnTar.ProfLoc_Ava_Hrs_ErnTarTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    public class ProfLoc_Avai_Hrs_EarnTar_Tests : CommonDriver
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
                if (data.AvailabilityType != null)
                {
                    yield return new TestCaseData(data.AvailabilityType);
                }

            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "availability_selecttype.json", "Availabilityselecttype" })]
        public void Availabilityselecttype(string AvailabilityType)
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
            
            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectAvailabilityAction(AvailabilityType);
            if (AvailabilityType == "Part Time")
            {
                Console.WriteLine("Part Time is selected");

            }
            else
            {
                Console.WriteLine($"Expected Part Time but got {AvailabilityType}");
            }

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));

            if (popupAlert.Text == "Availability updated")
            {
                Assert.Pass("Availability updated successfully");
            }
            else
            {
                Assert.Fail("Availability updated unsuccessfull");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "availability_changetype.json", "Availabilitychangetype" })]
        public void Availabilitychangetype(string AvailabilityType)
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();

            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectAvailabilityAction(AvailabilityType);

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement selectpopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = selectpopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (selectpopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Availability updated successfully");
            }
            else
            {
                Console.WriteLine("Availability updated unsuccessfull");
            }
            
           profLoc_Avai_Hrs_EarnTarPageObj.ChangeAvailabilityAction(AvailabilityType);
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string changepromptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (popupAlert.Text == "Availability updated")
            {
                Assert.Pass("Availability updated successfully");
            }
            else
            {
                Assert.Fail("Availability updated unsuccessfull");
            }


        }


    }
}
