using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class NotificationPage : CommonDriver
    {
        private IWebElement signInButton => driver.Value.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));

        private IWebElement emailAddressTextbox => driver.Value.FindElement(By.XPath("//input[@placeholder='Email address']"));

        private IWebElement passwordTextbox => driver.Value.FindElement(By.XPath("//input[@placeholder='Password']"));

        private IWebElement loginButton => driver.Value.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        public void SendSkillSwapRequest(string searchSkill, string selectSeller, string selectSkill, string messageToSeller, string Emailaddress, string Password, string Sender)
        {
            IWebElement searchSkillsSearchIcon = driver.Value.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
            searchSkillsSearchIcon.Click();
            Thread.Sleep(2000);
            IWebElement searchSkills = driver.Value.FindElement(By.XPath("(//input[@placeholder='Search skills'])[2]"));
            searchSkills.SendKeys(searchSkill + Keys.Enter);
            Thread.Sleep(2000);
            IWebElement selectListing = driver.Value.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]"));
            Console.WriteLine($"Selected {selectListing.Text}");
            selectListing.Click();
            IWebElement messageToSellerTextbox = driver.Value.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea"));
            messageToSellerTextbox.SendKeys(messageToSeller);
            Thread.Sleep(3000);
            string sentDate = DateTime.Now.ToString("dd MMM, yyyy");
            IWebElement requestButton = driver.Value.FindElement(By.XPath("//div[@class='ui teal  button']"));
            requestButton.Click();
            Thread.Sleep(2000);
            IWebElement yesButton = driver.Value.FindElement(By.XPath("//button[@class='ui button ui teal button' and text()='Yes']"));
            yesButton.Click();
          
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (popupAlert.Text == "Request sent")
            {
              
                Console.WriteLine($"SkillSwap request sent successfully on {sentDate}");
            }
            else
            {
                Console.WriteLine("SkillSwap request not sent");
            }
            IWebElement manageRequest = driver.Value.FindElement(By.XPath("//div[@class='ui dropdown link item' and @tabindex='0']"));
            manageRequest.Click();
            Thread.Sleep(2000);
            IWebElement sentRequests = driver.Value.FindElement(By.XPath("//a[@class='item' and @href='/Home/SentRequest']"));
            sentRequests.Click();
            Thread.Sleep(2000);
            IWebElement skillswaprequestsent = driver.Value.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
            //skillswaprequestsent.Click(); 
            if (skillswaprequestsent.Text.Contains (selectSkill))
            {
                Console.WriteLine("selected listing is correct");
            }
            else
            {
                Console.WriteLine("selected listing is incorrect");
            }
            Thread.Sleep(3000);
            
            IWebElement recipient = driver.Value.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));
            IWebElement date = driver.Value.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[7]"));
           
            if (recipient.Text == selectSeller && date.Text == sentDate)
            {
                Console.WriteLine("Recipient name should be full name because if there are two seller with same first name then it can be confusing and date is not correct");
            }
            else
            {
                Console.WriteLine("Recipient name should be full name because if there are two seller with same first name then it can be confusing and date are correct");
            }

            IWebElement signOutButton = driver.Value.FindElement(By.XPath("//button[@class='ui green basic button' and text()='Sign Out']"));
            signOutButton.Click();
            Thread.Sleep(2000);
            IWebElement signinButton = driver.Value.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
            Thread.Sleep(2000);

            IWebElement emailAddressTextbox = driver.Value.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddressTextbox.SendKeys(Emailaddress);

            IWebElement passwordTextbox = driver.Value.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys(Password);

            IWebElement loginButton = driver.Value.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement hilock = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hilock.Text == "Hi Lock")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }
            Thread.Sleep(2000);
            IWebElement manageRequests = driver.Value.FindElement(By.XPath("//div[@class='ui dropdown link item' and @tabindex='0']"));
            manageRequests.Click();
            Thread.Sleep(2000);
            IWebElement receivedRequests = driver.Value.FindElement(By.XPath("//a[@class='item' and @href='/Home/ReceivedRequest']"));
            receivedRequests.Click();
            Thread.Sleep(2000);
            IWebElement sentrequest = driver.Value.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));
            if (sentrequest.Text.Contains(Sender))
            {
                Assert.Pass("Request received from Tony");
            }
            else
            {
                Assert.Fail("Request not received");
            }

        }

        
        public void NotificationLoadMoreandShowLess(string Emailaddress, string Password, string Notification, string NewNotification)
        {
            signInButton.Click();
            Thread.Sleep(2000);
            emailAddressTextbox.SendKeys(Emailaddress);
            passwordTextbox.SendKeys(Password);
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement hilock = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hilock.Text == "Hi Lock")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }
            Thread.Sleep(3000);
            IWebElement dashboardTab = driver.Value.FindElement(By.XPath("//a[@class='item' and @href='/Account/Dashboard']"));
            dashboardTab.Click();
            Thread.Sleep(2000);
            IWebElement notificationList = driver.Value.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div"));
            int initialNotificationCount = notificationList.FindElements(By.XPath("//div[@class='item link']")).Count;
            Console.WriteLine("Initial notification count: " + initialNotificationCount);

            IWebElement loadMoreButton = driver.Value.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            loadMoreButton.Click();

            // Wait for the new notifications to load
            Thread.Sleep(2000);

            // Get the updated notification count
            int updatedNotificationCount = notificationList.FindElements(By.XPath("//div[@class='item link']")).Count;
            Console.WriteLine("Updated notification count: " + updatedNotificationCount);

            // Assert that the notification count has increased by 5
            //Assert.AreEqual(initialNotificationCount + 5, updatedNotificationCount, "Notification count did not increase by 5");
            //Assert.That(updatedNotificationCount, Is.EqualTo(initialNotificationCount + 5), "Notification count did not increase by 5");
            Console.WriteLine($"Updated notification count: {updatedNotificationCount}, Expected notification count: {initialNotificationCount + 5}");
            if (updatedNotificationCount == initialNotificationCount + 5)
            {
                Console.WriteLine("Test Passed: Notification count increased by 5");
            }
            else
            {
                Console.WriteLine("Test Failed: Notification count did not increase by 5");
            }
            
            IWebElement showLessButton = driver.Value.FindElement(By.XPath("//a[@class='ui button' and text()='...Show Less']"));
            showLessButton.Click();

            // Wait for the notifications to collapse
            Thread.Sleep(3000);

            // Get the final notification count
            int finalNotificationCount = notificationList.FindElements(By.XPath("//div[@class='item link']")).Count;
            Console.WriteLine("Final notification count: " + finalNotificationCount);

            // Assert that the notification count has decreased to the initial count
            //Assert.AreEqual(initialNotificationCount, finalNotificationCount, "Notification count did not decrease to the initial count");
            Assert.That(finalNotificationCount, Is.EqualTo(initialNotificationCount), "Notification count did not decrease to the initial count");

        }
        public void MarkAllAsRead(string Emailaddress, string Password)
        {
            signInButton.Click();
            Thread.Sleep(2000);
            emailAddressTextbox.SendKeys(Emailaddress);
            passwordTextbox.SendKeys(Password);
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement hilock = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hilock.Text == "Hi Lock")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }
            Thread.Sleep(3000);
            try
            {
                IWebElement notificationCountElement = driver.Value.FindElement(By.XPath("//div[@class='floating ui blue label']"));
                if (int.TryParse(notificationCountElement.Text, out int notificationCount))
                {
                    Console.WriteLine("Notification Count: " + notificationCount);
                }
                else
                {
                    Console.WriteLine("Failed to parse notification count");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Notification count element not found");
            }

            IWebElement notification = driver.Value.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
            notification.Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement notificationContent = driver.Value.FindElement(By.XPath("//div[@class='content' and contains(@style, 'font-weight: bold')]"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Notification content bold not found");
            }


            IWebElement markAllAsRead = driver.Value.FindElement(By.XPath("//a[contains(text(), 'Mark all as read')]"));
            markAllAsRead.Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement notificationCountElementAfterMarkRead = driver.Value.FindElement(By.XPath("//div[@class='floating ui blue label']"));
                if (int.TryParse(notificationCountElementAfterMarkRead.Text, out int notificationCountAfterMarkRead) && notificationCountAfterMarkRead == 0)
                {
                    Console.WriteLine("Notification count is zero as expected");
                }
                else
                {
                    Console.WriteLine("Notification count is not zero or failed to parse");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Notification count element not found after mark read");
            }


            // Wait for the notification content to be updated
            Thread.Sleep(3000);

            try
            {
                IWebElement Notification = driver.Value.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
                Notification.Click();
                IWebElement notificationContentAfterMarkRead = driver.Value.FindElement(By.XPath("//div[@class='content' and contains(@style, 'font-weight: bold')]"));
                Console.WriteLine("Notification content is still bold");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Notification content is no longer bold as expected after mark all as read");
            }

        }
        public void SelectandUnselect(string Emailaddress, string Password)
        {
            signInButton.Click();
            Thread.Sleep(2000);
            emailAddressTextbox.SendKeys(Emailaddress);
            passwordTextbox.SendKeys(Password);
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement hilock = driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hilock.Text == "Hi Lock")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }
            Thread.Sleep(3000);
            IWebElement notification = driver.Value.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
            notification.Click();
            Thread.Sleep(3000);
            IWebElement seeAll = driver.Value.FindElement(By.XPath("//a[@href='/Account/Dashboard' and contains(text(), 'See All...')]"));
            seeAll.Click();
            Thread.Sleep(3000);
            while (true)
            {
                try
                {
                    IWebElement loadMoreButton = driver.Value.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
                    loadMoreButton.Click();
                    Thread.Sleep(2000);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Load More button is no longer visible");
                    break;
                }
            }
            Thread.Sleep(3000);
            while (true)
            {
                try
                {
                    IWebElement showLessButton = driver.Value.FindElement(By.XPath("//a[@class='ui button' and text()='...Show Less']"));
                    showLessButton.Click();
                    Thread.Sleep(2000);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Show Less button is no longer visible");
                    break;
                }
            }
            Thread.Sleep(3000);

            //IWebElement loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            //loadMoreButton.Click();
            //Thread.Sleep(2000);
            //IWebElement AgainloadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            //AgainloadMoreButton.Click();
            //Thread.Sleep(2000);

            IWebElement selectAll = driver.Value.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
            selectAll.Click();
            Thread.Sleep(3000);
            IWebElement unSelectAll = driver.Value.FindElement(By.XPath("//i[@class='ban icon']"));
            unSelectAll.Click();
            Thread.Sleep(2000);
            IWebElement selectAllAgain = driver.Value.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
            selectAllAgain.Click();
            Thread.Sleep(3000);
            IWebElement markSelectionAsRead = driver.Value.FindElement(By.XPath("//i[@class='check square icon']"));
            markSelectionAsRead.Click();
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (popupAlert.Text == "Notification updated")
            {

                Console.WriteLine("Notification updated is correct");
            }
            else
            {
                Console.WriteLine("SkillSwap request not sent");
            }
            IWebElement checkBox = driver.Value.FindElement(By.XPath("//input[@type='checkbox' and @value='0']"));
            checkBox.Click();
            Thread.Sleep(3000);
            IWebElement deleteSelection = driver.Value.FindElement(By.XPath("//i[@class='trash icon']"));
            deleteSelection.Click();
            Wait.WaitToBeClickable(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement poopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (poopupAlert.Text == "Notification updated")
            {

                Console.WriteLine("Notification updated is correct ");
            }
            else
            {
                Console.WriteLine("SkillSwap request not sent");
            }

        }



        }
    }

