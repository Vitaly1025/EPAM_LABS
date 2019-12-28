using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        private const string mistakebuttonPath = "//*[@class='mstake']";
        private const string correctTextFieldPath = "//*[@id='corrtext']";
        private const string correctButtonPath = "//*[@id='corrector']/form/input";

        private const string loginFieldPath = "//*[@name='email'][@class='regfield']";
        private const string passwordFieldPath = "//*[@name='pass'][@class='regfield']";
        private const string loginsuccessPath = "/html/body/table/tbody/tr/td[2]/div/center/h2";
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage Login(string login, string pass)
        {
            driver.FindElement(By.XPath(loginFieldPath)).SendKeys(login);
            driver.FindElement(By.XPath(passwordFieldPath)).SendKeys(pass + "\n");
            return new LoginPage(driver);
        }

        public bool IsTrueAccess()
        {
            return driver.FindElement(By.XPath(loginsuccessPath)).Text.Contains("Личные данные");
        }
    }
}
