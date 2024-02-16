using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace Edible.Utilities
{
    class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        string browserName;

        public ThreadLocal<IWebDriver> getdriver = new ThreadLocal<IWebDriver>();

        [OneTimeSetUp]

        public void setup()
        {
            string WorkingDirectory = Environment.CurrentDirectory;
            string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            string reportpath = ProjectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Enviroment", "UAT");
            extent.AddSystemInfo("Tester Name", "Umair Gillani");

        }
        public ChromeDriver driver;
        [SetUp]
        public void start()
        {
            test = null;
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

       

          ChromeOptions options = new ChromeOptions();
          driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://eaweb-us-uat.netsolace.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //driver.FindElement(By.XPath("//img[@alt='Close']")).Click();
            //button[@class='MuiButtonBase-root MuiIconButton-root MuiIconButton-colorSecondary MuiIconButton-sizeSmall css-1a6tvqs']
            
            driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root MuiIconButton-root MuiIconButton-colorSecondary MuiIconButton-sizeSmall css-m21lnp']")).Click();      }

        [TearDown]

        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var Stacktrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            string filename = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("TestFailed", CaptureScreeenshot(driver,filename));
                test.Log(Status.Fail, "Test Failed with LogTrace" + Stacktrace);
            }
            if(status == TestStatus.Passed)
            {
                test.Pass("test Passed", CaptureScreeenshot(driver, filename));
                test.Log(Status.Pass);
            }
            if(status == TestStatus.Skipped)
            {
                test.Skip("Test Skipped", CaptureScreeenshot(driver, filename));
                test.Log(Status.Skip, "Test Got Skipped" + Stacktrace);
            }
            extent.Flush();
            driver.Quit();
        }
        
        public MediaEntityModelProvider CaptureScreeenshot(IWebDriver driver, string ScreenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScreenshotName).Build();
        }
    }
}
