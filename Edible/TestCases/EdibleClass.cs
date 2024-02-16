using Edible.PageObjects;
using Edible.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edible.TestCases
{
    class Account :Base
    {
        
        [Test]
        public void Cookiesaccept()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Project_Objects obj = new Project_Objects(driver);
            obj.CookAccept().Click();
           
            Console.WriteLine("My First Program");

            //Account_login();
        }
        [Test]
        public void Account_login()
        {
            
            try
            {

                Project_Objects obj = new Project_Objects(driver);
                obj.Accountlgn().Click();


                obj.login().Click();
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space()='Log In']")));

                Console.Write("login appeared");

                obj.Emailfield().SendKeys("Tata@tcs.com");
                Thread.Sleep(2000);

                obj.Passwordfield().SendKeys("Tata@1234");
                Thread.Sleep(2000);

                obj.Signin().Click();
                //span[@class='MuiTypography-root MuiTypography-subtitle2 css-1ws10vy']
                Thread.Sleep(2000);
                var Nam = driver.FindElement(By.XPath("//span[@class='MuiTypography-root MuiTypography-subtitle2 css-1ws10vy']"));
                var Nambox = Nam.Text;

            }
            catch (Exception ex)
            {
                Assert.Fail("TestCases Fail");
                TestContext.Progress.WriteLine(ex.StackTrace);
            }
  

        }
        [Test]
        public void Account_logout()
        {
            //Account Login
            try
            {
                Project_Objects obj = new Project_Objects(driver);
                obj.Accountlgn().Click();

                obj.login().Click();

                Console.Write("login appeared");

                obj.Emailfield().SendKeys("Tata@tcs.com");
                Thread.Sleep(2000);

                obj.Passwordfield().SendKeys("Tata@1234");
                Thread.Sleep(2000);

                obj.Signin().Click();

                Thread.Sleep(2000);
                var Nam = driver.FindElement(By.XPath("//span[@class='MuiTypography-root MuiTypography-subtitle2 css-1ws10vy']"));
                var Nambox = Nam.Text;

                obj.Accountlgn().Click();
                Thread.Sleep(2000);
                obj.Signout().Click();

                   //driver.FindElement(By.XPath("//li[@role='menuitem']")).Click();
                // Console.Write("logout button clicked");


            }
            catch (Exception ex) {

                Assert.Fail("Logout Fail");
                TestContext.Progress.WriteLine(ex.StackTrace);                    
                  }
            

        }
        
    }
}
