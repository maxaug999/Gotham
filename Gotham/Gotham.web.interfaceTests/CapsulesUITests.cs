using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Gotham.web.interfaceTests
{
    public class CapsulesUITests
    {
        
        [Test]
        public void Test_AccessibilityEverywhere()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_capsules = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
                link_capsules.Click();
                var link_publish = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[4]/a[3]")).Text;
                Assert.AreEqual("Publier", link_publish);
            }
        }

        [Test]
        public void Test_PublishLink()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_capsules = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
                link_capsules.Click();
                var link_publish = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[4]/a[3]"));
                link_publish.Click();
                var expectedLink = "https://localhost:44379/Capsules/Publish/2".ToString();
                Assert.AreEqual(expectedLink, driver.Url);
            }
        }

        [Test]
        public void Test_Create_Link()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var link_alertes = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
                link_alertes.Click();
                var create_new_link = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
                create_new_link.Click();
                var ExpectedLink = "https://localhost:44379/Capsules/Create".ToString();
                Assert.AreEqual(ExpectedLink, driver.Url);
            }
        }
    }
}