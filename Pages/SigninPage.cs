using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class SigninPage : CommonDriver
    {
        public void ValidSigninActions()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();

            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();

            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailAddressTextbox.SendKeys("moneytony@ymail.com");

            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            passwordTextbox.SendKeys("Tonymoney@2025");

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
        }

        public void VerifyUserInHomePage()
        {
            IWebElement hiTony = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hiTony.Text == "Hi Tony")
            {
                Console.WriteLine("User has logged in Successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }

        }
    }
}
