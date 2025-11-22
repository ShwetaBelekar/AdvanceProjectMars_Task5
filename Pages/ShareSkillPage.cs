using AdvanceProjectMars_Task5.Utilities;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace AdvanceProjectMars_Task5.Pages
{
    public class ShareSkillPage : CommonDriver
    {
      
        private IWebElement ShareSkillButton => driver.Value.FindElement(By.XPath("//a[@href='/Home/ServiceListing']"));
        
        private IWebElement titleTextbox => driver.Value.FindElement(By.XPath("//input[@name='title']"));

        private IWebElement descriptionTextbox => driver.Value.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
        private IWebElement categoryDropdownButton => driver.Value.FindElement(By.XPath("//select[@name='categoryId']"));

        private IWebElement categoryOptions => driver.Value.FindElement(By.XPath("//option[contains(text(), 'Software Development') and @value='1']"));

        private IWebElement selectsubcategoryDropdownButton => driver.Value.FindElement(By.XPath("//select[@name='subcategoryId']"));

        private IWebElement selectsubcategoryOptions => driver.Value.FindElement(By.XPath("//option[contains(text(), 'Solution Architecture Design') and @value='1']"));

        private IWebElement tagTextbox => driver.Value.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        private IWebElement hourlyBasisServiceButton => driver.Value.FindElement(By.XPath("//input[@name='serviceType' and @value='0']"));

        private IWebElement oneoffServiceButton => driver.Value.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));

        private IWebElement onSiteLocationButton => driver.Value.FindElement(By.XPath("//input[@name='locationType' and @value='0']"));

        private IWebElement onlineLocationButton => driver.Value.FindElement(By.XPath("//input[@name='locationType' and @value='1']"));

        private IWebElement skillExchangeButton => driver.Value.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
        private IWebElement creditRadioButton => driver.Value.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
        private IWebElement skillExchangeTagTextbox => driver.Value.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement CreditButton => driver.Value.FindElement(By.XPath("//input[@name='charge']"));
        private IWebElement uploadWorkSamplesButton => driver.Value.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement activeRadioButton => driver.Value.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));

        private IWebElement hiddenRadioButton => driver.Value.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
        private IWebElement saveButton => driver.Value.FindElement(By.XPath("//input[@value='Save']"));
        
        private IWebElement cancelButton => driver.Value.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement manageListingsTab => driver.Value.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
        
        private IWebElement viewButton => driver.Value.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]/i"));
        private IWebElement editButton => driver.Value.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        private IWebElement deleteButton => driver.Value.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
        public void CreateShareSkillRecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string SkillTrade, string Credit, string SkillExchange, string Active)

        {

            Thread.Sleep(5000);
            ShareSkillButton.Click();

            
            titleTextbox.Click();
            titleTextbox.SendKeys(Title);
            Thread.Sleep(2000);
            
            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(Description);
            Thread.Sleep(2000);
            
            categoryDropdownButton.SendKeys(Category);
            Thread.Sleep(2000);
            selectsubcategoryDropdownButton.SendKeys(SelectSubcategory);
            Thread.Sleep(3000);
            tagTextbox.Click();
            tagTextbox.SendKeys(Tags + Keys.Enter);
            //tagTextbox.SendKeys(Tags);

            //hourlyBasisServiceButton.Click();
            Thread.Sleep(2000);
            if (ServiceType == "Hourly basis service")
            {
                hourlyBasisServiceButton.Click();
            }
            else if (ServiceType == "One-off service")
            {
                oneoffServiceButton.Click();
            }

                //oneoffServiceButton.Click();
                
            Thread.Sleep(3000);
            if (LocationType == "On site")
            {
                onSiteLocationButton.Click();
            }
            else if (LocationType == "Online")
            {
                onlineLocationButton.Click();
            }
            
            Thread.Sleep(3000);

            

            //onlineLocationButton.Click();

            if (SkillTrade == "Skill-exchange")
            {
                skillExchangeButton.Click();
                skillExchangeTagTextbox.Click();
                skillExchangeTagTextbox.SendKeys(SkillExchange + Keys.Enter);
            }
            else if (SkillTrade == "Credit")
            {
                creditRadioButton.Click();
                CreditButton.SendKeys(Credit + Keys.Enter);
            }
                
            Thread.Sleep(3000);

            uploadWorkSamplesButton.Click();
            Thread.Sleep(3000);
            string filePath = @"C:\Users\ganve\OneDrive\Pictures\Screenshots\Screenshot 2025-08-28 083208.png";
         
            Thread.Sleep(3000);
            
            driver.Value.FindElement(By.XPath("//input[@type='file']")).SendKeys(filePath);
            var simulator = new InputSimulator();
            simulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);
           
            if (Active == "Active")
            {
                activeRadioButton.Click();
            }
            else if (Active == "Hidden")
            {
                hiddenRadioButton.Click();
            }
            
            Thread.Sleep(2000);
            


            saveButton.Click();

            Wait.WaitToBeVisible(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement recordcreatedpopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = recordcreatedpopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (recordcreatedpopupAlert.Text == "Service Listing Added successfully") 
            {
                Console.WriteLine("Record created successfully");
            }
            else
            {
                Console.WriteLine("Record creation unsuccessful");
            }
                
            Wait.WaitToBeVisible(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement worksamplepopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string proomptText = worksamplepopupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);
            if (worksamplepopupAlert.Text == "There is an error when updating Work Samples - undefined") 
            {
                Console.WriteLine("error in the system work sample upload feature is not correctly uploading the work files");
            }
            else
            {
                Console.WriteLine("no error in the system work sample upload feature works correctly");
            }
            Thread.Sleep(8000);
            cancelButton.Click();
            Thread.Sleep(8000);
            manageListingsTab.Click();
            Thread.Sleep(3000);
            //categoryOptions.Click();
            //categoryOptions.SendKeys(Category);

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Data Analysis & Business Intelligence') and @value='2']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Test Automation') and @value='3']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Data Science') and @value='4']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Machine Learning') and @value='5']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Game Development') and @value='6']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Communication') and @value='7']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Fun & Lifestyle') and @value='8']"));
            //categoryOptions.Click();

            //IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Recruitment') and @value='9']"));
            //categoryOptions.Click();

            //selectsubcategoryOptions.Click();
            //selectsubcategoryOptions.SendKeys(SelectSubcategory);

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Programming') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Front End Development') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Back End Development') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Design Pattern') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'DevOps CI/CD') and @value='6']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='7']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Data Cleaning and Standardisation') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Data Warehousing') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'ETL Design') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Data Visualisation') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'PowerBI') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Tableau') and @value='6']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Wherescape RED') and @value='7']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='8']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Selenium') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Cucumber/Specflow') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'API Testing') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Performance Testing') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Python Programming') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'R Studio Programming') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Big Data') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Supervised Learning') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Unsupervised Learning') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Reinforcement Learning') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Unity') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Unreal') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), '3D Modeling') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Game Design') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'HTML5') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='6']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Communication at Work') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Job Hunting Advice') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Job Market Advice') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Interview Advice') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Job Analysis Consulting') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[7]"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Online Lessons') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Relationship Advice') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Astrology') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Health, Nutrition & Fitness') and @value='4']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Gaming') and @value='5']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Other') and @value='6']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Employability') and @value='1']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'CV Advices') and @value='2']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Interview Advice') and @value='3']"));
            //subcategoryOptions.Click();

            //IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Job Market Insight') and @value='4']"));
            //subcategoryOptions.Click();

        }
        public void CreateblankShareSkillRecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string SkillTrade, string Credit, string SkillExchange, string Active)

        {
            Thread.Sleep(3000);
            ShareSkillButton.Click();


            titleTextbox.Click();
            titleTextbox.SendKeys(Title);
            Thread.Sleep(2000);

            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(Description);
            Thread.Sleep(2000);

            categoryDropdownButton.SendKeys(Category);
            Thread.Sleep(2000);
            //selectsubcategoryDropdownButton.SendKeys(SelectSubcategory);
            //Thread.Sleep(3000);
            tagTextbox.Click();
            tagTextbox.SendKeys(Tags + Keys.Enter);
            //tagTextbox.SendKeys(Tags);

            //hourlyBasisServiceButton.Click();
            Thread.Sleep(2000);
            if (ServiceType == "Hourly basis service")
            {
                hourlyBasisServiceButton.Click();
            }
            else if (ServiceType == "One-off service")
            {
                oneoffServiceButton.Click();
            }

            //oneoffServiceButton.Click();

            Thread.Sleep(3000);
            if (LocationType == "On site")
            {
                onSiteLocationButton.Click();
            }
            else if (LocationType == "Online")
            {
                onlineLocationButton.Click();
            }

            Thread.Sleep(3000);



            //onlineLocationButton.Click();

            if (SkillTrade == "Skill-exchange")
            {
                skillExchangeButton.Click();
                skillExchangeTagTextbox.Click();
                skillExchangeTagTextbox.SendKeys(SkillExchange + Keys.Enter);
            }
            else if (SkillTrade == "Credit")
            {
                creditRadioButton.Click();
                CreditButton.SendKeys(Credit + Keys.Enter);
            }

            Thread.Sleep(3000);

            uploadWorkSamplesButton.Click();
            Thread.Sleep(3000);
            string filePath = @"C:\Users\ganve\OneDrive\Pictures\Screenshots\Screenshot 2025-08-28 083208.png";

            Thread.Sleep(3000);

            driver.Value.FindElement(By.XPath("//input[@type='file']")).SendKeys(filePath);
            var simulator = new InputSimulator();
            simulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);

            if (Active == "Active")
            {
                activeRadioButton.Click();
            }
            else if (Active == "Hidden")
            {
                hiddenRadioButton.Click();
            }

            Thread.Sleep(2000);



            saveButton.Click();

        }
        
        public void EditExistingShareSkillRecord(string NewTitle, string NewDescription, string NewCategory, string NewSelectSubcategory, string NewTags, string NewServiceType, string NewLocationType, string NewSkillTrade, string NewCredit, string NewSkillExchange, string NewActive)
        {

            //viewButton.Click();

            Thread.Sleep(5000);
            editButton.Click();
            titleTextbox.Click();
            titleTextbox.Clear();
            titleTextbox.SendKeys(NewTitle);
            Thread.Sleep(2000);

            descriptionTextbox.Click();
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(NewDescription);
            Thread.Sleep(2000);

            categoryDropdownButton.SendKeys(NewCategory);
            Thread.Sleep(2000);
            selectsubcategoryDropdownButton.SendKeys(NewSelectSubcategory);
            Thread.Sleep(3000);
            tagTextbox.Click();
            tagTextbox.Clear();
            tagTextbox.SendKeys(NewTags + Keys.Enter);
            //tagTextbox.SendKeys(Tags);

            //hourlyBasisServiceButton.Click();
            Thread.Sleep(2000);
            if (NewServiceType == "Hourly basis service")
            {
                hourlyBasisServiceButton.Click();
            }
            else if (NewServiceType == "One-off service")
            {
                oneoffServiceButton.Click();
            }

            //oneoffServiceButton.Click();

            Thread.Sleep(3000);
            if (NewLocationType == "On site")
            {
                onSiteLocationButton.Click();
            }
            else if (NewLocationType == "Online")
            {
                onlineLocationButton.Click();
            }

            Thread.Sleep(3000);



            //onlineLocationButton.Click();

            if (NewSkillTrade == "Skill-exchange")
            {
                skillExchangeButton.Click();
                skillExchangeTagTextbox.Click();
                skillExchangeTagTextbox.SendKeys(NewSkillExchange + Keys.Enter);
            }
            else if (NewSkillTrade == "Credit")
            {
                creditRadioButton.Click();
                CreditButton.SendKeys(NewCredit + Keys.Enter);
            }

            Thread.Sleep(3000);

            uploadWorkSamplesButton.Click();
            Thread.Sleep(3000);
            string filePath = @"C:\Users\ganve\OneDrive\Pictures\Screenshots\Screenshot 2025-08-28 083208.png";

            Thread.Sleep(3000);

            driver.Value.FindElement(By.XPath("//input[@type='file']")).SendKeys(filePath);
            var simulator = new InputSimulator();
            simulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);

            if (NewActive == "Active")
            {
                activeRadioButton.Click();
            }
            else if (NewActive == "Hidden")
            {
                hiddenRadioButton.Click();
            }

            Thread.Sleep(2000);



            saveButton.Click();

            Wait.WaitToBeVisible(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement recordcreatedpopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string promptText = recordcreatedpopupAlert.Text;
            Console.WriteLine("Alert text: " + promptText);
            if (recordcreatedpopupAlert.Text == "Service Listing Updated successfully")
            {
                Console.WriteLine("Record edited successfully");
            }
            else
            {
                Console.WriteLine("Record edited unsuccessful");
            }

            Wait.WaitToBeVisible(driver.Value, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 2);
            IWebElement worksamplepopupAlert = driver.Value.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            string proomptText = worksamplepopupAlert.Text;
            Console.WriteLine("Alert text: " + proomptText);
            if (worksamplepopupAlert.Text == "There is an error when updating Work Samples - undefined")
            {
                Console.WriteLine("error in the system work sample upload feature is not correctly uploading the work files");
            }
            else
            {
                Console.WriteLine("no error in the system work sample upload feature works correctly");
            }
            Thread.Sleep(8000);
            cancelButton.Click();
            Thread.Sleep(8000);
            manageListingsTab.Click();


        }

        public void DeleteShareSkillRecord()
        {
            
            deleteButton.Click();
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ui.tiny.modal.transition.visible.active")));
            IWebElement yesButton = driver.Value.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
            if (yesButton.Displayed && yesButton.Enabled)
            {
                yesButton.Click();
            }
            else
            {
                // Handle the case where the button is not visible or enabled
            }
            



        }
    }
}
