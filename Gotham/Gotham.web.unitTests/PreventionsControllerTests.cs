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
    public class PreventionsControllerTests
    {
        MockPreventionRepository mockRepo;
        PreventionsController controller;
        public PreventionsControllerTests()
        {
            mockRepo = new MockPreventionRepository();
            controller = new PreventionsController(mockRepo);
        }

        [Fact]
        public async Task Test_Index_retourne_la_liste_de_preventions()
        {
            var result = await controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_index_Model_est_un_Enumerable_de_Prevention()
        {
            var result = await controller.Index() as ViewResult;

            Assert.IsAssignableFrom<IEnumerable<Prevention>>(result.ViewData.Model);
        }

        [Fact]
        public async Task Test_derniere_Prevention_devrait_etre_dans_View()
        {
            var result = await controller.Index() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Contains(mockRepo.PreventionsList[0].ToString(), viewResult.ViewData.Model.ToString());

        }
    }
}
