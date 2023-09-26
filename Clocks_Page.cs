using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using SeleniumExtras.WaitHelpers;

namespace Final_Selenium_Project
{
    public class Clocks_Page
    {
        public IWebDriver driver;
        WebDriverWait wait;


        public Clocks_Page(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
                
        By firstClock = By.CssSelector("a[data-id=\"1162\"]");
        By secondClock = By.CssSelector("a[data-id=\"1055\"]");
        By compareButton = By.CssSelector("a[title=\"Compare products\"]");
        
        public void Select_Best_Clock_Parallels()
        {
            IWebElement compareList = driver.FindElement(firstClock);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", compareList);
            wait.Until(ExpectedConditions.ElementToBeClickable(firstClock)).Click();
            //Actions action = new Actions(driver);
           //action.MoveToElement(compareList).Perform();//Mislam deka kaj mene ne raboti Actions 
        }

        public void Select_Dolor_Ad_Hoc_Torquent()
        {
            IWebElement compareList = driver.FindElement(secondClock);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", compareList);
            wait.Until(ExpectedConditions.ElementToBeClickable(secondClock)).Click();
        }

        public void Click_On_Compare_Button()
        {
            driver.FindElement(compareButton).Click();
        }
    }
}
