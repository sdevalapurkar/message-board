using System;
using System.Collections.Generic;

namespace MessageBoard.Data
{
    public class Topic
    {
        public int Id { get; set; }

        public string title { get; set; }
        public string body { get; set; }
        public DateTime Created { get; set; }

        public bool Flagged { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}