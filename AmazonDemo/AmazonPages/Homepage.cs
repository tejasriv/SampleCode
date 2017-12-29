using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonPages
{
    public class Homepage
    {
        ActionEngine actionEngine;
        IWebDriver driver;
        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            actionEngine = new ActionEngine(driver);
        }
        public void EnterItemName(String name)
        {
            actionEngine.SendKeys(By.Id("twotabsearchtextbox"), name);
        }

        public void ClickSearch()
        {
            actionEngine.Click(By.XPath("//div[@class='nav-search-submit nav-sprite']"));
        }
        public void keyboardActions()
        {
            Actions action = new Actions(driver);
            action.KeyUp(Keys.Control).SendKeys(Keys.Control + "s").Build().Perform();
        }

        public void GetLinks()
        {
            IList<IWebElement> allLinks = driver.FindElements(By.XPath("//a[@class='a-link-normal s-access-detail-page  s-color-twister-title-link a-text-normal']"));
            Console.WriteLine(allLinks.Count());
        }
        public void ClickAnItem(String value)
        {
            actionEngine.MoveToElement(By.XPath("//a[@title='" + value + "']"));
            actionEngine.Click(By.XPath("//a[@title='"+value+"']"));
        }

        public void SwitchTo(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles.ElementAt(index));
        }

        public void ClearSearchField()
        {
            actionEngine.Clear(By.Id("twotabsearchtextbox"));
        }
        public void SwitchBack()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        public void GetItemTitle()
        {
            Console.WriteLine(actionEngine.GetText(By.Id("titleSection")));
            Console.WriteLine(actionEngine.GetText(By.XPath("//span[@id='priceblock_ourprice']")));
        }



    }
}
