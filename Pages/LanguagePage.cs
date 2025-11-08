using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using RazorEngine;
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
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
        
        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement editCancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
       
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
            Thread.Sleep(5000);
            //cancelButton.Click();
        }
        public void editExistingLanguageRecord(string NewLanguage, string NewLevel)
        {
            Thread.Sleep(5000);
            editButton.Click();
            Thread.Sleep(2000);
            addLanguageTextbox.Clear();
            addLanguageTextbox.SendKeys(NewLanguage);
            chooseLanguageLevelDropdownButton.SendKeys(NewLevel);
            Thread.Sleep(2000);
            updateButton.Click();
            Thread.Sleep(2000);
        }
        
        public void CancellingEditOperation(string EditLanguage)
        {
            Thread.Sleep(3000);
            editButton.Click();
            Thread.Sleep(2000);
            addLanguageTextbox.Clear();
            addLanguageTextbox.SendKeys(EditLanguage);
            Thread.Sleep(2000);
            editCancelButton.Click();

            Thread.Sleep(2000);
            IWebElement Language = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Language.Text == "German")
            {
                Console.WriteLine("Edit operation is cancelled and original language German is visible");
            }
            else
            {
                Console.WriteLine("Edit operation is cancelled but original language German is not visible");
            }
            editButton.Click();
            Thread.Sleep(2000);
            updateButton.Click();
            Thread.Sleep(2000);
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (newLanguage.Text == "English")
            {
                Console.WriteLine("Edit operation was cancelled so the data should be discarded and original language German should be visible but no the system is saving unnecessary data at the back");
            }
            else
            {
                Console.WriteLine("German is correct system is not saving any unnecessary data");
            }
        }

        public void deleteExistingLanguageRecord()
        {
          
            deleteButton.Click();
        }
        public void Addmorethanfourlanguage(string Language, string Level)
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
                if (addNewButton.Displayed)
                {
                    addNewButton.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    Assert.Pass("AddNew is not visible can't add language");
                }

            }
            catch (NoSuchElementException)
            {
                Assert.Pass("AddNew button hasn't been found, likely already at maximum languages");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected error occurred: {ex.Message}");
            }
            //addNewButton.Click();
            addLanguageTextbox.Click();
            addLanguageTextbox.SendKeys(Language);
            chooseLanguageLevelDropdownButton.SendKeys(Level);
            addButton.Click();
        }

        public void CreateDuplicateLanguageRecord(string DuplicateLanguage, string DuplicateLevel)
        {
            Thread.Sleep(5000);

            addNewButton.Click();
            addLanguageTextbox.Click();
            addLanguageTextbox.SendKeys(DuplicateLanguage);
            chooseLanguageLevelDropdownButton.SendKeys(DuplicateLevel);

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

    }
}
