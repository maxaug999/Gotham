using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Gotham.web.interfaceTests
{
    public class NouvellesUiTests
    {
        [Test]
        public void Test_AccessibilityEverywhere()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_nouvelles = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
                link_nouvelles.Click();
                var publish_link = driver.FindElement(By.XPath("/html/body/div/main/h1")).Text;
                StringAssert.Contains("Liste des nouvelles", publish_link);
            }
        }

        [Test]
        public void Test_Create_New_Link()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_nouvelles = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
                link_nouvelles.Click();
                var publish_link = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
                publish_link.Click();
                var ExpectedLink = "https://localhost:44379/Nouvelles/Create".ToString();
                Assert.AreEqual(ExpectedLink, driver.Url);
            }
        }

        [Test]
        public void Test_Details_Link()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_nouvelles = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
                link_nouvelles.Click();
                var details_link = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[5]/a[2]"));
                details_link.Click();
                var details_title = driver.FindElement(By.XPath("/html/body/div/main/h1")).Text;
                StringAssert.Contains("Details", details_title);
            }
        }
    }
}