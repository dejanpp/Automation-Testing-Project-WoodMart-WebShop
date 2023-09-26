using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final_Selenium_Project
{
    public class Home_Page
    {
        public IWebDriver driver;


        public Home_Page(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        By registerButton = By.CssSelector("a[title=\"My account\"]");
        By createAccButton = By.XPath("//a[text()=\"Create an Account\"]");
        By selectClocksMenu = By.XPath("//span[text()=\"Clocks\"]");
        By popUp = By.XPath("//h4[text() = \"HEY YOU, SIGN UP AND CONNECT TO WOODMART!\"]");

        public void Click_User_Registration_Button()
        {
            driver.FindElement(registerButton).Click();
        }

        public void Click_Create_Account_Button()
        {
            driver.FindElement(createAccButton).Click();
        }

        public void Click_On_Clocks_Menu()
        {
            driver.FindElement(selectClocksMenu).Click();
        }

        public void DismissPopUpIfDisplayed()
        {
            IWebElement popUpElement = driver.FindElement(popUp);

            if (popUpElement.Displayed)
            {
                Actions action = new Actions(driver);
                action.SendKeys(Keys.Escape).Perform();
                Thread.Sleep(3000);
                Assert.False(popUpElement.Displayed);
                Console.WriteLine("Pop Up was displayed");
            }
        }


    }
}
