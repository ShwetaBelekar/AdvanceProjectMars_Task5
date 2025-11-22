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
        private IWebElement signInButton => driver.Value.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));

        private IWebElement emailAddressTextbox => driver.Value.FindElement(By.XPath("//input[@placeholder='Email address']"));

        private IWebElement passwordTextbox => driver.Value.FindElement(By.XPath("//input[@placeholder='Password']"));

        private IWebElement loginButton => driver.Value.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        public void SigninActions(string emailAddress, string password)
        {  
            signInButton.Click();
            Thread.Sleep(2000);
            emailAddressTextbox.SendKeys(emailAddress);
            passwordTextbox.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(3000);
        }

        public void VerifyUserInHomePage()
        {
            IWebElement hiTony = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

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
