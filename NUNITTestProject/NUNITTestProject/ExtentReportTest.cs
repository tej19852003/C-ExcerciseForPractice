
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUNITTestProject
{
    [TestFixture]
    public class ExtentReportTest
    {
        ExtentReports extent = new ExtentReports("C:\\CSharp\\report\\report.html");
        IWebDriver driver = null;
        private ExtentTest test;

        [OneTimeSetUp]
        public void OnetimeSetUpTest()
        {
            extent = new ExtentReports("C:\\CSharp\\report\\report.html");
        }
        

        [Test]
        public void StartDriver()
        {
            test = extent.StartTest("Start Driver Test", "Starting Driver and Validating Download link");


            driver = new ChromeDriver(@"C:\\CSharp\\NUNITTestProject\\NUNITTestProject\\Files");
            test.Log(LogStatus.Info, "Starting Chrome Driver");
            driver.Url = "http://www.seleniumhq.org/";
            test.Log(LogStatus.Info, "Navigating to seleniumhq.org website");

            driver.Manage().Window.Maximize();
            test.Log(LogStatus.Info, "Maximized the window");

            bool check = driver.FindElement(By.LinkText("Download")).Displayed;
            test.Log(LogStatus.Pass, "Verified the download link is present");


            Console.WriteLine("check = " + check);

           
        }
        [Test]
        public void VerifyChromeDriverVersion()
        {
            test = extent.StartTest("VerifyChromeDriverVersion", "Verify ChromeDriver latest Version");

            driver.FindElement(By.LinkText("Download")).Click();
            test.Log(LogStatus.Pass, "Clicked on Download Link");

            String currenturl = driver.Url;
            if (currenturl.Contains("seleniumhq.org/download/")){
                test.Log(LogStatus.Pass, "Verified Page navigated to right URL");
                Assert.IsTrue(true);

            } else
            {
                test.Log(LogStatus.Fail, "Verified Page navigated to wrong URL");
                Console.WriteLine("Current URL = " + currenturl);
                Assert.IsTrue(false);
            }
            


        }
        [OneTimeTearDown]
        public void OnetimeTearDownTest()
        {
            extent.EndTest(test);
            extent.Flush();

            driver.Quit();
        }
    }
}
