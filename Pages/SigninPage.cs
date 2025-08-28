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

            IWebElement


        }
    }
}
