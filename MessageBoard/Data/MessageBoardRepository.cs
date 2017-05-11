using System.Linq;

namespace MessageBoard.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        private readonly MessageBoardContext _context;

        public MessageBoardRepository(MessageBoardContext context)
        {
            _context = context;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _context.Replies.Where(r => r.TopicId == topicId);
        }

        public IQueryable<Topic> GetTopics()
        {
            return _context.Topics;
        }
    }
}