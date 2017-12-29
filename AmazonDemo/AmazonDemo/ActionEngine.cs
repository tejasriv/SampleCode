using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;


namespace SeleniumActions
{
    public class ActionEngine
    {
        IWebDriver driver;

        //	constructor
        public ActionEngine(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetAttribute(By by, string attribute)
        {
            return FindEle(by).GetAttribute(attribute);
        }
        public bool IsChecked(By by)
        {
            if (FindEle(by).Selected)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void SendKeys(By by, String text)
        {
            FindEle(by).SendKeys(text);
        }

        public void GetCount(By by)
        {
            FindEle(by);
        }

        public void Click(By by)
        {
            FindEle(by).Click();
        }

        public void Clear(By by)
        {
            FindEle(by).Clear();
        }

        public String GetText(By by)
        {
            return FindEle(by).Text;
        }
        public void KeyboardActions(By by)
        {
            IWebElement target = FindEle(by);
            Actions keyboardActions = new Actions(driver);
            keyboardActions.SendKeys(Keys.End);
        }

        public void MoveToElement(By by)
        {

            IWebElement target = FindEle(by);
            Actions a = new Actions(driver);
            a.MoveToElement(target);
            a.Perform();
        }
        public IWebElement FindEle(By by)
        {
            IWebElement driEle = null;

            try
            {
                driEle = driver.FindElement(by);

            }
            catch (Exception e)
            {
                //StackTraceElement[] stackTraceElements = Thread.CurrentThread().getStackTrace();
                try
                {
                    // ITakeSnapShot(stackTraceElements[3].ToString().Split(new string[] { "\\(" }, StringSplitOptions.None)[0]);

                }
                catch (IOException e1)
                {
                    Console.WriteLine(e1);
                }
            }
            return driEle;

        }

        public void isElementDisplayed(By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (Exception e)
            {
                throw new Exception("ExpectedElementNotVisible");
            }
        }

        public void Wait(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                //try
                //{
                //    StackTraceElement[] stackTraceElements = Thread.CurrentThread().getStackTrace();
                //    ITakeSnapShot(stackTraceElements[3].ToString().Split(new string[] { "\\(" }, StringSplitOptions.None)[0]);
                //}
                //catch (IOException e1)
                //{
                //    Console.WriteLine(e1.StackTrace);
                //}
            }
        }

        public void Select(By by, String target)
        {
            SelectElement UniType = new SelectElement(FindEle(by));
            UniType.SelectByText(target);
        }

        public void TakeScreenshot(string methodname)
        {
            //screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //ss.saveasfile("d:\\screenshot" + methodname + "_" + randomstring.random(4, true, true) + ".jpeg");
            //ITakesscreenshot tc = ((ITakesscreenshot)driver).getscreenshot();


            //file srcfile = tc.getscreenshotas(outputtype.file);

            ////move image file to new destination
            //file destfile = new file("d:\\screenshot\\" + methodname + ".jpeg");

            ////copy file at destination
            //fileutils.copyfile(srcfile, destfile);
        }


    }
}
