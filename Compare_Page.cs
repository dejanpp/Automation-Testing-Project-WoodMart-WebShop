using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Selenium_Project
{
    public class Compare_Page
    {
        public IWebDriver driver;
        WebDriverWait wait;

        public Compare_Page(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        By first_Clock_Click_For_Comparation = By.XPath("//a[contains(text(), \"Best clock parallels\")]");
        By first_Clock_Add_Confirmation = By.XPath("//h1[contains(text(), \"Best clock parallels\")]");
        By second_Clock_Click_For_Comparation = By.XPath("//a[contains(text(), \"Dolor ad hac torquent\")]");
        By second_Clock_Add_Confirmation = By.XPath("//h1[contains(text(), \"Dolor ad hac torquent\")]");       
        By best_Clock_Parallels_Has_Five_Star_Rating = By.CssSelector("div[aria-label=\"Rated 5.00 out of 5\"]");
        By best_Clock_Parallels_Text = By.XPath("//p[text()=\"In stock\"]");
        By dolor_ad_hoc_torquent_Text = By.XPath("//p[text()=\"In stock\"]");
        By color_Select = By.XPath("//td[contains(text(),\"-\")]");
        By best_Color_Parallels_Brand = By.CssSelector("img[alt= \"Joseph Joseph\"]");
        By dolor_ad_hoc_torquent_Brand = By.CssSelector("img[alt= \"Louis Poulsen\"]");
        By remove_best_clock_parallels = By.CssSelector("a[data-id=\"1162\"]");
        By remove_dolor_ad_hoc_torquent = By.CssSelector("a.wd-compare-remove[data-id=\"1055\"]");       
        By compare_list_is_empty = By.XPath("//p[contains(text(), \"Compare list is empty.\")]");
        By clockPrice = By.XPath("//span[text()=\"780.00\"]");
        By clockDiscountPrice = By.XPath("//span[text()=\"555.00\"]");
        By compare_icon_is_zero = By.CssSelector("span.wd-tools-count");
        
        public void Confirm_Best_Clock_Parallels_Is_Added(string clockName)
        {
            driver.FindElement(first_Clock_Click_For_Comparation).Click();
            IWebElement clock_Text = driver.FindElement(first_Clock_Add_Confirmation);
            Assert.AreEqual(clock_Text.Text, clockName);
            Console.WriteLine("Best clock parallels is correctly added");           
        }

        public void Best_Clock_Parallels_Has_Discounted_Price(string price, string discount)
        {           
            IWebElement clock_Price = driver.FindElement(clockPrice);
            IWebElement clock_Discount = driver.FindElement(clockDiscountPrice);
            Assert.AreNotEqual(clock_Price.Text, clock_Discount.Text);           
            Console.WriteLine("Best clock parallels has discounted price");
        }

        public void Confirm_Dolor_Ad_Hoc_Torquent_Is_Added(string clockName)
        {
            driver.FindElement(second_Clock_Click_For_Comparation).Click();
            IWebElement clock_Text = driver.FindElement(second_Clock_Add_Confirmation);
            Assert.AreEqual(clock_Text.Text, clockName);
            Console.WriteLine("Dolor ad hac torquent is correctly added");
        }

        public void Best_Clock_Parallels_Has_Five_Star_Rating(string clockRating)
        {
            IWebElement rating = driver.FindElement(best_Clock_Parallels_Has_Five_Star_Rating);
            Assert.AreEqual(rating.GetAttribute("aria-label"), clockRating);
            Console.WriteLine("Best clock parallels has 5 star rating");
        }

        public void Best_Clock_Parallels_In_Stock(string clockInStock)
        {
            IWebElement inStock = driver.FindElement(best_Clock_Parallels_Text);
            Assert.AreEqual(inStock.Text, clockInStock);
            Console.WriteLine("Best clock parallels is in stock");
        }

        public void Dolor_Ad_Hoc_In_Stock(string clockInStock)
        {
            IList<IWebElement> inStock = driver.FindElements(dolor_ad_hoc_torquent_Text);
            Assert.AreEqual(inStock[inStock.Count - 1].Text, clockInStock);
            Console.WriteLine("Dolor ad hoc is in stock");
        }

        public void Dolor_ad_hoc_torquent_No_Color(string clockColor)
        {
            IWebElement clock_Color = driver.FindElement(color_Select);
            Assert.AreEqual(clock_Color.Text, clockColor);
            Console.WriteLine("Dolor ad hoc torquent has no color selections");
        }

        public void Clocks_Brand_Assertions()
        {
            IWebElement clock_Brand1 = driver.FindElement(best_Color_Parallels_Brand);
            IWebElement clock_Brand2 = driver.FindElement(dolor_ad_hoc_torquent_Brand);
            Assert.AreNotEqual(clock_Brand1.GetAttribute("alt"), clock_Brand2.GetAttribute("alt"));
            Console.WriteLine("The Clocks are from diferent Brands");
        }

        public void Clock_1_Remove()
        {
            driver.FindElement(remove_best_clock_parallels).Click();                       
            Console.WriteLine("First clock is removed");
        }
        public void Clock_2_Remove()
        {
            driver.FindElement(remove_dolor_ad_hoc_torquent).Click();                      
            Console.WriteLine("Second clock is removed");
        }
      
        public void Assert_Empty_List_Is_Displayed()
        {
            IWebElement empty_list = driver.FindElement(compare_list_is_empty);
            Assert.AreEqual(empty_list.Text, "Compare list is empty.");
            Console.WriteLine("Compare list is empty.");
        }
        public void Comparation_List_Is_Set_To_Zero()
        {
            IWebElement compareZero = driver.FindElement(compare_icon_is_zero);
            Assert.AreEqual(compareZero.Text, "0");
            Console.WriteLine("Comparation List is set to zero");
        }





    }
}
