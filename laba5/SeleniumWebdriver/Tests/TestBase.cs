using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriver.Tests
{
    public abstract class TestBase
    {
        protected IWebDriver _webDriver;

        [SetUp]
        public void StartBrowser()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://e-mogilev.by/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _webDriver.Quit();
            _webDriver.Dispose();
        }

        protected IWebElement GetWebElement(string xPath)
        {
            try
            {
                return _webDriver.FindElement(By.XPath(xPath));
            }
            catch
            {
                return null;
            }
        }
    }
}
