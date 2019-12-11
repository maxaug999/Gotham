using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Gotham.web.interfaceTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Accessible_de_partout()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");
                var lien_Prevention = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
                lien_Prevention.Click();
                var publish_link = driver.FindElement(By.XPath("/html/body/div/main/h1")).Text;
                StringAssert.Contains("Liste des Préventions", publish_link);
            }
        }

        [Test]
        public void Test_Prevention_Create()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))

            {

                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var lien_Prevention = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[5]/a"));
                lien_Prevention.Click();
                var create_new_link = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
                create_new_link.Click();
                var ExpectedLink = "https://localhost:44379/Preventions/Create".ToString();
                Assert.AreEqual(ExpectedLink, driver.Url);
            }
        }
        [Test]
        public void Test_Prevention_Detail()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://localhost:44379/");

                var lien_Prevention = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
                lien_Prevention.Click();
                var details_link = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[6]/a[2]"));
                details_link.Click();
                var details_title = driver.FindElement(By.XPath("/html/body/div/main/h1")).Text;
                StringAssert.Contains("Details", details_title);
            }

        }
    }
}