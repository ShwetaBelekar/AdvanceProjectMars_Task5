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

            driver.Value = new ChromeDriver();
            loginPageObj = new LoginPage();
            //LoginPage loginPageObj = new LoginPage();
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
            if (CommonDriver.driver.Value != null)
            {
                CommonDriver.driver.Value.Quit();
                CommonDriver.driver.Value.Dispose();
            }
            //driver.Quit();


        }
       
        
       


}

}
