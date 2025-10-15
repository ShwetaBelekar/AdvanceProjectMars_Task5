using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class SearchskillsPage : CommonDriver
    {
        private IWebElement searchSkillsSearchIcon => driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));

        private IWebElement filterOnline => driver.FindElement(By.XPath("//button[text()='Online']"));
       
        private IWebElement filterOnsite => driver.FindElement(By.XPath("//button[text()='Onsite']"));
        private IWebElement filterShowAll => driver.FindElement(By.XPath("//button[text()='ShowAll']"));

        private IWebElement searchSkills => driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[2]"));
        private IWebElement searchUser => driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
        private IWebElement searchUserRefresh => driver.FindElement(By.XPath("//i[@class='repeat icon']"));
        private IWebElement allCategories => driver.FindElement(By.XPath("//a[text()='All Categories']"));
        private IWebElement softwareDevelopmentCategory => driver.FindElement(By.XPath("//a[text()='Software Development']"));
        private IWebElement solutionArchitectureDesignSubcategory => driver.FindElement(By.XPath("//a[text()='Solution Architecture Design']"));
        private IWebElement programmingSubcategory => driver.FindElement(By.XPath("//a[text()='Programming']"));
        private IWebElement frontEndDevelopmentSubcategory => driver.FindElement(By.XPath("//a[text()='Front End Development']"));
        private IWebElement backEndDevelopmentSubcategory => driver.FindElement(By.XPath("//a[text()='Back End Development']"));
        private IWebElement designPatternSubcategory => driver.FindElement(By.XPath("//a[text()='Design Pattern']"));
        private IWebElement devOpsCIandCDSubcategory => driver.FindElement(By.XPath("//a[text()='DevOps CI/CD']"));
        private IWebElement otherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));

        private IWebElement dataAnalysisAndBusinessIntelligenceCategory => driver.FindElement(By.XPath("//a[text()='Data Analysis & Business Intelligence']"));
        private IWebElement datacleaningandstandardisationSubcategory => driver.FindElement(By.XPath("//a[text()='Data Cleaning and Standardisation']"));
        private IWebElement dataWarehousingSubcategory => driver.FindElement(By.XPath("//a[text()='Data Warehousing']"));
        private IWebElement eTLDesignSubcategory => driver.FindElement(By.XPath("//a[text()='ETL Design']"));
        private IWebElement dataVisualisationSubcategory => driver.FindElement(By.XPath("//a[text()='Data Visualisation']"));
        private IWebElement powerBISubcategory => driver.FindElement(By.XPath("//a[text()='PowerBI']"));
        private IWebElement tableauSubcategory => driver.FindElement(By.XPath("//a[text()='Tableau']"));

        private IWebElement wherescapeREDSubcategory => driver.FindElement(By.XPath("//a[text()='Wherescape RED']"));
        private IWebElement DataAnalysisAndBusinessIntelligenceOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));



        private IWebElement testAutomationCategory => driver.FindElement(By.XPath("//a[text()='Test Automation']"));
        private IWebElement seleniumSubcategory => driver.FindElement(By.XPath("//a[text()='Selenium']"));
        private IWebElement cucumberSpecflowSubcategory => driver.FindElement(By.XPath("//a[text()='Cucumber/Specflow']"));
        private IWebElement APITestingSubcategory => driver.FindElement(By.XPath("//a[text()='API Testing']"));
        private IWebElement performanceTestingSubcategory => driver.FindElement(By.XPath("//a[text()='Performance Testing']"));
        private IWebElement testAutomationOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement dataScienceCategory => driver.FindElement(By.XPath("//a[text()='Data Science']"));
        private IWebElement pythonProgrammingSubcategory => driver.FindElement(By.XPath("//a[text()='Python Programming']"));
        private IWebElement rStudioProgrammingSubcategory => driver.FindElement(By.XPath("//a[text()='R Studio Programming']"));
        private IWebElement bigDataSubcategory => driver.FindElement(By.XPath("//a[text()='Big Data']"));
        private IWebElement dataScienceOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement machineLearningCategory => driver.FindElement(By.XPath("//a[text()='Machine Learning']"));
        private IWebElement supervisedLearningSubcategory => driver.FindElement(By.XPath("//a[text()='Supervised Learning']"));
        private IWebElement unsupervisedLearningSubcategory => driver.FindElement(By.XPath("//a[text()='Unsupervised Learning']"));
        private IWebElement reinforcementLearningSubcategory => driver.FindElement(By.XPath("//a[text()='Reinforcement Learning']"));
        private IWebElement machineLearningOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement gameDevelopmentCategory => driver.FindElement(By.XPath("//a[text()='Game Development']"));
        
        private IWebElement unitySubcategory => driver.FindElement(By.XPath("//a[text()='Unity']"));
        private IWebElement unrealSubcategory => driver.FindElement(By.XPath("//a[text()='Unreal']"));
        private IWebElement threeDModelingSubcategory => driver.FindElement(By.XPath("//a[text()='3D Modeling']"));
        private IWebElement gameDesignSubcategory => driver.FindElement(By.XPath("//a[text()='Game Design']"));
        private IWebElement HTMLfiveSubcategory => driver.FindElement(By.XPath("//a[text()='HTML5']"));
        private IWebElement gameDevelopmentOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement communicationCategory => driver.FindElement(By.XPath("//a[text()='Communication']"));
        private IWebElement communicationAtWorkSubcategory => driver.FindElement(By.XPath("//a[text()='Communication at Work']"));
        private IWebElement jobHuntingAdviceSubcategory => driver.FindElement(By.XPath("//a[text()='Job Hunting Advice']"));
        private IWebElement jobMarketAdviceSubcategory => driver.FindElement(By.XPath("//a[text()='Job Market Advice']"));
        private IWebElement communicationInterviewAdviceSubcategory => driver.FindElement(By.XPath("//a[text()='Interview Advice']"));
        private IWebElement jobAnalysisConsultingSubcategory => driver.FindElement(By.XPath("//a[text()='Job Analysis Consulting']"));
        private IWebElement communicationOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement funAndLifestyleCategory => driver.FindElement(By.XPath("(//a[text()='Fun & Lifestyle'])[1]"));
        private IWebElement onlineLessonsSubcategory => driver.FindElement(By.XPath("//a[text()='Online Lessons']"));
        private IWebElement relationshipAdviceSubcategory => driver.FindElement(By.XPath("//a[text()='Relationship Advice']"));
        private IWebElement astrologySubcategory => driver.FindElement(By.XPath("//a[text()='Astrology']"));
        private IWebElement healthNutritionFitnessSubcategory => driver.FindElement(By.XPath("//a[text()='Health, Nutrition & Fitness']"));
        private IWebElement gamingSubcategory => driver.FindElement(By.XPath("//a[text()='Gaming']"));
        private IWebElement funAndLifestyleOtherSubcategory => driver.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement recruitmentCategory => driver.FindElement(By.XPath("//a[text()='Recruitment']"));
        private IWebElement employabilitySubcategory => driver.FindElement(By.XPath("//a[text()='Employability']"));
        private IWebElement cvAdvicesSubcategory => driver.FindElement(By.XPath("//a[text()='CV Advices']"));
        private IWebElement recruitmentInterviewAdviceSubcategory => driver.FindElement(By.XPath("//a[text()='Interview Advice']"));
        private IWebElement jobMarketInsightSubcategory => driver.FindElement(By.XPath("//a[text()='Job Market Insight']"));
        public void SearchSkillWithOnlineFilter(string Filter)
        {
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            filterOnline.Click();
            //int totalOnlineListings = 0;
            //int totalPages = 3; // You know there are 3 pages

            //for (int i = 1; i <= totalPages; i++)
            //{
            //    totalOnlineListings += driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span")).Count;

            //    if (i < totalPages)
            //    {
            //        // Navigate to the next page
            //        driver.FindElement(By.XPath("//button[@class='ui button otherPage'][contains(text(), '" + (i + 1) + "')]")).Click();
            //        Thread.Sleep(2000); // You can use WebDriverWait instead of Thread.Sleep
            //    }
            //}

            //Console.WriteLine("Total online listings: " + totalOnlineListings);

            //if (totalOnlineListings == 19)
            //{
            //    Console.WriteLine("The total number of online listings is 19.");
            //}
            //else
            //{
            //    Console.WriteLine("The total number of online listings is not 19.");
            //}
        }
    }
    
}
