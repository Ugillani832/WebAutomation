using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edible.PageObjects
{
    class Project_Objects
    {
        private IWebDriver driver;
        //Constructor
        public Project_Objects(IWebDriver driver)
        {
            this.driver = driver;

            //initiating the element to the page factory
            PageFactory.InitElements(driver, this);
        }

       //assiging the value to attrubute
       //Allocating the element
        [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")]
       // assigning above to variable Element
        private IWebElement Element;

        
        [FindsBy(How = How.XPath, Using = "//button[@id='account-menu-button']")]
        private IWebElement Accountbtn;  

        // driver.FindElement(By.XPath("//button[normalize-space()='Log in']")).Click();

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Log in']")]
        private IWebElement Loginbtn;

        [FindsBy(How = How.XPath, Using = "//input[@id='mui-15']")]
        private IWebElement Email;
        

        [FindsBy(How = How.XPath, Using = "//input[@id='mui-16']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Sign In']")]
        private IWebElement Signinbtn;

       // [FindsBy(How = How.XPath, Using = "//button[@id='account-menu-button']")]
       // private IWebElement Accountbtn;

        [FindsBy(How = How.XPath, Using = "//h6[normalize-space()='Sign Out']")]
        private IWebElement Signoutbtn;  




        //driver.FindElement(By.XPath("//li[@role='menuitem']")).Click();
        // Console.Write("logout button clicked");

        //driver.FindElement(By.XPath("//button[normalize-space()='Sign In']")).Click();

        public IWebElement CookAccept()
        { 
            return Element;
        }

        public IWebElement Accountlgn()
        {
            return Accountbtn;
        }
        public IWebElement login()
        {
            return Loginbtn;
        }
        public IWebElement Emailfield()
        {
            return Email;
        }
        public IWebElement Passwordfield()
        {
            return Password;
        }

        public IWebElement Signin()
        {
            return Signinbtn;
        }
        public IWebElement Signout()
        {
            return Signoutbtn;
        }

    }
}
