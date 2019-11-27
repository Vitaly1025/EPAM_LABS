using System;
using System.Threading;
using NUnit.Framework;

namespace SeleniumWebdriver.Tests
{
    [TestFixture]
    public class SearchTest : TestBase
    {
        private const string ExpectedErrorText =
            "Ничего не найдено.";
        /*
            1. Проверка работы строки поиска
                1) Перейти на главную страницу https://e-mogilev.by .
                2) Заполнить строку поиска (К примеру введём в строку поиска слово Часы);
            Ожидаемый результат: если данный товар присутствует, то должен отобразиться
            список товаров и подходящие категории. В случае его отсутствия должно отобразиться
            сообщение "Ничего не найдено".
        */
        [Test]
        public void SearchShopItem()
        {
            var destinationText = GetWebElement("//INPUT[@type='text'][@id='search_box_area']");
            destinationText.SendKeys("телефон");
            destinationText.SendKeys("\t");
            destinationText.SendKeys("\r\n");
            Thread.Sleep(2000);
            var errorMessage = GetWebElement("//H2[contains(text(),'Ничего не найдено.')]");
            Assert.AreNotEqual(ExpectedErrorText, errorMessage?.Text);
        }


        /*
            2. Проверка работы выбора товаров с помощью фильтра по категориям товара
                1) Перейти на главную страницу https://e-mogilev.by .
                2) Выберем категорию товара(К примеру выберем иконку с изображением компьютера);
            Ожидаемый результат: должен отобразиться список товаров соответсвующий категории.
        */

        [Test]
        public void SelectCategory()
        {
            var searchButton = GetWebElement("//i[@class='icon-menu icon1']");
            searchButton.Click();
            Thread.Sleep(4000);
            var errorMessage = GetWebElement("//H2[contains(text(),'Популярные')]");
            Assert.AreEqual("Популярные", errorMessage.Text);
        }
    }
}
