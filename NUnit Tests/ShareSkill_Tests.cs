using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Shareskill.ShareskillTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    public class ShareSkill_Tests : CommonDriver
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
                if (data.Credit == null)
                {
                    // Skill Trade record
                    yield return new TestCaseData(new
                    {
                        Title = data.Title,
                        Description = data.Description,
                        Category = data.Category,
                        SelectSubcategory = data.SelectSubcategory,
                        Tags = data.Tags,
                        ServiceType = data.ServiceType,
                        LocationType = data.LocationType,
                        SkillTrade = data.SkillTrade,
                        SkillExchange = data.SkillExchange,
                        Active = data.Active,
                        Credit = (string)null
                    });
                }
                else
                {
                    // Credit record
                    yield return new TestCaseData(new
                    {
                        Title = data.Title,
                        Description = data.Description,
                        Category = data.Category,
                        SelectSubcategory = data.SelectSubcategory,
                        Tags = data.Tags,
                        ServiceType = data.ServiceType,
                        LocationType = data.LocationType,
                        SkillTrade = data.SkillTrade,
                        SkillExchange = (string)null,
                        Active = data.Active,
                        Credit = data.Credit
                    });
                }
            }
        }
       
        
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_validshareskillrecord.json", "Createvalidshareskillrecord" })]
        public void Createvalidshareskillrecord(dynamic record)
        { 
            Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");

            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateShareSkillRecord(record.Title,
        record.Description,
        record.Category,
        record.SelectSubcategory,
        record.Tags,
        record.ServiceType,
        record.LocationType,
        record.SkillTrade,
        record.Credit,
        record.SkillExchange,
        record.Active);
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            IWebElement newListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (newListing.Text == record.Title)
            {
                Console.WriteLine($"Test passed for data: Title = {record.Title}");
                Assert.Pass("Record created successfully");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Assert.Fail("Record creation unsuccessful");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_invalidshareskillrecord.json", "Createinvalidshareskillrecord" })]
        public void Createinvalidshareskillrecord(dynamic record)
        {
            Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");

            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateShareSkillRecord(record.Title,
        record.Description,
        record.Category,
        record.SelectSubcategory,
        record.Tags,
        record.ServiceType,
        record.LocationType,
        record.SkillTrade,
        record.Credit,
        record.SkillExchange,
        record.Active);
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            IWebElement newListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (newListing.Text == record.Title)
            {
                Console.WriteLine($"Test passed for data: Title = {record.Title}");
                Assert.Pass("Record created successfully, system is accepting invalid data");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Assert.Fail("Record creation unsuccessful, system is not accepting invalid data");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_blankshareskillrecord.json", "Createblankshareskillrecord" })]
        public void Createblankshareskillrecord(dynamic record)
        {
            Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");

            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateblankShareSkillRecord(record.Title,
        record.Description,
        record.Category,
        record.SelectSubcategory,
        record.Tags,
        record.ServiceType,
        record.LocationType,
        record.SkillTrade,
        record.Credit,
        record.SkillExchange,
        record.Active);
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string promptText = popupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (popupAlert.Text == "Please complete the form correctly.")
            {
                Assert.Pass("System doesn't accepts blank record");
            }
            else
            {
                Assert.Fail("System accepts blank record");
            }
          
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_duplicateshareskillrecord.json", "Createduplicateshareskillrecord" })]
        public void Createduplicateshareskillrecord(dynamic record)
        {
            Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");

            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateShareSkillRecord(record.Title,
        record.Description,
        record.Category,
        record.SelectSubcategory,
        record.Tags,
        record.ServiceType,
        record.LocationType,
        record.SkillTrade,
        record.Credit,
        record.SkillExchange,
        record.Active);
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            IWebElement newListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (newListing.Text == record.Title)
            {
                //Console.WriteLine($"Test passed for data: Title = {record.Title}");
                Console.WriteLine("Record created successfully");
            }
            else
            {
                //Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Console.WriteLine("Record creation unsuccessful");
            }
            Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");
            shareSkillPageObj.CreateShareSkillRecord(record.Title,
        record.Description,
        record.Category,
        record.SelectSubcategory,
        record.Tags,
        record.ServiceType,
        record.LocationType,
        record.SkillTrade,
        record.Credit,
        record.SkillExchange,
        record.Active);
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            IWebElement duplicateListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (duplicateListing.Text == record.Title)
            {
                Console.WriteLine($"Test passed for data: Title = {record.Title}");
                Assert.Pass("Duplicate record created successfully, error in the system");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Assert.Fail("Duplicate record not accepted");
            }
        }
    }
}
