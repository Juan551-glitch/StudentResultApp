using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Xunit;

namespace StudentResultApp.Tests
{
    public class StudentResultUiTests : IDisposable
    {
        private readonly IWebDriver driver;

        public StudentResultUiTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
        }

        [Fact]
        public void HomePage_Should_Load_Successfully()
        {
            driver.Navigate().GoToUrl("https://localhost:7220");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.PageSource.Contains("Student Result Management System"));

            Assert.Contains("Student Result Management System", driver.PageSource);

            Thread.Sleep(3000);
        }

        [Fact]
        public void Student_Page_Should_Display_Content()
        {
            driver.Navigate().GoToUrl("https://localhost:7220");
            Thread.Sleep(3000); // Wait for the page to load

            Assert.Contains("Result", driver.PageSource);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}