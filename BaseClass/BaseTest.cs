using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.BaseClass
{
 
    public class BaseTest : CommonDriver
    {
        
        protected LoginPage loginPageObj;
        protected HomeToLanguagePage homeToLanguagePageObj;
        protected HomeToSkillPage homeToSkillPageObj;
        protected static ExtentReports extentReport;
        protected ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();
        
        [OneTimeSetUp]
        public void Open()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
            string reportDirectory = Path.Combine(projectRoot, "ExtentReports");
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            string reportPath = Path.Combine(reportDirectory, "report.html");
            extentReport = new ExtentReports();
            var spark = new ExtentSparkReporter(reportPath);
            extentReport.AttachReporter(spark);
            
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
        }
        
        [SetUp]
        public void SetUp()
        {
           
            string category = TestContext.CurrentContext.Test.Properties["Category"].ToString();
            string testName = $"{TestContext.CurrentContext.Test.Name} - {category}";
            test.Value = extentReport.CreateTest(testName);
         
        }
        [TearDown]
        public void TearDown()
        {
            //if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Language"))
            //{
            //    try
            //    {
            //        Thread.Sleep(2000);
            //        HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
            //        homeToLanguagePageObj.NavigateToLanguage();
            //        Thread.Sleep(1000);
            //        var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            //        for (int i = deleteButtons.Count - 1; i >= 0; i--)
            //        {
            //            deleteButtons[i].Click();
            //            Thread.Sleep(2000);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error during cleanup: {ex.Message}");
            //    }

            //}
            //else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Skill"))
            //{
            //    try
            //    {
            //        HomeToSkillPage homeToSkillPageObj = new HomeToSkillPage();
            //        homeToSkillPageObj.NavigateToSkill();

            //        var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            //        for (int i = deleteButtons.Count - 1; i >= 0; i--)
            //        {
            //            deleteButtons[i].Click();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error during cleanup: {ex.Message}");
            //    }

            //}

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Value.Log(Status.Fail, "Test failed");
                test.Value.AddScreenCaptureFromPath(GetScreenshot());
            }
            else
            {
                test.Value.Log(Status.Pass, "Test passed");
            }
           

        }
        private string GetScreenshot()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
            string screenshotDirectory = Path.Combine(projectRoot, "Screenshot");
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }
            string filename = $"screenshot_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";
            string screenshotPath = Path.Combine(screenshotDirectory, filename);
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
         
            extentReport.Flush();
            driver.Quit();
        }
       
        
       


}

}
