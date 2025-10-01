using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
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
                if (data.Title != null && data.Description != null && data.Category != null && data.SelectSubcategory != null && data.Tags != null && data.ServiceType != null && data.LocationType != null &&  data.Credit != null)
                {
                    yield return new TestCaseData(data.Title, data.Description, data.Category, data.SelectSubcategory, data.Tags, data.ServiceType, data.LocationType, data.Credit);
                }

                else if (data.Title != null && data.Description != null && data.Category != null && data.SelectSubcategory != null && data.Tags != null && data.ServiceType != null && data.LocationType != null && data.SkillTrade != null && data.SkillExchange != null && data.Active != null)
                {
                    yield return new TestCaseData(data.Title, data.Description, data.Category, data.SelectSubcategory, data.Tags, data.ServiceType, data.LocationType, data.SkillTrade, data.SkillExchange, data.Active);
                }
                

            }

        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_validshareskillrecord.json", "Createvalidshareskillrecord" })]
        public void Createvalidshareskillrecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string SkillTrade, string SkillExchange, string Active)
        {
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateShareSkillRecord(Title, Description, Category, SelectSubcategory, Tags, ServiceType, LocationType, SkillTrade, SkillExchange, Active);
            Console.WriteLine($"Selected {Title} {Description} {Category} {SelectSubcategory} {Tags} {ServiceType} {LocationType} {SkillTrade} {SkillExchange} {Active}");
            //Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box-inner' and contains(text(), 'Service Listing Added Successfully')]", 2);
            //IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Service Listing Added Successfully')]"));
            //string promptText = popupAlert.Text;
            //Console.WriteLine("Alert text: " + promptText);
            //if (popupAlert.Text == "Service Listing Added Successfully")
            //{
            //    Assert.Pass("Record created successfully");
            //}
            //else
            //{
            //    Assert.Fail("Record creation unsuccessful");
            //}
            IWebElement newListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (newListing.Text == "Selenium") 
            {
                Assert.Pass("Record created successfully");
            }
            else
            {

                Assert.Fail("Record creation unsuccessful");
            }
            
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_dietitianshareskillrecord.json", "Createdietitianshareskillrecord" })]
        public void Createdietitianshareskillrecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string Credit)
        {
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.CreateDietitianShareSkillRecord(Title, Description, Category, SelectSubcategory, Tags, ServiceType, LocationType, Credit);
            Console.WriteLine($"Selected {Title} {Description} {Category} {SelectSubcategory} {Tags} {ServiceType} {LocationType} {Credit}");
            IWebElement neewListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (neewListing.Text == "Dietitian")
            {
                Assert.Pass("Record created successfully");
            }
            else
            {
                Assert.Fail("Record creation unsuccessful");
            }
        }
    }
}
