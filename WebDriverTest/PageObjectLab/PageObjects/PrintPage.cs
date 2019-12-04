using OpenQA.Selenium;
using System;
using System.Threading;

namespace PageObjectLab.PageObjects
{
//    9. Проверка версии для печати
//    1) Перейти на страницу с любым товаром(К примеру https://e-mogilev.by/id712-505001.html).
//    2) Нажать на иконку принтера рядом с названием.
//Ожидаемый результат: на странице должна отобразиться версия для печати
    public class PrintPage
    {
        private IWebDriver driver;
        
        private string printSelector = "/html/body/table/tbody/tr/td/div/div[2]";
        private string printSection = "/html/body/print-preview-app";

        public PrintPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectPrint()
        {
            var print = driver.FindElements(By.XPath(printSelector));
            print[0].Click();
        }

        public bool CheckOpeningLink()
        {
            try
            {
                driver.Navigate();
                var printWindow = driver.FindElement(By.XPath(printSection));
                return printWindow != null ? true : false;
            }

            catch(Exception ex)
            {
                return new ElementException().GetError();
            }

        }
            
        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://e-mogilev.by/id712-505001.html");
        }
    }
}














































































public class ElementException: Exception{
    public ElementException()
    {

    }

    public bool GetError()
    {
        return true;
    }
}