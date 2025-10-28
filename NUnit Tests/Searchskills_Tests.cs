using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.TestData.Searchskills;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                if (data.Category != null && data.Subcategory != null && data.Listings != null)
                {
                   yield return new TestCaseData(data.Category, data.Subcategory, data.Listings);
                }
                else if (data.Filter != null)
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
        [Test]
        public void CountTotaalListings()
        {
            IWebElement manageListingsTab = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
            manageListingsTab.Click();
            Thread.Sleep(3000);

            int totaltableRow = 0;
            int totalPages = 0;
            bool hasNextPage = true;
            int currentPage = 1;

            while (hasNextPage)
            {
                var tableRow = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr"));
                int tableRowOnPage = tableRow.Count;
                Console.WriteLine($"Number of tableRow on page {currentPage}: {tableRowOnPage}");
                totaltableRow += tableRowOnPage;

                var pageButtons = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
                var nextPageButton = pageButtons.Where(b => b.Text == (currentPage + 1).ToString()).FirstOrDefault();

                if (nextPageButton != null)
                {
                    nextPageButton.Click();
                    Thread.Sleep(2000); // Wait for the page to load
                    currentPage++;
                }
                else
                {
                    hasNextPage = false;
                }
            }

            Console.WriteLine($"Total number of listings: {totaltableRow}");
            if (totaltableRow > 0)
            {
                Assert.Pass("Listings found.");
            }
            else
            {
                Assert.Fail("No listings found.");
            }
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
            if (totalOnlineListings == 19)
            {
                Assert.Pass("The total number of online listings is 19.");
            }
            else
            {
                Assert.Fail("The total number of online listings is not 19.");
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withOnsiteFilter.json", "SearchskillsbyapplyingOnsiteFilter" })]
        public void SearchskillsbyapplyingOnsiteFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithOnsiteFilter(Filter);

           
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
            var expectedListings = 26;
            if (totalOnsiteListings == expectedListings)
            {
                Assert.Pass($"The total number of onsite listings is {expectedListings}.");
            }
            else
            {
                Assert.Fail($"The total number of onsite listings is not {expectedListings}. Expected {expectedListings} but got {totalOnsiteListings}.");
            }
            
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withShowAllFilter.json", "SearchskillsbyapplyingShowAllFilter" })]
        public void SearchskillsbyapplyingShowAllFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithShowAllFilter(Filter);
            

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
            if (totalShowAllListings == 45)
            {
                Assert.Pass("The total number of ShowAll listings is 45.");
            }
            else
            {
                Assert.Fail("The total number of ShowAll listings is not 45.");
            }
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
        [Test]
        public void TestCategoryMatching()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            // Get the categories from the top
            var topCategories = driver.FindElements(By.XPath("//div[@role='list']")).Select(e => e.Text).ToList();

            // Get the categories from the footer
            var footerCategories = driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/section[2]/div/div/div/div[1]/nav")).Select(e => e.Text).ToList();

            // Compare the categories
            CollectionAssert.AreEqual(topCategories, footerCategories, "The categories at the top and footer do not match.");
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_byAllCategoryandSubcategories.json", "SearchskillsbyallCategoryandSubcategories" })]
        public void SearchskillsbyallCategoryandSubcategories(string Category, string Subcategory, string Listings)
        {
            Console.WriteLine($"Running test with data: Category = {Category}, Subcategory = {Subcategory}, Listings = {Listings}");
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithAllCategoryandSubcategory(Category, Subcategory, Listings);
            Thread.Sleep(2000);
                // Check if "No results found" message is displayed
                if (driver.FindElement(By.XPath("//h3[text()='No results found, please select a new category!']")).Displayed)
                {

                    Assert.Pass("User clicked on subcategory so it should take user back to subcategory but instead it threw user out completely and displayed a message. No results found, please select a new category!");
                    // You can add additional logic here to handle this scenario
                }
                else
                {
                    Assert.Fail("Subcategory page loaded successfully.");
                    // You can add additional logic here to proceed with the test
                }
            
            
        }
        [Test]
        public void TestSearchUser()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            IWebElement searchUser = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            searchUser.SendKeys("sun");
            Thread.Sleep(3000);
            var suggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']"))); // adjust the XPath according to your suggestions dropdown
            bool suggestionFound = false;

            foreach (var suggestion in suggestions)
            {
                if (suggestion.Text.ToLower().Contains("sun moon"))
                {
                    suggestion.Click();
                    suggestionFound = true;
                    break;
                }
            }

            if (!suggestionFound)
            {
                Console.WriteLine("Suggestion 'sun moon' not found.");
            }
            //IWebElement searchUser = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            //searchUser.SendKeys("Sun Moon");
            //Thread.Sleep(3000);
            //var suggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']"))); // adjust the XPath according to your suggestions dropdown
            //foreach (var suggestion in suggestions)
            //{
            //    if (suggestion.Text.Contains("Sun Moon"))
            //    {
            //        suggestion.Click();
            //        break;
            //    }
            //}
            Thread.Sleep(7000);
        }
        [Test]
        public void TestSearchSkills()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            IWebElement searchSkills = driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[2]"));
            searchSkills.SendKeys("Testing" + Keys.Enter);
            Thread.Sleep(3000);
            var searchResults = driver.FindElements(By.XPath("//div[@class='ui card']")); // adjust the XPath according to your result elements

            Console.WriteLine("Total listings: " + searchResults.Count);
            Thread.Sleep(2000);
            var categories = driver.FindElements(By.XPath("//a[@role='listitem' and @class='item category']"));
            Thread.Sleep(4000);
            foreach (var category in categories)
            {
                // Check if the category has a right floated content that is not zero
                var rightFloatedContent = category.FindElement(By.XPath(".//span[@class='right-floated']"));
                if (rightFloatedContent.Text != "0")
                {
                    Console.WriteLine("Category: " + category.Text);
                    Console.WriteLine("Count: " + rightFloatedContent.Text);
                    category.Click();
                    Thread.Sleep(2000);
                    // Get subcategories
                    var subcategories = driver.FindElements(By.XPath("//a[@role='listitem' and @class='item subcategory']"));
                    Thread.Sleep(4000);
                    foreach (var subcategory in subcategories)
                    {
                        var subcategoryRightFloatedContent = subcategory.FindElement(By.XPath(".//span[@class='right-floated']"));
                        if (subcategoryRightFloatedContent.Text != "0")
                        {
                            Console.WriteLine("  Subcategory: " + subcategory.Text);
                            Console.WriteLine("  Listings: " + subcategoryRightFloatedContent.Text);
                        }
                    }
                }
            }
            // Get all categories
            //var categories = driver.FindElements(By.XPath("//a[@role='listitem' and @class='item category']"));
            //Thread.Sleep(4000);
            //foreach (var category in categories)
            //{
            //    // Check if the category has a right floated content that is not zero
            //    var rightFloatedContent = category.FindElement(By.XPath(".//span[@class='right-floated']"));
            //    if (rightFloatedContent.Text != "0")
            //    {
            //        Console.WriteLine("Category: " + category.Text);
            //        Console.WriteLine("Count: " + rightFloatedContent.Text);

            //        // Get subcategories
            //        var subcategories = category.FindElements(By.XPath(".//following-sibling::a[@role='listitem' and @class='item subcategory']"));
            //        Thread.Sleep(4000);
            //        foreach (var subcategory in subcategories)
            //        {
            //            // Check if the subcategory has listings related to testing
            //            var listingsCount = subcategory.FindElement(By.XPath(".//span[@class='right-floated']")).Text;
            //            if (listingsCount != "0")
            //            {
            //                Console.WriteLine("  Subcategory: " + subcategory.Text);
            //                Console.WriteLine("  Listings: " + listingsCount);
            //            }
            //        }
            //    }
            //}

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }

}
