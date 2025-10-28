using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class SearchuserPage : CommonDriver
    {
        private IWebElement searchSkillsSearchIcon => driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
        private IWebElement searchUser => driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
        private IWebElement searchUserRefresh => driver.FindElement(By.XPath("//i[@class='repeat icon']"));
    }
}
