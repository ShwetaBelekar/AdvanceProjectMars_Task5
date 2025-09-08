using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class ProfLoc_Avai_Hrs_EarnTarPage : CommonDriver
    {
        private IWebElement profileTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));

        private IWebElement locationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[1]/div"));

        private IWebElement availabilityEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));

        private IWebElement availabilityDropdownButton => driver.FindElement(By.XPath("//select[@name='availabiltyType']"));

        private IWebElement availabilityTypeOption0 => driver.FindElement(By.XPath("//option[contains(text(), 'Part Time') and @value='0']"));

        private IWebElement availabilityTypeOption1 => driver.FindElement(By.XPath("//option[contains(text(), 'Full Time') and @value='1']"));

        private IWebElement hoursEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));

        private IWebElement hoursDropdownButton => driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));

        private IWebElement hoursTypeOption0 => driver.FindElement(By.XPath("//option[contains(text(), 'Less than 30hours a week') and @value='0']"));

        private IWebElement hoursTypeOption1 => driver.FindElement(By.XPath("//option[contains(text(), 'More than 30hours a week') and @value='1']"));

        private IWebElement hoursTypeOption2 => driver.FindElement(By.XPath("//option[contains(text(), 'As needed') and @value='2']"));

        private IWebElement earnTargetEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private IWebElement earnTargetDropdownButton => driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
        private IWebElement earnTargetTypeOption0 => driver.FindElement(By.XPath("//option[contains(text(), 'Less than $500 per month') and @value='0']"));
        private IWebElement earnTargetTypeOption1 => driver.FindElement(By.XPath("//option[contains(text(), 'Between $500 and $1000 per month') and @value='1']"));

        private IWebElement earnTargetTypeOption2 => driver.FindElement(By.XPath("//option[contains(text(), 'More than $1000 per month') and @value='2']"));

        public void LocationAction()
        {

            profileTab.Click();
            Thread.Sleep(3000);
           
            if (locationButton.Enabled)
            {
                Console.WriteLine("Location button is enabled, but it should not be.");
            }
            else
            {
                Console.WriteLine("Location button is not enabled, as expected.");
            }
        }
        public void SelectAvailabilityAction(string AvailabilityType)
        {
            profileTab.Click();
            availabilityEditButton.Click();
            Thread.Sleep(2000);
            
            availabilityDropdownButton.SendKeys(AvailabilityType);

            //Thread.Sleep(3000);

            //availabilityTypeOption0.SendKeys(AvailabilityType);

            //availabilityTypeOption1.Click();

        }
        public void ChangeAvailabilityAction(string NewAvailabilityType)
        {
            Thread.Sleep(5000);
            availabilityEditButton.Click();
            Thread.Sleep(2000);

            availabilityDropdownButton.SendKeys(NewAvailabilityType);
        }
        
        public void SelectHoursAction(string HoursType)
        {
            Thread.Sleep(5000);
            profileTab.Click();
            hoursEditButton.Click();
            Thread.Sleep(2000);
           
            hoursDropdownButton.SendKeys(HoursType);
            //Thread.Sleep(5000);

            
            //hoursTypeOption0.Click();

           
            //hoursTypeOption1.Click();

            
            //hoursTypeOption2.Click();

            
        }
        public void EditHoursAction(string EditHoursType, string ChangeHoursType)
        {
            Thread.Sleep(5000);
            hoursEditButton.Click();
            Thread.Sleep(3000);

            hoursDropdownButton.SendKeys(EditHoursType);

            Thread.Sleep(5000);
            hoursEditButton.Click();
            Thread.Sleep(3000);

            hoursDropdownButton.SendKeys(ChangeHoursType);

        }

        public void EarnTargetAction()
        {
            
            earnTargetEditButton.Click();
            Thread.Sleep(3000);

           
            earnTargetDropdownButton.Click();
            Thread.Sleep(8000);

          
            earnTargetTypeOption0.Click();

            
            earnTargetTypeOption1.Click();

            
            earnTargetTypeOption2.Click();

            IWebElement ppopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (ppopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Earn Target updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }
        }
    }
}

        

            


        

    


