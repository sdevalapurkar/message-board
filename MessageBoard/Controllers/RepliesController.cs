using System.Collections.Generic;
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
            _repo.GetRepliesByTopic(topicId); 
        }
    }
}
