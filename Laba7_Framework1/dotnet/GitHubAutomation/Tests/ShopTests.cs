using System;
using System.IO;
using Framework.Driver;

using Framework.Services;
using GitHubAutomation.Tests;
using GitHubAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Tests
{
    class ShopTests : TestConfig
    {

        /*
            1. Проверка работы строки поиска
                1) Перейти на главную страницу https://e-mogilev.by .
                2) Заполнить строку поиска (К примеру введём в строку поиска слово Часы);
            Ожидаемый результат: если данный товар присутствует, то должен отобразиться
            список товаров и подходящие категории. В случае его отсутствия должно отобразиться
            сообщение "Ничего не найдено".
        */
        [Test]
        public void SearchShopItemTest()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");
                Assert.IsTrue(
                new MainPage(Driver)
                        .EnterSearchValue("adfasdfsafsf")
                        .IsRightlySearch()
                        );

            });
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
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");
                Assert.IsTrue(
                new MainPage(Driver)
                        .SelectCategoryOnPage()
                        .IsRightlyCategorySelect()
                        );

            });
        }

        //    3. Проверка работы формы обратной связи
        //      1) Перейти на любую страницу в домене https://e-mogilev.by .
        //      2) Выбрать форму обратной связи, находящуюся внизу справа(Отправить нам сообщение).
        //      3) Описать проблему в строку ввода формы.
        //      4) Нажать на клавишу отправить формы.
        //      5) Заполнить контактные данные а именно(Имя, E-mail, Телефон).
        //      6) Нажать на клавишу отправить.
        [Test]
        public void CheckCallForm()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");

                Assert.IsTrue(
                         new MainPage(Driver)
                            .OpenContactForm()
                            .EnterIntoCallForm("sad")
                            .SendIntoCallForm("sdfs", "mailre@mail.ru", "+375-29-444-33-22")
                            .IsCallFormSendSuccess()
                        );

            });

        }

        //        4. Проверка добавления товаров в корзину
        //          1) Перейти на страницу со списком товаров(К примеру главная страница).
        //          2) Добавить в корзину несколько товаров(Добавим несколько товаров кликнув на кнопку купить в карточках товаров).
        //          3) Кликнуть на кнопку "Корзина".
        //      Ожидаемый результат: должна отобразиться страница со списком выбранных товаров
        //      и формой для ввода личных данных, посчитаться общая сумма товаров.Также вверху страницы будет отображаться количество товаров в корзине.
        [Test]
        public void BasketItemsTest()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");
                Assert.IsTrue(
                new MainPage(Driver)
                        .AddItemsToBasket()
                        .ClickToBasket()
                        .ResultBaket()
                        );

            });

        }


        //5. Проверка осуществления заказа
        //    1) Перейти на страницу со списком товаров(К примеру главная страница).
        //    2) Добавить в корзину несколько товаров(Добавим несколько товаров кликнув на кнопку купить в карточках товаров).
        //    3) Кликнуть на кнопку "Корзина".
        //    4) Заполнить форму "Оформления заказа" и нажать "Оформить заказ".
        //Ожидаемый результат: должно появиться сообщение о принятии заказа 
        //"Спасибо, Ваш заказ #427154 оформлен в интернет-магазине e-mogilev.by".

        [Test]
        public void AccpetOrderTest()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");

                Assert.IsTrue(
                                    new MainPage(Driver)
                       .AddItemsToBasket()
                       .ClickToBasket()
                       .InsertDataIntoAcceptForm()
                       .IsOrderAccept()
                        );

            });

        }

        //    6. Проверка работы страницы "контакты"
        //    1) Перейти на страницу https://e-mogilev.by/contact.php .
        //    2) Выбрать любой адрес(К примеру г.Могилёв) и нажать "Показать на карте".
        //      Ожидаемый результат: перенос на гугл карту с выбраным адресом.
        [Test]
        public void CheckContactPage()
        {
            MakeScreenshotWhenFail(() =>
            {
                Assert.IsTrue(
                                    new MainPage(Driver)
                       .GoToContactPage()
                       .SelectLocation()
                       .CheckOpeningLink()
                        );

            });
        }
        //  7. Проверка возможности поделиться статьёй 
        //      1) Перейти на страницу https://e-mogilev.by/story.html .
        //      2) Выбрать статью(К примеру https://e-mogilev.by/st984.html).
        //      3) Выбрать социальную сеть и нажать на иконку.
        //      Ожидаемый результат: результатом будет являться успешное добавление поста в соц сеть.
        [Test]
        public void CheckShareFunctional()
        {
            MakeScreenshotWhenFail(() =>
            {
                Assert.IsTrue(
                new MainPage(Driver)
                   .GoToArticlePage()
                   .GoToShare()
                        );

        });
        }
        //        8. Проверка коррекции страницы
        //    1) Перейти на страницу с любым товаром(К примеру https://e-mogilev.by/id712-505001.html).
        //    2) Нажать на "Нашли ошибку в описании? Сообщите нам, мы исправим".
        //    3) Ввести информацию и капчу.
        //  Ожидаемый результат: Обновление страницы и вывод сообщения "Спасибо, Ваше замечание отправлено модераторам".

        [Test]
        public void CheckCorrectionFunctionallity()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");
                Assert.IsTrue(
                                    new MainPage(Driver)
                       .GoToShopItemPage()
                       .SelectMistakeForm()
                       .EnterCorrectText("some text")
                       .SendCorrectForm()
                       .IsCorrect()
                        );

            });
        }
        //    9. Проверка версии для печати
        //    1) Перейти на страницу с любым товаром(К примеру https://e-mogilev.by/id712-505001.html).
        //    2) Нажать на иконку принтера рядом с названием.
        //Ожидаемый результат: на странице должна отобразиться версия для печати
        [Test]
        public void CheckPrintOption()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://e-mogilev.by/");
                Assert.IsTrue(
                                    new MainPage(Driver)
                       .GoToPrintPage()
                       .SelectPrint()
                       .CheckOpeningLink()
                        );

            });
        }
    //    10.    Проверка входа в личный кабинет пользователя
    //    1) Произвести регистрацию на странице https://e-mogilev.by/vxod.html .
    //    2) Выбрать пункт "Войти" и ввести данные указанные на прошлом шаге.
    //  Ожидаемый результат: в случае успешного входа должно произойти перенаправление
    //  на страницу личного кабинета пользователя со список личных данных.
        [Test]
        public void CheckLogin()
        {
            Driver.Navigate().GoToUrl("https://e-mogilev.by/");
            MakeScreenshotWhenFail(() =>
            {
                //Assert.IsTrue(
                new MainPage(Driver)
                   .GoToLoginPage()
                   .Login("vitalik@mail.ru", "1234qwer")
                   .IsTrueAccess();
                       //.CheckOpeningLink()
                        //);

            });
        }

    }
}
