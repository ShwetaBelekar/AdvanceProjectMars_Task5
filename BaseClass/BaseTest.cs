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

            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Signin"))
            {
                driver = new ChromeDriver();
            }
            else
            {
                driver = new ChromeDriver();
                LoginPage loginPageObj = new LoginPage();
                loginPageObj.LoginActions();
            }
            
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
            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Language"))
            {
                try
                {
                    HomeToLanguagePage homeToLanguagePageObj = new HomeToLanguagePage();
                    homeToLanguagePageObj.NavigateToLanguage();

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }
                
            }
            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Skill"))
            {
                try
                {
                    HomeToSkillPage homeToSkillPageObj = new HomeToSkillPage();
                    homeToSkillPageObj.NavigateToSkill();

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();  
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }

            }
            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Signin"))
            {
               

            }

            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("ShareSkill"))
            {
                try
                {
                    IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
                    manageListingsTab.Click();
                    bool hasRecords = true;
                    while (hasRecords)
                    {
                        var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
                        if (deleteButtons.Count == 0)
                        {
                            hasRecords = false;
                        }
                        else
                        {
                            for (int i = deleteButtons.Count - 1; i >= 0; i--)
                            {
                                deleteButtons[i].Click();


                                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ui.tiny.modal.transition.visible.active")));
                                IWebElement yesButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
                                if (yesButton.Displayed && yesButton.Enabled)
                                {
                                    yesButton.Click();
                                    Thread.Sleep(3000);
                                }
                                else
                                {
                                    // Handle the case where the button is not visible or enabled
                                }

                            }
                            var nextPageButton = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
                            if (nextPageButton.Count > 0 && nextPageButton[nextPageButton.Count - 1].Text == "Next")
                            {
                                nextPageButton[nextPageButton.Count - 1].Click();
                                // Wait for the page
                                Thread.Sleep(2000);
                            }
                        }
                    }


                
                try
                {
                    IWebElement messageElement = driver.FindElement(By.XPath("//*[contains(text(), 'You do not have any service listings!')]"));
                    if (messageElement.Displayed)
                    {
                        Console.WriteLine("All records have been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("An error occurred while deleting records.");
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("An error occurred while deleting records.");
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }

            }

            extentReport.Flush();
            driver.Quit();
        }
       
        
       


}
}
