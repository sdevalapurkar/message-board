﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using MessageBoard.Controllers;
using MessageBoard.Data;
using MessageBoard.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageBoard.Tests.Controllers
{
    [TestClass]
    public class TopicsControllerTests
    {
        private TopicsController _ctrl;

        [TestInitialize]
        public void Init()
        {
            _ctrl = new TopicsController(new FakeMessageBoardRepository());
        }

        [TestMethod]
        public void TopicsController_Get()
        {
            var results = _ctrl.Get(true);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
            Assert.IsNotNull(results.First());
        }

        [TestMethod]
        public void TopicsController_Post()
        {
            // Testing POST is harder than it should be but we need to do some work:

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/topics");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "topics" } });

            _ctrl.ControllerContext = new HttpControllerContext(config, routeData, request);
            _ctrl.Request = request;
            _ctrl.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            var newTopic = new Topic()
            {
                title = "Test Topic",
                body = "This is a best topic"
            };

            var result = _ctrl.Post(newTopic);

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

        }

    }
}
