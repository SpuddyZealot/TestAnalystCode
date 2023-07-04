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
        CodeField.SendKeys("RecentTest");

        IWebElement DescField = driver.FindElement(By.Id("Description"));
        DescField.Click();
        DescField.SendKeys("RecentTest");

        IWebElement PPUField = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        PPUField.Click();

        IWebElement PriceBox = driver.FindElement(By.Id("Price"));
        PriceBox.SendKeys("123456");

        IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
        SaveButton.Click();
        Thread.Sleep(3750);
                
        IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        LastPage.Click();

        IWebElement CheckCell = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (CheckCell.Text == "RecentTest")
        {
            Console.WriteLine("A new Entry has been created.");
        }
        else
        {
            Console.WriteLine("Entry Failed to be created.");
        }

        Thread.Sleep(1500);

        IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        DeleteButton.Click();
        Thread.Sleep(500);

        driver.SwitchTo().Alert().Accept();

        if (CheckCell.Text == "RecentTest")
        {
            Console.WriteLine("The Entry Has Been Deleted.");
        }
        else
        {
            Console.WriteLine("Entry Is still Present.");
        }

    }
}