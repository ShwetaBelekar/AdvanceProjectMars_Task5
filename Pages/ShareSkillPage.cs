using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        public void CreateShareSkillRecord()
        {
            IWebElement shareSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
            shareSkillButton.Click();

            IWebElement titleTextbox = driver.FindElement(By.XPath("//input[@name='title']"));
            titleTextbox.Click();

            IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            descriptionTextbox.Click();

            IWebElement categoryDropdownButton = driver.FindElement(By.XPath("//select[@name='categoryId']"));
            categoryDropdownButton.Click();

            IWebElement categoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Software Development') and @value='1']"));
            categoryOptions.Click();

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

            IWebElement subcategoryDropdownButton = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
            subcategoryDropdownButton.Click();

            IWebElement subcategoryOptions = driver.FindElement(By.XPath("//option[contains(text(), 'Solution Architecture Design') and @value='1']"));
            subcategoryOptions.Click();

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

            IWebElement tagTextbox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            tagTextbox.Click();

            IWebElement hourlyBasisServiceButton = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='0']"));
            hourlyBasisServiceButton.Click();

            IWebElement oneoffServiceButton = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
            oneoffServiceButton.Click();

            IWebElement onSiteLocationButton = driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']"));
            onSiteLocationButton.Click();

            IWebElement onlineLocationButton = driver.FindElement(By.XPath("//input[@name='locationType' and @value='1']"));
            onlineLocationButton.Click();

            IWebElement skillExchangeButton = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
            skillExchangeButton.Click();

            IWebElement creditButton = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
            creditButton.Click();

            IWebElement skillExchangeTagTextbox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
            skillExchangeTagTextbox.Click();

            IWebElement uploadWorkSmaplesButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            uploadWorkSmaplesButton.Click();

            IWebElement activeRadioButton = driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));
            activeRadioButton.Click();

            IWebElement hiddenRadioButton = driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
            hiddenRadioButton.Click();

            IWebElement saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            saveButton.Click();

            IWebElement cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            cancelButton.Click();

        }

        public void EditShareSkillRecord()
        {
            IWebElement viewButton = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]/i"));
            viewButton.Click();

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
            editButton.Click();

        }

        public void DeleteShareSkillRecord()
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
            deleteButton.Click();
        }
    }
}
