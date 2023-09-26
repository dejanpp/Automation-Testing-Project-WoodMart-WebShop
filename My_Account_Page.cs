using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Selenium_Project
{
    public class My_Account_Page
    {
        public IWebDriver driver;
        WebDriverWait wait;

        public My_Account_Page(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        By userNameField = By.Id("reg_username");
        By emailAddressField = By.Id("reg_email");
        By passwordField = By.Id("reg_password");
        By RegisterButton = By.CssSelector("button[value=Register]");
        By clickHome = By.XPath("//span[text()=\"Home\"]");
        By clickMyAccButton = By.CssSelector("a[title=\"My account\"]");
        By clickAccDetailsButton = By.CssSelector("div.edit-account-link");
        By clickLogoutButton = By.XPath("//a[text()=\"Log out\"]");
        By emailVerification = By.CssSelector("input#account_email");

        public string RandomString()
        {
            string inputString = "dejan";
            string timestampenow = DateTime.Now.ToString().Replace('/', '1').Replace(':', '2').Replace(" ", "3");
            string random = string.Concat(inputString, timestampenow);
            return random;
        }
        public void Enter_User_Name()
        {           
            string randomUserName = RandomString();
            driver.FindElement(userNameField).SendKeys(randomUserName);
        }

        public string Enter_Email()
        {           
            string randomUserEmail = string.Concat(RandomString(), "@hotmail.com");
            driver.FindElement(emailAddressField).SendKeys(randomUserEmail);
            return randomUserEmail;
        }
        public void Enter_Password()
        {           
            string randomUserPassword = RandomString();
            driver.FindElement(passwordField).SendKeys(randomUserPassword);
        }

        public void Click_Register_Button()
        {
            //driver.FindElement(RegisterButton).Click();
            IWebElement register_Button = driver.FindElement(RegisterButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", register_Button);
            wait.Until(ExpectedConditions.ElementIsVisible(RegisterButton)).Click();
            //Mi pravese problem so klikot zatoa go napraviv so Java Script Executor
        }
        public void Click_My_Acc_Button()
        {
            driver.FindElement(clickMyAccButton).Click();
        }
        public void Click_Acc_Details_Button()
        {
            driver.FindElement(clickAccDetailsButton).Click();
        }
        
        public void Email_Verification(string email)
        {
            IWebElement verificateEmail = driver.FindElement(emailVerification);            
            Assert.AreEqual(verificateEmail.GetAttribute("value"), email);
            Console.WriteLine("Email is Verificated");
        }

        public void Click_Home_Button()
        {
            driver.FindElement(clickHome).Click();
        }
       
        public void Click_Logout_Button()
        {
            driver.FindElement(clickLogoutButton).Click();
            Console.WriteLine("The page is logged out");
        }                
    }
}
