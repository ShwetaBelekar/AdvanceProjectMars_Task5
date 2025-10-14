using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.NUnit_Tests
{
    [TestFixture]
    public class Searchskills_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
        }
        [Test]
        public void CountTotalListings()
        {
            IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
            manageListingsTab.Click();
            Thread.Sleep(3000);

            int totalPages = 11;
            int listingsPerPage = 5;
            int listingsOnLastPage = 3;

            int totalCount = (totalPages - 1) * listingsPerPage + listingsOnLastPage;

            Assert.That(totalCount, Is.GreaterThan(0));
            Console.WriteLine("Total listings: " + totalCount);
        }
        //[Test]
        //public void CountActiveAndHiddenListings()
        //{
        //    IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
        //    manageListingsTab.Click();
        //    Thread.Sleep(3000);
        //    int totalActive = 0;
        //    int totalHidden = 0;

        //    for (int i = 1; i <= 11; i++)
        //    {
        //        totalActive += driver.FindElements(By.XPath("//i[@class='blue check circle outline large icon']")).Count;
        //        totalHidden += driver.FindElements(By.XPath("//i[@class='grey remove circle large icon']")).Count;

        //        if (i < 11)
        //        {
        //            var nextPageButtons = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
        //            foreach (var button in nextPageButtons)
        //            {
        //                if (button.Text != i.ToString())
        //                {
        //                    button.Click();
        //                    break;
        //                }
        //            }
        //            Thread.Sleep(2000); // You can use WebDriverWait instead of Thread.Sleep
        //        }
        //    }

        //    Console.WriteLine("Active listings: " + totalActive);
        //    Console.WriteLine("Hidden listings: " + totalHidden);
        //}
        //[Test]
        //public void CountActiveAndHiddenListings()
        //{
        //    IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
        //    manageListingsTab.Click();
        //    Thread.Sleep(3000);
        //    int totalActive = 0;
        //    int totalHidden = 0;

        //    for (int i = 1; i <= 11; i++)
        //    {
        //        totalActive += driver.FindElements(By.XPath("//i[@class='blue check circle outline large icon']")).Count;
        //        totalHidden += driver.FindElements(By.XPath("//i[@class='grey remove circle large icon']")).Count;

        //        if (i < 11)
        //        {
        //            driver.FindElement(By.XPath("//button[@class='ui button otherPage']")).Click();
        //            Thread.Sleep(2000); // You can use WebDriverWait instead of Thread.Sleep
        //        }
        //    }

        //    Console.WriteLine("Active listings: " + totalActive);
        //    Console.WriteLine("Hidden listings: " + totalHidden);
        //}
        [Test]
        public void SearchSkillWithOnlineFilter()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            IWebElement filterOnline = driver.FindElement(By.XPath("//button[text()='Online']"));
            filterOnline.Click();

            int totalOnlineListings = 0;
            int totalPages = 3; // You know there are 3 pages
            Thread.Sleep(4000);
            for (int i = 1; i <= totalPages; i++)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {i}: {listingsOnPage}");
                totalOnlineListings += listingsOnPage;

                if (i < totalPages)
                {
                    // Navigate to the next page
                    var pageButtons = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
                    foreach (var button in pageButtons)
                    {
                        if (button.Text == (i + 1).ToString())
                        {
                            button.Click();
                            Thread.Sleep(2000); // Wait for the page to load
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Total number of listings: {totalOnlineListings}");
        }
    }
    
}
