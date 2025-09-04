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




    }
}
