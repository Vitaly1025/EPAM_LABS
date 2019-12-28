using Framework.Models;
using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace GitHubAutomation.Pages
{
    class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string seatchItemsPath = "//*[@id='search_box_area']";
        private const string searchItemAnswerPath = "//H2[contains(text(),'Ничего не найдено.')]";

        private const string categoryiconPath = "//i[@class='icon-menu icon1']";
        private const string categoryAnwswerPath = "//H2[contains(text(),'Популярные')]";

        private const string callFormPath = "//*[@id='jvlabelWrap']";
        private const string callFormInputPath = "//*[@id='jcont']//*//textarea";
        private const string callFormNamePath = "//*[@id='scrollbar-container']//*//input[@name='name']";
        private const string callFormMailPath = "//*[@id='scrollbar-container']//*//input[@name='email']";
        private const string callFormPhonePath = "//*[@id='scrollbar-container']//*//input[@name='phone']";
        private const string callFormSendPath = "//*[@class='text_Xc']";
        private const string callFormAcceptMessege = "//*[@id='scrollbar-container']//*//JDIV[@class='text_2i']";
        
        private const string basketPath = "/html/body/div[4]/table/tbody/tr/td[4]/a";
        private const string someItemsPath = "//a[@rel='nofollow'][@title='Положить в корзину']";
        private const string resultBasketPath = "//td[@colspan='3'][@class='cart_summary']";

        private const string loginPath = "//*[@href='/vxod.html']";

        private const string shopItemPath = "/html/body/table/tbody/tr/td/div/div[3]/div/div[1]/div[3]";


        public bool IsRightlySearch()
        {
            return driver.FindElement(By.XPath(searchItemAnswerPath)) == null ? true : driver.FindElement(By.XPath(searchItemAnswerPath)).Text.Contains("Ничего не найдено.");
        }
        public MainPage EnterSearchValue(string predicat)
        {
            var destinationText = driver.FindElement(By.XPath(seatchItemsPath));
            destinationText.SendKeys(predicat);
            destinationText.SendKeys("\t");
            destinationText.SendKeys("\r\n");
            Thread.Sleep(2000);
            return new MainPage(driver);
        }
        public MainPage SendIntoCallForm(string name, string email, string phone)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(callFormNamePath)).SendKeys(name);
            driver.FindElement(By.XPath(callFormMailPath)).SendKeys(email);
            driver.FindElement(By.XPath(callFormPhonePath)).SendKeys(phone);
            driver.FindElement(By.XPath(callFormSendPath)).Click();
            return new MainPage(driver);
        }
        public MainPage SelectCategoryOnPage()
        {
            var searchButton = driver.FindElement(By.XPath(categoryiconPath));
            searchButton.Click();
            Thread.Sleep(4000);
            return new MainPage(driver);
        }

        public bool IsRightlyCategorySelect()
        {
            return driver.FindElement(By.XPath(categoryAnwswerPath)).Text.Contains("Популярные");
        }

        public bool IsCallFormSendSuccess()
        {
            Thread.Sleep(500);
            return driver.FindElement(By.XPath(callFormAcceptMessege)).Text.Contains("Теперь ваши сообщения");
        }
        public MainPage EnterIntoCallForm(string message)
        {
            Thread.Sleep(500);
            driver.FindElement(By.XPath(callFormInputPath)).SendKeys(message);
            driver.FindElement(By.XPath(callFormInputPath)).SendKeys("\n");
            return new MainPage(driver);
        }

        public MainPage OpenContactForm()
        {
            Thread.Sleep(5000); 
            var contactPage = driver.FindElement(By.XPath(callFormPath));
            driver.FindElement(By.XPath(callFormPath)).Click();
            return new MainPage(driver);
        }

        public ContactPage GoToContactPage()
        {
            driver.Navigate().GoToUrl("https://e-mogilev.by/contact.php");
            return new ContactPage(driver);
        }
        public ShopItemPage GoToShopItemPage()
        {
            driver.FindElement(By.XPath(shopItemPath)).Click();
            return new ShopItemPage(driver);
        }
        public LoginPage GoToLoginPage()
        {
            driver.FindElement(By.XPath(loginPath)).Click();
            return new LoginPage(driver);
        }

        public PrintPage GoToPrintPage()
        {
            driver.Navigate().GoToUrl("https://e-mogilev.by/id712-505001.html");
            return new PrintPage(driver);
        }
        public ArticlesPage GoToArticlePage()
        {
            driver.Navigate().GoToUrl("https://e-mogilev.by/st991.html");
            return new ArticlesPage(driver);
        }

        public MainPage AddItemsToBasket()
        {
            var ToBasketElement = driver.FindElements(By.XPath(someItemsPath));
            ToBasketElement[0].Click();
            ToBasketElement[1].Click();
            return new MainPage(driver);
        }

        public BasketPage ClickToBasket()
        {
            var BasketButton = driver.FindElement(By.XPath(basketPath));
            //BasketButton.Click();
            driver.Navigate().GoToUrl("https://e-mogilev.by/cart.html");
            return new BasketPage(driver);
        }

    }
}
