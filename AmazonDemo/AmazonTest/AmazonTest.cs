using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using AmazonPages;
using System.Threading;

namespace AmazonTest
{
    [TestClass]
    public class AmazonTest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            //driver = new ChromeDriver("D:");
            driver = new FirefoxDriver("D:\\");
        }

        [Test]
        public void arrowQA()
        {
            driver.Url = "https://www.amazon.in/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            Homepage home = new Homepage(driver);
            home.keyboardActions();
            home.EnterItemName("router");
            
            Thread.Sleep(3000);
            //home.ClickSearch();
            Thread.Sleep(2000);
            home.GetLinks();
           
            home.ClickAnItem("D-Link DIR-615 Wireless-N300 Router (Black)");
            home.ClickAnItem("Mi 3C Router (White)");
            home.ClickAnItem("TP-Link TL-WR740N Wireless Router (white)");
            home.SwitchTo(3);
            home.GetItemTitle();
            //Dlink is 1st
            home.SwitchTo(1);
            home.GetItemTitle();
            home.SwitchTo(2);
            home.GetItemTitle();
            home.SwitchBack();
            Thread.Sleep(2000);
            home.ClearSearchField();
            home.EnterItemName("Laptops");
            home.ClickSearch();
            home.GetLinks();

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
