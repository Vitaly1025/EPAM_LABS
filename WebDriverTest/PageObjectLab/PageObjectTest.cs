using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectLab.PageObjects;
using System;

namespace PageObjectLab
{
    public class PageObjectTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"F:\Учёба\7 семестр\Testing\EPAM_LABS\WebDriverTest\PageObjectLab");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void CheckContactPage()
        {
            var contactPage = new ContactPage(driver);
            contactPage.GoToPage();
            contactPage.SelectLocation();
            Assert.IsTrue(contactPage.CheckOpeningLink());
        }

        [Test]
        public void CheckPrintOption()
        {
            var printPage = new PrintPage(driver);
            printPage.GoToPage();
            printPage.SelectPrint();
            Assert.IsTrue(printPage.CheckOpeningLink());
        }
    }
}