using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class ShopItemPage
    {
        private IWebDriver driver;

        private const string mistakebuttonPath= "//*[@class='mstake']";
        private const string correctTextFieldPath = "//*[@id='corrtext']";
        private const string correctButtonPath = "//*[@id='corrector']/form/input";
        public ShopItemPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ShopItemPage SelectMistakeForm()
        {
            driver.FindElement(By.XPath(mistakebuttonPath)).Click();
            return new ShopItemPage(driver);
        }
        public ShopItemPage EnterCorrectText(string text)
        {
            driver.FindElement(By.XPath(correctTextFieldPath)).Click();
            return new ShopItemPage(driver);
        }
        public ShopItemPage SendCorrectForm()
        {
            driver.FindElement(By.XPath(correctButtonPath)).Click();
            return new ShopItemPage(driver);
        }
        public bool IsCorrect()
        {
            return true;
        }
    }
}
