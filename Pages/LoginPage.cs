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
    public class LoginPage : CommonDriver
    {
        public void LoginActions()
        {

            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
            Thread.Sleep(2000);

            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddressTextbox.SendKeys("moneytony@ymail.com");

            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Tonymoney@2025");

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(5000);
        }
       
        public void VerifyUserInHomePage()
        {
            //Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui secondary menu']//span[@class='item ui dropdown link']", 2);
            IWebElement hitony = driver.FindElement(By.XPath("//span[contains(@class, 'dropdown') and contains(text(), 'Hi')]"));

            if (hitony.Text == "Hi Tony")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }




        }
    }
}
