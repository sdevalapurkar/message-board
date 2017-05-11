using System;
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

        public bool AddReply(Reply newReply)
        {
            try
            {
                _context.Replies.Add(newReply);
                return true;
            }
            catch (Exception e)
            {
                return false;
                //also need to log error
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _context.Topics.Add(newTopic);
                return true;

            }
            catch (Exception e)
            {
                //log error
                return false;
            }
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _context.Replies.Where(r => r.TopicId == topicId);
        }

        public IQueryable<Topic> GetTopics()
        {
            return _context.Topics;
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return _context.Topics.Include("Replies");
        }

        public bool Save()
        {
            try
            {
               return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                //also need to log this error later
                return false;
            }
        }
    }
}

