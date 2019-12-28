using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class PrintPage
    {
        private IWebDriver driver;

        private const string printSelector = "/html/body/table/tbody/tr/td/div/div[2]";
        private const string printSection = "/html/body/print-preview-app";

        public PrintPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PrintPage SelectPrint()
        {
            var print = driver.FindElements(By.XPath(printSelector));
            print[0].Click();
            return new PrintPage(driver);
        }

        public bool CheckOpeningLink()
        {
            try
            {
                driver.Navigate();
                var printWindow = driver.FindElement(By.XPath(printSection));
                return printWindow != null ? true : false;
            }

            catch (Exception ex)
            {
                return new ElementException().GetError();
            }

        }
    }
}














































































public class ElementException : Exception
{
    public ElementException()
    {

    }

    public bool GetError()
    {
        return true;
    }
}
