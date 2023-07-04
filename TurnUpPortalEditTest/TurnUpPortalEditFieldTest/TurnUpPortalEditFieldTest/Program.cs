using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Tethering;
using OpenQA.Selenium.Interactions;

public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
        PasswordTextbox.SendKeys("123123");

        IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        LoginButton.Click();

        IWebElement AdminButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        AdminButton.Click();

        IWebElement TimeMatButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TimeMatButton.Click();

        IWebElement NewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        NewButton.Click();

        IWebElement CodeField = driver.FindElement(By.Id("Code"));
        CodeField.Click();
        CodeField.SendKeys("EditTest");

        IWebElement DescField = driver.FindElement(By.Id("Description"));
        DescField.Click();
        DescField.SendKeys("EditTest");

        IWebElement PPUField = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        PPUField.Click();

        IWebElement PriceBox = driver.FindElement(By.Id("Price"));
        PriceBox.SendKeys("123456");

        IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
        SaveButton.Click();
        Thread.Sleep(3750);

        IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        LastPage.Click();

        IWebElement CheckNew = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        Thread.Sleep(1500);

        IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        EditButton.Click();
        Thread.Sleep(250);

        IWebElement EditPrice = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        EditPrice.Click();

        IWebElement EditPriceBox = driver.FindElement(By.Id("Price"));
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys(Keys.Backspace);
        EditPriceBox.SendKeys("654321");

        IWebElement SaveEditButton = driver.FindElement(By.Id("SaveButton"));
        SaveEditButton.Click();

        Thread.Sleep(3750);

        IWebElement CheckLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
        CheckLastPage.Click();

        IWebElement CheckEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

        if (CheckEdit.Text == "$654,321.00")
        {
            Console.WriteLine("The Entry Has Been Edited.");
        }
        else
        {
            Console.WriteLine("Entry Has Not Been Changed.");
        }
        //Notes to self for next time;
        // DO NOT USE PRICE TAG TO CHECK EDITS, redoing the same test over and over only to find it needs coma's and $ was not fun
        // Perhaps try changing the name or description fields...
    }
}
