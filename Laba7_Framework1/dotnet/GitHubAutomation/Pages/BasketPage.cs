using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    public class BasketPage
    {
        IWebDriver driver;

        public BasketPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string fioPath = "//INPUT[@type='text'][@name='fio']";
        private const string phonePath = "//INPUT[@type='text'][@name='t_m']";
        private const string emailPath = "//INPUT[@type='text'][@name='email']";
        private const string cityPath = "//INPUT[@type='text'][@name='city_point']";
        private const string acceptButtonPath = "//INPUT[@type='button'][@value='Оформить заказ']";
        private const string someItemsPath = "//a[@rel='nofollow'][@title='Положить в корзину']";
        private const string resultBasketPath = "//td[@colspan='3'][@class='cart_summary']";
        private const string cityAcceptPath = "//*[@id='x8_delivery_city']";
        private const string indexPath = "//*[@id='zip']";
        private const string addressPath = "//*[@id='addr']";
        private const string orderaccpetPath = "/html/body/table/tbody/tr/td[2]/div/center/h2";

        public IWebElement BasketButton { get; set; }
        public IWebElement ToBasketElement { get; set; }
        public IWebElement ResultBasketElement { get; set; }

        //[FindsBy(How = How.XPath, Using = shippingAndPayment)]
        //public IWebElement ShippingAndPaymentButton { get; set; }

        //[FindsBy(How = How.XPath, Using = specialMenuField)]
        //public IWebElement specialMenuButton { get; set; }

        public bool ResultBaket()
        {
            var ResultBasketElement = driver.FindElement(By.XPath(resultBasketPath));
            return ResultBasketElement.Text.Contains("2 товара");
        }

        public bool IsOrderAccept()
        {
            var ResultBasketElement = driver.FindElement(By.XPath(orderaccpetPath));
            return ResultBasketElement.Text.Contains("Ваш заказ");
        }


        public BasketPage InsertDataIntoAcceptForm()
        {
            driver.FindElement(By.XPath(fioPath)).SendKeys("dsfsdfsdf");
            driver.FindElement(By.XPath(phonePath)).SendKeys("3429542");
            driver.FindElement(By.XPath(emailPath)).SendKeys("sdfsd@mail.ru");
            driver.FindElement(By.XPath(cityPath)).SendKeys("г. Могилев");
            Thread.Sleep(1500);
            driver.FindElement(By.XPath(cityAcceptPath)).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.XPath(indexPath)).SendKeys("2201002");
            driver.FindElement(By.XPath(addressPath)).SendKeys("Кирова 3Б");
            driver.FindElement(By.XPath(acceptButtonPath)).Click();
            return new BasketPage(driver);
        }

    }
}
