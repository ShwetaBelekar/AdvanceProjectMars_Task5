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
        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addLanguageTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement chooseLanguageLevelDropdownButton => driver.FindElement(By.XPath("//select[@name='level']"));

        private IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement editCancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
        public void CreateLanguageRecord(string Language, string Level)
        {
            Thread.Sleep(5000);
            addNewButton.Click();
            addLanguageTextbox.Click();
            addLanguageTextbox.SendKeys(Language);
            chooseLanguageLevelDropdownButton.SendKeys(Level);

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
            //levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
            //levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
            //levelOption.Click();

            //IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
            //levelOption.Click();

            addButton.Click();
            //cancelButton.Click();
        }
        public void EditLanguageRecord()
        {
            
            editButton.Click();

            updateButton.Click();
            
            editCancelButton.Click();

        }

        public void deleteLanguageRecord()
        {
          
            deleteButton.Click();
        }




    }
}
