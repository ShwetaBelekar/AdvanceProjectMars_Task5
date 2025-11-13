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
        [Test]
        public void TestSearchUser()
        {
            IWebElement searchSkillsSearchIcon = driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            string searchText = "sunmoon";
            string targetText = "Sun mOOn";
            IWebElement searchUser = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            searchUser.SendKeys(searchText);
            Thread.Sleep(3000);
            var suggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']")));
            bool suggestionFound = false;

            foreach (var suggestion in suggestions)
            {
                if (suggestion.Text.ToLower().Contains(targetText.ToLower()))
                {
                    suggestion.Click();
                    Assert.Pass($"Suggestion '{targetText}' found and clicked.");
                    suggestionFound = true;
                    break;
                }
            }

            if (!suggestionFound)
            {
                Assert.Pass($"Suggestion '{targetText}' not found but system doesn't throw any message result not found.");
            }
            //string searchText = "ear";
            //string targetText = "earth";
            //IWebElement searchUser = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            //searchUser.SendKeys(searchText);
            //Thread.Sleep(3000);
            //var suggestions = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//div[@class='result' and @score='0']")));

            //if (suggestions.Count == 0)
            //{
            //    Assert.Fail($"No suggestions found for '{targetText}'. User not found.");
            //}
            //else
            //{
            //    bool suggestionFound = false;

            //    foreach (var suggestion in suggestions)
            //    {
            //        if (suggestion.Text.ToLower().Contains(targetText.ToLower()))
            //        {
            //            suggestion.Click();
            //            suggestionFound = true;
            //            break;
            //        }
            //    }
            //    Assert.That(suggestionFound, Is.True, $"Suggestion '{targetText}' not found.");
            //    //Assert.True(suggestionFound, $"Suggestion '{targetText}' not found.");
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
            searchSkills.SendKeys("Automation" + Keys.Enter);
            Thread.Sleep(3000);
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
        [Test]
        public void SendSkillSwapRequest()
        {
            IWebElement searchSkills = driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]"));
            searchSkills.SendKeys("Cooking" + Keys.Enter);
            Thread.Sleep(2000);
            IWebElement selectListing = driver.FindElement(By.XPath("//p[@class='row-padded']"));
            Console.WriteLine($"Selected {selectListing.Text}");
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
            IWebElement manageRequest = driver.FindElement(By.XPath("//div[@class='ui dropdown link item' and @tabindex='0']"));
            manageRequest.Click();
            Thread.Sleep(2000);
            IWebElement sentRequests = driver.FindElement(By.XPath("//a[@class='item' and @href='/Home/SentRequest']"));
            sentRequests.Click();
            Thread.Sleep(2000);
            IWebElement skillswaprequestsent = driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]"));
            //skillswaprequestsent.Click();
            if (skillswaprequestsent.Text == "LearnCooking")
            {
                Console.WriteLine("selected listing is correct");
            }
            else
            {
                Console.WriteLine("selected listing is incorrect");
            }
            Thread.Sleep(3000);
            IWebElement recipient = driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));
            IWebElement date = driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[7]"));
            if(recipient.Text == "Sun" && date.Text == "29th Oct, 2025")
            {
                Assert.Pass("Recipient name should be full name because if there are two seller with same first name then it can be confusing and date is not correct");
            }
            else
            {
                Assert.Fail("Recipient name and date are correct");
            }
            IWebElement signOutButton = driver.FindElement(By.XPath("//button[@class='ui green basic button' and text()='Sign Out']"));
            signOutButton.Click();
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
            Thread.Sleep(2000);

            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddressTextbox.SendKeys("moonsun@gmail.com");

            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Sun@123");

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement hisun = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hisun.Text == "Hi Sun")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
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
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }

}
