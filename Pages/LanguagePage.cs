using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class LanguagePage : CommonDriver
    {
        public void CreateLanguageRecord()
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguageTextbox.Click();
            addLanguageTextbox.SendKeys("English");

            IWebElement chooseLanguageLevelDropdownButton = driver.FindElement(By.XPath("//select[@name='level']"));
            chooseLanguageLevelDropdownButton.Click();

            IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
            levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
            //levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
            //levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
            //levelOption.Click();

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
            cancelButton.Click();
            

        }
        public void EditLanguageRecord()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            

            IWebElement editCancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            editCancelButton.Click();

        }

        public void deleteLanguageRecord()
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
            deleteButton.Click();
        }




    }
}
