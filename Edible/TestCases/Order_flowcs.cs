using Edible.PageObjects;
using Edible.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.Page;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edible.TestCases
{
    class Order_flows :Base
    {
        [Test]
        public void SearchProduct()
        {
           
            try
            {
             OrderObjects obj = new OrderObjects(driver);
                obj.SearchProduct().SendKeys("5326");
                obj.SearchFieldFocustype().SendKeys(Keys.Enter);

                
                // Thread.Sleep(1000);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementToBeClickable(obj.SearchFieldFocustype());


                //obj.SearchFieldFocustype().SendKeys("5326");
                //Thread.Sleep(1000);
               // obj.SearchFieldFocustype().SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='arr']")));
                
                obj.GetSearchedProduct().Click();   
            }
            catch(Exception e){
                Assert.Fail("TestCases Fail");
                TestContext.Progress.WriteLine(e.StackTrace);
            }

        }
        [Test]
        public void AvalibilitySection()
        {
            SearchProduct();
            try
            {
                OrderObjects obj = new OrderObjects(driver);

                //var element = driver.FindElement(By.id("element-id"));
                //Actions actions = new Actions(driver);
                //actions.MoveToElement(obj.InsertZipCode()).SendKeys("06514").Perform();
                //actions.Perform();


               obj.InsertZipCode().SendKeys("06514");

                obj.DeliveryDateSelection().Click();
                obj.DeliveryTypeOrder().Click();
                obj.StoreList().Click();

                Thread.Sleep(2000);
                obj.AddOnContinueButton().Click();

            }
            catch (Exception e)
            {
                Assert.Fail("TestCase Fail");
                TestContext.Progress.WriteLine(e.StackTrace);           
            }

        }
        [Test]
        public void DeliveryInformation()
        {
            AvalibilitySection();
            try
            {
                OrderObjects obj = new OrderObjects(driver);
                obj.DeliveryFirstName().SendKeys("Umair");
                obj.DeliveryLastName().SendKeys("Gillani");
                obj.DeliveryStreetAddress().SendKeys("1920 Dixwell Ave");
                obj.DeliveryHomePhone().SendKeys("192-838-7490");
                obj.AddressType().Click();
                driver.FindElement(By.XPath("//li[normalize-space()='Residential']")).Click();
                obj.CityTown().Click();

                driver.FindElement(By.XPath("//li[normalize-space()='Hamden']")).Click();

                IWebElement framScroll = driver.FindElement(By.XPath("//button[normalize-space()='Add To Cart']"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", framScroll);

                driver.FindElement(By.XPath("//button[normalize-space()='Add To Cart']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root MuiIconButton-root MuiIconButton-colorSecondary MuiIconButton-sizeLarge css-1wj3pt2']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//button[normalize-space()='Add To Cart']")).Click();
            }

            catch (Exception e)
            {
                Assert.Fail("TestCase Fail");
                TestContext.Progress.WriteLine(e.StackTrace);
            }
        }
        [Test]
         public void CartPage()
       {
            DeliveryInformation();
            try
            {
               WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath("//h1[contains(.,'Shopping Cart')]")), "Shopping Cart"));
            }
            catch (Exception e)
            {
                Assert.Fail("Test case Fail");
                TestContext.Progress.WriteLine(e.StackTrace);            }
        }
    }
}

   

