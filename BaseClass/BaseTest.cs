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

namespace AdvanceProjectMars_Task5.BaseClass
{
    public class BaseTest : CommonDriver
    {
        [OneTimeSetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
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
                driver.Quit();
            }
        }

    }
}
