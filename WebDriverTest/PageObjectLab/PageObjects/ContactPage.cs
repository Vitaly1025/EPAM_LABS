using OpenQA.Selenium;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace PageObjectLab.PageObjects
{
//    6. Проверка работы страницы "контакты"
//    1) Перейти на страницу https://e-mogilev.by/contact.php .
//    2) Выбрать любой адрес(К примеру г.Могилёв) и нажать "Показать на карте".
//      Ожидаемый результат: перенос на гугл карту с выбраным адресом.
    public class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectLocation()
        {
            var products = driver.FindElements(By.XPath("/html/body/table/tbody/tr/td/div/div[2]/table/tbody/tr/td/span/div[1]/a"));
            products[0].Click();
        }

        public bool CheckOpeningLink()
        {
            return driver.Url.Contains("#map_mogilev");
        }
ч        public void GoToPage()
        {
                
        }
        
    }
}
