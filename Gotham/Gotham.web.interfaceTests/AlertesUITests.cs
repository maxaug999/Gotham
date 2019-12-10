using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Gotham.web.interfaceTests
{
    public class AlertesUITests
    {
        [Test]
        public void Test_AccessibilityEverywhere()
        {
            using(var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_alertes = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[5]/a"));
                link_alertes.Click();
                var publish_link = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[7]/a[3]")).Text;
                StringAssert.Contains("Publier", publish_link);
            }
        }

        [Test]
        public void Test_Publish_Link()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_alertes = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[5]/a"));
                link_alertes.Click();
                var publish_link = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[7]/a[3]"));
                publish_link.Click();
                var ExpectedLink = "https://localhost:44379/Alertes/Publish/1".ToString();
                Assert.AreEqual(ExpectedLink, driver.Url);
            }
        }

        [Test]
        public void Test_Create_Link()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_alertes = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[5]/a"));
                link_alertes.Click();
                var create_new_link = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
                create_new_link.Click();
                var ExpectedLink = "https://localhost:44379/Alertes/Create".ToString();
                Assert.AreEqual(ExpectedLink, driver.Url);
            }
        }
    }
}
