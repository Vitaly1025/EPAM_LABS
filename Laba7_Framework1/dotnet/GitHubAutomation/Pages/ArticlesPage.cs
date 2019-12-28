using GitHubAutomation.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class ArticlesPage
    {
        private IWebDriver driver;
        private const string vkIconPath = "//a[@class='b-share__handle b-share__link b-share-btn__vkontakte']";
        private const string vkShareMessage = "//*[@id='share_mail']";
        private const string vkShareInput = "//*[@id='share_friend_inp']";
        private const string vkShareSend = "//*[@id='post_button']";
        private const string vkSelectUser = "//*[@id='wddi92767422_share_friend_dd']";
        private const string vkSuccess = "//*[@id='share_cont']/div/div[1]/b";
        public ArticlesPage(IWebDriver driver)
        {
            
            CoreDriver something = new CoreDriver(); // creating an object 
                                                     // settings 
            something.my_port = 50150; // multiple chrome instances - will be run on different ports 
                                       // I am currently having 4 chrome profiles ;) 
            something.my_name = "mynewprofile"; // full profile name will be: 'profile + my_name'. Check the code of the object. 
                                                // void 
            something.ConfigureProfile(); // creating new profile or updating existing one, if folder eists 
            something.Initialize(); // starting the browser 
            driver.Close();
            this.driver = something.driver;
        }

        public bool GoToShare()
        {
            driver.Navigate().GoToUrl("https://e-mogilev.by/st991.html");
            driver.FindElement(By.XPath(vkIconPath)).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
            jscript.ExecuteScript("document.getElementById('share_mail').click()");
            Thread.Sleep(500);
            //driver.FindElement(By.XPath(vkShareMessage)).Click();
            driver.FindElement(By.XPath(vkShareInput)).SendKeys("Vitaliy Kurzenkov");
            Thread.Sleep(3000);
            jscript.ExecuteScript("WideDropdown.select('share_friend_dd', event)");
            //driver.FindElement(By.XPath(vkSelectUser)).Click();
            //driver.FindElement(By.XPath(vkShareSend)).Click();
            jscript.ExecuteScript("document.getElementById('post_button').click()");
            Thread.Sleep(2000);
            return driver.FindElement(By.XPath(vkSuccess)).Text.Contains("Success");
        }

    }
}
