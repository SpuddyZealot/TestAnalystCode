using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalTests.Extas.Utilities;

namespace TurnUpPortalTests.Extas.Pages
{
    public class DataBase
    {
        public void CreateDataEntry(IWebDriver driver)
        {
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

            //Go To last page of Database
            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();

            //Test
            IWebElement checkNew = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkNew.Text == "Test")
            {
                Console.WriteLine("New Entry Has Been Created Successfully. Test Passed.");
            }
            else
            {
                Console.WriteLine("The New Entry Has Not Been Created. Test Failed.");
            }
        }

        public void DeleteDataEntry(IWebDriver driver)
        {
            //Delete Entry 
            IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            DeleteButton.Click();
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();

            //TEST
            IWebElement checkDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkDelete.Text == "Test")
            {
                Console.WriteLine("Entry Is still Present. Test Failed");
            }
            else
            {
                Console.WriteLine("The Entry Has Been Deleted. Test Passed");
            }

        }

        public void EditDataEntry(IWebDriver driver)
        {
            //Click Edit Entry Button
            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            EditButton.Click();

            Wait.WaitToBeClickableMethod(driver, "Xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 7);

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

            //Go To last page of Database Glitch, Xpath needs to be reset or a recreated for some reason in order to go to last page.
            //Can not use already created lastpage element. Temp Fix below.
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
        }

    }
}
