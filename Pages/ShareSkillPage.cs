using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        private IWebElement ShareSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));

        private IWebElement titleTextbox => driver.FindElement(By.XPath("//input[@name='title']"));

        private IWebElement descriptionTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
        private IWebElement categoryDropdownButton => driver.FindElement(By.XPath("//select[@name='categoryId']"));

        private IWebElement categoryOptions => driver.FindElement(By.XPath("//option[contains(text(), 'Software Development') and @value='1']"));

        private IWebElement selectsubcategoryDropdownButton => driver.FindElement(By.XPath("//select[@name='subcategoryId']"));

        private IWebElement selectsubcategoryOptions => driver.FindElement(By.XPath("//option[contains(text(), 'Solution Architecture Design') and @value='1']"));

        private IWebElement tagTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        private IWebElement hourlyBasisServiceButton => driver.FindElement(By.XPath("//input[@name='serviceType' and @value='0']"));

        private IWebElement oneoffServiceButton => driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));

        private IWebElement onSiteLocationButton => driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']"));

        private IWebElement onlineLocationButton => driver.FindElement(By.XPath("//input[@name='locationType' and @value='1']"));

        private IWebElement skillExchangeButton => driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));

        

        private IWebElement skillExchangeTagTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement uploadWorkSmaplesButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement activeRadioButton => driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));

        private IWebElement hiddenRadioButton => driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//input[@value='Save']"));
        private IWebElement manageListingsTab => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/a[3]"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        private IWebElement viewButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]/i"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
        public void CreateShareSkillRecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string SkillTrade, string SkillExchange, string Active)
        {
            Thread.Sleep(3000);
            ShareSkillButton.Click();

            
            titleTextbox.Click();
            titleTextbox.SendKeys(Title);

            
            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(Description);
            Thread.Sleep(2000);
            
            categoryDropdownButton.SendKeys(Category);
            

           
            //categoryOptions.Click();
            //categoryOptions.SendKeys(Category);
            Thread.Sleep(2000);
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

            
            selectsubcategoryDropdownButton.SendKeys(SelectSubcategory);

            
            //selectsubcategoryOptions.Click();
            //selectsubcategoryOptions.SendKeys(SelectSubcategory);
            Thread.Sleep(3000);
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

            
            tagTextbox.Click();
            tagTextbox.SendKeys(Tags + Keys.Enter);
            //tagTextbox.SendKeys(Tags);

            //hourlyBasisServiceButton.Click();
            Thread.Sleep(2000);
            
            //oneoffServiceButton.Click();
            oneoffServiceButton.SendKeys(ServiceType);
            Thread.Sleep(3000);
            onSiteLocationButton.SendKeys(LocationType);
            Thread.Sleep(3000);

            //onlineLocationButton.Click();


            skillExchangeButton.SendKeys(SkillTrade);
            Thread.Sleep(3000);
            
            //creditButton.Click();

            
            skillExchangeTagTextbox.Click();
            skillExchangeTagTextbox.SendKeys(SkillExchange + Keys.Enter);
            Thread.Sleep(3000);
           
            //uploadWorkSmaplesButton.Click();

            
            activeRadioButton.SendKeys(Active);
            Thread.Sleep(2000);

            //hiddenRadioButton.Click();
            

            saveButton.Click();
            Thread.Sleep(5000);
            
            manageListingsTab.Click();
            
           
            //cancelButton.Click();

        }
        public void CreateDietitianShareSkillRecord(string Title, string Description, string Category, string SelectSubcategory, string Tags, string ServiceType, string LocationType, string Credit)
        {
            Thread.Sleep(3000);
            ShareSkillButton.Click();


            titleTextbox.Click();
            titleTextbox.SendKeys(Title);


            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(Description);
            Thread.Sleep(2000);

            categoryDropdownButton.SendKeys(Category);
            Thread.Sleep(2000);
            selectsubcategoryDropdownButton.SendKeys(SelectSubcategory);
            Thread.Sleep(3000);
            tagTextbox.Click();
            tagTextbox.SendKeys(Tags + Keys.Enter);
            Thread.Sleep(2000);
            hourlyBasisServiceButton.SendKeys(ServiceType);
            
            Thread.Sleep(3000);
            onlineLocationButton.SendKeys(LocationType);

            Thread.Sleep(5000);
            IWebElement creditRadioButton = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
            creditRadioButton.Click();
            Thread.Sleep(3000);
            IWebElement CreditButton = driver.FindElement(By.XPath("//input[@name='charge']"));
            CreditButton.SendKeys(Credit + Keys.Enter);
            hiddenRadioButton.Click();
            saveButton.Click();
            Thread.Sleep(5000);

            manageListingsTab.Click();

        }
        public void EditShareSkillRecord()
        {
            
            viewButton.Click();

            
            editButton.Click();

        }

        public void DeleteShareSkillRecord()
        {
            
            deleteButton.Click();
        }
    }
}
