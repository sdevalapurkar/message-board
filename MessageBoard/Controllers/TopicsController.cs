using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Topic> Get()
        {
            var topics = _repo.GetTopicsIncludingReplies()
                .OrderByDescending(t => t.Created)
                .Take(25)
                .ToList();

            return topics;
        }

        public HttpResponseMessage Post([FromBody] Topic newTopic)
        {
            if (newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            var x = _repo.AddTopic(newTopic);
            var y = _repo.Save();

            if (x && y)
            {
                return Request.CreateResponse(HttpStatusCode.Created, 
                    newTopic);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
