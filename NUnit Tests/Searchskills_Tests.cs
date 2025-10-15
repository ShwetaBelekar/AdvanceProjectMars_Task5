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
using static AdvanceProjectMars_Task5.TestData.Searchskills.SearchskillsTestData;

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
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
                if (data.Filter != null)
                {
                    yield return new TestCaseData(data.Filter);
                }

            }
        }
        [Test]
        public void CountTotalListings()
        {
            IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
            manageListingsTab.Click();
            Thread.Sleep(3000);
            //IWebElement tableRow = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr"));
            int totaltableRow = 0;
            int totalPages = 11; // You know there are 3 pages
            Thread.Sleep(4000);
            for (int i = 1; i <= totalPages; i++)
            {
                var tableRow = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr"));
                int tableRowOnPage = tableRow.Count;
                Console.WriteLine($"Number of tableRow on page {i}: {tableRowOnPage}");
                totaltableRow += tableRowOnPage;

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
            
            Console.WriteLine($"Total number of listings: {totaltableRow}");
            //int totalPages = 11;
            //int listingsPerPage = 5;
            //int listingsOnLastPage = 3;

            //int totalCount = (totalPages - 1) * listingsPerPage + listingsOnLastPage;

            //Assert.That(totalCount, Is.GreaterThan(0));
            //Console.WriteLine("Total listings: " + totalCount);
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
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withOnlineFilter.json", "SearchskillsbyapplyingOnlineFilter" })]
        public void SearchskillsbyapplyingOnlineFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithOnlineFilter(Filter);
            //IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            //searchSkillsSearchIcon.Click();
            //Thread.Sleep(3000);
            //IWebElement filterOnline = driver.FindElement(By.XPath("//button[text()='Online']"));
            //filterOnline.Click();

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
        [Test]
        public void SearchSkillWithOnsiteFilter()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            IWebElement filterOnsite = driver.FindElement(By.XPath("//button[text()='Onsite']"));
            filterOnsite.Click();

            int totalOnsiteListings = 0;
            int totalPages = 3; // You know there are 3 pages
            Thread.Sleep(4000);
            for (int i = 1; i <= totalPages; i++)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {i}: {listingsOnPage}");
                totalOnsiteListings += listingsOnPage;

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

            Console.WriteLine($"Total number of listings: {totalOnsiteListings}");
        }
        [Test]
        public void SearchSkillWithShowAllFilter()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            IWebElement filterShowAll = driver.FindElement(By.XPath("//button[text()='ShowAll']"));
            filterShowAll.Click();

            int totalShowAllListings = 0;
            int totalPages = 5; // You know there are 3 pages
            Thread.Sleep(4000);
            for (int i = 1; i <= totalPages; i++)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {i}: {listingsOnPage}");
                totalShowAllListings += listingsOnPage;

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

            Console.WriteLine($"Total number of listings: {totalShowAllListings}");
        }
        [Test]
        public void ShowAllContent()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
           

            int totalShowAllContent = 0;
            int totalPages = 5; // You know there are 3 pages
            Thread.Sleep(6000);
            var sellerListings = new Dictionary<string, int>
                {
                 {"Tony Money", 0},
                 {"Sun Moon", 0}
                };

            for (int i = 1; i <= totalPages; i++)
            {
                var Content = driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]"));
                int ContentOnPage = Content.Count;
                Console.WriteLine($"Number of listings on page {i}: {ContentOnPage}");
                foreach (var item in Content)
                {
                    Console.WriteLine(item.Text);
                    //string sellerName = "";
                    //if (item.Text.Contains("Tony Money"))
                    //{
                    //    sellerName = "Tony Money";
                    //}
                    //else if (item.Text.Contains("Sun Moon"))
                    //{
                    //    sellerName = "Sun Moon";
                    //}

                    //if (!string.IsNullOrEmpty(sellerName))
                    //{
                    //    if (sellerListings.ContainsKey(sellerName))
                    //    {
                    //        sellerListings[sellerName]++;
                    //    }
                    //    else
                    //    {
                    //        sellerListings.Add(sellerName, 1);   
                    //    }  
                    //}
                    var sellerNameElement = item.FindElement(By.XPath(".//a[@class='seller-info']"));
                    var sellerName = sellerNameElement.Text.Trim();

                    if (sellerListings.ContainsKey(sellerName))
                    {
                        sellerListings[sellerName]++;
                    }
                }
                totalShowAllContent += ContentOnPage;

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

            Console.WriteLine($"Total number of listings: {totalShowAllContent}");
            foreach (var seller in sellerListings)
            {
                Console.WriteLine($"{seller.Key} has {seller.Value} listings.");
            }
        }
        
    }

}
