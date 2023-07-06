using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Tethering;
using OpenQA.Selenium.Interactions;
using TurnUpPortalTests.Extas.Pages;

public class Program
{
    public void Main(string[] args)
    {

        //Open New Chrome Browser and Navigate to TurnUp Login Page
        IWebDriver driver = new ChromeDriver();

        //Login Page Object initialization and definition
        Login loginPageObjs = new Login();
        loginPageObjs.LoginMethod(driver);

        //Home Page Object initialization and definition
        HomePage homePageobjs = new HomePage();
        homePageobjs.GoToTMDataBaseMethod(driver);

        //DataBase page Object initialization and definition
        DataBase dataBaseobjs = new DataBase();
        dataBaseobjs.CreateDataEntry(driver);

        dataBaseobjs.EditDataEntry(driver);

        dataBaseobjs.DeleteDataEntry(driver);

        //driver.Quit();

        //Console.WriteLine("Test has been Completed");
    }
}
