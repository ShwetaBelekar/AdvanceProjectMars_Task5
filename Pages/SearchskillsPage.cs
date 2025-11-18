using AdvanceProjectMars_Task5.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class SearchskillsPage : CommonDriver
    {
        private IWebElement searchSkillsSearchIcon => driver.Value.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));

        private IWebElement filterOnline => driver.Value.FindElement(By.XPath("//button[text()='Online']"));
      
        private IWebElement filterOnsite => driver.Value.FindElement(By.XPath("//button[text()='Onsite']"));
        private IWebElement filterShowAll => driver.Value.FindElement(By.XPath("//button[text()='ShowAll']"));

        private IWebElement searchSkills => driver.Value.FindElement(By.XPath("(//input[@placeholder='Search skills'])[2]"));
        private IWebElement searchIcon => driver.Value.FindElement(By.XPath("(//i[@class='search link icon'])[2]"));
        private IWebElement searchUser => driver.Value.FindElement(By.XPath("//input[@placeholder='Search user']"));
        private IWebElement searchUserRefresh => driver.Value.FindElement(By.XPath("//i[@class='repeat icon']"));
        private IWebElement category => driver.Value.FindElement(By.XPath("//a[@role='listitem' and @class='item category']"));
        private IWebElement subcategories => driver.Value.FindElement(By.XPath("//a[@role='listitem' and @class='item subcategory']"));
        
        private IWebElement allCategories => driver.Value.FindElement(By.XPath("//a[text()='All Categories']"));
        private IWebElement softwareDevelopmentCategory => driver.Value.FindElement(By.XPath("//a[text()='Software Development']"));
        private IWebElement solutionArchitectureDesignSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Solution Architecture Design']"));
        private IWebElement programmingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Programming']"));
        private IWebElement frontEndDevelopmentSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Front End Development']"));
        private IWebElement backEndDevelopmentSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Back End Development']"));
        private IWebElement designPatternSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Design Pattern']"));
        private IWebElement devOpsCIandCDSubcategory => driver.Value.FindElement(By.XPath("//a[text()='DevOps CI/CD']"));
        private IWebElement otherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));

        private IWebElement dataAnalysisAndBusinessIntelligenceCategory => driver.Value.FindElement(By.XPath("//a[text()='Data Analysis & Business Intelligence']"));
        private IWebElement datacleaningandstandardisationSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Data Cleaning and Standardisation']"));
        private IWebElement dataWarehousingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Data Warehousing']"));
        private IWebElement eTLDesignSubcategory => driver.Value.FindElement(By.XPath("//a[text()='ETL Design']"));
        private IWebElement dataVisualisationSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Data Visualisation']"));
        private IWebElement powerBISubcategory => driver.Value.FindElement(By.XPath("//a[text()='PowerBI']"));
        private IWebElement tableauSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Tableau']"));

        private IWebElement wherescapeREDSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Wherescape RED']"));
        private IWebElement DataAnalysisAndBusinessIntelligenceOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));



        private IWebElement testAutomationCategory => driver.Value.FindElement(By.XPath("//a[text()='Test Automation']"));
        private IWebElement seleniumSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Selenium']"));
        private IWebElement cucumberSpecflowSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Cucumber/Specflow']"));
        private IWebElement APITestingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='API Testing']"));
        private IWebElement performanceTestingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Performance Testing']"));
        private IWebElement testAutomationOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement dataScienceCategory => driver.Value.FindElement(By.XPath("//a[text()='Data Science']"));
        private IWebElement pythonProgrammingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Python Programming']"));
        private IWebElement rStudioProgrammingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='R Studio Programming']"));
        private IWebElement bigDataSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Big Data']"));
        private IWebElement dataScienceOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement machineLearningCategory => driver.Value.FindElement(By.XPath("//a[text()='Machine Learning']"));
        private IWebElement supervisedLearningSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Supervised Learning']"));
        private IWebElement unsupervisedLearningSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Unsupervised Learning']"));
        private IWebElement reinforcementLearningSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Reinforcement Learning']"));
        private IWebElement machineLearningOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement gameDevelopmentCategory => driver.Value.FindElement(By.XPath("//a[text()='Game Development']"));
        
        private IWebElement unitySubcategory => driver.Value.FindElement(By.XPath("//a[text()='Unity']"));
        private IWebElement unrealSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Unreal']"));
        private IWebElement threeDModelingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='3D Modeling']"));
        private IWebElement gameDesignSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Game Design']"));
        private IWebElement HTMLfiveSubcategory => driver.Value.FindElement(By.XPath("//a[text()='HTML5']"));
        private IWebElement gameDevelopmentOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement communicationCategory => driver.Value.FindElement(By.XPath("//a[text()='Communication']"));
        private IWebElement communicationAtWorkSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Communication at Work']"));
        private IWebElement jobHuntingAdviceSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Job Hunting Advice']"));
        private IWebElement jobMarketAdviceSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Job Market Advice']"));
        private IWebElement communicationInterviewAdviceSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Interview Advice']"));
        private IWebElement jobAnalysisConsultingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Job Analysis Consulting']"));
        private IWebElement communicationOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement funAndLifestyleCategory => driver.Value.FindElement(By.XPath("(//a[text()='Fun & Lifestyle'])[1]"));
        private IWebElement onlineLessonsSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Online Lessons']"));
        private IWebElement relationshipAdviceSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Relationship Advice']"));
        private IWebElement astrologySubcategory => driver.Value.FindElement(By.XPath("//a[text()='Astrology']"));
        private IWebElement healthNutritionFitnessSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Health, Nutrition & Fitness']"));
        private IWebElement gamingSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Gaming']"));
        private IWebElement funAndLifestyleOtherSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Other']"));
        private IWebElement recruitmentCategory => driver.Value.FindElement(By.XPath("//a[text()='Recruitment']"));
        private IWebElement employabilitySubcategory => driver.Value.FindElement(By.XPath("//a[text()='Employability']"));
        private IWebElement cvAdvicesSubcategory => driver.Value.FindElement(By.XPath("//a[text()='CV Advices']"));
        private IWebElement recruitmentInterviewAdviceSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Interview Advice']"));
        private IWebElement jobMarketInsightSubcategory => driver.Value.FindElement(By.XPath("//a[text()='Job Market Insight']"));
        public void SearchSkillWithOnlineFilter(string Filter)
        {
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            filterOnline.Click();
            
        }
        public void SearchSkillWithOnsiteFilter(string Filter)
        {
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            filterOnsite.Click();

        }
        public void SearchSkillWithShowAllFilter(string Filter)
        {
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            filterShowAll.Click();

        }
        public void TestSearchUser(string searchText, string targetText)
        {
            
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
            
            searchUser.SendKeys(searchText);
            Thread.Sleep(3000);
            
        }
        public void TestNewSearchUser(string NewsearchText, string NewtargetText)
        {
            searchUserRefresh.Click();
            Thread.Sleep(2000);
            searchUser.SendKeys(NewsearchText);
            Thread.Sleep(3000);
        }
        public void TestSearchSkill(string searchSkill)
        {
            
            searchSkillsSearchIcon.Click();
            Thread.Sleep(3000);
           
            searchSkills.SendKeys(searchSkill);
            searchIcon.Click();
            Thread.Sleep(2000);
            
        }
        public void SearchSkillWithAllCategoryandSubcategory(string Category, string Subcategory, string Listings)
        {
            Thread.Sleep(2000);
            searchSkillsSearchIcon.Click();
            Thread.Sleep(2000);
            if (Category == "Software Development")
            {
                softwareDevelopmentCategory.Click();
            }

            else if (Category == "Data Analysis & Business Intelligence")
            {
                dataAnalysisAndBusinessIntelligenceCategory.Click();
            }
            else if (Category == "Test Automation")
            {
                testAutomationCategory.Click();
            }
            else if (Category == "Data Science")
            {
                dataScienceCategory.Click();
            }
            else if (Category == "Machine Learning")
            {
                machineLearningCategory.Click();
            }
            else if (Category == "Game Development")
            {
                gameDevelopmentCategory.Click();
            }
            else if (Category == "Communication")
            {
                communicationCategory.Click();
            }
            else if (Category == "Fun & Lifestyle")
            {
                funAndLifestyleCategory.Click();
            }
            else if (Category == "Recruitment")
            {
                recruitmentCategory.Click();
            }

            Thread.Sleep(2000);
            if (Subcategory == "Solution Architecture Design")
            {
                solutionArchitectureDesignSubcategory.Click();
            }
            else if (Subcategory == "Programming")
            {
                programmingSubcategory.Click();
            }
            else if (Subcategory == "Front End Development")
            {
                frontEndDevelopmentSubcategory.Click();
            }
            else if (Subcategory == "Back End Development")
            {
                backEndDevelopmentSubcategory.Click();
            }
            else if (Subcategory == "Design Pattern")
            {
                designPatternSubcategory.Click();
            }
            else if (Subcategory == "DevOps CI/CD")
            {
                devOpsCIandCDSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                otherSubcategory.Click();
            }
            else if (Subcategory == "Data Cleaning and Standardisation")
            {
                datacleaningandstandardisationSubcategory.Click();
            }
            else if (Subcategory == "Data Warehousing")
            {
                dataWarehousingSubcategory.Click();
            }
            else if (Subcategory == "ETL Design")
            {
                eTLDesignSubcategory.Click();
            }
            else if (Subcategory == "Data Visualisation")
            {
                dataVisualisationSubcategory.Click();
            }
            else if (Subcategory == "PowerBI")
            {
                powerBISubcategory.Click();
            }
            else if (Subcategory == "Tableau")
            {
                tableauSubcategory.Click();
            }
            else if (Subcategory == "Wherescape RED")
            {
                wherescapeREDSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                DataAnalysisAndBusinessIntelligenceOtherSubcategory.Click();
            }
            else if (Subcategory == "Selenium")
            {
                seleniumSubcategory.Click();
            }
            else if (Subcategory == "Cucumber/Specflow")
            {
                cucumberSpecflowSubcategory.Click();
            }
            else if (Subcategory == "API Testing")
            {
                APITestingSubcategory.Click();  
            }
            else if (Subcategory == "Performance Testing")
            {
                performanceTestingSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                testAutomationOtherSubcategory.Click();
            }
            else if (Subcategory == "Python Programming")
            {
                pythonProgrammingSubcategory.Click();
            }
            else if (Subcategory == "R Studio Programming")
            {
                rStudioProgrammingSubcategory.Click();
            }
            else if (Subcategory == "Big Data")
            {
                bigDataSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                dataScienceOtherSubcategory.Click();
            }
            else if (Subcategory == "Supervised Learning")
            {
                supervisedLearningSubcategory.Click();
            }
            else if (Subcategory == "Unsupervised Learning")
            {
                unsupervisedLearningSubcategory.Click();
            }
            else if (Subcategory == "Reinforcement Learning")
            {
                reinforcementLearningSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                machineLearningOtherSubcategory.Click();
            }
            else if (Subcategory == "Unity")
            {
                unitySubcategory.Click();
            }
            else if (Subcategory == "Unreal")
            {
                unrealSubcategory.Click();
                ////Thread.Sleep(3000);
                ////var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                ////if (rightFloatedContent.Count > 0)
                ////{
                ////    Assert.Pass("No listings found for Unreal subcategory.");
                ////    // You can add additional logic here to handle this scenario
                ////}

            }
            else if (Subcategory == "3D Modeling")
            {
                threeDModelingSubcategory.Click();
            }
            else if (Subcategory == "Game Design")
            {
                gameDesignSubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 1)
                //{
                //    Assert.Pass("No listings found for Game Design subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}
                
            }
            else if (Subcategory == "HTML5")
            {
                HTMLfiveSubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 2)
                //{
                //    Assert.Pass("No listings found for HTML5 subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}

            }
            else if (Subcategory == "Other")
            {
                gameDevelopmentOtherSubcategory.Click();
            }
            else if (Subcategory == "Communication at Work")
            {
                communicationAtWorkSubcategory.Click();
            }
            else if (Subcategory == "Job Hunting Advice")
            {
                jobHuntingAdviceSubcategory.Click();
            }
            else if (Subcategory == "Job Market Advice")
            {
                jobMarketAdviceSubcategory.Click();
            }
            else if (Subcategory == "Interview Advice")
            {
                communicationInterviewAdviceSubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 0)
                //{
                //    Assert.Pass("No listings found for Interview Advice subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}

            }
            else if (Subcategory == "Job Analysis Consulting")
            {
                jobAnalysisConsultingSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                communicationOtherSubcategory.Click();
            }
            else if (Subcategory == "Online Lessons")
            {
                onlineLessonsSubcategory.Click();
            }
            else if (Subcategory == "Relationship Advice")
            {
                relationshipAdviceSubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 0)
                //{
                //    Assert.Pass("No listings found for Relationship Advice subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}
            }
            else if (Subcategory == "Astrology")
            {
                astrologySubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 1)
                //{
                //    Assert.Pass("No listings found for Astrology subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}
            }
            else if (Subcategory == "Health, Nutrition & Fitness")
            {
                healthNutritionFitnessSubcategory.Click();
            }
            else if (Subcategory == "Gaming")
            {
                gamingSubcategory.Click();
            }
            else if (Subcategory == "Other")
            {
                funAndLifestyleOtherSubcategory.Click();
            }
            else if (Subcategory == "Employability")
            {
                employabilitySubcategory.Click();
            }
            else if (Subcategory == "CV Advices")
            {
                cvAdvicesSubcategory.Click();
                //Thread.Sleep(3000);
                //var rightFloatedContent = ((ReadOnlyCollection<IWebElement>)driver.FindElements(By.XPath("//span[@class='right-floated' and text()='0']")));
                //if (rightFloatedContent.Count > 0)
                //{
                //    Assert.Pass("No listings found for CV Advices subcategory.");
                //    // You can add additional logic here to handle this scenario
                //}

            }
            else if (Subcategory == "Interview Advice")
            {
                recruitmentInterviewAdviceSubcategory.Click();
            }
            else if (Subcategory == "Job Market Insight")
            {
                jobMarketInsightSubcategory.Click();
            }

            Thread.Sleep(2000);
            
            var elements = driver.Value.FindElements(By.XPath("//p[@class='row-padded']"));
            if (elements.Count == 0)
            {
                Assert.Pass("No results found, please select a new category!");
                
            }
            else
            {
                foreach (var element in elements)
                {
                    if (element.Text.Trim() == Listings)
                    {
                        element.Click();
                        break;
                    }
                }

            }
               
            Thread.Sleep(2000);

            IWebElement gobackToSubcategory = driver.Value.FindElement(By.XPath("//a[contains(@href, '/Home/Search?cat=') and contains(@href, '&subcat=')]"));
            string subcategoryText = gobackToSubcategory.Text;
            Console.WriteLine($"Selected Subcategory: {subcategoryText}");
            gobackToSubcategory.Click();

        }
       

    }
    
}
