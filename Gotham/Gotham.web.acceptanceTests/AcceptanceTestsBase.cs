using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;

namespace Gotham.web.acceptanceTests
{
    public class AcceptanceTestsBase : IDisposable
    {
        private const string RELATIVE_WEB_APP_PATH = "Gotham/Gotham.web";

        private readonly TestServer _testServer;

        public AcceptanceTestsBase()
        {
            // Est appelé avant l'exécution de chacun des tests
            // Démarre un serveur de tests

            var acceptanceTestsBasePath = PlatformServices.Default.Application.ApplicationBasePath;

            var webAppContentPath = GetAbsoluteWebAppPath(acceptanceTestsBasePath, RELATIVE_WEB_APP_PATH);

            var builder = new WebHostBuilder()
                .UseContentRoot(webAppContentPath)
                .UseStartup<Startup>();

            _testServer = new TestServer(builder);

            HttpClient = _testServer.CreateClient();
            HttpClient.BaseAddress = new Uri("http://localhost");
        }

        protected HttpClient HttpClient { get; }

        public void Dispose()
        {
            HttpClient.Dispose();
            _testServer.Dispose();
        }

        private string GetAbsoluteWebAppPath(string accpetanceTestsBasePath, string relativeWebAppPath)
        {
            var directoryInfo = new DirectoryInfo(accpetanceTestsBasePath);
            do
            {
                var solutionFileInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, relativeWebAppPath));
                if (solutionFileInfo.Exists)
                    return Path.GetFullPath(Path.Combine(directoryInfo.FullName, relativeWebAppPath));
                directoryInfo = directoryInfo.Parent;
            } while (directoryInfo.Parent != null);

            throw new Exception($"Impossible de trouver le dossier de l'application web ({relativeWebAppPath})");
        }
    }
}
