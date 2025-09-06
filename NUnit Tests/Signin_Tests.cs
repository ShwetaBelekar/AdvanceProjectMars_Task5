using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.TestData.Signin;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Signin.SigninTestData;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    public class Signin_Tests : CommonDriver
    {
        [SetUp]

        public void SetUpSteps()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
        }

        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Emailaddress != null && data.Password != null)
                {
                    yield return new TestCaseData(data.Emailaddress, data.Password);
                }
                
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "signin_validcredentials.json", "signinwithvalidcredentials" })]
        public void signinwithvalidcredentials(string emailaddress, string password)
        {
            SigninPage signinPageObj = new SigninPage();
            signinPageObj.SigninActions(emailaddress, password);
            signinPageObj.VerifyUserInHomePage();
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "signin_invalidcredentials.json", "signinwithinvalidcredentials" })]
        public void signinwithinvalidcredentials(string emailaddress, string password)
        {
            SigninPage signinPageObj = new SigninPage();
            signinPageObj.SigninActions(emailaddress, password);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            if (popupAlert.Text == "Confirm your email")
            {
                Console.WriteLine("User can't signin with the invalid credentials");
            }
            else
            {
                Console.WriteLine("User can signin with the invalid credentials");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "signin_blankemailaddress.json", "signinwithblankemailaddress" })]
        public void signinwithblankemailaddress(string emailaddress, string password)
        {
            SigninPage signinPageObj = new SigninPage();
            signinPageObj.SigninActions(emailaddress, password);
            IWebElement redPrompt = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));
            string promptText = redPrompt.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (redPrompt.Text == "Please enter a valid email address")
            {
                Console.WriteLine("User can't signin with blank emailaddress");
            }
            else
            {
                Console.WriteLine("User can signin with blankemailaddress");
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "signin_blankpassword.json", "signinwithblankpassword" })]
        public void signinwithblankpassword(string emailaddress, string password)
        {
            SigninPage signinPageObj = new SigninPage();
            signinPageObj.SigninActions(emailaddress, password);
            IWebElement redPrompt = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));
            string promptText = redPrompt.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (redPrompt.Text == "Password must be at least 6 characters")
            {
                Console.WriteLine("User can't signin with blank password");
            }
            else
            {
                Console.WriteLine("User can signin with blank password");
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "signin_blankemailandpassword.json", "signinwithblankemailandpassword" })]
        public void signinwithblankemailandpassword(string emailaddress, string password)
        {
            SigninPage signinPageObj = new SigninPage();
            signinPageObj.SigninActions(emailaddress, password);
            IWebElement redPrompt1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));
            IWebElement redPrompt2 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));
            string promptText1 = redPrompt1.Text;
            string promptText2 = redPrompt2.Text;
            Console.WriteLine($"Alert text: {promptText1} {promptText2}");
            if (redPrompt1.Text == "Please enter a valid email address" && redPrompt2.Text == "Password must be at least 6 characters")
            {
                Console.WriteLine("User can't signin with blankemailandpassword");
            }
            else
            {
                Console.WriteLine("User can signin with blankemailandpassword");
            }
        }






    }
}
