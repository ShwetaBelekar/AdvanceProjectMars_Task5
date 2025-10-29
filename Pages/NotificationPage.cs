using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class NotificationPage : CommonDriver
    {
        private IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));

        private IWebElement emailAddressTextbox => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));

        private IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@placeholder='Password']"));

        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        public void SendSkillSwapRequest()
        {
            signInButton.Click();
            emailAddressTextbox.SendKeys("starsun@gmail.com");
            passwordTextbox.SendKeys("Star@123");
            loginButton.Click();
            Thread.Sleep(3000);
            IWebElement searchSkills = driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]"));
            searchSkills.SendKeys("Testing" + Keys.Enter);
            Thread.Sleep(2000);
            IWebElement selectListing = driver.FindElement(By.XPath("//p[@class='row-padded' and contains(text(), 'Postman')]"));
            selectListing.Click();
            IWebElement messageToSeller = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea"));
            messageToSeller.SendKeys("I am interested in your Skill");
            Thread.Sleep(3000);
            IWebElement requestButton = driver.FindElement(By.XPath("//div[@class='ui teal  button']"));
            requestButton.Click();
            Thread.Sleep(2000);
            IWebElement yesButton = driver.FindElement(By.XPath("//button[@class='ui button ui teal button' and text()='Yes']"));
            yesButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (popupAlert.Text == "Request sent")
            {
                Console.WriteLine("SkillSwap request sent successfully");
            }
            else
            {
                Console.WriteLine("SkillSwap request not sent");
            }
            IWebElement signOutButton = driver.FindElement(By.XPath("//button[@class='ui green basic button' and contains(text(), 'Sign Out')]"));
            signOutButton.Click();

        }
        public void CheckNotificationAlerts()
        {
            signInButton.Click();
            emailAddressTextbox.SendKeys("moneytony@ymail.com");
            passwordTextbox.SendKeys("Tonymoney@2025");
            loginButton.Click();
            Thread.Sleep(3000);
            IWebElement notifications = driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));

        }
    }
}
