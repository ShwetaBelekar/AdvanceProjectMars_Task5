using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
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
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    foreach (var data in testData[testName])
        //    {
        //        if (data.Credit == null)
        //        {
        //            // Skill Trade record
        //            yield return new TestCaseData(data.Title, data.Description, data.Category, data.SelectSubcategory, data.Tags, data.ServiceType, data.LocationType, data.SkillTrade, data.SkillExchange, data.Active);
        //        }
        //        else
        //        {
        //            // Credit record
        //            yield return new TestCaseData(data.Title, data.Description, data.Category, data.SelectSubcategory, data.Tags, data.ServiceType, data.LocationType, data.Credit);
        //        }
        //    }
        //}
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    foreach (var data in testData[testName])
        //    {
        //        if (data.Title != null && data.Description != null && data.Category != null && data.SelectSubcategory != null && data.Tags != null && data.ServiceType != null && data.LocationType != null && data.SkillTrade != null && data.Credit != null && data.SkillExchange != null && data.Active != null)
        //        {
        //            yield return new TestCaseData(data.Title, data.Description, data.Category, data.SelectSubcategory, data.Tags, data.ServiceType, data.LocationType, data.SkillTrade, data.Credit, data.SkillExchange, data.Active);
        //        }

        //    }
        //}
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    foreach (var data in testData[testName])
        //    {
        //        if (data.SkillTrade != null && data.SkillExchange != null)
        //        {
        //            // Handle skill trade records
        //            yield return new TestCaseData(data).SetName($"{testName}_SkillTrade");
        //        }
        //        else if (data.Credit != null)
        //        {
        //            // Handle credit records
        //            yield return new TestCaseData(data).SetName($"{testName}_Credit");
        //        }
        //        else
        //        {
        //            // Handle other types of records
        //            yield return new TestCaseData(data).SetName($"{testName}_Other");
        //        }
        //    }
        //}
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    int testNumber = 1;
        //    foreach (var data in testData[testName])
        //    {
        //        string testCaseName = $"ShareSkillTest_{testNumber}";
        //        yield return new TestCaseData(data).SetName(testCaseName);
        //        testNumber++;
        //    }
        //}
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
        //[Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_invalidshareskillrecord.json", "Createinvalidshareskillrecord" })]
        //public void Createinvalidshareskillrecord(dynamic record)
        //{
        //    Console.WriteLine($"Running test with data: Title = {record.Title}, Description = {record.Description}");

        //    ShareSkillPage shareSkillPageObj = new ShareSkillPage();
        //    shareSkillPageObj.CreateShareSkillRecord(record);
        //    IWebElement newListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
        //    if (newListing.Text == record.Title)
        //    {
        //        Console.WriteLine($"Test passed for data: Title = {record.Title}");
        //        Assert.Pass("Record created successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Test failed for data: Title = {record.Title}");
        //        Assert.Fail("Record creation unsuccessful");
        //    }
        //}

    }
}
