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
        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addSkillTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement chooseSkillLevelDropdownButton => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement editCancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
       
        public void CreateSkillRecord(string Skill, string Level)
        {
            Thread.Sleep(3000);
            addNewButton.Click();

            addSkillTextbox.Click();
            addSkillTextbox.SendKeys(Skill);

            chooseSkillLevelDropdownButton.Click();
            chooseSkillLevelDropdownButton.SendKeys(Level);

            //IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
            //skillLevelOption.Click();
            //IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
            //skillLevelOption.Click();
            //IWebElement skillLevelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
            //skillLevelOption.Click();
            addButton.Click();
            Thread.Sleep(5000);
            //cancelButton.Click();  

        }
        public void CreateDuplicateRecord(string Skill,string Level)
        {
            Thread.Sleep(5000);
            addNewButton.Click();

            addSkillTextbox.Click();
            addSkillTextbox.SendKeys(Skill);
            Thread.Sleep(3000);
            chooseSkillLevelDropdownButton.Click();
            chooseSkillLevelDropdownButton.SendKeys(Level);
            addButton.Click();
            Thread.Sleep(2000);
        }

        public void EditSkillRecord(string NewSkill, string NewLevel)
        {
            Thread.Sleep(5000);
            editButton.Click();
            addSkillTextbox.Clear();
            addSkillTextbox.SendKeys(NewSkill);
            Thread.Sleep(2000);
            chooseSkillLevelDropdownButton.Click();
            chooseSkillLevelDropdownButton.SendKeys(NewLevel);
            Thread.Sleep(2000);
            updateButton.Click();

            //editCancelButton.Click();  

        }
        public void CancellingAnEditOperation(string EditSkill)
        {
            Thread.Sleep(5000);
            editButton.Click();
            addSkillTextbox.Click();
            addSkillTextbox.Clear();
            addSkillTextbox.SendKeys(EditSkill);
            Thread.Sleep(3000);
            editCancelButton.Click();
            Thread.Sleep(2000);
            IWebElement Skill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Skill.Text == "Yoga")   
            {
                Console.WriteLine("Edit operation is cancelled and original Skill Yoga is visible");
            }
            else
            {
                Console.WriteLine("Edit operation is cancelled but original Skill Yoga is not visible");
            }
            editButton.Click();
            Thread.Sleep(2000);
            updateButton.Click();
            Thread.Sleep(2000);
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (newSkill.Text == "Calligraphy")
            {
                Console.WriteLine("Edit operation was cancelled so the data should be discarded and original Skill Yoga should be visible but no the system is saving unnecessary data at the back");
            }
            else
            {
                Console.WriteLine("Calligraphy is correct system is not saving any unnecessary data");
            }
        }
        public void DeleteSkillRecord()
        {
            deleteButton.Click();
        }
      
    }
}
