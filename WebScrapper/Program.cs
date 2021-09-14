using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebScrapper
{
    class Program
    {
        private static string _url = "https://app.hustlegotreal.com/Account/Login";
        private static string _userName = "testing@hustlegotreal.com";
        private static string _password = "HGR2021";

        static void Main(string[] args)
        {
            IWebDriver driver = null;

            var DeviceDriver = ChromeDriverService.CreateDefaultService();
            DeviceDriver.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-infobars");

            driver = new ChromeDriver(DeviceDriver, options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(new Uri(_url, UriKind.Absolute));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IWebElement element = driver.FindElement(By.Name("Email"));
            IWebElement passwordElement = driver.FindElement(By.Name("Password"));

            // Action can be performed on Input Text element
            element.SendKeys(_userName);
            passwordElement.SendKeys(_password);

            IWebElement submitBtnElement = driver.FindElement(By.TagName("button"));
            // Action can be performed on Input Button element
            submitBtnElement.Submit();
        }
    }
}
