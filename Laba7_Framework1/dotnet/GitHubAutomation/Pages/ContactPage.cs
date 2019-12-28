using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class ContactPage
    {
        private IWebDriver driver;
        private const string locationPath = "/html/body/table/tbody/tr/td/div/div[2]/table/tbody/tr/td/span/div[1]/a";


        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ContactPage SelectLocation()
        {
            var products = driver.FindElements(By.XPath(locationPath));
            products[0].Click();
            return new ContactPage(driver);
        }

        public bool CheckOpeningLink()
        {
            return driver.Url.Contains("#map_mogilev");
        }

    }
}
