using System;

namespace MessageBoard.Data
{
    public class Reply
    {
        public string Body { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public int TopicId { get; set; }
    }
}