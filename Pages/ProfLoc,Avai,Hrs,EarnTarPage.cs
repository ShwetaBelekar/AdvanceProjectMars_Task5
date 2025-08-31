using AdvanceProjectMars_Task5.Utilities;
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
        public void ValidLocAvaHrsEarnTarAction()
        {
            IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileTab.Click();
            Thread.Sleep(3000);
            IWebElement locationButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[1]/div"));
            if (locationButton.Enabled)
            {
                Console.WriteLine("Location button is enabled, but it should not be.");
            }
            else
            {
                Console.WriteLine("Location button is not enabled, as expected.");
            }

            IWebElement availabilityEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            availabilityEditButton.Click();
            Thread.Sleep(3000);
            IWebElement availabilityDropdownButton = driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
            availabilityDropdownButton.Click();
            Thread.Sleep(5000);

            IWebElement availabilityTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'Part Time') and @value='0']"));
            availabilityTypeOption.Click();

            //IWebElement availabilityTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'Full Time') and @value='1']"));
            //availabilityTypeOption.Click();

            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (popupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Availability updated successfully");
            }
            else
            {
                Console.WriteLine("Availability updated unsuccessfull");
            }

            IWebElement hoursEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            hoursEditButton.Click();
            Thread.Sleep(3000);
            IWebElement hoursDropdownButton = driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            hoursDropdownButton.Click();
            Thread.Sleep(5000);

            IWebElement hoursTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'Less than 30hours a week') and @value='0']"));
            hoursTypeOption.Click();

            //IWebElement hoursTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'More than 30hours a week') and @value='1']"));
            //hoursTypeOption.Click();

            //IWebElement hoursTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'As needed') and @value='2']"));
            //hoursTypeOption.Click();
            IWebElement poopupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if (poopupAlert.Text == "Availability updated")
            {
                Console.WriteLine("Error in the system, alert should be Hours updated but getting alert Availlability updated!");
            }
            else
            {
                Console.WriteLine("No Error in the system, popup alert is correct!");
            }

            IWebElement earnTargetEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            earnTargetEditButton.Click();
            Thread.Sleep(3000);

            IWebElement earnTargetDropdownButton = driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
            earnTargetDropdownButton.Click();
            Thread.Sleep(8000);

            IWebElement earnTargetTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'Less than $500 per month') and @value='0']"));
            earnTargetTypeOption.Click();

            //IWebElement earnTargetTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'Between $500 and $1000 per month') and @value='1']"));
            //earnTargetTypeOption.Click();

            //IWebElement earnTargetTypeOption = driver.FindElement(By.XPath("//option[contains(text(), 'More than $1000 per month') and @value='2']"));
            //earnTargetTypeOption.Click();
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
}
