using Gotham.persistence;
using Gotham.web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Gotham.web.unitTests
{
    public class NouvellesControllerTests
    {
        [Fact]
        public async Task Test_Index_Returns_A_ViewResult()
        {
            var mockRepo = new MockNouvellesRepository();
            var controller = new NouvellesController(mockRepo);

            var result = await controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
