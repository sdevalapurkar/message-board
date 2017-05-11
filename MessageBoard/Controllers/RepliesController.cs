﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;

        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reply> Get(int topicId)
        {
            return _repo.GetRepliesByTopic(topicId);
            
        }

        public HttpResponseMessage Post(int topicId, [FromBody] Reply newReply)
        {
            if (newReply.Created == default(DateTime))
            {
                newReply.Created = DateTime.UtcNow;
            }

            newReply.TopicId = topicId;

            var x = _repo.AddReply(newReply);
            var y = _repo.Save();

            if (x && y)
            {
                return Request.CreateResponse(HttpStatusCode.Created,
                    newReply);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
