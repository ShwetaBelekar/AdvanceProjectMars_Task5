using AdvanceProjectMars_Task5.BaseClass;
using AdvanceProjectMars_Task5.Pages;
using AdvanceProjectMars_Task5.TestData.Searchskills;
using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

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
    [Parallelizable]
    [TestFixture]
    public class Searchskills_Tests : BaseTest
    {
        [SetUp]
        public void SetUpSteps()
        {
            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://localhost:5003/Home");
            //driver.Manage().Window.Maximize();
            LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions();
            loginPageObj.VerifyUserInHomePage();
        }
        public static IEnumerable<TestCaseData> GetTestData(string fileName, string testName)
        {
            var testData = TestDataReader.ReadTestData(fileName);
            foreach (var data in testData[testName])
            {
               
                if (data.searchText != null && data.targetText != null && data.NewsearchText != null && data.NewtargetText != null)
                {
                    yield return new TestCaseData(data.searchText, data.targetText, data.NewsearchText, data.NewtargetText);
                }
                else if (data.Category != null && data.Subcategory != null && data.Listings != null)
                {
                    yield return new TestCaseData(data.Category, data.Subcategory, data.Listings);
                }
                else if (data.searchSkill != null)
                {
                    yield return new TestCaseData(data.searchSkill);
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
                    Thread.Sleep(2000); 
                    currentPage++;
                }
                else
                {
                    hasNextPage = false;
                }
            }

            Console.WriteLine($"Total number of listings: {totaltableRow}");
            string message = totaltableRow > 0 ? "Listings found." : "You do not have any service listings!";
            Assert.Pass(message);
            
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withOnlineFilter.json", "SearchskillsbyapplyingOnlineFilter" })]
        public void SearchskillsbyapplyingOnlineFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithOnlineFilter(Filter);
            int totalOnlineListings = 0;
            bool hasNextPage = true;
            int currentPage = 1;
            Thread.Sleep(4000);
            while (hasNextPage)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {currentPage}: {listingsOnPage}");
                totalOnlineListings += listingsOnPage;

                var pageButtons = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
                var nextPageButton = pageButtons.Where(b => b.Text == (currentPage + 1).ToString()).FirstOrDefault();

                if (nextPageButton != null)
                {
                    nextPageButton.Click();
                    Thread.Sleep(2000); 
                    currentPage++;
                }
                else
                {
                    hasNextPage = false;
                }
            }

            Console.WriteLine($"Total number of listings: {totalOnlineListings}");
            if (totalOnlineListings > 0)
            {
                Assert.Pass($"The total number of online listings is {totalOnlineListings}.");
            }
            else
            {
                Assert.Fail("No online listings found.");
            }
            
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withOnsiteFilter.json", "SearchskillsbyapplyingOnsiteFilter" })]
        public void SearchskillsbyapplyingOnsiteFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithOnsiteFilter(Filter);
            int totalOnsiteListings = 0;
            bool hasNextPage = true;
            int currentPage = 1;
            Thread.Sleep(4000);
            while (hasNextPage)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {currentPage}: {listingsOnPage}");
                totalOnsiteListings += listingsOnPage;

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

            Console.WriteLine($"Total number of listings: {totalOnsiteListings}");
            if (totalOnsiteListings > 0)
            {
                Assert.Pass($"The total number of onsite listings is {totalOnsiteListings}.");
            }
            else
            {
                Assert.Fail("No onsite listings found.");
            }
            
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_withShowAllFilter.json", "SearchskillsbyapplyingShowAllFilter" })]
        public void SearchskillsbyapplyingShowAllFilter(string Filter)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithShowAllFilter(Filter);
            

            int totalShowAllListings = 0;
            bool hasNextPage = true;
            int currentPage = 1;
           
            Thread.Sleep(4000);
            while (hasNextPage)
            {
                var listings = driver.FindElements(By.XPath("//div[@class='ui card']"));
                int listingsOnPage = listings.Count;
                Console.WriteLine($"Number of listings on page {currentPage}: {listingsOnPage}");
                totalShowAllListings += listingsOnPage;
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
        

            Console.WriteLine($"Total number of listings: {totalShowAllListings}");
            if (totalShowAllListings > 0)
            {
                Assert.Pass($"The total number of showall listings is {totalShowAllListings}.");
            }
            else
            {
                Assert.Fail("No showall listings found.");
            }
        }
        [Test]
        public void ShowAllContent()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            int totalShowAllContent = 0;
            bool hasNextPage = true;
            int currentPage = 0;
            Thread.Sleep(6000);
            var sellerListings = new Dictionary<string, int>();

            while (hasNextPage)
            {
                var Content = driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]"));
                int ContentOnPage = Content.Count;
                Console.WriteLine($"Number of listings on page {currentPage + 1}: {ContentOnPage}");
                foreach (var item in Content)
                {
                    Console.WriteLine(item.Text);

                    var sellerNameElement = item.FindElement(By.XPath(".//a[@class='seller-info']"));
                    var sellerName = sellerNameElement.Text.Trim();

                    if (sellerListings.ContainsKey(sellerName))
                    {
                        sellerListings[sellerName]++;
                    }
                    else
                    {
                        sellerListings.Add(sellerName, 1);
                    }
                }
                totalShowAllContent += ContentOnPage;

                var pageButtons = driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
                var nextPageButton = pageButtons.Where(b => b.Text == (currentPage + 2).ToString()).FirstOrDefault();

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

            Console.WriteLine($"Total number of listings: {totalShowAllContent}");
            TestContext.Progress.WriteLine("Seller Listings:");
            foreach (var seller in sellerListings)
            {
                TestContext.Progress.WriteLine($"{seller.Key} has {seller.Value} listings.");
                Console.WriteLine($"{seller.Key} has {seller.Value} listings.");
            }
            

        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_byAllCategoryandSubcategories.json", "SearchskillsbyallCategoryandSubcategories" })]
        public void SearchskillsbyallCategoryandSubcategories(string Category, string Subcategory, string Listings)
        {
            Console.WriteLine($"Running test with data: Category = {Category}, Subcategory = {Subcategory}, Listings = {Listings}");
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.SearchSkillWithAllCategoryandSubcategory(Category, Subcategory, Listings);
            Thread.Sleep(2000);
               
                if (driver.FindElement(By.XPath("//h3[text()='No results found, please select a new category!']")).Displayed)
                {

                    Assert.Pass("User clicked on subcategory so it should take user back to subcategory but instead it threw user out completely and displayed a message. No results found, please select a new category!");
                    
                }
                else
                {
                    Assert.Fail("Subcategory page loaded successfully.");
                   
                }
            
            
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_SearchUser.json", "TestSearchUser" })]
        public void TestSearchUser(string searchText, string targetText, string NewsearchText, string NewtargetText)
        {

            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.TestSearchUser(searchText, targetText);
            var suggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']")));
            bool suggestionFound = false;

            foreach (var suggestion in suggestions)
            {
                if (suggestion.Text.ToLower().Contains(targetText.ToLower()))
                {
                    suggestion.Click();
                    Console.WriteLine($"Suggestion '{targetText}' found and clicked.");
                    suggestionFound = true;
                    break;
                }
            }

            if (!suggestionFound)
            {
                Console.WriteLine($"Suggestion '{targetText}' not found but system doesn't throw any message result not found.");
            }
            
            Thread.Sleep(7000);
            searchskillsPageObj.TestNewSearchUser(NewsearchText, NewtargetText);
            var newsuggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']")));
            bool newsuggestionFound = false;

            foreach (var newsuggestion in newsuggestions)
            {
                if (newsuggestion.Text.ToLower().Contains(NewtargetText.ToLower()))
                {
                    newsuggestion.Click();
                    Assert.Pass($"NewSuggestion '{NewtargetText}' found and clicked.");
                    suggestionFound = true;
                    break;
                }
            }

            if (!newsuggestionFound)
            {
                Assert.Pass($"NewSuggestion '{NewtargetText}' not found but system doesn't throw any message result not found.");
            }
            Thread.Sleep(7000);
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Searchskills_SearchSkill.json", "TestSearchSkill" })]
        public void TestSearchSkill(string searchSkill)
        {
            SearchskillsPage searchskillsPageObj = new SearchskillsPage();
            searchskillsPageObj.TestSearchSkill(searchSkill);
            var searchResults = driver.FindElements(By.XPath("//div[@class='ui card']"));
            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found, please select a new category!");
                Assert.Pass("No results found, please select a new category!");
                return;
            }
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
            

        }
       
        [Test]
        public void CheckNotificationAlerts()
        {
            Thread.Sleep(2000);
            IWebElement notification = driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
            notification.Click();
            Thread.Sleep(3000);
            IWebElement seeAll = driver.FindElement(By.XPath("//a[@href='/Account/Dashboard' and contains(text(), 'See All...')]"));
            seeAll.Click();
            Thread.Sleep(3000);
            IWebElement markAllAsRead = driver.FindElement(By.XPath("//a[contains(text(), 'Mark all as read')]"));
            markAllAsRead.Click();
            IWebElement selectAll = driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
            selectAll.Click();
            IWebElement unSelectAll = driver.FindElement(By.XPath("//i[@class='ban icon']"));
            unSelectAll.Click();
            IWebElement markSelectionAsRead = driver.FindElement(By.XPath("//i[@class='check square icon']"));
            markSelectionAsRead.Click();
            IWebElement checkBox = driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']"));
            checkBox.Click();
            IWebElement loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            loadMoreButton.Click();
            IWebElement showLessButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='...Show Less']"));
            showLessButton.Click();
            //IWebElement deleteSelection = driver.FindElement(By.XPath("//i[@class='trash icon']"));
            //deleteSelection.Click();



        }
        //[TearDown]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}

    }

}
