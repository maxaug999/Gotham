using Gotham.domain;
using Gotham.persistence;
using Gotham.web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gotham.web.unitTests
{
    public class TestAlertesController
    {
        MockAlertesRepository mockRepo;
        AlertesController controller;

        public TestAlertesController()
        {
            mockRepo = new MockAlertesRepository();
            controller = new AlertesController(mockRepo);
        }
        [Fact]
        public async Task Test_Index_Returns_A_ViewResult()
        {
            var mockRepo = new MockAlertesRepository();
            var controller = new AlertesController(mockRepo);

            var result = await controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_Index_Model_Is_An_Enumerable_Model_Of_Joueurs()
        {
            var mockRepo = new MockAlertesRepository();
            var controller = new AlertesController(mockRepo);

            var result = await controller.Index() as ViewResult;

            Assert.IsAssignableFrom<IEnumerable<Alerte>>(result.ViewData.Model);
        }

        [Fact]
        public async Task Index_Last_Alert_Should_Be_In_View()
        {
            var result = await controller.Index() as ViewResult;

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Contains(mockRepo._alertes.ToString(), viewResult.ViewData.Model.ToString());
        }
    }
}
