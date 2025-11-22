using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Utilities
{
    public class CommonDriver
    {
        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() => new ChromeDriver());
        //public static IWebDriver driver;
    }
}
