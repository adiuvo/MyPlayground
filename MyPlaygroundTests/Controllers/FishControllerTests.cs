using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlayground.Controllers;
using Xunit;
namespace MyPlayground.Controllers.Tests
{
    using System.Web.Mvc;

    using MyPlayground.Models;

    public class FishControllerTests
    {
        [Fact()]
        public void IndexTest()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            // Test we're using the default view name
            Assert.Equal("", result.ViewName);
        }
 }
}
