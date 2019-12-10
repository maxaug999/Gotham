using Gotham.domain;
using Gotham.persistence;
using Gotham.web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Gotham.web.unitTests
{
    public class NouvellesControllerTests
    {
        MockNouvellesRepository mockRepo;
        NouvellesController controller;
        public NouvellesControllerTests()
        {
            mockRepo = new MockNouvellesRepository();
            controller = new NouvellesController(mockRepo);
        }

        [Fact]
        public async Task Test_Index_Returns_A_ViewResult()
        {
            var result = await controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_Index_Model_Is_An_Enumerable_Model_Of_Nouvelles()
        {
            var result = await controller.Index() as ViewResult;

            Assert.IsAssignableFrom<IEnumerable<Nouvelle>>(result.ViewData.Model);
        }

        [Fact]
        public async Task Index_Last_Nouvelle_Should_Be_In_View()
        {
            var result = await controller.Index() as ViewResult;

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(mockRepo._nouvelles[mockRepo._nouvelles.Count - 1], viewResult.ViewData.Model);
        }
    }
}
