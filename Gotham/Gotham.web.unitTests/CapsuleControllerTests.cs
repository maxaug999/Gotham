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
    public class CapsuleControllerTests
    {
        private readonly MockCapsuleRepository _mockRepo;
        private readonly CapsulesController _controller;
        public CapsuleControllerTests()
        {
            _mockRepo = new MockCapsuleRepository();
            _controller = new CapsulesController(_mockRepo);
        }

        [Fact]
        public async Task Test_Index_Returns_A_ViewResult()
        {
            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_Index_Model_Is_An_Enumerable_Model_Of_Capsules()
        {
            var result = await _controller.Index() as ViewResult;

            Assert.IsAssignableFrom<IEnumerable<Capsule>>(result.ViewData.Model);
        }
    }
}