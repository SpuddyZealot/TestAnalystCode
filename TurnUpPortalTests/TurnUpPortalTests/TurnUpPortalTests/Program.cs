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

        IWebElement pricePUField = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        pricePUField.Click();

        IWebElement priceBox = driver.FindElement(By.Id("Price"));
        priceBox.SendKeys("123456");

        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3750);

        IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        lastPage.Click();

        IWebElement checkCell = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (checkCell.Text == "Test")
        {
            Console.WriteLine("New Entry Has Been Created Successfully");
        }
        else
        {
            Console.WriteLine("The New Entry Has Not Been Created.");
        }

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

        //TEST
        IWebElement checkEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        if (checkEdit.Text == "$654,321.00")
        {
            Console.WriteLine("The Entry Has Been Edited.");
        }
        else
        {
            Console.WriteLine("Entry Has Not Been Changed.");
        }

        Thread.Sleep(300);

        //DELETE NEW ENTRY
        IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        DeleteButton.Click();
        Thread.Sleep(500);
        driver.SwitchTo().Alert().Accept();

        //TEST

        if (checkCell.Text == "Test")
        {
            Console.WriteLine("Entry Is still Present.");
        }
        else
        {
            Console.WriteLine("The Entry Has Been Deleted.");
        }

    }
}
