using System.Data.Entity;
using MessageBoard.Models;

namespace MessageBoard.Data
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


    }
}