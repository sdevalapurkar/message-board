using System.Linq;
using MessageBoard.Controllers;
using MessageBoard.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageBoard.Tests.Controllers
{
    [TestClass]
    class TopicsControllerTests
    {
        [TestMethod]
        public void TopicsController_Get()
        {
            var ctrl = new TopicsController(new FakeMessageBoardRepository());

            var results = ctrl.Get(true);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
            Assert.IsNotNull(results.First());
        }
    }
}
