using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class SkillPage : CommonDriver
    {
        public void CreateSkillRecord()
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addSkillTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillTextbox.Click();

            IWebElement chooseSkillLevelDropdownButton = driver.FindElement(By.XPath("//select[@name='level']"));
            chooseSkillLevelDropdownButton.Click();

            IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
            skillLevelOption.Click();
            //IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
            //skillLevelOption.Click();
            //IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
            //skillLevelOption.Click();

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
            cancelButton.Click();  

        }

        public void EditSkillRecord()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();

            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            cancelButton.Click();  

        }
        public void DeleteSkillRecord()
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteButton.Click();
        }
      
    }
}
