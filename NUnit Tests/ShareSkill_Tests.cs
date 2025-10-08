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
        //public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        //{
        //    var testData = TestDataReader.ReadTestData(fileName);
        //    foreach (var data in testData[testName])
        //    {
        //        if (data.Credit == null)
        //        {
        //            // Skill Trade record
        //            yield return new TestCaseData(new
        //            {
        //                Title = data.Title,
        //                Description = data.Description,
        //                Category = data.Category,
        //                SelectSubcategory = data.SelectSubcategory,
        //                Tags = data.Tags,
        //                ServiceType = data.ServiceType,
        //                LocationType = data.LocationType,
        //                SkillTrade = data.SkillTrade,
        //                SkillExchange = data.SkillExchange,
        //                Active = data.Active,
        //                Credit = (string)null
        //            });
        //        }
        //        else
        //        {
        //            // Credit record
        //            yield return new TestCaseData(new
        //            {
        //                Title = data.Title,
        //                Description = data.Description,
        //                Category = data.Category,
        //                SelectSubcategory = data.SelectSubcategory,
        //                Tags = data.Tags,
        //                ServiceType = data.ServiceType,
        //                LocationType = data.LocationType,
        //                SkillTrade = data.SkillTrade,
        //                SkillExchange = (string)null,
        //                Active = data.Active,
        //                Credit = data.Credit
        //            });
        //        }
        //        if (data.NewCredit == null)
        //        {
        //            yield return new TestCaseData(new
        //            {
        //                Title = data.Title,
        //                Description = data.Description,
        //                Category = data.Category,
        //                SelectSubcategory = data.SelectSubcategory,
        //                Tags = data.Tags,
        //                ServiceType = data.ServiceType,
        //                LocationType = data.LocationType,
        //                SkillTrade = data.SkillTrade,
        //                SkillExchange = data.SkillExchange,
        //                Active = data.Active,
        //                Credit = (string)null,
        //                NewTitle = data.NewTitle,
        //                NewDescription = data.NewDescription,
        //                NewCategory = data.NewCategory,
        //                NewSelectSubcategory = data.NewSelectSubcategory,
        //                NewTags = data.NewTags,
        //                NewServiceType = data.NewServiceType,
        //                NewLocationType = data.NewLocationType,
        //                NewSkillTrade = data.NewSkillTrade,
        //                NewSkillExchange = data.NewSkillExchange,
        //                NewActive = data.NewActive,
        //                NewCredit = (string)null
        //            });
        //        }
        //        else
        //        {
        //            yield return new TestCaseData(new
        //            {
        //                Title = data.Title,
        //                Description = data.Description,
        //                Category = data.Category,
        //                SelectSubcategory = data.SelectSubcategory,
        //                Tags = data.Tags,
        //                ServiceType = data.ServiceType,
        //                LocationType = data.LocationType,
        //                SkillTrade = data.SkillTrade,
        //                SkillExchange = (string)null,
        //                Active = data.Active,
        //                Credit = data.Credit,
        //                NewTitle = data.NewTitle,
        //                NewDescription = data.NewDescription,
        //                NewCategory = data.NewCategory,
        //                NewSelectSubcategory = data.NewSelectSubcategory,
        //                NewTags = data.NewTags,
        //                NewServiceType = data.NewServiceType,
        //                NewLocationType = data.NewLocationType,
        //                NewSkillTrade = data.NewSkillTrade,
        //                NewSkillExchange = (string)null,
        //                NewActive = data.NewActive,
        //                NewCredit = data.NewCredit
        //            });
        //        }

        //    }
        //}
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Credit == null && data.NewCredit == null)
                {
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
                        Credit = (string)null,
                        NewTitle = data.NewTitle,
                        NewDescription = data.NewDescription,
                        NewCategory = data.NewCategory,
                        NewSelectSubcategory = data.NewSelectSubcategory,
                        NewTags = data.NewTags,
                        NewServiceType = data.NewServiceType,
                        NewLocationType = data.NewLocationType,
                        NewSkillTrade = data.NewSkillTrade,
                        NewSkillExchange = data.NewSkillExchange,
                        NewActive = data.NewActive,
                        NewCredit = (string)null
                    });
                }
                else if (data.Credit != null && data.NewCredit != null)
                {
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
                        Credit = data.Credit,
                        NewTitle = data.NewTitle,
                        NewDescription = data.NewDescription,
                        NewCategory = data.NewCategory,
                        NewSelectSubcategory = data.NewSelectSubcategory,
                        NewTags = data.NewTags,
                        NewServiceType = data.NewServiceType,
                        NewLocationType = data.NewLocationType,
                        NewSkillTrade = data.NewSkillTrade,
                        NewSkillExchange = (string)null,
                        NewActive = data.NewActive,
                        NewCredit = data.NewCredit
                    });
                }
                else if (data.Credit == null && data.NewCredit != null)
                {
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
                        Credit = (string)null,
                        NewTitle = data.NewTitle,
                        NewDescription = data.NewDescription,
                        NewCategory = data.NewCategory,
                        NewSelectSubcategory = data.NewSelectSubcategory,
                        NewTags = data.NewTags,
                        NewServiceType = data.NewServiceType,
                        NewLocationType = data.NewLocationType,
                        NewSkillTrade = data.NewSkillTrade,
                        NewSkillExchange = (string)null,
                        NewActive = data.NewActive,
                        NewCredit = data.NewCredit
                    });
                }
                else
                {
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
                        Credit = data.Credit,
                        NewTitle = data.NewTitle,
                        NewDescription = data.NewDescription,
                        NewCategory = data.NewCategory,
                        NewSelectSubcategory = data.NewSelectSubcategory,
                        NewTags = data.NewTags,
                        NewServiceType = data.NewServiceType,
                        NewLocationType = data.NewLocationType,
                        NewSkillTrade = data.NewSkillTrade,
                        NewSkillExchange = data.NewSkillExchange,
                        NewActive = data.NewActive,
                        NewCredit = (string)null
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
            if (newListing.Text == record.Title) //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr/td[3]
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
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_editexistingshareskillrecord.json", "Editexistingshareskillrecord" })]
        public void Editexistingshareskillrecord(dynamic record)

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
                Console.WriteLine("Record created successfully");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Console.WriteLine("Record creation unsuccessful");
            }
            Console.WriteLine($"Running test with data: Title = {record.NewTitle}, Description = {record.NewDescription}");
            shareSkillPageObj.EditExistingShareSkillRecord(record.NewTitle,
        record.NewDescription,
        record.NewCategory,
        record.NewSelectSubcategory,
        record.NewTags,
        record.NewServiceType,
        record.NewLocationType,
        record.NewSkillTrade,
        record.NewCredit,
        record.NewSkillExchange,
        record.NewActive);
            Console.WriteLine($"Selected {record.NewTitle} {record.NewDescription} {record.NewCategory} {record.NewSelectSubcategory} {record.NewTags} {record.NewServiceType} {record.NewLocationType} {record.NewSkillTrade} {record.NewCredit} {record.NewSkillExchange} {record.NewActive}");
            IWebElement editedListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"));
            if (editedListing.Text == record.NewTitle)
            {
                Console.WriteLine($"Test passed for data: Title = {record.NewTitle}");
                Assert.Pass("Record edited successfully");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.NewTitle}");
                Assert.Fail("Record edited unsuccessful");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "shareskill_deleteexistingshareskillrecord.json", "Deleteexistingshareskillrecord" })]
        public void Deleteexistingshareskillrecord(dynamic record)
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
                Console.WriteLine("Record created successfully");
            }
            else
            {
                Console.WriteLine($"Test failed for data: Title = {record.Title}");
                Console.WriteLine("Record creation unsuccessful");
            }
            shareSkillPageObj.DeleteShareSkillRecord();
            Console.WriteLine($"Selected {record.Title} {record.Description} {record.Category} {record.SelectSubcategory} {record.Tags} {record.ServiceType} {record.LocationType} {record.SkillTrade} {record.Credit} {record.SkillExchange} {record.Active}");
            bool testPassed = false;
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
                IWebElement poppupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string promptText = poppupAlert.Text;
                Console.WriteLine("Alert text: " + promptText);
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
        [Test]
        public void Description()
        {
            //IWebElement descriptionTooltip = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[1]/div"));

            //IWebElement descriptionFielderror = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            // Get the tooltip text
            IWebElement ShareSkillButton = driver.FindElement(By.XPath("//a[@href='/Home/ServiceListing']"));
            ShareSkillButton.Click();
            Thread.Sleep(3000);
            string tooltipHtml = driver.FindElement(By.XPath("(//div[@class='tooltip'])[2]")).GetAttribute("innerHTML");
            Console.WriteLine("Actual Tooltip HTML: " + tooltipHtml);

            IWebElement descriptionField = driver.FindElement(By.Name("description"));
            string placeholderText = descriptionField.GetAttribute("placeholder");

            // Assert that the tooltip and placeholder text are consistent
            if (tooltipHtml != placeholderText)
            {
                Console.WriteLine("Tooltip text: " + tooltipHtml);
                Console.WriteLine("Placeholder text: " + placeholderText);
                Assert.Pass("Tooltip text and placeholder text do not match. This can confuse user.");

                
            }
            else
            {
                Assert.Fail("Tooltip text and placeholder text match.");

            }
        }
    }
}
