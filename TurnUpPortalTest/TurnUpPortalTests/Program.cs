using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Tethering;
using OpenQA.Selenium.Interactions;

public class Program
{
    public void Main(string[] args)
    {
        //Login Test

        //Open New Chrome Browser and Navigate to TurnUp Login Page
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

        //Enter Login Credentials
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
        PasswordTextbox.SendKeys("123123");

        //Click Login Button
        IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        LoginButton.Click();

        //Test
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in. Test Passed.");

        }
        else
        {
            Console.WriteLine("User has not logged in. Test Failed");
        }

        //Create New Entry Test

        //Navigate to Time and Materials Tab
        IWebElement adminButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        adminButton.Click();
        IWebElement timeMatButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeMatButton.Click();

        //Create New Entry
        IWebElement newButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        newButton.Click();

        //Add Information to New Entry
        IWebElement codeField = driver.FindElement(By.Id("Code"));
        codeField.Click();
        codeField.SendKeys("Test");

        IWebElement descField = driver.FindElement(By.Id("Description"));
        descField.Click();
        descField.SendKeys("This is a test Entry, Delete after test");

        IWebElement pricePUField = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        pricePUField.Click();

        IWebElement priceBox = driver.FindElement(By.Id("Price"));
        priceBox.SendKeys("123456");

        //Save New Entry
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3750);

        //Navigate to last page of Database
        IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        lastPage.Click();

        //Test
        IWebElement checkCell = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (checkCell.Text == "Test")
        {
            Console.WriteLine("New Entry Has Been Created Successfully. Test Passed.");
        }
        else
        {
            Console.WriteLine("The New Entry Has Not Been Created. Test Failed.");
        }

        Thread.Sleep(1500);

        //Edit Existing Entry Test

        //Click button to Edit Entry
        IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        EditButton.Click();
        Thread.Sleep(250);

        //Edit Price data in Entry
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

        //Save Changes to Entry
        IWebElement SaveEditButton = driver.FindElement(By.Id("SaveButton"));
        SaveEditButton.Click();

        Thread.Sleep(3750);

        //Navigate to last page of database
        IWebElement checkLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
        checkLastPage.Click();

        //TEST
        IWebElement checkEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        if (checkEdit.Text == "$654,321.00")
        {
            Console.WriteLine("The Entry Has Been Edited. Test Passed");
        }
        else
        {
            Console.WriteLine("Entry Has Not Been Changed. Test Failed");
        }

        Thread.Sleep(300);

        //DELETE ENTRY TEST

        //Delete Entry 
        IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        DeleteButton.Click();
        Thread.Sleep(500);
        driver.SwitchTo().Alert().Accept();

        //TEST
        if (checkCell.Text == "Test")
        {
            Console.WriteLine("Entry Is still Present. Test Failed");
        }
        else
        {
            Console.WriteLine("The Entry Has Been Deleted. Test Passed");
        }

        driver.Quit();

        Console.WriteLine("Test has been Completed");
    }
}
