using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    [Parallelizable]
    [TestFixture]
    public class ProfLoc_Avai_Hrs_EarnTar_Tests : CommonDriver
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
        }

        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.AvailabilityType != null && data.NewAvailabilityType != null)
                {
                    yield return new TestCaseData(data.AvailabilityType, data.NewAvailabilityType);
                }
                else if (data.AvailabilityType != null)
                {
                    yield return new TestCaseData(data.AvailabilityType);
                }
                else if (data.HoursType != null && data.EditHoursType != null && data.ChangeHoursType != null)
                {
                    yield return new TestCaseData(data.HoursType, data.EditHoursType, data.ChangeHoursType);
                }
                else if (data.HoursType != null)
                {
                    yield return new TestCaseData(data.HoursType);
                }
                else if (data.EarnTargetType != null && data.EditEarnTargetType != null && data.ChangeEarnTargetType != null)
                {
                    yield return new TestCaseData(data.EarnTargetType, data.EditEarnTargetType, data.ChangeEarnTargetType);
                }
                else if (data.EarnTargetType != null)
                {
                    yield return new TestCaseData(data.EarnTargetType);
                }
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "availability_selecttype.json", "Availabilityselecttype" })]
        public void Availabilityselecttype(string AvailabilityType)
        {
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions();
            //loginPageObj.VerifyUserInHomePage();

            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectAvailabilityAction(AvailabilityType);
            Console.WriteLine($"Selected {AvailabilityType}");
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
        public void Availabilitychangetype(string AvailabilityType, string NewAvailabilityType)
        {
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions();
            //loginPageObj.VerifyUserInHomePage();

            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectAvailabilityAction(AvailabilityType);
            if (AvailabilityType == "Full Time")
            {
                Console.WriteLine("Full Time is selected");

            }
            else
            {
                Console.WriteLine($"Expected Full Time but got {AvailabilityType}");
            }

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

            profLoc_Avai_Hrs_EarnTarPageObj.ChangeAvailabilityAction(NewAvailabilityType);
            if (NewAvailabilityType == "Part Time")
            {
                Console.WriteLine("Part Time is selected");

            }
            else
            {
                Console.WriteLine($"Expected Part Time but got {NewAvailabilityType}");
            }
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
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "hours_selecttype.json", "Hoursselecttype" })]
        public void Hoursselecttype(string HoursType)
        {
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions();
            //loginPageObj.VerifyUserInHomePage();

            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectHoursAction(HoursType);
            Console.WriteLine($"Selected {HoursType}");
            //if (HoursType == "Less than 30hours a week")
            //{
            //    Console.WriteLine("Less than 30hours a week is selected");

            //}
            //else if (HoursType == "More than 30hours a week")
            //{
            //    Console.WriteLine("More than 30hours a week is selected");
            //}
            //else if (HoursType == "As needed")
            //{
            //    Console.WriteLine("As needed is selected");
            //}

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);

            if (poopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Hours updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "hours_changetype.json", "Hourschangetype" })]
        public void Hourschangetype(string HoursType, string EditHoursType, string ChangeHoursType)
        {
            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectHoursAction(HoursType);
            Console.WriteLine($"Selected {HoursType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);

            if (poopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Hours updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }
            profLoc_Avai_Hrs_EarnTarPageObj.EditHoursAction(EditHoursType);
            Console.WriteLine($"Selected {EditHoursType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string proomptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);

            if (popupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Hours updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }
            profLoc_Avai_Hrs_EarnTarPageObj.ChangeHoursAction(ChangeHoursType);
            Console.WriteLine($"Selected {ChangeHoursType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement ppopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string prooomptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + prooomptText);

            if (ppopupAlert.Text == "Availability updated")
            {
                Assert.Pass("Error in the system, alert should be Hours updated but getting alert Availlability updated!");
            }
            else
            {
                Assert.Fail("No Error in the system, popup alert is correct!");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "earntarget_selecttype.json", "EarnTargetselecttype" })]
        public void EarnTargetselecttype(string EarnTargetType)
        {
            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectEarnTargetAction(EarnTargetType);
            Console.WriteLine($"Selected {EarnTargetType}");

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement ppopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (ppopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Earn Target updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "earntarget_changetype.json", "EarnTargetchangetype" })]
        public void EarnTargetchangetype(string EarnTargetType, string EditEarnTargetType, string ChangeEarnTargetType)
        {
            ProfLoc_Avai_Hrs_EarnTarPage profLoc_Avai_Hrs_EarnTarPageObj = new ProfLoc_Avai_Hrs_EarnTarPage();
            profLoc_Avai_Hrs_EarnTarPageObj.SelectEarnTargetAction(EarnTargetType);
            Console.WriteLine($"Selected {EarnTargetType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = poopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);

            if (poopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be EarnTarget updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }
            profLoc_Avai_Hrs_EarnTarPageObj.EditEarnTargetAction(EditEarnTargetType);
            Console.WriteLine($"Selected {EditEarnTargetType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string proomptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);

            if (popupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be EarnTarget updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }
            profLoc_Avai_Hrs_EarnTarPageObj.ChangeEarnTargetAction(ChangeEarnTargetType);
            Console.WriteLine($"Selected {ChangeEarnTargetType}");
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement ppopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string prooomptText = ppopupAlert.Text;
            Console.WriteLine("Alert text: " + prooomptText);

            if (ppopupAlert.Text == "Availability updated")
            {
                Assert.Pass("Error in the system, alert should be EarnTarget updated but getting alert Availlability updated!");
            }
            else
            {
                Assert.Fail("No Error in the system, popup alert is correct!");
            }
        }
        [Test]
        public void LocationFeature_IsNotInteractable()
        {
           
            IWebElement location = driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.four.wide.column > div > div > div > div > div > div.extra.content > div > div:nth-child(1) > span > strong"));

            
            Actions actions = new Actions(driver);
            actions.DoubleClick(location).Perform();

            var initialText = location.Text;
            actions.DoubleClick(location).Perform();
            Assert.That(location.Text, Is.EqualTo(initialText));
            if(initialText == location.Text)
            {
                Assert.Pass("Upon double clicking the location button remains the same, hence user can't interact with this feature");
            }
            else
            {
                Assert.Fail("Upon double clicking the location button the feature opens allows user to interact with it");
            }

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
