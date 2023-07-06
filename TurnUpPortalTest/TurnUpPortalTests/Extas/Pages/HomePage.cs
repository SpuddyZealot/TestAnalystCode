using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalTests.Extas.Pages
{
    public class HomePage
    {
        public void GoToTMDataBaseMethod(IWebDriver driver)
        {
            //Navigate to Time and Materials Tab
            IWebElement adminButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminButton.Click();
            IWebElement timeMatButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMatButton.Click();
        }
    }
}
