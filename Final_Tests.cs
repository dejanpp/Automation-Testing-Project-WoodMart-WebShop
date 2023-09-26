using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Interactions;

namespace Final_Selenium_Project
{
    [TestFixture]
    public class Final_Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://woodmart.xtemos.com/home/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Description("Registration")]
        [Order(1)]       
        public void Test_1_Registration()
        {
            Home_Page homePage = new Home_Page(driver);
            My_Account_Page myAccount = new My_Account_Page(driver);            

            homePage.Click_User_Registration_Button();
            homePage.Click_Create_Account_Button();
            myAccount.Enter_User_Name();
            string enterEmail = myAccount.Enter_Email();
            myAccount.Enter_Password();
            myAccount.Click_Register_Button();
            //myAccount.Click_Register_Button();//Morav da stavam uste eden klik zatoa sto kaj mene pravi ponekogas problem ne klika-
                                              //na Register kopceto...ako ne e vo red vaka odkomentiraj go... 
            myAccount.Click_Acc_Details_Button();
            myAccount.Email_Verification(enterEmail);
        }
        [Test]
        [Order(2)]
        [Description("Add Best clock parallels and Dolor ad hoc torquent Clocks")]
        public void Test_2_Add_Clocks()
        {
            Home_Page homePage = new Home_Page(driver);
            My_Account_Page myAccount = new My_Account_Page(driver);
            Clocks_Page myClocks = new Clocks_Page(driver);
            Compare_Page compareClocks = new Compare_Page(driver);

            myAccount.Click_Home_Button();
            homePage.Click_On_Clocks_Menu();
            myClocks.Select_Best_Clock_Parallels();
            myClocks.Select_Dolor_Ad_Hoc_Torquent();
            myClocks.Click_On_Compare_Button();
            compareClocks.Confirm_Best_Clock_Parallels_Is_Added("Best clock parallels");
            myClocks.Click_On_Compare_Button();
            compareClocks.Confirm_Dolor_Ad_Hoc_Torquent_Is_Added("Dolor ad hac torquent");
            myClocks.Click_On_Compare_Button();
        }
        [Test]
        [Order(3)]
        [Description("Assert Best Clock Parallels has discounted price")]
        public void Test_3_Assert_Price()
        {
            Compare_Page compareClocks = new Compare_Page(driver);            

            compareClocks.Best_Clock_Parallels_Has_Discounted_Price("780.00", "555.00");
        }
        [Test]
        [Order(4)]
        [Description("Best clock parallels has five star rating")]
        public void Test_4_Assert_Rating()
        {
            Compare_Page compareClocks = new Compare_Page(driver);

            compareClocks.Best_Clock_Parallels_Has_Five_Star_Rating("Rated 5.00 out of 5");
        }
        [Test]
        [Order(5)]
        [Description("Both Clocks are In Stock")]
        public void Test_5_In_Stock()
        {
            Compare_Page compareClocks = new Compare_Page(driver);

            compareClocks.Best_Clock_Parallels_In_Stock("In stock");
            compareClocks.Dolor_Ad_Hoc_In_Stock("In stock");
        }
        [Test]
        [Order(6)]
        [Description("Both clocks are from different brands")]
        public void Test_6_Assert_Brand()
        {
            Compare_Page compareClocks = new Compare_Page(driver);

            compareClocks.Clocks_Brand_Assertions();
        }
        [Test]
        [Order(7)]
        [Description("Dolor ad hoc torquent not have color selection")]
        public void Test_7_No_Color()
        {
            Compare_Page compareClocks = new Compare_Page(driver);

            compareClocks.Dolor_ad_hoc_torquent_No_Color("-");
        }
        [Test]
        [Order(8)]
        [Description("Remove clocks, Assert that compare list is empty")]
        public void Test_8_Assert_List_Is_Empty()
        {            
            Clocks_Page myClocks = new Clocks_Page(driver);
            Compare_Page compareClocks = new Compare_Page(driver);
            Home_Page homePage = new Home_Page(driver);

            homePage.DismissPopUpIfDisplayed();
            //Mislam deka ka mene ne mi raboti actions ili escape komandata pa mozno e da se pojavi popup-ot i da padni testot
            compareClocks.Clock_1_Remove();
            myClocks.Click_On_Compare_Button();//ovde staviv click nesto kako refresh zatoa sto ne mi go brisese edniot clock verojatno e nekakov bug
            compareClocks.Clock_2_Remove();
            compareClocks.Assert_Empty_List_Is_Displayed();
            compareClocks.Comparation_List_Is_Set_To_Zero();
        }
        [Test]
        [Order(9)]
        [Description("Log Out")]
        public void Test_9_Log_out()
        {
            My_Account_Page myAccount = new My_Account_Page(driver);

            myAccount.Click_My_Acc_Button();
            myAccount.Click_Logout_Button();                                  
        }
        

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}